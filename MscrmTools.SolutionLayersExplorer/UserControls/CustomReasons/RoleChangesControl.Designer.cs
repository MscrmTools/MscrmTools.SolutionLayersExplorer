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
            this.lvPrivs = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDepth = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvPrivs
            // 
            this.lvPrivs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chDepth});
            this.lvPrivs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPrivs.FullRowSelect = true;
            this.lvPrivs.HideSelection = false;
            this.lvPrivs.Location = new System.Drawing.Point(0, 0);
            this.lvPrivs.Name = "lvPrivs";
            this.lvPrivs.Size = new System.Drawing.Size(1056, 446);
            this.lvPrivs.TabIndex = 0;
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
            // RoleChangesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvPrivs);
            this.Name = "RoleChangesControl";
            this.Size = new System.Drawing.Size(880, 372);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvPrivs;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chDepth;
    }
}
