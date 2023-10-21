
namespace MscrmTools.SolutionLayersExplorer.UserControls.CustomReasons
{
    partial class GenericLayersComparerControl
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
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.pnlLayer1ToCompare = new System.Windows.Forms.Panel();
            this.cbbLayers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlAttributeToCompare = new System.Windows.Forms.Panel();
            this.cbbProperties = new System.Windows.Forms.ComboBox();
            this.chkShowOnlyDiff = new System.Windows.Forms.CheckBox();
            this.lblProperty = new System.Windows.Forms.Label();
            this.diffControl = new Menees.Diffs.Windows.Forms.DiffControl();
            this.pnlLayer2ToCompare = new System.Windows.Forms.Panel();
            this.cbbLayers2 = new System.Windows.Forms.ComboBox();
            this.lblLayer2 = new System.Windows.Forms.Label();
            this.btnShowDiffFullScreen = new System.Windows.Forms.Button();
            this.pnlInfo.SuspendLayout();
            this.pnlLayer1ToCompare.SuspendLayout();
            this.pnlAttributeToCompare.SuspendLayout();
            this.pnlLayer2ToCompare.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.SystemColors.Info;
            this.pnlInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInfo.Controls.Add(this.lblInfo);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(1235, 44);
            this.pnlInfo.TabIndex = 2;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(20, 10);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(386, 20);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Compare layers by selecting two layers and a property";
            // 
            // pnlLayer1ToCompare
            // 
            this.pnlLayer1ToCompare.Controls.Add(this.cbbLayers);
            this.pnlLayer1ToCompare.Controls.Add(this.label1);
            this.pnlLayer1ToCompare.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLayer1ToCompare.Location = new System.Drawing.Point(0, 44);
            this.pnlLayer1ToCompare.Name = "pnlLayer1ToCompare";
            this.pnlLayer1ToCompare.Size = new System.Drawing.Size(1235, 35);
            this.pnlLayer1ToCompare.TabIndex = 3;
            // 
            // cbbLayers
            // 
            this.cbbLayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbbLayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLayers.FormattingEnabled = true;
            this.cbbLayers.Location = new System.Drawing.Point(100, 0);
            this.cbbLayers.Name = "cbbLayers";
            this.cbbLayers.Size = new System.Drawing.Size(1135, 28);
            this.cbbLayers.TabIndex = 1;
            this.cbbLayers.SelectedIndexChanged += new System.EventHandler(this.cbbLayers_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Layer 1";
            // 
            // pnlAttributeToCompare
            // 
            this.pnlAttributeToCompare.Controls.Add(this.cbbProperties);
            this.pnlAttributeToCompare.Controls.Add(this.chkShowOnlyDiff);
            this.pnlAttributeToCompare.Controls.Add(this.lblProperty);
            this.pnlAttributeToCompare.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAttributeToCompare.Location = new System.Drawing.Point(0, 114);
            this.pnlAttributeToCompare.Name = "pnlAttributeToCompare";
            this.pnlAttributeToCompare.Size = new System.Drawing.Size(1235, 35);
            this.pnlAttributeToCompare.TabIndex = 4;
            // 
            // cbbProperties
            // 
            this.cbbProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbbProperties.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbProperties.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbProperties.FormattingEnabled = true;
            this.cbbProperties.Location = new System.Drawing.Point(100, 0);
            this.cbbProperties.Name = "cbbProperties";
            this.cbbProperties.Size = new System.Drawing.Size(963, 27);
            this.cbbProperties.TabIndex = 2;
            this.cbbProperties.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbbProperties_DrawItem);
            this.cbbProperties.SelectedIndexChanged += new System.EventHandler(this.cbbProperties_SelectedIndexChanged);
            // 
            // chkShowOnlyDiff
            // 
            this.chkShowOnlyDiff.AutoSize = true;
            this.chkShowOnlyDiff.Checked = true;
            this.chkShowOnlyDiff.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowOnlyDiff.Dock = System.Windows.Forms.DockStyle.Right;
            this.chkShowOnlyDiff.Location = new System.Drawing.Point(1063, 0);
            this.chkShowOnlyDiff.Name = "chkShowOnlyDiff";
            this.chkShowOnlyDiff.Size = new System.Drawing.Size(172, 35);
            this.chkShowOnlyDiff.TabIndex = 3;
            this.chkShowOnlyDiff.Text = "Show only changes";
            this.chkShowOnlyDiff.UseVisualStyleBackColor = true;
            this.chkShowOnlyDiff.CheckedChanged += new System.EventHandler(this.chkShowOnlyDiff_CheckedChanged);
            // 
            // lblProperty
            // 
            this.lblProperty.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblProperty.Location = new System.Drawing.Point(0, 0);
            this.lblProperty.Name = "lblProperty";
            this.lblProperty.Size = new System.Drawing.Size(100, 35);
            this.lblProperty.TabIndex = 1;
            this.lblProperty.Text = "Property";
            // 
            // diffControl
            // 
            this.diffControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.diffControl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.diffControl.LineDiffHeight = 95;
            this.diffControl.Location = new System.Drawing.Point(0, 184);
            this.diffControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.diffControl.Name = "diffControl";
            this.diffControl.OverviewWidth = 44;
            this.diffControl.ShowWhiteSpaceInLineDiff = true;
            this.diffControl.Size = new System.Drawing.Size(1235, 586);
            this.diffControl.TabIndex = 5;
            this.diffControl.ViewFont = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diffControl.Visible = false;
            // 
            // pnlLayer2ToCompare
            // 
            this.pnlLayer2ToCompare.Controls.Add(this.cbbLayers2);
            this.pnlLayer2ToCompare.Controls.Add(this.lblLayer2);
            this.pnlLayer2ToCompare.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLayer2ToCompare.Location = new System.Drawing.Point(0, 79);
            this.pnlLayer2ToCompare.Name = "pnlLayer2ToCompare";
            this.pnlLayer2ToCompare.Size = new System.Drawing.Size(1235, 35);
            this.pnlLayer2ToCompare.TabIndex = 6;
            // 
            // cbbLayers2
            // 
            this.cbbLayers2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbbLayers2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLayers2.FormattingEnabled = true;
            this.cbbLayers2.Location = new System.Drawing.Point(100, 0);
            this.cbbLayers2.Name = "cbbLayers2";
            this.cbbLayers2.Size = new System.Drawing.Size(1135, 28);
            this.cbbLayers2.TabIndex = 1;
            this.cbbLayers2.SelectedIndexChanged += new System.EventHandler(this.cbbLayers_SelectedIndexChanged);
            // 
            // lblLayer2
            // 
            this.lblLayer2.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblLayer2.Location = new System.Drawing.Point(0, 0);
            this.lblLayer2.Name = "lblLayer2";
            this.lblLayer2.Size = new System.Drawing.Size(100, 35);
            this.lblLayer2.TabIndex = 0;
            this.lblLayer2.Text = "Layer 2";
            // 
            // btnShowDiffFullScreen
            // 
            this.btnShowDiffFullScreen.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnShowDiffFullScreen.Location = new System.Drawing.Point(0, 149);
            this.btnShowDiffFullScreen.Name = "btnShowDiffFullScreen";
            this.btnShowDiffFullScreen.Size = new System.Drawing.Size(1235, 35);
            this.btnShowDiffFullScreen.TabIndex = 7;
            this.btnShowDiffFullScreen.Text = "Show differences on full screen";
            this.btnShowDiffFullScreen.UseVisualStyleBackColor = true;
            this.btnShowDiffFullScreen.Visible = false;
            this.btnShowDiffFullScreen.Click += new System.EventHandler(this.btnShowDiffFullScreen_Click);
            // 
            // GenericLayersComparerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.diffControl);
            this.Controls.Add(this.btnShowDiffFullScreen);
            this.Controls.Add(this.pnlAttributeToCompare);
            this.Controls.Add(this.pnlLayer2ToCompare);
            this.Controls.Add(this.pnlLayer1ToCompare);
            this.Controls.Add(this.pnlInfo);
            this.Name = "GenericLayersComparerControl";
            this.Size = new System.Drawing.Size(1235, 770);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.pnlLayer1ToCompare.ResumeLayout(false);
            this.pnlAttributeToCompare.ResumeLayout(false);
            this.pnlAttributeToCompare.PerformLayout();
            this.pnlLayer2ToCompare.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Panel pnlLayer1ToCompare;
        private System.Windows.Forms.ComboBox cbbLayers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlAttributeToCompare;
        private System.Windows.Forms.ComboBox cbbProperties;
        private System.Windows.Forms.Label lblProperty;
        private Menees.Diffs.Windows.Forms.DiffControl diffControl;
        private System.Windows.Forms.Panel pnlLayer2ToCompare;
        private System.Windows.Forms.ComboBox cbbLayers2;
        private System.Windows.Forms.Label lblLayer2;
        private System.Windows.Forms.CheckBox chkShowOnlyDiff;
        private System.Windows.Forms.Button btnShowDiffFullScreen;
    }
}
