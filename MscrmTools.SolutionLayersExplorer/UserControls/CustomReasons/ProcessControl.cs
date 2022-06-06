using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using MscrmTools.SolutionLayersExplorer.AppCode.Args;
using System;
using System.Windows.Forms;

namespace MscrmTools.SolutionLayersExplorer.UserControls.CustomReasons
{
    public partial class ProcessControl : UserControl
    {
        private readonly Guid _id;
        private readonly bool _isFlow;

        public ProcessControl(Guid id, IOrganizationService service)
        {
            InitializeComponent();

            _id = id;

            _isFlow = service.Retrieve("workflow", id, new ColumnSet("category")).GetAttributeValue<OptionSetValue>("category").Value == 5;
        }

        public event EventHandler<ComparisonEventArgs> ComparisonRequested;

        private void btnCompare_Click(object sender, EventArgs e)
        {
            ComparisonRequested?.Invoke(this, new ComparisonEventArgs { IsSpecific = false, Entity = "workflow", Attribute = _isFlow ? "clientdata" : "xaml", Id = _id });
        }
    }
}