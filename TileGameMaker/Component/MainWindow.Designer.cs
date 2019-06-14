namespace TileGameMaker.Component
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
            this.MenuBar = new System.Windows.Forms.MenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowMapPropertiesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowPaletteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowTilesetMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowTemplateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuBar
            // 
            this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.viewToolStripMenuItem});
            this.MenuBar.Location = new System.Drawing.Point(0, 0);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Size = new System.Drawing.Size(747, 24);
            this.MenuBar.TabIndex = 1;
            this.MenuBar.Text = "MenuBar";
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitMenuItem});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(37, 20);
            this.FileMenu.Text = "File";
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.X)));
            this.ExitMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ExitMenuItem.Text = "Exit";
            this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // StatusBar
            // 
            this.StatusBar.Location = new System.Drawing.Point(0, 378);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(747, 22);
            this.StatusBar.TabIndex = 2;
            this.StatusBar.Text = "statusStrip1";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowMapPropertiesMenuItem,
            this.ShowPaletteMenuItem,
            this.ShowTilesetMenuItem,
            this.ShowTemplateMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // ShowMapPropertiesMenuItem
            // 
            this.ShowMapPropertiesMenuItem.Checked = true;
            this.ShowMapPropertiesMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShowMapPropertiesMenuItem.Name = "ShowMapPropertiesMenuItem";
            this.ShowMapPropertiesMenuItem.Size = new System.Drawing.Size(186, 22);
            this.ShowMapPropertiesMenuItem.Text = "Show Map Properties";
            this.ShowMapPropertiesMenuItem.Click += new System.EventHandler(this.ShowMapPropertiesMenuItem_Click);
            // 
            // ShowPaletteMenuItem
            // 
            this.ShowPaletteMenuItem.Checked = true;
            this.ShowPaletteMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShowPaletteMenuItem.Name = "ShowPaletteMenuItem";
            this.ShowPaletteMenuItem.Size = new System.Drawing.Size(186, 22);
            this.ShowPaletteMenuItem.Text = "Show Palette";
            this.ShowPaletteMenuItem.Click += new System.EventHandler(this.ShowPaletteMenuItem_Click);
            // 
            // ShowTilesetMenuItem
            // 
            this.ShowTilesetMenuItem.Checked = true;
            this.ShowTilesetMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShowTilesetMenuItem.Name = "ShowTilesetMenuItem";
            this.ShowTilesetMenuItem.Size = new System.Drawing.Size(186, 22);
            this.ShowTilesetMenuItem.Text = "Show Tileset";
            this.ShowTilesetMenuItem.Click += new System.EventHandler(this.ShowTilesetMenuItem_Click);
            // 
            // ShowTemplateMenuItem
            // 
            this.ShowTemplateMenuItem.Checked = true;
            this.ShowTemplateMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShowTemplateMenuItem.Name = "ShowTemplateMenuItem";
            this.ShowTemplateMenuItem.Size = new System.Drawing.Size(186, 22);
            this.ShowTemplateMenuItem.Text = "Show Template";
            this.ShowTemplateMenuItem.Click += new System.EventHandler(this.ShowTemplateMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 400);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.MenuBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MenuBar;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tile Game Maker";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuBar;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripMenuItem FileMenu;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowMapPropertiesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowPaletteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowTilesetMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowTemplateMenuItem;
    }
}