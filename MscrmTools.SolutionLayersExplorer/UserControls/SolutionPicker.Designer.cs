
namespace MscrmTools.SolutionLayersExplorer.UserControls
{
    partial class SolutionPicker
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tslFilter = new System.Windows.Forms.ToolStripLabel();
            this.tstbFilter = new System.Windows.Forms.ToolStripTextBox();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.lvSolutions = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chkLoadAll = new System.Windows.Forms.CheckBox();
            this.chkShowHidden = new System.Windows.Forms.CheckBox();
            this.toolStrip1.SuspendLayout();
            this.pnlOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslFilter,
            this.tstbFilter});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(315, 31);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tslFilter
            // 
            this.tslFilter.Name = "tslFilter";
            this.tslFilter.Size = new System.Drawing.Size(59, 26);
            this.tslFilter.Text = "Filter: ";
            // 
            // tstbFilter
            // 
            this.tstbFilter.Name = "tstbFilter";
            this.tstbFilter.Size = new System.Drawing.Size(200, 31);
            this.tstbFilter.TextChanged += new System.EventHandler(this.toolStripTextBox1_TextChanged);
            // 
            // pnlOptions
            // 
            this.pnlOptions.Controls.Add(this.chkShowHidden);
            this.pnlOptions.Controls.Add(this.chkLoadAll);
            this.pnlOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOptions.Location = new System.Drawing.Point(0, 31);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(315, 55);
            this.pnlOptions.TabIndex = 3;
            // 
            // lvSolutions
            // 
            this.lvSolutions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chVersion});
            this.lvSolutions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSolutions.FullRowSelect = true;
            this.lvSolutions.HideSelection = false;
            this.lvSolutions.Location = new System.Drawing.Point(0, 86);
            this.lvSolutions.MultiSelect = false;
            this.lvSolutions.Name = "lvSolutions";
            this.lvSolutions.Size = new System.Drawing.Size(315, 922);
            this.lvSolutions.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvSolutions.TabIndex = 4;
            this.lvSolutions.UseCompatibleStateImageBehavior = false;
            this.lvSolutions.View = System.Windows.Forms.View.Details;
            this.lvSolutions.SelectedIndexChanged += new System.EventHandler(this.lvSolutions_SelectedIndexChanged);
            // 
            // chName
            // 
            this.chName.Text = "Solution";
            this.chName.Width = 182;
            // 
            // chVersion
            // 
            this.chVersion.Text = "Version";
            this.chVersion.Width = 114;
            // 
            // chkLoadAll
            // 
            this.chkLoadAll.AutoSize = true;
            this.chkLoadAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkLoadAll.Location = new System.Drawing.Point(0, 0);
            this.chkLoadAll.Name = "chkLoadAll";
            this.chkLoadAll.Size = new System.Drawing.Size(315, 24);
            this.chkLoadAll.TabIndex = 0;
            this.chkLoadAll.Text = "Show unmanaged solutions";
            this.chkLoadAll.UseVisualStyleBackColor = true;
            // 
            // chkShowHidden
            // 
            this.chkShowHidden.AutoSize = true;
            this.chkShowHidden.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkShowHidden.Location = new System.Drawing.Point(0, 24);
            this.chkShowHidden.Name = "chkShowHidden";
            this.chkShowHidden.Size = new System.Drawing.Size(315, 24);
            this.chkShowHidden.TabIndex = 1;
            this.chkShowHidden.Text = "Show hidden solutions";
            this.chkShowHidden.UseVisualStyleBackColor = true;
            // 
            // SolutionPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvSolutions);
            this.Controls.Add(this.pnlOptions);
            this.Controls.Add(this.toolStrip1);
            this.Name = "SolutionPicker";
            this.Size = new System.Drawing.Size(315, 1008);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlOptions.ResumeLayout(false);
            this.pnlOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel tslFilter;
        private System.Windows.Forms.ToolStripTextBox tstbFilter;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.CheckBox chkShowHidden;
        private System.Windows.Forms.CheckBox chkLoadAll;
        private System.Windows.Forms.ListView lvSolutions;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chVersion;
    }
}
