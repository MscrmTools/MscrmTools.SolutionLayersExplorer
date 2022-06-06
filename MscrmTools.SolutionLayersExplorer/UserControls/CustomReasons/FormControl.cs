using MscrmTools.SolutionLayersExplorer.AppCode.Args;
using System;
using System.Windows.Forms;

namespace MscrmTools.SolutionLayersExplorer.UserControls.CustomReasons
{
    public partial class FormControl : UserControl
    {
        private readonly Guid _id;

        public FormControl(Guid id)
        {
            InitializeComponent();

            _id = id;
        }

        public event EventHandler<ComparisonEventArgs> ComparisonRequested;

        private void btnCompare_Click(object sender, EventArgs e)
        {
            ComparisonRequested?.Invoke(this, new ComparisonEventArgs { IsSpecific = false, Entity = "systemform", Attribute = "formxml", Id = _id });
        }
    }
}