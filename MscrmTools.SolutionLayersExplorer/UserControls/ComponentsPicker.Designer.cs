
namespace MscrmTools.SolutionLayersExplorer.UserControls
{
    partial class ComponentsPicker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComponentsPicker));
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tbsLoadActiveLayers = new System.Windows.Forms.ToolStripButton();
            this.tsbRemoveActiveLayer = new System.Windows.Forms.ToolStripButton();
            this.tsbCheckAll = new System.Windows.Forms.ToolStripButton();
            this.tsbExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.lvComponents = new System.Windows.Forms.ListView();
            this.chType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chActiveLayers = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbsLoadActiveLayers,
            this.tsbRemoveActiveLayer,
            this.tsbCheckAll,
            this.tsbExportToExcel});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.TabIndex = 1; 
            this.tsMain.Size = new System.Drawing.Size(717, 34);
            this.tsMain.Text = "tsComponents";
            // 
            // tbsLoadActiveLayers
            // 
            this.tbsLoadActiveLayers.Image = global::MscrmTools.SolutionLayersExplorer.Properties.Resources.layers;
            this.tbsLoadActiveLayers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbsLoadActiveLayers.Name = "tbsLoadActiveLayers";
            this.tbsLoadActiveLayers.Size = new System.Drawing.Size(174, 29);
            this.tbsLoadActiveLayers.Text = "Load Active layers";
            this.tbsLoadActiveLayers.ToolTipText = "Load Active layers for checked items";
            this.tbsLoadActiveLayers.Click += new System.EventHandler(this.tbsLoadActiveLayers_Click);
            // 
            // tsbRemoveActiveLayer
            // 
            this.tsbRemoveActiveLayer.Image = global::MscrmTools.SolutionLayersExplorer.Properties.Resources.layers__1_;
            this.tsbRemoveActiveLayer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRemoveActiveLayer.Name = "tsbRemoveActiveLayer";
            this.tsbRemoveActiveLayer.Size = new System.Drawing.Size(174, 29);
            this.tsbRemoveActiveLayer.Text = "Remove Active layer(s)";
            this.tsbRemoveActiveLayer.Click += new System.EventHandler(this.tsbRemoveActiveLayer_Click);
            // 
            // tsbCheckAll
            // 
            this.tsbCheckAll.Image = global::MscrmTools.SolutionLayersExplorer.Properties.Resources.check_box_with_check_sign;
            this.tsbCheckAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCheckAll.Name = "tsbCheckAll";
            this.tsbCheckAll.Size = new System.Drawing.Size(174, 29);
            this.tsbCheckAll.Text = "Check all";
            this.tsbCheckAll.Click += new System.EventHandler(this.tsbCheckAll_Click);
            // 
            // tsbExportToExcel
            // 
            this.tsbExportToExcel.Image = ((System.Drawing.Image)(resources.GetObject("tsbExportToExcel.Image")));
            this.tsbExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExportToExcel.Name = "tsbExportToExcel";
            this.tsbExportToExcel.Size = new System.Drawing.Size(174, 29);
            this.tsbExportToExcel.Text = "Export";
            this.tsbExportToExcel.Click += new System.EventHandler(this.tbsExportToExcel_Click);
            // 
            // lvComponents
            // 
            this.lvComponents.CheckBoxes = true;
            this.lvComponents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chType,
            this.chCount,
            this.chActiveLayers});
            this.lvComponents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvComponents.FullRowSelect = true;
            this.lvComponents.HideSelection = false;
            this.lvComponents.Location = new System.Drawing.Point(0, 50);
            this.lvComponents.Margin = new System.Windows.Forms.Padding(4);
            this.lvComponents.MultiSelect = false;
            this.lvComponents.Name = "lvComponents";
            this.lvComponents.Size = new System.Drawing.Size(956, 1149);
            this.lvComponents.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvComponents.TabIndex = 2;
            this.lvComponents.UseCompatibleStateImageBehavior = false;
            this.lvComponents.View = System.Windows.Forms.View.Details;
            this.lvComponents.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvComponents_ColumnClick);
            this.lvComponents.SelectedIndexChanged += new System.EventHandler(this.lvComponents_SelectedIndexChanged);
            // 
            // chType
            // 
            this.chType.Text = "Components";
            this.chType.Width = 200;
            // 
            // chCount
            // 
            this.chCount.Text = "Count";
            this.chCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chActiveLayers
            // 
            this.chActiveLayers.Text = "Active layers";
            this.chActiveLayers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chActiveLayers.Width = 100;
            // 
            // ComponentsPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvComponents);
            this.Controls.Add(this.tsMain);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ComponentsPicker";
            this.Size = new System.Drawing.Size(956, 1199);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ListView lvComponents;
        private System.Windows.Forms.ColumnHeader chType;
        private System.Windows.Forms.ColumnHeader chCount;
        private System.Windows.Forms.ColumnHeader chActiveLayers;
        private System.Windows.Forms.ToolStripButton tbsLoadActiveLayers;
        private System.Windows.Forms.ToolStripButton tsbRemoveActiveLayer;
        private System.Windows.Forms.ToolStripButton tsbCheckAll;
        private System.Windows.Forms.ToolStripButton tsbExportToExcel;
    }
}
