
using System;

namespace MscrmTools.SolutionLayersExplorer
{
    partial class MyPluginControl
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
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbLoadSolutions = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.solutionPicker1 = new MscrmTools.SolutionLayersExplorer.UserControls.SolutionPicker();
            this.scType = new System.Windows.Forms.SplitContainer();
            this.componentsPicker1 = new MscrmTools.SolutionLayersExplorer.UserControls.ComponentsPicker();
            this.scItems = new System.Windows.Forms.SplitContainer();
            this.lvItems = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbRemoveActiveLayer = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.sChanges = new ScintillaNET.Scintilla();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.sAllProperties = new ScintillaNET.Scintilla();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.sChildren = new ScintillaNET.Scintilla();
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scType)).BeginInit();
            this.scType.Panel1.SuspendLayout();
            this.scType.Panel2.SuspendLayout();
            this.scType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scItems)).BeginInit();
            this.scItems.Panel1.SuspendLayout();
            this.scItems.Panel2.SuspendLayout();
            this.scItems.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbLoadSolutions,
            this.toolStripSeparator1,
            this.tsbCancel});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(1569, 34);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "tsMain";
            this.toolStripMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripMenu_ItemClicked);
            // 
            // tsbLoadSolutions
            // 
            this.tsbLoadSolutions.Image = global::MscrmTools.SolutionLayersExplorer.Properties.Resources.Dataverse_16x16;
            this.tsbLoadSolutions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLoadSolutions.Name = "tsbLoadSolutions";
            this.tsbLoadSolutions.Size = new System.Drawing.Size(148, 29);
            this.tsbLoadSolutions.Text = "Load solutions";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 34);
            // 
            // tsbCancel
            // 
            this.tsbCancel.Enabled = false;
            this.tsbCancel.Image = global::MscrmTools.SolutionLayersExplorer.Properties.Resources.icons8_cancel;
            this.tsbCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancel.Name = "tsbCancel";
            this.tsbCancel.Size = new System.Drawing.Size(83, 29);
            this.tsbCancel.Text = "Cancel";
            this.tsbCancel.Click += new System.EventHandler(this.tsbCancel_Click);
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scMain.Location = new System.Drawing.Point(0, 34);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.solutionPicker1);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.scType);
            this.scMain.Size = new System.Drawing.Size(1569, 1034);
            this.scMain.SplitterDistance = 301;
            this.scMain.TabIndex = 5;
            // 
            // solutionPicker1
            // 
            this.solutionPicker1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.solutionPicker1.Location = new System.Drawing.Point(0, 0);
            this.solutionPicker1.Name = "solutionPicker1";
            this.solutionPicker1.Service = null;
            this.solutionPicker1.Size = new System.Drawing.Size(301, 1034);
            this.solutionPicker1.TabIndex = 0;
            this.solutionPicker1.OnSelected += new System.EventHandler(this.solutionPicker1_OnSelected);
            // 
            // scType
            // 
            this.scType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scType.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scType.Location = new System.Drawing.Point(0, 0);
            this.scType.Name = "scType";
            // 
            // scType.Panel1
            // 
            this.scType.Panel1.Controls.Add(this.componentsPicker1);
            // 
            // scType.Panel2
            // 
            this.scType.Panel2.Controls.Add(this.scItems);
            this.scType.Size = new System.Drawing.Size(1264, 1034);
            this.scType.SplitterDistance = 275;
            this.scType.TabIndex = 0;
            // 
            // componentsPicker1
            // 
            this.componentsPicker1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.componentsPicker1.Location = new System.Drawing.Point(0, 0);
            this.componentsPicker1.Name = "componentsPicker1";
            this.componentsPicker1.Service = null;
            this.componentsPicker1.Size = new System.Drawing.Size(275, 1034);
            this.componentsPicker1.TabIndex = 0;
            this.componentsPicker1.OnActiveLayerRemovalRequested += new System.EventHandler(this.ComponentsPicker1_OnActiveLayerRemovalRequested);
            this.componentsPicker1.OnActiveLayerRequested += new System.EventHandler(this.ComponentsPicker1_OnActiveLayerRequested);
            this.componentsPicker1.OnSelected += new System.EventHandler(this.ComponentsPicker1_OnSelected);
            // 
            // scItems
            // 
            this.scItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scItems.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scItems.Location = new System.Drawing.Point(0, 0);
            this.scItems.Name = "scItems";
            // 
            // scItems.Panel1
            // 
            this.scItems.Panel1.Controls.Add(this.lvItems);
            this.scItems.Panel1.Controls.Add(this.toolStrip1);
            // 
            // scItems.Panel2
            // 
            this.scItems.Panel2.Controls.Add(this.tabControl1);
            this.scItems.Size = new System.Drawing.Size(985, 1034);
            this.scItems.SplitterDistance = 300;
            this.scItems.TabIndex = 0;
            // 
            // lvItems
            // 
            this.lvItems.CheckBoxes = true;
            this.lvItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName});
            this.lvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvItems.FullRowSelect = true;
            this.lvItems.HideSelection = false;
            this.lvItems.Location = new System.Drawing.Point(0, 55);
            this.lvItems.Name = "lvItems";
            this.lvItems.Size = new System.Drawing.Size(360, 1186);
            this.lvItems.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvItems.TabIndex = 2;
            this.lvItems.UseCompatibleStateImageBehavior = false;
            this.lvItems.View = System.Windows.Forms.View.Details;
            this.lvItems.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvItems_ColumnClick);
            this.lvItems.SelectedIndexChanged += new System.EventHandler(this.lvItems_SelectedIndexChanged);
            // 
            // chName
            // 
            this.chName.Text = "Name";
            this.chName.Width = 200;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbRemoveActiveLayer});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(360, 46);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "tsItems";
            // 
            // tsbRemoveActiveLayer
            // 
            this.tsbRemoveActiveLayer.Image = global::MscrmTools.SolutionLayersExplorer.Properties.Resources.layers__1_;
            this.tsbRemoveActiveLayer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRemoveActiveLayer.Name = "tsbRemoveActiveLayer";
            this.tsbRemoveActiveLayer.Size = new System.Drawing.Size(209, 41);
            this.tsbRemoveActiveLayer.Text = "Remove Active layer(s)";
            this.tsbRemoveActiveLayer.Click += new System.EventHandler(this.tsbRemoveActiveLayer_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(681, 1034);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.sChanges);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(673, 1001);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Changes";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // sChanges
            // 
            this.sChanges.AutomaticFold = ((ScintillaNET.AutomaticFold)(((ScintillaNET.AutomaticFold.Show | ScintillaNET.AutomaticFold.Click) 
            | ScintillaNET.AutomaticFold.Change)));
            this.sChanges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sChanges.IndentationGuides = ScintillaNET.IndentView.Real;
            this.sChanges.Lexer = ScintillaNET.Lexer.Json;
            this.sChanges.Location = new System.Drawing.Point(3, 3);
            this.sChanges.Name = "sChanges";
            this.sChanges.Size = new System.Drawing.Size(667, 995);
            this.sChanges.TabIndex = 2;
            this.sChanges.TextChanged += new System.EventHandler(this.scintilla1_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.sAllProperties);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(673, 1001);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "All Properties";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // sAllProperties
            // 
            this.sAllProperties.AutomaticFold = ((ScintillaNET.AutomaticFold)(((ScintillaNET.AutomaticFold.Show | ScintillaNET.AutomaticFold.Click) 
            | ScintillaNET.AutomaticFold.Change)));
            this.sAllProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sAllProperties.IndentationGuides = ScintillaNET.IndentView.Real;
            this.sAllProperties.Lexer = ScintillaNET.Lexer.Json;
            this.sAllProperties.Location = new System.Drawing.Point(3, 3);
            this.sAllProperties.Name = "sAllProperties";
            this.sAllProperties.Size = new System.Drawing.Size(667, 995);
            this.sAllProperties.TabIndex = 3;
            this.sAllProperties.TextChanged += new System.EventHandler(this.scintilla1_TextChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.sChildren);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(673, 1001);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Children";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // sChildren
            // 
            this.sChildren.AutomaticFold = ((ScintillaNET.AutomaticFold)(((ScintillaNET.AutomaticFold.Show | ScintillaNET.AutomaticFold.Click) 
            | ScintillaNET.AutomaticFold.Change)));
            this.sChildren.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sChildren.IndentationGuides = ScintillaNET.IndentView.Real;
            this.sChildren.Lexer = ScintillaNET.Lexer.Json;
            this.sChildren.Location = new System.Drawing.Point(3, 3);
            this.sChildren.Name = "sChildren";
            this.sChildren.Size = new System.Drawing.Size(667, 995);
            this.sChildren.TabIndex = 3;
            this.sChildren.TextChanged += new System.EventHandler(this.scintilla1_TextChanged);
            // 
            // MyPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.toolStripMenu);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MyPluginControl";
            this.Size = new System.Drawing.Size(1569, 1068);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.scType.Panel1.ResumeLayout(false);
            this.scType.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scType)).EndInit();
            this.scType.ResumeLayout(false);
            this.scItems.Panel1.ResumeLayout(false);
            this.scItems.Panel1.PerformLayout();
            this.scItems.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scItems)).EndInit();
            this.scItems.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       






        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.SplitContainer scMain;
        private UserControls.SolutionPicker solutionPicker1;
        private System.Windows.Forms.ToolStripButton tsbLoadSolutions;
        private System.Windows.Forms.SplitContainer scType;
        private UserControls.ComponentsPicker componentsPicker1;
        private System.Windows.Forms.SplitContainer scItems;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView lvItems;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbRemoveActiveLayer;
        private ScintillaNET.Scintilla sChanges;
        private ScintillaNET.Scintilla sAllProperties;
        private ScintillaNET.Scintilla sChildren;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbCancel;
    }
}
