namespace MscrmTools.SolutionLayersExplorer.UserControls.CustomReasons
{
    partial class SavedQueryControl
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
            this.btnCompareQuery = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCompare
            // 
            this.btnCompare.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCompare.Location = new System.Drawing.Point(10, 10);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(949, 68);
            this.btnCompare.TabIndex = 2;
            this.btnCompare.Text = "Compare Layout with another environment";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // btnCompareQuery
            // 
            this.btnCompareQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCompareQuery.Location = new System.Drawing.Point(10, 78);
            this.btnCompareQuery.Name = "btnCompareQuery";
            this.btnCompareQuery.Size = new System.Drawing.Size(949, 68);
            this.btnCompareQuery.TabIndex = 3;
            this.btnCompareQuery.Text = "Compare Query with another environment";
            this.btnCompareQuery.UseVisualStyleBackColor = true;
            this.btnCompareQuery.Click += new System.EventHandler(this.btnCompareQuery_Click);
            // 
            // SavedQueryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCompareQuery);
            this.Controls.Add(this.btnCompare);
            this.Name = "SavedQueryControl";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(969, 377);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Button btnCompareQuery;
    }
}
