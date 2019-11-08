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
            this.BtnNew = new System.Windows.Forms.ToolStripButton();
            this.BtnExport = new System.Windows.Forms.ToolStripButton();
            this.BtnImport = new System.Windows.Forms.ToolStripButton();
            this.BtnReset = new System.Windows.Forms.ToolStripButton();
            this.PnlColorPicker = new System.Windows.Forms.Panel();
            this.ForeBackColorPanels = new System.Windows.Forms.Panel();
            this.BackColorPanel = new System.Windows.Forms.Panel();
            this.ForeColorPanel = new System.Windows.Forms.Panel();
            this.TxtColorsPerRow = new System.Windows.Forms.ToolStripTextBox();
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
            this.BtnNew,
            this.BtnExport,
            this.BtnImport,
            this.BtnReset,
            this.TxtColorsPerRow});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(8, 5, 0, 2);
            this.toolStrip1.Size = new System.Drawing.Size(219, 30);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BtnNew
            // 
            this.BtnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnNew.Image = global::TileGameMaker.Properties.Resources.page_white;
            this.BtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(23, 20);
            this.BtnNew.Text = "toolStripButton1";
            this.BtnNew.ToolTipText = "Clear palette";
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // BtnExport
            // 
            this.BtnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnExport.Image = global::TileGameMaker.Properties.Resources.diskette;
            this.BtnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(23, 20);
            this.BtnExport.Text = "toolStripButton1";
            this.BtnExport.ToolTipText = "Export palette";
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // BtnImport
            // 
            this.BtnImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnImport.Image = global::TileGameMaker.Properties.Resources.folder;
            this.BtnImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnImport.Name = "BtnImport";
            this.BtnImport.Size = new System.Drawing.Size(23, 20);
            this.BtnImport.Text = "toolStripButton1";
            this.BtnImport.ToolTipText = "Import palette";
            this.BtnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // BtnReset
            // 
            this.BtnReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnReset.Image = global::TileGameMaker.Properties.Resources.undo;
            this.BtnReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(23, 20);
            this.BtnReset.Text = "toolStripButton1";
            this.BtnReset.ToolTipText = "Reset palette to default";
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
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
            // TxtColorsPerRow
            // 
            this.TxtColorsPerRow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtColorsPerRow.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtColorsPerRow.MaxLength = 2;
            this.TxtColorsPerRow.Name = "TxtColorsPerRow";
            this.TxtColorsPerRow.Size = new System.Drawing.Size(50, 23);
            this.TxtColorsPerRow.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtColorsPerRow.ToolTipText = "Colors per row to display";
            this.TxtColorsPerRow.Leave += new System.EventHandler(this.TxtColorsPerRow_Leave);
            this.TxtColorsPerRow.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtColorsPerRow_KeyUp);
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
        private System.Windows.Forms.ToolStripButton BtnReset;
        private System.Windows.Forms.ToolStripButton BtnExport;
        private System.Windows.Forms.ToolStripButton BtnImport;
        private System.Windows.Forms.ToolStripTextBox TxtColorsPerRow;
    }
}
