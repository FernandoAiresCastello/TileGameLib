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
            this.PnlColorPicker = new System.Windows.Forms.Panel();
            this.ForeBackColorPanels = new System.Windows.Forms.Panel();
            this.BackColorPanel = new System.Windows.Forms.Panel();
            this.ForeColorPanel = new System.Windows.Forms.Panel();
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
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnNew});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(219, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BtnNew
            // 
            this.BtnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnNew.Image = global::TileGameMaker.Properties.Resources.page_white;
            this.BtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(23, 22);
            this.BtnNew.Text = "toolStripButton1";
            this.BtnNew.ToolTipText = "Clear palette";
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // ColorPickerPanel
            // 
            this.PnlColorPicker.AutoScroll = true;
            this.PnlColorPicker.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PnlColorPicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlColorPicker.Location = new System.Drawing.Point(3, 28);
            this.PnlColorPicker.Name = "ColorPickerPanel";
            this.PnlColorPicker.Size = new System.Drawing.Size(213, 212);
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
            // ColorPickerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ColorPickerControl";
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
    }
}
