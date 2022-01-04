using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MscrmTools.SolutionLayersExplorer.UserControls.CustomReasons
{
    public partial class OptionSetChangesControl : UserControl
    {
        private readonly string _json;

        private readonly List<Tuple<int, string, string>> _labels = new List<Tuple<int, string, string>>();
        private readonly List<Tuple<int, int, string, string, string, string>> _values = new List<Tuple<int, int, string, string, string, string>>();

        public OptionSetChangesControl(string json)
        {
            InitializeComponent();

            _json = json;
        }

        public void DisplayCustomReason()
        {
            var jo = JObject.Parse(_json);

            foreach (var joLabel in ((JArray)((JObject)jo["LocalizedLabels"])["Entities"]))
            {
                var attrs = (JArray)joLabel["Attributes"];
                var labelType = ((JObject)attrs.First(a => ((JObject)a).Value<string>("Key") == "objectcolumnname")).Value<string>("Value");
                var label = ((JObject)attrs.First(a => ((JObject)a).Value<string>("Key") == "label")).Value<string>("Value");
                var lcid = ((JObject)attrs.First(a => ((JObject)a).Value<string>("Key") == "languageid")).Value<int>("Value");

                _labels.Add(new Tuple<int, string, string>(lcid, labelType, label));
            }

            foreach (var joValue in ((JArray)((JObject)jo["AttributePicklistValues"])["Entities"]))
            {
                var attrs = (JArray)joValue["Attributes"];
                _values.Add(new Tuple<int, int, string, string, string, string>(
                     ((JObject)attrs.FirstOrDefault(a => ((JObject)a).Value<string>("Key") == "value"))?.Value<int>("Value") ?? -1,
                     ((JObject)attrs.FirstOrDefault(a => ((JObject)a).Value<string>("Key") == "displayorder"))?.Value<int>("Value") ?? -1,
                     ((JObject)attrs.FirstOrDefault(a => ((JObject)a).Value<string>("Key") == "color"))?.Value<string>("Value"),
                     ((JObject)attrs.FirstOrDefault(a => ((JObject)a).Value<string>("Key") == "externalvalue"))?.Value<string>("Value"),
                     ((JObject)attrs.FirstOrDefault(a => ((JObject)a).Value<string>("Key") == "DisplayName - LocalizedLabel"))?.Value<string>("Value"),
                     ((JObject)attrs.FirstOrDefault(a => ((JObject)a).Value<string>("Key") == "Description - LocalizedLabel"))?.Value<string>("Value")));
            }

            lvLabels.Items.Clear();
            lvLabels.Items.AddRange(_labels.Select(p => new ListViewItem(p.Item1.ToString()) { SubItems = { new ListViewItem.ListViewSubItem() { Text = p.Item2 }, new ListViewItem.ListViewSubItem() { Text = p.Item3 } } }).ToArray());

            lvValues.Items.Clear();
            lvValues.Items.AddRange(_values.Select(v => new ListViewItem(v.Item1.ToString())
            {
                SubItems = {
                    new ListViewItem.ListViewSubItem(){Text=v.Item2.ToString() },
                  new ListViewItem.ListViewSubItem(){Text=v.Item3?.ToString() },
                  new ListViewItem.ListViewSubItem(){Text=v.Item4?.ToString() }
                  },
                Tag = v
            }).ToArray());
        }

        private void lvValues_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvValueLabels.Items.Clear();
            var selectedItem = lvValues.SelectedItems.Cast<ListViewItem>().FirstOrDefault();
            if (selectedItem == null) return;

            var item = (Tuple<int, int, string, string, string, string>)selectedItem.Tag;

            var value = item.Item1;

            if (!string.IsNullOrEmpty(item.Item5))
            {
                var joDisp = JObject.Parse(item.Item5);
                var dispProperties = ((JObject)joDisp["LocalizedLabels"]).Properties();
                foreach (var property in dispProperties)
                {
                    var label = ((JObject)((JObject)joDisp["LocalizedLabels"])[property.Name]).Value<string>("LocalizedLabel");

                    lvValueLabels.Items.Add(new ListViewItem(property.Name)
                    {
                        SubItems = {
                       new ListViewItem.ListViewSubItem(){Text="Display name" },
                        new ListViewItem.ListViewSubItem(){Text=label }
                  }
                    });
                }
            }

            if (!string.IsNullOrEmpty(item.Item6))
            {
                var joDesc = JObject.Parse(item.Item6);
                var descProperties = ((JObject)joDesc["LocalizedLabels"]).Properties();
                foreach (var property in descProperties)
                {
                    var label = ((JObject)((JObject)joDesc["LocalizedLabels"])[property.Name]).Value<string>("LocalizedLabel");

                    lvValueLabels.Items.Add(new ListViewItem(property.Name)
                    {
                        SubItems = {
                       new ListViewItem.ListViewSubItem(){Text="Description" },
                        new ListViewItem.ListViewSubItem(){Text=label }
                  }
                    });
                }
            }
        }
    }
}