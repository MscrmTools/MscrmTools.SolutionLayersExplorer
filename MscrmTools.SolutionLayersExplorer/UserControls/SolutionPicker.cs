using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace MscrmTools.SolutionLayersExplorer.UserControls
{
    public partial class SolutionPicker : UserControl
    {
        private List<Entity> _entities = new List<Entity>();

        private Thread filterThread;

        public SolutionPicker()
        {
            InitializeComponent();
        }

        public event EventHandler OnSelected;

        public Entity SelectedSolution => lvSolutions.SelectedItems.Cast<ListViewItem>().FirstOrDefault()?.Tag as Entity;

        public CrmServiceClient Service { get; set; }

        public void DisplaySolutions(object filter = null)
        {
            Invoke(new Action(() =>
            {
                lvSolutions.Items.Clear();
                lvSolutions.Items.AddRange(_entities
                    .Where(s => filter == null
                    || s.GetAttributeValue<string>("friendlyname").ToLower().IndexOf(filter.ToString().ToLower()) >= 0
                    || s.GetAttributeValue<string>("uniquename").ToLower().IndexOf(filter.ToString().ToLower()) >= 0
                    )
                    .Select(s => new ListViewItem(s.GetAttributeValue<string>("friendlyname")) { Tag = s }).ToArray());
            }));
        }

        public void LoadSolutions()
        {
            var solutions = Service.RetrieveMultiple(new QueryExpression("solution")
            {
                NoLock = true,
                ColumnSet = new ColumnSet(true),
                Criteria = new FilterExpression
                {
                    Conditions =
                    {
                        new ConditionExpression("ismanaged", ConditionOperator.Equal, true)
                    }
                }
            }).Entities;

            _entities = solutions.ToList();
        }

        private void lvSolutions_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            OnSelected?.Invoke(this, new EventArgs());
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            filterThread?.Abort();
            filterThread = new Thread(DisplaySolutions);
            filterThread.Start(tstbFilter.Text);
        }
    }
}