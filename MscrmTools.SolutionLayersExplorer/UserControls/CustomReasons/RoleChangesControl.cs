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
        private readonly string _json;

        private readonly Dictionary<string, string> _privileges = new Dictionary<string, string>();

        public RoleChangesControl(string json)
        {
            InitializeComponent();

            _json = json;
        }

        public void DisplayCustomReason()
        {
            var jo = JObject.Parse(_json);

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
    }
}