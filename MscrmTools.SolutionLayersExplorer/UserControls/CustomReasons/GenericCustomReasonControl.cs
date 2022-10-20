using MscrmTools.SolutionLayersExplorer.AppCode.Args;
using System;
using System.Windows.Forms;

namespace MscrmTools.SolutionLayersExplorer.UserControls.CustomReasons
{
    public partial class GenericCustomReasonControl : UserControl
    {
        private readonly string _attribute;
        private readonly string _entity;
        private readonly Guid _id;

        public GenericCustomReasonControl(string entity, string attribute, Guid id)
        {
            InitializeComponent();

            _id = id;
            _entity = entity;
            _attribute = attribute;
        }

        public event EventHandler<ComparisonEventArgs> ComparisonRequested;

        private void btnCompare_Click(object sender, EventArgs e)
        {
            ComparisonRequested?.Invoke(this, new ComparisonEventArgs { IsSpecific = false, Entity = _entity, Attribute = _attribute, Id = _id });
        }
    }
}