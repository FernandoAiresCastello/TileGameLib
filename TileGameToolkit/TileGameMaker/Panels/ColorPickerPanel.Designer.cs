namespace TileGameMaker.Panels
{
    partial class ColorPickerPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.LblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.LblHover = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripAndColorPicker = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.BtnImportRawBytes = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.BtnExportRawBytes = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnExportHexRgb = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnExportHexCsv = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnNew = new System.Windows.Forms.ToolStripButton();
            this.BtnRestoreDefault = new System.Windows.Forms.ToolStripDropDownButton();
            this.PnlColorPicker = new System.Windows.Forms.Panel();
            this.ForeBackColorPanels = new System.Windows.Forms.Panel();
            this.BackColorPanel = new System.Windows.Forms.Panel();
            this.ForeColorPanel = new System.Windows.Forms.Panel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToFileAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tableLayoutPanel1.SuspendLayout();
            this.StatusBar.SuspendLayout();
            this.ToolStripAndColorPicker.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.ForeBackColorPanels.SuspendLayout();
            this.BackColorPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.StatusBar, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ToolStripAndColorPicker, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ForeBackColorPanels, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(219, 347);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // StatusBar
            // 
            this.StatusBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LblStatus,
            this.LblHover});
            this.StatusBar.Location = new System.Drawing.Point(0, 323);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(219, 24);
            this.StatusBar.SizingGrip = false;
            this.StatusBar.TabIndex = 3;
            this.StatusBar.Text = "statusStrip1";
            // 
            // LblStatus
            // 
            this.LblStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.LblStatus.Name = "LblStatus";
            this.LblStatus.Size = new System.Drawing.Size(59, 19);
            this.LblStatus.Text = "LblStatus";
            // 
            // LblHover
            // 
            this.LblHover.Name = "LblHover";
            this.LblHover.Size = new System.Drawing.Size(55, 19);
            this.LblHover.Text = "LblHover";
            // 
            // ToolStripAndColorPicker
            // 
            this.ToolStripAndColorPicker.ColumnCount = 1;
            this.ToolStripAndColorPicker.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ToolStripAndColorPicker.Controls.Add(this.toolStrip1, 0, 0);
            this.ToolStripAndColorPicker.Controls.Add(this.PnlColorPicker, 0, 1);
            this.ToolStripAndColorPicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolStripAndColorPicker.Location = new System.Drawing.Point(0, 0);
            this.ToolStripAndColorPicker.Margin = new System.Windows.Forms.Padding(0);
            this.ToolStripAndColorPicker.Name = "ToolStripAndColorPicker";
            this.ToolStripAndColorPicker.RowCount = 2;
            this.ToolStripAndColorPicker.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ToolStripAndColorPicker.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ToolStripAndColorPicker.Size = new System.Drawing.Size(219, 243);
            this.ToolStripAndColorPicker.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton2,
            this.toolStripSplitButton1,
            this.toolStripSeparator1,
            this.BtnNew,
            this.BtnRestoreDefault});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(8, 5, 0, 2);
            this.toolStrip1.Size = new System.Drawing.Size(219, 30);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSplitButton2
            // 
            this.toolStripSplitButton2.AutoToolTip = false;
            this.toolStripSplitButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripSeparator2,
            this.BtnImportRawBytes});
            this.toolStripSplitButton2.Image = global::TileGameMaker.Properties.Resources.folder;
            this.toolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton2.Name = "toolStripSplitButton2";
            this.toolStripSplitButton2.Size = new System.Drawing.Size(29, 20);
            this.toolStripSplitButton2.Text = "toolStripSplitButton1";
            // 
            // BtnImportRawBytes
            // 
            this.BtnImportRawBytes.Name = "BtnImportRawBytes";
            this.BtnImportRawBytes.Size = new System.Drawing.Size(180, 22);
            this.BtnImportRawBytes.Text = "Bytes";
            this.BtnImportRawBytes.Click += new System.EventHandler(this.BtnImportRawBytes_Click);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.AutoToolTip = false;
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToFileAsToolStripMenuItem,
            this.toolStripSeparator3,
            this.BtnExportRawBytes,
            this.BtnExportHexRgb,
            this.BtnExportHexCsv});
            this.toolStripSplitButton1.Image = global::TileGameMaker.Properties.Resources.diskette;
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(29, 20);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // BtnExportRawBytes
            // 
            this.BtnExportRawBytes.Name = "BtnExportRawBytes";
            this.BtnExportRawBytes.Size = new System.Drawing.Size(180, 22);
            this.BtnExportRawBytes.Text = "Bytes";
            this.BtnExportRawBytes.Click += new System.EventHandler(this.BtnExportRawBytes_Click);
            // 
            // BtnExportHexRgb
            // 
            this.BtnExportHexRgb.Name = "BtnExportHexRgb";
            this.BtnExportHexRgb.Size = new System.Drawing.Size(167, 22);
            this.BtnExportHexRgb.Text = "Hexadecimal RGB";
            this.BtnExportHexRgb.Click += new System.EventHandler(this.BtnExportHexRgb_Click);
            // 
            // BtnExportHexCsv
            // 
            this.BtnExportHexCsv.Name = "BtnExportHexCsv";
            this.BtnExportHexCsv.Size = new System.Drawing.Size(167, 22);
            this.BtnExportHexCsv.Text = "Hexadecimal CSV";
            this.BtnExportHexCsv.Click += new System.EventHandler(this.BtnExportHexCsv_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // BtnNew
            // 
            this.BtnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnNew.Image = global::TileGameMaker.Properties.Resources.broom;
            this.BtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(23, 20);
            this.BtnNew.Text = "toolStripButton1";
            this.BtnNew.ToolTipText = "Clear palette";
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // BtnRestoreDefault
            // 
            this.BtnRestoreDefault.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnRestoreDefault.Image = global::TileGameMaker.Properties.Resources.site_backup_and_restore;
            this.BtnRestoreDefault.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnRestoreDefault.Name = "BtnRestoreDefault";
            this.BtnRestoreDefault.Size = new System.Drawing.Size(29, 20);
            // 
            // PnlColorPicker
            // 
            this.PnlColorPicker.AutoScroll = true;
            this.PnlColorPicker.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PnlColorPicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlColorPicker.Location = new System.Drawing.Point(3, 33);
            this.PnlColorPicker.Name = "PnlColorPicker";
            this.PnlColorPicker.Size = new System.Drawing.Size(213, 207);
            this.PnlColorPicker.TabIndex = 1;
            this.PnlColorPicker.MouseLeave += new System.EventHandler(this.ColorPicker_MouseLeave);
            // 
            // ForeBackColorPanels
            // 
            this.ForeBackColorPanels.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ForeBackColorPanels.Controls.Add(this.BackColorPanel);
            this.ForeBackColorPanels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ForeBackColorPanels.Location = new System.Drawing.Point(3, 246);
            this.ForeBackColorPanels.Name = "ForeBackColorPanels";
            this.ForeBackColorPanels.Size = new System.Drawing.Size(213, 74);
            this.ForeBackColorPanels.TabIndex = 1;
            // 
            // BackColorPanel
            // 
            this.BackColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BackColorPanel.Controls.Add(this.ForeColorPanel);
            this.BackColorPanel.Location = new System.Drawing.Point(70, 6);
            this.BackColorPanel.Name = "BackColorPanel";
            this.BackColorPanel.Size = new System.Drawing.Size(74, 59);
            this.BackColorPanel.TabIndex = 4;
            // 
            // ForeColorPanel
            // 
            this.ForeColorPanel.Location = new System.Drawing.Point(16, 15);
            this.ForeColorPanel.Name = "ForeColorPanel";
            this.ForeColorPanel.Size = new System.Drawing.Size(41, 28);
            this.ForeColorPanel.TabIndex = 5;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Enabled = false;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "Import from file as:";
            // 
            // exportToFileAsToolStripMenuItem
            // 
            this.exportToFileAsToolStripMenuItem.Enabled = false;
            this.exportToFileAsToolStripMenuItem.Name = "exportToFileAsToolStripMenuItem";
            this.exportToFileAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportToFileAsToolStripMenuItem.Text = "Export to file as:";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
            // 
            // ColorPickerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ColorPickerPanel";
            this.Size = new System.Drawing.Size(219, 347);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.ToolStripAndColorPicker.ResumeLayout(false);
            this.ToolStripAndColorPicker.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ForeBackColorPanels.ResumeLayout(false);
            this.BackColorPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripStatusLabel LblStatus;
        private System.Windows.Forms.ToolStripStatusLabel LblHover;
        private System.Windows.Forms.TableLayoutPanel ToolStripAndColorPicker;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BtnNew;
        private System.Windows.Forms.Panel PnlColorPicker;
        private System.Windows.Forms.Panel ForeBackColorPanels;
        private System.Windows.Forms.Panel BackColorPanel;
        private System.Windows.Forms.Panel ForeColorPanel;
        private System.Windows.Forms.ToolStripDropDownButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem BtnExportRawBytes;
        private System.Windows.Forms.ToolStripMenuItem BtnExportHexRgb;
        private System.Windows.Forms.ToolStripDropDownButton toolStripSplitButton2;
        private System.Windows.Forms.ToolStripMenuItem BtnImportRawBytes;
        private System.Windows.Forms.ToolStripMenuItem BtnExportHexCsv;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton BtnRestoreDefault;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exportToFileAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}
