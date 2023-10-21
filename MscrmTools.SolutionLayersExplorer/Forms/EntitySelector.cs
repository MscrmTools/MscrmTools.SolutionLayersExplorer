using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MscrmTools.SolutionLayersExplorer.Forms
{
    public partial class EntitySelector : Form
    {
        public EntitySelector(List<EntityMetadata> emds)
        {
            InitializeComponent();

            lvTables.Items.AddRange(emds.Select(e => new ListViewItem(e.DisplayName?.UserLocalizedLabel?.Label ?? e.SchemaName) { Tag = e }).ToArray());
            lvTables.Sorting = SortOrder.Ascending;
            lvTables.Sort();
        }

        public List<EntityMetadata> SelectTables => lvTables.CheckedItems.Cast<ListViewItem>().Select(li => (EntityMetadata)li.Tag).ToList();

        private void tsbClearAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvTables.Items)
            {
                item.Checked = false;
            }
        }

        private void tsbSelectAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvTables.Items)
            {
                item.Checked = true;
            }
        }
    }
}