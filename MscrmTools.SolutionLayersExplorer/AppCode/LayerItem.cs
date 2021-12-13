using Microsoft.Xrm.Sdk;
using System.Windows.Forms;

namespace MscrmTools.SolutionLayersExplorer.AppCode
{
    public class LayerItem
    {
        public Entity ActiveLayer { get; set; }
        public ListViewItem ComponentListViewItem { get; internal set; }
        public ListViewItem ListViewItem { get; internal set; }
        public Entity Record { get; set; }

        public void DecrementeParentComponentCount()
        {
            this.ComponentListViewItem.SubItems[2].Text = (int.Parse(this.ComponentListViewItem.SubItems[2].Text) - 1).ToString();
        }
    }
}