using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Metadata.Query;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using MscrmTools.SolutionLayersExplorer.AppCode;
using MscrmTools.SolutionLayersExplorer.UserControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ScintillaNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace MscrmTools.SolutionLayersExplorer
{
    public partial class MyPluginControl : PluginControlBase, IPayPalPlugin, IGitHubPlugin
    {
        private List<LayerItem> bulkRemoveList = new List<LayerItem>();
        private List<Tuple<int, string>> componentsDefs;
        private BackgroundWorker currentBw;
        private List<EntityMetadata> emds;

        public MyPluginControl()
        {
            InitializeComponent();

            scMain.SplitterDistance = 300;
            scType.SplitterDistance = 400;
            scItems.SplitterDistance = 300;

            SetScintillatControl(sChanges);
            SetScintillatControl(sAllProperties);
            SetScintillatControl(sChildren);
        }

        public string DonationDescription => "Donation for Solution Layers Explorer";

        public string EmailAccount => "tanguy92@hotmail.com";

        public string RepositoryName => "MscrmTools.SolutionLayersExplorer";

        public string UserName => "MscrmTools";

        public void ApplyState(object state)
        {
            throw new NotImplementedException();
        }

        public object GetState()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            emds = null;
        }

        private static string JsonPrettify(string json)
        {
            using (var stringReader = new StringReader(json))
            using (var stringWriter = new StringWriter())
            {
                var jsonReader = new JsonTextReader(stringReader);
                var jsonWriter = new JsonTextWriter(stringWriter) { Formatting = Formatting.Indented };
                jsonWriter.WriteToken(jsonReader);
                return stringWriter.ToString();
            }
        }

        private void ComponentsPicker1_OnActiveLayerRemovalRequested(object sender, EventArgs e)
        {
            var items = componentsPicker1.SelectedComponents.SelectMany(c => ((List<LayerItem>)c.Tag)).Where(c => c.ActiveLayer != null).ToList();

            RemoveActiveLayers(items);
        }

        private void ComponentsPicker1_OnActiveLayerRequested(object sender, EventArgs e)
        {
            tsbLoadActiveLayers_Click(sender, e);
        }

        private void ComponentsPicker1_OnSelected(object sender, EventArgs e)
        {
            lvItems.Items.Clear();

            var components = componentsPicker1.SelectedComponent;
            if (components == null || components.Count == 0) return;

            List<Guid> entityIds = new List<Guid>();

            if (lvItems.Columns.Count == 2)
            {
                lvItems.Columns.RemoveAt(1);
            }

            var list = new List<ListViewItem>();

            if (components.First().Record.GetAttributeValue<OptionSetValue>("componenttype").Value == 2
                && components.Any(c => c.ActiveLayer != null))
            {
                lvItems.Columns.Add(new ColumnHeader
                {
                    Text = "Entity",
                    Width = 120
                });

                foreach (var component in components.Where(c => c.ActiveLayer != null))
                {
                    var entityId = new Guid(((JObject)((JArray)JObject.Parse(component.ActiveLayer.GetAttributeValue<string>("msdyn_componentjson"))["Attributes"]).First(o => ((JObject)o).Value<string>("Key") == "entityid")).Value<string>("Value"));
                    if (!entityIds.Contains(entityId))
                    {
                        entityIds.Add(entityId);
                    }
                }

                if (emds == null || entityIds.Any(id => emds.All(emd => emd.MetadataId != id)))
                {
                    WorkAsync(
                        new WorkAsyncInfo
                        {
                            Message = "Loading metadata...",
                            Work = (bw, evt) =>
                            {
                                EntityQueryExpression entityQueryExpression = new EntityQueryExpression
                                {
                                    Criteria = new MetadataFilterExpression(LogicalOperator.Or),
                                    Properties = new MetadataPropertiesExpression("MetadataId", "DisplayName")
                                };

                                entityIds.ForEach(id =>
                                {
                                    entityQueryExpression.Criteria.Conditions.Add(new MetadataConditionExpression("MetadataId", MetadataConditionOperator.Equals, id));
                                });

                                RetrieveMetadataChangesRequest retrieveMetadataChangesRequest = new RetrieveMetadataChangesRequest
                                {
                                    Query = entityQueryExpression,
                                    ClientVersionStamp = null
                                };

                                emds = ((RetrieveMetadataChangesResponse)Service.Execute(retrieveMetadataChangesRequest)).EntityMetadata.ToList();
                            },
                            PostWorkCallBack = evt =>
                            {
                                lvItems.Items.AddRange(components
                                 .Where(c => c.ActiveLayer != null)
                                 .Select(i => new ListViewItem(i.ActiveLayer.GetAttributeValue<string>("msdyn_name"))
                                 {
                                     SubItems = {
                                            new ListViewItem.ListViewSubItem
                                            {
                                                Text = emds.First(emd => emd.MetadataId == new Guid(((JObject)((JArray)JObject.Parse(i.ActiveLayer.GetAttributeValue<string>("msdyn_componentjson"))["Attributes"]).First(o => ((JObject)o).Value<string>("Key") == "entityid")).Value<string>("Value"))).DisplayName?.UserLocalizedLabel?.Label
                                            }
                                         },
                                     Tag = i
                                 })
                                 .ToArray());
                            }
                        }
                    );
                }
                else
                {
                    foreach (var component in components.Where(c => c.ActiveLayer != null))
                    {
                        var lvi = new ListViewItem(component.ActiveLayer.GetAttributeValue<string>("msdyn_name"))
                        {
                            SubItems = {
                                            new ListViewItem.ListViewSubItem
                                            {
                                                Text = emds.First(emd => emd.MetadataId == new Guid(((JObject)((JArray)JObject.Parse(component.ActiveLayer.GetAttributeValue<string>("msdyn_componentjson"))["Attributes"]).First(o => ((JObject)o).Value<string>("Key") == "entityid")).Value<string>("Value"))).DisplayName?.UserLocalizedLabel?.Label
                                            }
                                       },
                            Tag = component
                        };
                        component.ListViewItem = lvi;
                        list.Add(lvi);
                    }
                }

                return;
            }

            foreach (var component in components.Where(c => c.ActiveLayer != null))
            {
                var lvi = new ListViewItem(component.ActiveLayer.GetAttributeValue<string>("msdyn_name")) { Tag = component };
                component.ListViewItem = lvi;
                list.Add(lvi);
            }

            lvItems.Items.AddRange(list.ToArray());
        }

        private void LoadComponentDefinitions()
        {
            var definitions = Service.RetrieveMultiple(new QueryExpression("solutioncomponentdefinition")
            {
                NoLock = true,
                ColumnSet = new ColumnSet(true)
            }).Entities;

            var omc = ((OptionSetMetadata)((RetrieveOptionSetResponse)Service.Execute(
                        new RetrieveOptionSetRequest
                        {
                            Name = "componenttype"
                        })).OptionSetMetadata).Options;

            componentsDefs = definitions.Select(d => new Tuple<int, string>(d.GetAttributeValue<int>("objecttypecode"), d.GetAttributeValue<string>("name"))).ToList();
            componentsDefs.AddRange(omc.Select(o => new Tuple<int, string>(o.Value.Value, o.Label?.UserLocalizedLabel?.Label ?? "")).ToList());
            componentsDefs.Add(new Tuple<int, string>(80, "Model driven app"));
        }

        private void LoadSolutions()
        {
            solutionPicker1.Service = (CrmServiceClient)Service;

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading solutions...",
                Work = (bw, e) =>
                {
                    solutionPicker1.LoadSolutions();

                    LoadComponentDefinitions();
                },
                PostWorkCallBack = (e) =>
                {
                    if (e.Error != null)
                    {
                        MessageBox.Show(this, $"Error when loading solutions: {e.Error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    solutionPicker1.DisplaySolutions();
                }
            });
        }

        private void lvItems_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            lvItems.Sorting = lvItems.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            lvItems.ListViewItemSorter = new ListViewItemComparer(e.Column, lvItems.Sorting);
        }

        private void lvItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = lvItems.SelectedItems.Cast<ListViewItem>().FirstOrDefault();
            if (item == null) return;
            if (((LayerItem)item.Tag).ActiveLayer == null)
            {
                lvItems.Items.Remove(item);
                return;
            }

            sChanges.Text = JsonPrettify(((LayerItem)item.Tag).ActiveLayer.GetAttributeValue<string>("msdyn_changes"));
            sAllProperties.Text = JsonPrettify(((LayerItem)item.Tag).ActiveLayer.GetAttributeValue<string>("msdyn_componentjson"));
            sChildren.Text = JsonPrettify(((LayerItem)item.Tag).ActiveLayer.GetAttributeValue<string>("msdyn_children"));
            sChanges.EmptyUndoBuffer();
            sAllProperties.EmptyUndoBuffer();
            sChildren.EmptyUndoBuffer();
        }

        private void RemoveActiveLayers(List<LayerItem> items)
        {
            if (DialogResult.No == MessageBox.Show(this, $@"Are you sure you want to remove active layer for {items.Count} items?", @"Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            SetRunningStatus(true);

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Starting active layer removal...",
                IsCancelable = true,
                Work = (bw, evt) =>
                {
                    currentBw = bw;

                    int current = 1;
                    foreach (var item in items)
                    {
                        if (bw.CancellationPending) return;

                        var pct = 100 * current / items.Count;
                        bw.ReportProgress(pct, $"Removing Active Customizations {item.ActiveLayer.GetAttributeValue<string>("msdyn_name")} ({current}/{items.Count})");

                        var request = new OrganizationRequest("RemoveActiveCustomizations");
                        request.Parameters["SolutionComponentName"] = item.ActiveLayer.GetAttributeValue<string>("msdyn_solutioncomponentname");
                        request.Parameters["ComponentId"] = item.ActiveLayer.GetAttributeValue<Guid>("msdyn_componentid");

                        Service.Execute(request);

                        Invoke(new Action(() =>
                        {
                            item.DecrementeParentComponentCount();

                            var itemToRemove = lvItems.Items.Cast<ListViewItem>().FirstOrDefault(i => i == item.ListViewItem);
                            if (itemToRemove != null)
                            {
                                lvItems.Items.Remove(itemToRemove);
                            }

                            if (bulkRemoveList.Contains(item))
                            {
                                if (evt.Result == null)
                                {
                                    evt.Result = new List<LayerItem>();
                                }

                            ((List<LayerItem>)evt.Result).Add(item);
                            }
                            sChanges.Text = string.Empty;
                            sAllProperties.Text = string.Empty;
                            sChildren.Text = string.Empty;

                            sChanges.EmptyUndoBuffer();
                            sAllProperties.EmptyUndoBuffer();
                            sChildren.EmptyUndoBuffer();
                        }));

                        item.ActiveLayer = null;

                        current++;
                    }
                },
                PostWorkCallBack = (evt) =>
                {
                    if (evt.Result is List<LayerItem> list)
                    {
                        foreach (var item in list)
                        {
                            bulkRemoveList.Remove(item);
                        }
                    }

                    SetRunningStatus(false);

                    if (evt.Error != null)
                    {
                        MessageBox.Show(this, $"Error when removing active layer: {evt.Error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                },
                ProgressChanged = (evt) =>
                {
                    SetWorkingMessage(evt.UserState.ToString());
                }
            });
        }

        private void scintilla1_TextChanged(object sender, EventArgs e)
        {
            var ctrl = (Scintilla)sender;
            ctrl.Margins[0].Width = ctrl.Lines.Count.ToString().Length * 12;
        }

        private void SetRunningStatus(bool isRunning)
        {
            tsbCancel.Enabled = isRunning;
            tsbLoadSolutions.Enabled = !isRunning;
            solutionPicker1.Enabled = !isRunning;
            componentsPicker1.Enabled = !isRunning;
            tsbRemoveActiveLayer.Enabled = !isRunning;
            lvItems.Enabled = !isRunning;

            tsbRemoveActiveLayersBulk.Text = string.Format(tsbRemoveActiveLayersBulk.Tag.ToString(), bulkRemoveList.Count, bulkRemoveList.Count > 0 ? "s" : "");
            tsbRemoveActiveLayersBulk.Visible = !isRunning && bulkRemoveList.Count > 0;
            tssRalSeparator.Visible = tsbRemoveActiveLayersBulk.Visible;
            tsbClearActiveLayerList.Visible = tsbRemoveActiveLayersBulk.Visible;
        }

        private void SetScintillatControl(Scintilla ctrl)
        {
            ctrl.StyleResetDefault();
            ctrl.Styles[Style.Default].Font = "Consolas";
            ctrl.Styles[Style.Default].Size = 10;
            ctrl.StyleClearAll();
            ctrl.Styles[Style.Json.Default].ForeColor = Color.Silver;
            ctrl.Styles[Style.Json.BlockComment].ForeColor = Color.Green;
            ctrl.Styles[Style.Json.PropertyName].ForeColor = Color.Red;
            ctrl.Styles[Style.Json.String].ForeColor = Color.Blue;
            ctrl.Styles[Style.Json.Number].ForeColor = Color.Blue;
            ctrl.Styles[Style.Json.Keyword].ForeColor = Color.Blue;
            ctrl.Styles[Style.Json.StringEol].BackColor = Color.Pink;
            ctrl.Styles[Style.Json.Operator].ForeColor = Color.Black;

            // Instruct the lexer to calculate folding
            ctrl.SetProperty("fold", "1");
            ctrl.SetProperty("fold.compact", "1");
            ctrl.SetProperty("fold.html", "1");

            // Configure a margin to display folding symbols
            ctrl.Margins[2].Type = MarginType.Symbol;
            ctrl.Margins[2].Mask = Marker.MaskFolders;
            ctrl.Margins[2].Sensitive = true;
            ctrl.Margins[2].Width = 20;

            // Set colors for all folding markers
            for (int i = 25; i <= 31; i++)
            {
                ctrl.Markers[i].SetForeColor(SystemColors.ControlLightLight);
                ctrl.Markers[i].SetBackColor(SystemColors.ControlDark);
            }

            // Configure folding markers with respective symbols
            ctrl.Markers[Marker.Folder].Symbol = MarkerSymbol.BoxPlus;
            ctrl.Markers[Marker.FolderOpen].Symbol = MarkerSymbol.BoxMinus;
            ctrl.Markers[Marker.FolderEnd].Symbol = MarkerSymbol.BoxPlusConnected;
            ctrl.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            ctrl.Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.BoxMinusConnected;
            ctrl.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            ctrl.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;
        }

        private void solutionPicker1_OnSelected(object sender, EventArgs e)
        {
            var solution = ((SolutionPicker)sender).SelectedSolution;
            if (solution == null) return;

            componentsPicker1.Service = (CrmServiceClient)Service;

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading components...",
                Work = (bw, evt) =>
                {
                    componentsPicker1.LoadComponents(solution.Id);
                },
                PostWorkCallBack = (evt) =>
                {
                    if (evt.Error != null)
                    {
                        MessageBox.Show(this, $"Error when loading components: {evt.Error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    componentsPicker1.DisplayComponents(componentsDefs);
                }
            });
        }

        private void toolStripMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == tsbLoadSolutions)
            {
                ExecuteMethod(LoadSolutions);
            }
        }

        private void tsbAddToRemovalList_Click(object sender, EventArgs e)
        {
            var items = lvItems.GetCheckedOrSelectedItems().Select(i => (LayerItem)i.Tag)
                .Where(i => !bulkRemoveList.Contains(i))
                .ToList();

            if (items.Count > 0)
            {
                bulkRemoveList.AddRange(items);
            }

            tsbRemoveActiveLayersBulk.Text = string.Format(tsbRemoveActiveLayersBulk.Tag.ToString(), bulkRemoveList.Count, bulkRemoveList.Count > 0 ? "s" : "");
            tsbRemoveActiveLayersBulk.Visible = true;
            tssRalSeparator.Visible = tsbRemoveActiveLayersBulk.Visible;
            tsbClearActiveLayerList.Visible = tsbRemoveActiveLayersBulk.Visible;
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            currentBw?.CancelAsync();
            currentBw?.ReportProgress(0, "Terminating current operation then cancelling...");
        }

        private void tsbClearActiveLayerList_Click(object sender, EventArgs e)
        {
            bulkRemoveList.Clear();
            tsbRemoveActiveLayersBulk.Visible = false;
            tssRalSeparator.Visible = tsbRemoveActiveLayersBulk.Visible;
            tsbClearActiveLayerList.Visible = tsbRemoveActiveLayersBulk.Visible;
        }

        private void tsbLoadActiveLayers_Click(object sender, EventArgs e)
        {
            var components = componentsPicker1.SelectedComponents;
            if (components.Count == 0) return;

            foreach (var component in components)
            {
                if (component.SubItems.Count < 3)
                    component.SubItems.Add(new ListViewItem.ListViewSubItem());

                component.SubItems[2].Text = "...";
            }

            SetRunningStatus(true);

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading active layers...",
                IsCancelable = true,
                Work = (bw, evt) =>
                {
                    currentBw = bw;

                    foreach (var component in components)
                    {
                        if (bw.CancellationPending) return;

                        var items = component.Tag as List<LayerItem>;
                        if (items == null) continue;

                        bw.ReportProgress(0, $"Loading active layers for {component.Text}...");

                        var als = new ActiveLayerSearch((CrmServiceClient)Service);
                        als.GetActiveLayers(items);
                    }
                },
                PostWorkCallBack = (evt) =>
                {
                    SetRunningStatus(false);

                    if (evt.Error != null)
                    {
                        MessageBox.Show(this, $"Error when loading components: {evt.Error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    componentsPicker1.DisplayActiveLayers();
                    componentsPicker1.UncheckAll();

                    ComponentsPicker1_OnSelected(null, new EventArgs());
                },
                ProgressChanged = evt =>
                {
                    SetWorkingMessage(evt.UserState.ToString());
                }
            });
        }

        private void tsbRemoveActiveLayer_Click(object sender, EventArgs e)
        {
            var items = lvItems.GetCheckedOrSelectedItems().Select(i => (LayerItem)i.Tag).ToList();

            if (items.Count == 0)
            {
                MessageBox.Show(this, @"Please select at least one component", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RemoveActiveLayers(items);
        }

        private void tsbRemoveActiveLayersBulk_Click(object sender, EventArgs e)
        {
            RemoveActiveLayers(bulkRemoveList);
        }
    }
}