using MscrmTools.SolutionLayersExplorer.AppCode.Args;
using System;
using System.Windows.Forms;

namespace MscrmTools.SolutionLayersExplorer.UserControls.CustomReasons
{
    public partial class SavedQueryControl : UserControl
    {
        private readonly Guid _id;

        public SavedQueryControl(Guid id)
        {
            InitializeComponent();

            _id = id;
        }

        public event EventHandler<ComparisonEventArgs> ComparisonRequested;

        private void btnCompare_Click(object sender, EventArgs e)
        {
            ComparisonRequested?.Invoke(this, new ComparisonEventArgs { IsSpecific = false, Entity = "savedquery", Attribute = "layoutxml", Id = _id });
        }

        private void btnCompareQuery_Click(object sender, EventArgs e)
        {
            ComparisonRequested?.Invoke(this, new ComparisonEventArgs { IsSpecific = false, Entity = "savedquery", Attribute = "fetchxml", Id = _id });
        }
    }
}