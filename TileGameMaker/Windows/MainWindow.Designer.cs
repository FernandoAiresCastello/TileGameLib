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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.MainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.MapPropertiesPanel = new System.Windows.Forms.Panel();
            this.TemplatePanel = new System.Windows.Forms.Panel();
            this.ColorPickerPanel = new System.Windows.Forms.Panel();
            this.TilePickerPanel = new System.Windows.Forms.Panel();
            this.MapEditorPanel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MiNewProject = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MiOpenProject = new System.Windows.Forms.ToolStripMenuItem();
            this.MainLayout.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainLayout
            // 
            this.MainLayout.ColumnCount = 3;
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.MainLayout.Controls.Add(this.MapPropertiesPanel, 2, 1);
            this.MainLayout.Controls.Add(this.TemplatePanel, 2, 0);
            this.MainLayout.Controls.Add(this.ColorPickerPanel, 0, 1);
            this.MainLayout.Controls.Add(this.TilePickerPanel, 0, 0);
            this.MainLayout.Controls.Add(this.MapEditorPanel, 1, 0);
            this.MainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayout.Location = new System.Drawing.Point(0, 24);
            this.MainLayout.Name = "MainLayout";
            this.MainLayout.RowCount = 2;
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainLayout.Size = new System.Drawing.Size(784, 426);
            this.MainLayout.TabIndex = 0;
            // 
            // MapPropertiesPanel
            // 
            this.MapPropertiesPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MapPropertiesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapPropertiesPanel.Location = new System.Drawing.Point(655, 216);
            this.MapPropertiesPanel.Name = "MapPropertiesPanel";
            this.MapPropertiesPanel.Size = new System.Drawing.Size(126, 207);
            this.MapPropertiesPanel.TabIndex = 4;
            // 
            // TemplatePanel
            // 
            this.TemplatePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TemplatePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TemplatePanel.Location = new System.Drawing.Point(655, 3);
            this.TemplatePanel.Name = "TemplatePanel";
            this.TemplatePanel.Size = new System.Drawing.Size(126, 207);
            this.TemplatePanel.TabIndex = 3;
            // 
            // ColorPickerPanel
            // 
            this.ColorPickerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColorPickerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ColorPickerPanel.Location = new System.Drawing.Point(3, 216);
            this.ColorPickerPanel.Name = "ColorPickerPanel";
            this.ColorPickerPanel.Size = new System.Drawing.Size(124, 207);
            this.ColorPickerPanel.TabIndex = 2;
            // 
            // TilePickerPanel
            // 
            this.TilePickerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TilePickerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TilePickerPanel.Location = new System.Drawing.Point(3, 3);
            this.TilePickerPanel.Name = "TilePickerPanel";
            this.TilePickerPanel.Size = new System.Drawing.Size(124, 207);
            this.TilePickerPanel.TabIndex = 1;
            // 
            // MapEditorPanel
            // 
            this.MapEditorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MapEditorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapEditorPanel.Location = new System.Drawing.Point(133, 3);
            this.MapEditorPanel.Name = "MapEditorPanel";
            this.MainLayout.SetRowSpan(this.MapEditorPanel, 2);
            this.MapEditorPanel.Size = new System.Drawing.Size(516, 420);
            this.MapEditorPanel.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiNewProject,
            this.MiOpenProject,
            this.toolStripSeparator1,
            this.MiExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // MiExit
            // 
            this.MiExit.Name = "MiExit";
            this.MiExit.Size = new System.Drawing.Size(180, 22);
            this.MiExit.Text = "Exit";
            this.MiExit.Click += new System.EventHandler(this.MiExit_Click);
            // 
            // MiNewProject
            // 
            this.MiNewProject.Name = "MiNewProject";
            this.MiNewProject.Size = new System.Drawing.Size(180, 22);
            this.MiNewProject.Text = "New Project";
            this.MiNewProject.Click += new System.EventHandler(this.MiNewProject_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // MiOpenProject
            // 
            this.MiOpenProject.Name = "MiOpenProject";
            this.MiOpenProject.Size = new System.Drawing.Size(180, 22);
            this.MiOpenProject.Text = "Open Project";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 450);
            this.Controls.Add(this.MainLayout);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tile Game Maker";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MainLayout.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainLayout;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel MapEditorPanel;
        private System.Windows.Forms.Panel ColorPickerPanel;
        private System.Windows.Forms.Panel MapPropertiesPanel;
        private System.Windows.Forms.Panel TemplatePanel;
        private System.Windows.Forms.Panel TilePickerPanel;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MiExit;
        private System.Windows.Forms.ToolStripMenuItem MiNewProject;
        private System.Windows.Forms.ToolStripMenuItem MiOpenProject;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}