using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MscrmTools.SolutionLayersExplorer.AppCode
{
    public static class Extensions
    {
        public static List<ListViewItem> GetCheckedOrSelectedItems(this ListView listView)
        {
            var checkedItems = listView.CheckedItems.Cast<ListViewItem>().ToList();
            if (checkedItems.Count > 0) return checkedItems;

            return listView.SelectedItems.Cast<ListViewItem>().ToList();
        }
    }
}