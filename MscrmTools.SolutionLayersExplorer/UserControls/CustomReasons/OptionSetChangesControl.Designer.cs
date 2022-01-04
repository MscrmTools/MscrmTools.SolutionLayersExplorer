namespace MscrmTools.SolutionLayersExplorer.UserControls.CustomReasons
{
    partial class OptionSetChangesControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gbLabels = new System.Windows.Forms.GroupBox();
            this.gbValues = new System.Windows.Forms.GroupBox();
            this.lvLabels = new System.Windows.Forms.ListView();
            this.chLcid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLabelType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLabel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvValueLabels = new System.Windows.Forms.ListView();
            this.chValueLabelLcid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chValueLabelLabel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvValues = new System.Windows.Forms.ListView();
            this.chValueValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chValueOrder = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chColor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chExternalValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chValueLabelType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbLabels.SuspendLayout();
            this.gbValues.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.gbValues, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.gbLabels, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(964, 402);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gbLabels
            // 
            this.gbLabels.Controls.Add(this.lvLabels);
            this.gbLabels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbLabels.Location = new System.Drawing.Point(3, 3);
            this.gbLabels.Name = "gbLabels";
            this.gbLabels.Size = new System.Drawing.Size(958, 195);
            this.gbLabels.TabIndex = 0;
            this.gbLabels.TabStop = false;
            this.gbLabels.Text = "Labels";
            // 
            // gbValues
            // 
            this.gbValues.Controls.Add(this.splitContainer1);
            this.gbValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbValues.Location = new System.Drawing.Point(3, 204);
            this.gbValues.Name = "gbValues";
            this.gbValues.Size = new System.Drawing.Size(958, 195);
            this.gbValues.TabIndex = 1;
            this.gbValues.TabStop = false;
            this.gbValues.Text = "Optionset Values";
            // 
            // lvLabels
            // 
            this.lvLabels.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chLcid,
            this.chLabelType,
            this.chLabel});
            this.lvLabels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvLabels.FullRowSelect = true;
            this.lvLabels.HideSelection = false;
            this.lvLabels.Location = new System.Drawing.Point(3, 22);
            this.lvLabels.Name = "lvLabels";
            this.lvLabels.Size = new System.Drawing.Size(952, 170);
            this.lvLabels.TabIndex = 0;
            this.lvLabels.UseCompatibleStateImageBehavior = false;
            this.lvLabels.View = System.Windows.Forms.View.Details;
            // 
            // chLcid
            // 
            this.chLcid.Text = "Language code";
            this.chLcid.Width = 150;
            // 
            // chLabelType
            // 
            this.chLabelType.Text = "Type";
            this.chLabelType.Width = 100;
            // 
            // chLabel
            // 
            this.chLabel.Text = "Label";
            this.chLabel.Width = 300;
            // 
            // lvValueLabels
            // 
            this.lvValueLabels.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chValueLabelLcid,
            this.chValueLabelType,
            this.chValueLabelLabel});
            this.lvValueLabels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvValueLabels.HideSelection = false;
            this.lvValueLabels.Location = new System.Drawing.Point(0, 0);
            this.lvValueLabels.Name = "lvValueLabels";
            this.lvValueLabels.Size = new System.Drawing.Size(631, 170);
            this.lvValueLabels.TabIndex = 4;
            this.lvValueLabels.UseCompatibleStateImageBehavior = false;
            this.lvValueLabels.View = System.Windows.Forms.View.Details;
            // 
            // chValueLabelLcid
            // 
            this.chValueLabelLcid.Text = "Language";
            this.chValueLabelLcid.Width = 100;
            // 
            // chValueLabelLabel
            // 
            this.chValueLabelLabel.Text = "Label";
            this.chValueLabelLabel.Width = 300;
            // 
            // lvValues
            // 
            this.lvValues.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chValueValue,
            this.chValueOrder,
            this.chColor,
            this.chExternalValue});
            this.lvValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvValues.FullRowSelect = true;
            this.lvValues.HideSelection = false;
            this.lvValues.Location = new System.Drawing.Point(0, 0);
            this.lvValues.Name = "lvValues";
            this.lvValues.Size = new System.Drawing.Size(317, 170);
            this.lvValues.TabIndex = 5;
            this.lvValues.UseCompatibleStateImageBehavior = false;
            this.lvValues.View = System.Windows.Forms.View.Details;
            this.lvValues.SelectedIndexChanged += new System.EventHandler(this.lvValues_SelectedIndexChanged);
            // 
            // chValueValue
            // 
            this.chValueValue.Text = "Value";
            // 
            // chValueOrder
            // 
            this.chValueOrder.Text = "Order";
            // 
            // chColor
            // 
            this.chColor.Text = "Color";
            this.chColor.Width = 100;
            // 
            // chExternalValue
            // 
            this.chExternalValue.Text = "Ext. value";
            this.chExternalValue.Width = 100;
            // 
            // chValueLabelType
            // 
            this.chValueLabelType.Text = "Type";
            this.chValueLabelType.Width = 100;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 22);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvValues);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvValueLabels);
            this.splitContainer1.Panel2MinSize = 400;
            this.splitContainer1.Size = new System.Drawing.Size(952, 170);
            this.splitContainer1.SplitterDistance = 317;
            this.splitContainer1.TabIndex = 6;
            // 
            // OptionSetChangesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "OptionSetChangesControl";
            this.Size = new System.Drawing.Size(964, 402);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gbLabels.ResumeLayout(false);
            this.gbValues.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox gbValues;
        private System.Windows.Forms.ListView lvValues;
        private System.Windows.Forms.ColumnHeader chValueValue;
        private System.Windows.Forms.ColumnHeader chValueOrder;
        private System.Windows.Forms.ColumnHeader chColor;
        private System.Windows.Forms.ColumnHeader chExternalValue;
        private System.Windows.Forms.ListView lvValueLabels;
        private System.Windows.Forms.ColumnHeader chValueLabelLcid;
        private System.Windows.Forms.ColumnHeader chValueLabelLabel;
        private System.Windows.Forms.GroupBox gbLabels;
        private System.Windows.Forms.ListView lvLabels;
        private System.Windows.Forms.ColumnHeader chLcid;
        private System.Windows.Forms.ColumnHeader chLabelType;
        private System.Windows.Forms.ColumnHeader chLabel;
        private System.Windows.Forms.ColumnHeader chValueLabelType;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
