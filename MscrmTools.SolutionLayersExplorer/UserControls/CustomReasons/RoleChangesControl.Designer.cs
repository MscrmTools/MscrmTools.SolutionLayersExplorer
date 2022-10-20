namespace MscrmTools.SolutionLayersExplorer.UserControls.CustomReasons
{
    partial class RoleChangesControl
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
            this.btnCompare = new System.Windows.Forms.Button();
            this.lvPrivs = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDepth = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlNoChange = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlNoChange.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCompare
            // 
            this.btnCompare.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCompare.Location = new System.Drawing.Point(0, 0);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(986, 61);
            this.btnCompare.TabIndex = 2;
            this.btnCompare.Text = "Compare with another environment";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // lvPrivs
            // 
            this.lvPrivs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chDepth});
            this.lvPrivs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPrivs.FullRowSelect = true;
            this.lvPrivs.HideSelection = false;
            this.lvPrivs.Location = new System.Drawing.Point(0, 61);
            this.lvPrivs.Name = "lvPrivs";
            this.lvPrivs.Size = new System.Drawing.Size(986, 251);
            this.lvPrivs.TabIndex = 3;
            this.lvPrivs.UseCompatibleStateImageBehavior = false;
            this.lvPrivs.View = System.Windows.Forms.View.Details;
            // 
            // chName
            // 
            this.chName.Text = "Privilege";
            this.chName.Width = 150;
            // 
            // chDepth
            // 
            this.chDepth.Text = "Depth";
            this.chDepth.Width = 100;
            // 
            // pnlNoChange
            // 
            this.pnlNoChange.Controls.Add(this.label1);
            this.pnlNoChange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNoChange.Location = new System.Drawing.Point(0, 61);
            this.pnlNoChange.Name = "pnlNoChange";
            this.pnlNoChange.Size = new System.Drawing.Size(986, 251);
            this.pnlNoChange.TabIndex = 4;
            this.pnlNoChange.Visible = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(986, 251);
            this.label1.TabIndex = 1;
            this.label1.Text = "No changes for privileges found";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RoleChangesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlNoChange);
            this.Controls.Add(this.lvPrivs);
            this.Controls.Add(this.btnCompare);
            this.Name = "RoleChangesControl";
            this.Size = new System.Drawing.Size(986, 312);
            this.pnlNoChange.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.ListView lvPrivs;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chDepth;
        private System.Windows.Forms.Panel pnlNoChange;
        private System.Windows.Forms.Label label1;
    }
}
