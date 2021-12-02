using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MscrmTools.SolutionLayersExplorer.AppCode
{
    public static class Extensions
    {
        public static List<ListViewItem> GetCheckedOrSelectedItems(this ListView listView)
        {
            var items = listView.SelectedItems.Cast<ListViewItem>().ToList();
            items = items.Union(listView.CheckedItems.Cast<ListViewItem>()).ToList();

            return items;
        }
    }
}