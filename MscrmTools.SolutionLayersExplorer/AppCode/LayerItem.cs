using Microsoft.Xrm.Sdk;
using System.Windows.Forms;

namespace MscrmTools.SolutionLayersExplorer.AppCode
{
    public class LayerItem
    {
        public Entity ActiveLayer { get; set; }
        public ListViewItem ListViewItem { get; internal set; }
        public Entity Record { get; set; }

        public void Remove()
        {
            this.ListViewItem.SubItems[2].Text = (int.Parse(this.ListViewItem.SubItems[2].Text) - 1).ToString();
        }
    }
}