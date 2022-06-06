using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using MscrmTools.SolutionLayersExplorer.AppCode.Args;
using System;
using System.Windows.Forms;

namespace MscrmTools.SolutionLayersExplorer.UserControls.CustomReasons
{
    public partial class WebresourceControl : UserControl
    {
        private readonly Guid _id;
        private readonly string _name;

        public WebresourceControl(Guid id, IOrganizationService service)
        {
            InitializeComponent();

            _id = id;

            _name = service.Retrieve("webresource", id, new ColumnSet("name")).GetAttributeValue<string>("name");
        }

        public event EventHandler<ComparisonEventArgs> ComparisonRequested;

        private void btnCompare_Click(object sender, EventArgs e)
        {
            ComparisonRequested?.Invoke(this, new ComparisonEventArgs { IsSpecific = true, SpecificType = "Webresources", SpecificValue = _name, Id = _id });
        }
    }
}