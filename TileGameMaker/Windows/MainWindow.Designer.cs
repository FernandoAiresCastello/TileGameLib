namespace TileGameMaker.Windows
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnSaveProject = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnCloseProject = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnTemplateObjects = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnDataExtractor = new System.Windows.Forms.ToolStripMenuItem();
            this.WindowLayout = new System.Windows.Forms.TableLayoutPanel();
            this.MainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.RightPanel = new System.Windows.Forms.Panel();
            this.ProjectAndMapPropertiesPanel = new System.Windows.Forms.TableLayoutPanel();
            this.MapPropertiesPanel = new System.Windows.Forms.Panel();
            this.ProjectPanel = new System.Windows.Forms.Panel();
            this.TopRightPanel = new System.Windows.Forms.Panel();
            this.ColorPickerPanel = new System.Windows.Forms.Panel();
            this.TilePickerPanel = new System.Windows.Forms.Panel();
            this.MapAndCommandLineSplitContainer = new System.Windows.Forms.SplitContainer();
            this.CentralSplitContainer = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SidePanel = new System.Windows.Forms.Panel();
            this.MapEditorPanel = new System.Windows.Forms.Panel();
            this.CommandLinePanel = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1.SuspendLayout();
            this.WindowLayout.SuspendLayout();
            this.MainLayout.SuspendLayout();
            this.RightPanel.SuspendLayout();
            this.ProjectAndMapPropertiesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapAndCommandLineSplitContainer)).BeginInit();
            this.MapAndCommandLineSplitContainer.Panel1.SuspendLayout();
            this.MapAndCommandLineSplitContainer.Panel2.SuspendLayout();
            this.MapAndCommandLineSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CentralSplitContainer)).BeginInit();
            this.CentralSplitContainer.Panel1.SuspendLayout();
            this.CentralSplitContainer.Panel2.SuspendLayout();
            this.CentralSplitContainer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnSaveProject,
            this.BtnCloseProject,
            this.toolStripSeparator2,
            this.BtnTemplateObjects,
            this.toolStripSeparator1,
            this.MiExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.fileToolStripMenuItem.Text = "Project";
            // 
            // BtnSaveProject
            // 
            this.BtnSaveProject.Image = global::TileGameMaker.Properties.Resources.diskette;
            this.BtnSaveProject.Name = "BtnSaveProject";
            this.BtnSaveProject.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.BtnSaveProject.Size = new System.Drawing.Size(184, 22);
            this.BtnSaveProject.Text = "Save";
            this.BtnSaveProject.Click += new System.EventHandler(this.BtnSaveProject_Click);
            // 
            // BtnCloseProject
            // 
            this.BtnCloseProject.Image = global::TileGameMaker.Properties.Resources.folder_vertical_zipper;
            this.BtnCloseProject.Name = "BtnCloseProject";
            this.BtnCloseProject.Size = new System.Drawing.Size(184, 22);
            this.BtnCloseProject.Text = "Close";
            this.BtnCloseProject.Click += new System.EventHandler(this.BtnCloseProject_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(181, 6);
            // 
            // BtnTemplateObjects
            // 
            this.BtnTemplateObjects.Image = global::TileGameMaker.Properties.Resources.bricks;
            this.BtnTemplateObjects.Name = "BtnTemplateObjects";
            this.BtnTemplateObjects.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.BtnTemplateObjects.Size = new System.Drawing.Size(184, 22);
            this.BtnTemplateObjects.Text = "Template objects";
            this.BtnTemplateObjects.Click += new System.EventHandler(this.BtnTemplateObjects_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // MiExit
            // 
            this.MiExit.Image = global::TileGameMaker.Properties.Resources.cross;
            this.MiExit.Name = "MiExit";
            this.MiExit.Size = new System.Drawing.Size(184, 22);
            this.MiExit.Text = "Quit";
            this.MiExit.Click += new System.EventHandler(this.MiExit_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnDataExtractor});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // BtnDataExtractor
            // 
            this.BtnDataExtractor.Image = global::TileGameMaker.Properties.Resources.database_lightning;
            this.BtnDataExtractor.Name = "BtnDataExtractor";
            this.BtnDataExtractor.Size = new System.Drawing.Size(147, 22);
            this.BtnDataExtractor.Text = "Data extractor";
            this.BtnDataExtractor.Click += new System.EventHandler(this.BtnDataExtractor_Click);
            // 
            // WindowLayout
            // 
            this.WindowLayout.ColumnCount = 1;
            this.WindowLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.WindowLayout.Controls.Add(this.MainLayout, 0, 0);
            this.WindowLayout.Controls.Add(this.statusStrip1, 0, 1);
            this.WindowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WindowLayout.Location = new System.Drawing.Point(0, 24);
            this.WindowLayout.Margin = new System.Windows.Forms.Padding(0);
            this.WindowLayout.Name = "WindowLayout";
            this.WindowLayout.RowCount = 2;
            this.WindowLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.WindowLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.WindowLayout.Size = new System.Drawing.Size(784, 426);
            this.WindowLayout.TabIndex = 2;
            // 
            // MainLayout
            // 
            this.MainLayout.ColumnCount = 3;
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.MainLayout.Controls.Add(this.RightPanel, 2, 0);
            this.MainLayout.Controls.Add(this.TopRightPanel, 2, 1);
            this.MainLayout.Controls.Add(this.ColorPickerPanel, 0, 1);
            this.MainLayout.Controls.Add(this.TilePickerPanel, 0, 0);
            this.MainLayout.Controls.Add(this.MapAndCommandLineSplitContainer, 1, 0);
            this.MainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayout.Location = new System.Drawing.Point(0, 0);
            this.MainLayout.Margin = new System.Windows.Forms.Padding(0);
            this.MainLayout.Name = "MainLayout";
            this.MainLayout.RowCount = 2;
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 344F));
            this.MainLayout.Size = new System.Drawing.Size(784, 404);
            this.MainLayout.TabIndex = 1;
            // 
            // RightPanel
            // 
            this.RightPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RightPanel.Controls.Add(this.ProjectAndMapPropertiesPanel);
            this.RightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightPanel.Location = new System.Drawing.Point(655, 3);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.Size = new System.Drawing.Size(126, 54);
            this.RightPanel.TabIndex = 4;
            // 
            // ProjectAndMapPropertiesPanel
            // 
            this.ProjectAndMapPropertiesPanel.ColumnCount = 1;
            this.ProjectAndMapPropertiesPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ProjectAndMapPropertiesPanel.Controls.Add(this.MapPropertiesPanel, 0, 1);
            this.ProjectAndMapPropertiesPanel.Controls.Add(this.ProjectPanel, 0, 0);
            this.ProjectAndMapPropertiesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectAndMapPropertiesPanel.Location = new System.Drawing.Point(0, 0);
            this.ProjectAndMapPropertiesPanel.Name = "ProjectAndMapPropertiesPanel";
            this.ProjectAndMapPropertiesPanel.RowCount = 2;
            this.ProjectAndMapPropertiesPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ProjectAndMapPropertiesPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ProjectAndMapPropertiesPanel.Size = new System.Drawing.Size(124, 52);
            this.ProjectAndMapPropertiesPanel.TabIndex = 0;
            // 
            // MapPropertiesPanel
            // 
            this.MapPropertiesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapPropertiesPanel.Location = new System.Drawing.Point(3, -113);
            this.MapPropertiesPanel.Name = "MapPropertiesPanel";
            this.MapPropertiesPanel.Size = new System.Drawing.Size(118, 162);
            this.MapPropertiesPanel.TabIndex = 1;
            // 
            // ProjectPanel
            // 
            this.ProjectPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectPanel.Location = new System.Drawing.Point(3, 3);
            this.ProjectPanel.Name = "ProjectPanel";
            this.ProjectPanel.Size = new System.Drawing.Size(118, 1);
            this.ProjectPanel.TabIndex = 0;
            // 
            // TopRightPanel
            // 
            this.TopRightPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TopRightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TopRightPanel.Location = new System.Drawing.Point(655, 63);
            this.TopRightPanel.Name = "TopRightPanel";
            this.TopRightPanel.Size = new System.Drawing.Size(126, 338);
            this.TopRightPanel.TabIndex = 3;
            // 
            // ColorPickerPanel
            // 
            this.ColorPickerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColorPickerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ColorPickerPanel.Location = new System.Drawing.Point(3, 63);
            this.ColorPickerPanel.Name = "ColorPickerPanel";
            this.ColorPickerPanel.Size = new System.Drawing.Size(124, 338);
            this.ColorPickerPanel.TabIndex = 2;
            // 
            // TilePickerPanel
            // 
            this.TilePickerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TilePickerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TilePickerPanel.Location = new System.Drawing.Point(3, 3);
            this.TilePickerPanel.Name = "TilePickerPanel";
            this.TilePickerPanel.Size = new System.Drawing.Size(124, 54);
            this.TilePickerPanel.TabIndex = 1;
            // 
            // MapAndCommandLineSplitContainer
            // 
            this.MapAndCommandLineSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapAndCommandLineSplitContainer.Location = new System.Drawing.Point(133, 3);
            this.MapAndCommandLineSplitContainer.Name = "MapAndCommandLineSplitContainer";
            this.MapAndCommandLineSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MapAndCommandLineSplitContainer.Panel1
            // 
            this.MapAndCommandLineSplitContainer.Panel1.Controls.Add(this.CentralSplitContainer);
            // 
            // MapAndCommandLineSplitContainer.Panel2
            // 
            this.MapAndCommandLineSplitContainer.Panel2.Controls.Add(this.CommandLinePanel);
            this.MapAndCommandLineSplitContainer.Panel2Collapsed = true;
            this.MainLayout.SetRowSpan(this.MapAndCommandLineSplitContainer, 2);
            this.MapAndCommandLineSplitContainer.Size = new System.Drawing.Size(516, 398);
            this.MapAndCommandLineSplitContainer.SplitterDistance = 323;
            this.MapAndCommandLineSplitContainer.TabIndex = 5;
            // 
            // CentralSplitContainer
            // 
            this.CentralSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CentralSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.CentralSplitContainer.Name = "CentralSplitContainer";
            // 
            // CentralSplitContainer.Panel1
            // 
            this.CentralSplitContainer.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // CentralSplitContainer.Panel2
            // 
            this.CentralSplitContainer.Panel2.Controls.Add(this.MapEditorPanel);
            this.CentralSplitContainer.Size = new System.Drawing.Size(516, 398);
            this.CentralSplitContainer.SplitterDistance = 63;
            this.CentralSplitContainer.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.SidePanel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 398F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(63, 398);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // SidePanel
            // 
            this.SidePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SidePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SidePanel.Location = new System.Drawing.Point(0, 0);
            this.SidePanel.Margin = new System.Windows.Forms.Padding(0);
            this.SidePanel.Name = "SidePanel";
            this.SidePanel.Size = new System.Drawing.Size(63, 398);
            this.SidePanel.TabIndex = 4;
            // 
            // MapEditorPanel
            // 
            this.MapEditorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MapEditorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapEditorPanel.Location = new System.Drawing.Point(0, 0);
            this.MapEditorPanel.Name = "MapEditorPanel";
            this.MapEditorPanel.Size = new System.Drawing.Size(449, 398);
            this.MapEditorPanel.TabIndex = 2;
            // 
            // CommandLinePanel
            // 
            this.CommandLinePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CommandLinePanel.Location = new System.Drawing.Point(0, 0);
            this.CommandLinePanel.Name = "CommandLinePanel";
            this.CommandLinePanel.Size = new System.Drawing.Size(150, 46);
            this.CommandLinePanel.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 404);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 450);
            this.Controls.Add(this.WindowLayout);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.WindowLayout.ResumeLayout(false);
            this.WindowLayout.PerformLayout();
            this.MainLayout.ResumeLayout(false);
            this.RightPanel.ResumeLayout(false);
            this.ProjectAndMapPropertiesPanel.ResumeLayout(false);
            this.MapAndCommandLineSplitContainer.Panel1.ResumeLayout(false);
            this.MapAndCommandLineSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MapAndCommandLineSplitContainer)).EndInit();
            this.MapAndCommandLineSplitContainer.ResumeLayout(false);
            this.CentralSplitContainer.Panel1.ResumeLayout(false);
            this.CentralSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CentralSplitContainer)).EndInit();
            this.CentralSplitContainer.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MiExit;
        private System.Windows.Forms.TableLayoutPanel WindowLayout;
        private System.Windows.Forms.TableLayoutPanel MainLayout;
        private System.Windows.Forms.Panel TopRightPanel;
        private System.Windows.Forms.Panel ColorPickerPanel;
        private System.Windows.Forms.Panel TilePickerPanel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer MapAndCommandLineSplitContainer;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.Panel CommandLinePanel;
        private System.Windows.Forms.ToolStripMenuItem BtnDataExtractor;
        private System.Windows.Forms.SplitContainer CentralSplitContainer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel MapEditorPanel;
        private System.Windows.Forms.Panel SidePanel;
        private System.Windows.Forms.Panel RightPanel;
        private System.Windows.Forms.TableLayoutPanel ProjectAndMapPropertiesPanel;
        private System.Windows.Forms.Panel MapPropertiesPanel;
        private System.Windows.Forms.Panel ProjectPanel;
        private System.Windows.Forms.ToolStripMenuItem BtnSaveProject;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem BtnCloseProject;
        private System.Windows.Forms.ToolStripMenuItem BtnTemplateObjects;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}