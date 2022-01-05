using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using MscrmTools.SolutionLayersExplorer.AppCode.Args;
using System;
using System.Windows.Forms;

namespace MscrmTools.SolutionLayersExplorer.UserControls.CustomReasons
{
    public partial class ModelDrivenAppControl : UserControl
    {
        private readonly string _appUniqueName;
        private readonly Guid _id;

        public ModelDrivenAppControl(Guid id, IOrganizationService service)
        {
            InitializeComponent();

            _id = id;

            _appUniqueName = service.Retrieve("appmodule", id, new ColumnSet("uniquename")).GetAttributeValue<string>("uniquename");
        }

        public event EventHandler<ComparisonEventArgs> ComparisonRequested;

        private void btnCompare_Click(object sender, EventArgs e)
        {
            ComparisonRequested?.Invoke(this, new ComparisonEventArgs { IsSpecific = true, SpecificType = "Model driven app", SpecificValue = _appUniqueName, Id = _id });
        }
    }
}