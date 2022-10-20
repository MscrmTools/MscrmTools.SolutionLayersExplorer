using MscrmTools.SolutionLayersExplorer.AppCode.Args;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MscrmTools.SolutionLayersExplorer.UserControls.CustomReasons
{
    public partial class RoleChangesControl : UserControl
    {
        private readonly string _allJson;
        private readonly string _json;
        private readonly Dictionary<string, string> _privileges = new Dictionary<string, string>();
        private string _roleName;

        public RoleChangesControl(string json, string allJson)
        {
            InitializeComponent();

            _json = json;
            _allJson = allJson;
        }

        public event EventHandler<ComparisonEventArgs> ComparisonRequested;

        public void DisplayCustomReason()
        {
            var allJo = JObject.Parse(_allJson);
            _roleName = ((JArray)allJo["Attributes"]).First(a => ((JObject)a).Value<string>("Key") == "name").Value<string>("Value");

            if (string.IsNullOrEmpty(_json) || _json == "{}")
            {
                lvPrivs.Items.Clear();
                lvPrivs.Visible = false;
                pnlNoChange.Visible = true;
                return;
            }

            var jo = JObject.Parse(_json);
            if (!jo.ContainsKey("RolePrivileges"))
            {
                lvPrivs.Visible = false;
                pnlNoChange.Visible = true;
                return;
            }

            foreach (var joPriv in ((JArray)((JObject)jo["RolePrivileges"])["Entities"]))
            {
                var attrs = (JArray)joPriv["Attributes"];
                var privName = ((JObject)attrs.First(a => ((JObject)a).Value<string>("Key") == "privilegename")).Value<string>("Value");
                var privDepth = ((JObject)attrs.First(a => ((JObject)a).Value<string>("Key") == "privilegedepthmask")).Value<string>("Value");

                _privileges.Add(privName, privDepth);
            }

            lvPrivs.Items.Clear();
            lvPrivs.Items.AddRange(_privileges.Select(p => new ListViewItem(p.Key) { SubItems = { new ListViewItem.ListViewSubItem() { Text = p.Value } } }).ToArray());
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            ComparisonRequested?.Invoke(this, new ComparisonEventArgs { IsSpecific = true, SpecificType = "Security Roles", SpecificValue = _roleName, Id = Guid.Empty });
        }
    }
}