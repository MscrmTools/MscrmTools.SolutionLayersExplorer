using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Metadata.Query;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using MscrmTools.SolutionLayersExplorer.AppCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MscrmTools.SolutionLayersExplorer.UserControls
{
    public partial class ComponentsPicker : UserControl
    {
        private List<Entity> _components = new List<Entity>();

        public ComponentsPicker()
        {
            InitializeComponent();

            lvComponents.ListViewItemSorter = new ListViewItemComparer();
        }

        public event EventHandler OnActiveLayerRemovalRequested;

        public event EventHandler OnActiveLayerRequested;

        public event EventHandler OnSelected;

        public List<LayerItem> SelectedComponent => lvComponents.SelectedItems.Cast<ListViewItem>().FirstOrDefault()?.Tag as List<LayerItem>;
        public List<ListViewItem> SelectedComponents => lvComponents.GetCheckedOrSelectedItems();
        public CrmServiceClient Service { get; set; }

        public void DisplayActiveLayers()
        {
            foreach (var item in lvComponents.Items.Cast<ListViewItem>())
            {
                if (item.SubItems.Count > 2 && item.SubItems[2].Text == "...")
                    item.SubItems[2].Text = ((List<LayerItem>)item.Tag).Count(i => i.ActiveLayer != null).ToString();
            }
        }

        public void DisplayComponents(List<Tuple<int, string>> componentsDefs)
        {
            lvComponents.Items.Clear();

            var grps = _components.GroupBy(c => c.GetAttributeValue<OptionSetValue>("componenttype")?.Value);

            foreach (var grp in grps.OrderBy(g => g.Key))
            {
                if (grp == null) continue;

                var def = componentsDefs.FirstOrDefault(d => d.Item1 == grp.Key);
                if (def == null) continue;

                var lvi = new ListViewItem($"{def.Item2}") { SubItems = { new ListViewItem.ListViewSubItem { Text = grp.Count().ToString() } } };
                var lis = grp.Select(g => new LayerItem { Record = g, ComponentListViewItem = lvi }).ToList();
                lvi.Tag = lis;

                lvComponents.Items.Add(lvi);
            }
        }

        public void LoadComponents(Guid solutionId)
        {
            var solutions = Service.RetrieveMultiple(new QueryExpression("solutioncomponent")
            {
                NoLock = true,
                ColumnSet = new ColumnSet(true),
                Criteria = new FilterExpression
                {
                    Conditions =
                    {
                        new ConditionExpression("solutionid", ConditionOperator.Equal, solutionId)
                    }
                }
            }).Entities;

            _components = solutions.ToList();

            List<EntityMetadata> emds = new List<EntityMetadata>();
            var rels = solutions.Where(c => c.GetAttributeValue<OptionSetValue>("componenttype").Value == 10).ToList();
            if (rels.Count > 0)
            {
                var relMetadataIds = rels
                    .Select(c => c.GetAttributeValue<Guid>("objectid"))
                    .ToList();

                EntityQueryExpression entityQueryExpression = new EntityQueryExpression
                {
                    Criteria = new MetadataFilterExpression(LogicalOperator.And)
                    {
                        Conditions ={
                            new MetadataConditionExpression("IsActivity", MetadataConditionOperator.Equals, true)
                        }
                    },
                    Properties = new MetadataPropertiesExpression("MetadataId", "LogicalName", "ManyToOneRelationships")
                };

                RetrieveMetadataChangesRequest retrieveMetadataChangesRequest = new RetrieveMetadataChangesRequest
                {
                    Query = entityQueryExpression,
                    ClientVersionStamp = null
                };

                emds = ((RetrieveMetadataChangesResponse)Service.Execute(retrieveMetadataChangesRequest)).EntityMetadata.ToList();
                var relsToExclude = emds.SelectMany(e => e.ManyToOneRelationships).Where(r => r.ReferencingAttribute == "regardingobjectid").Select(r => r.MetadataId).ToList();
                _components = _components.Except(solutions.Where(c => relsToExclude.Contains(c.GetAttributeValue<Guid>("objectid")))).ToList();
            }

            emds = new List<EntityMetadata>();
            var fullEntities = solutions.Where(c => c.GetAttributeValue<OptionSetValue>("componenttype").Value == 1 && c.GetAttributeValue<OptionSetValue>("rootcomponentbehavior").Value == 0).ToList();
            if (fullEntities.Any())
            {
                var entityQueryExpression = new EntityQueryExpression
                {
                    Criteria = new MetadataFilterExpression(LogicalOperator.And)
                    {
                        Conditions ={
                            new MetadataConditionExpression("MetadataId", MetadataConditionOperator.In, fullEntities.Select(fe => fe.GetAttributeValue<Guid>("objectid")).ToArray())
                        }
                    },
                    Properties = new MetadataPropertiesExpression("LogicalName", "Attributes", "OneToManyRelationships", "ManyToOneRelationships", "ManyToManyRelationships"),
                    AttributeQuery = new AttributeQueryExpression
                    {
                        Properties = new MetadataPropertiesExpression("MetadataId"),
                        Criteria = new MetadataFilterExpression
                        {
                            Conditions =
                            {
                                new MetadataConditionExpression("IsManaged", MetadataConditionOperator.Equals, true)
                            }
                        }
                    },
                    RelationshipQuery = new RelationshipQueryExpression
                    {
                        Properties = new MetadataPropertiesExpression("MetadataId"),
                        Criteria = new MetadataFilterExpression
                        {
                            Conditions =
                            {
                                new MetadataConditionExpression("IsManaged", MetadataConditionOperator.Equals, true)
                            }
                        }
                    }
                };

                RetrieveMetadataChangesRequest retrieveMetadataChangesRequest = new RetrieveMetadataChangesRequest
                {
                    Query = entityQueryExpression,
                    ClientVersionStamp = null
                };

                emds = ((RetrieveMetadataChangesResponse)Service.Execute(retrieveMetadataChangesRequest)).EntityMetadata.ToList();

                // Attributs
                _components.AddRange(emds.SelectMany(e => e.Attributes).Select(e => new Entity("solutioncomponent")
                {
                    ["objectid"] = e.MetadataId,
                    ["componenttype"] = new OptionSetValue(2),
                }).ToArray());

                // Relations
                _components.AddRange(emds.SelectMany(e => e.Attributes).Select(e => new Entity("solutioncomponent")
                {
                    ["objectid"] = e.MetadataId,
                    ["componenttype"] = new OptionSetValue(10),
                }).ToArray());

                // Formulaires
                var forms = Service.RetrieveMultiple(new QueryExpression("systemform")
                {
                    NoLock = true,
                    ColumnSet = new ColumnSet("name"),
                    Criteria = new FilterExpression
                    {
                        Conditions =
                        {
                            new ConditionExpression("objecttypecode", ConditionOperator.In, emds.Select(e=>e.LogicalName).ToArray())
                        }
                    }
                });

                _components.AddRange(forms.Entities.Select(e => new Entity("solutioncomponent")
                {
                    ["objectid"] = e.Id,
                    ["componenttype"] = new OptionSetValue(60),
                }).ToArray());

                // Vues
                var queries = Service.RetrieveMultiple(new QueryExpression("savedquery")
                {
                    NoLock = true,
                    ColumnSet = new ColumnSet("name"),
                    Criteria = new FilterExpression
                    {
                        Conditions =
                        {
                            new ConditionExpression("returnedtypecode", ConditionOperator.In, emds.Select(e=>e.LogicalName).ToArray())
                        }
                    }
                });

                _components.AddRange(queries.Entities.Select(e => new Entity("solutioncomponent")
                {
                    ["objectid"] = e.Id,
                    ["componenttype"] = new OptionSetValue(26),
                }).ToArray());

                // Charts
                var charts = Service.RetrieveMultiple(new QueryExpression("savedqueryvisualization")
                {
                    NoLock = true,
                    ColumnSet = new ColumnSet("name"),
                    Criteria = new FilterExpression
                    {
                        Conditions =
                        {
                            new ConditionExpression("primaryentitytypecode", ConditionOperator.In, emds.Select(e=>e.LogicalName).ToArray())
                        }
                    }
                });

                _components.AddRange(charts.Entities.Select(e => new Entity("solutioncomponent")
                {
                    ["objectid"] = e.Id,
                    ["componenttype"] = new OptionSetValue(59),
                }).ToArray());
            }
        }

        internal void UncheckAll()
        {
            foreach (ListViewItem item in lvComponents.Items)
            {
                item.Checked = false;
            }
        }

        private void lvComponents_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            lvComponents.Sorting = lvComponents.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            lvComponents.ListViewItemSorter = new ListViewItemComparer(e.Column, lvComponents.Sorting);
        }

        private void lvComponents_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnSelected?.Invoke(this, new EventArgs());
        }

        private void tbsLoadActiveLayers_Click(object sender, EventArgs e)
        {
            OnActiveLayerRequested?.Invoke(this, new EventArgs());
        }

        private void tsbCheckAll_Click(object sender, EventArgs e)
        {
            if (tsbCheckAll.Text == "Check all")
            {
                foreach (ListViewItem item in lvComponents.Items)
                {
                    item.Checked = true;
                }

                tsbCheckAll.Text = "Uncheck all";
                tsbCheckAll.Image = Properties.Resources.check_box_empty;
            }
            else
            {
                foreach (ListViewItem item in lvComponents.Items)
                {
                    item.Checked = false;
                }

                tsbCheckAll.Text = "Check all";
                tsbCheckAll.Image = Properties.Resources.check_box_with_check_sign;
            }
        }

        private void tsbRemoveActiveLayer_Click(object sender, EventArgs e)
        {
            OnActiveLayerRemovalRequested?.Invoke(this, new EventArgs());
        }
    }
}