namespace TileGameMaker.Panels
{
    partial class TilePickerPanel
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BtnNew = new System.Windows.Forms.ToolStripButton();
            this.BtnCopy = new System.Windows.Forms.ToolStripButton();
            this.BtnPaste = new System.Windows.Forms.ToolStripButton();
            this.BtnReset = new System.Windows.Forms.ToolStripButton();
            this.BtnExport = new System.Windows.Forms.ToolStripButton();
            this.BtnImport = new System.Windows.Forms.ToolStripButton();
            this.PnlTilePicker = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.HoverLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.PnlTilePicker, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.statusStrip1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(235, 380);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnNew,
            this.BtnCopy,
            this.BtnPaste,
            this.BtnExport,
            this.BtnImport,
            this.BtnReset});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(235, 25);
            this.toolStrip1.TabIndex = 2;
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
            this.BtnNew.ToolTipText = "Clear tileset";
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // BtnCopy
            // 
            this.BtnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnCopy.Image = global::TileGameMaker.Properties.Resources.page_white_copy;
            this.BtnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnCopy.Name = "BtnCopy";
            this.BtnCopy.Size = new System.Drawing.Size(23, 22);
            this.BtnCopy.Text = "toolStripButton1";
            this.BtnCopy.ToolTipText = "Copy selected tile";
            this.BtnCopy.Click += new System.EventHandler(this.BtnCopy_Click);
            // 
            // BtnPaste
            // 
            this.BtnPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnPaste.Image = global::TileGameMaker.Properties.Resources.page_white_paste;
            this.BtnPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnPaste.Name = "BtnPaste";
            this.BtnPaste.Size = new System.Drawing.Size(23, 22);
            this.BtnPaste.Text = "toolStripButton1";
            this.BtnPaste.ToolTipText = "Paste tile";
            this.BtnPaste.Click += new System.EventHandler(this.BtnPaste_Click);
            // 
            // BtnReset
            // 
            this.BtnReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnReset.Image = global::TileGameMaker.Properties.Resources.undo;
            this.BtnReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(23, 22);
            this.BtnReset.Text = "toolStripButton1";
            this.BtnReset.ToolTipText = "Reset tileset to default";
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // BtnExport
            // 
            this.BtnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnExport.Image = global::TileGameMaker.Properties.Resources.diskette;
            this.BtnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(23, 22);
            this.BtnExport.Text = "toolStripButton1";
            this.BtnExport.ToolTipText = "Export tileset";
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // BtnImport
            // 
            this.BtnImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnImport.Image = global::TileGameMaker.Properties.Resources.folder;
            this.BtnImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnImport.Name = "BtnImport";
            this.BtnImport.Size = new System.Drawing.Size(23, 22);
            this.BtnImport.Text = "toolStripButton1";
            this.BtnImport.ToolTipText = "Import tileset";
            this.BtnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // PnlTilePicker
            // 
            this.PnlTilePicker.AutoScroll = true;
            this.PnlTilePicker.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PnlTilePicker.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PnlTilePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlTilePicker.Location = new System.Drawing.Point(3, 28);
            this.PnlTilePicker.Name = "PnlTilePicker";
            this.PnlTilePicker.Size = new System.Drawing.Size(229, 325);
            this.PnlTilePicker.TabIndex = 1;
            this.PnlTilePicker.MouseLeave += new System.EventHandler(this.TilePicker_MouseLeave);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel,
            this.HoverLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 356);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(235, 24);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(71, 19);
            this.StatusLabel.Text = "StatusLabel";
            // 
            // HoverLabel
            // 
            this.HoverLabel.Name = "HoverLabel";
            this.HoverLabel.Size = new System.Drawing.Size(67, 19);
            this.HoverLabel.Text = "HoverLabel";
            // 
            // TilePickerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TilePickerPanel";
            this.Size = new System.Drawing.Size(235, 380);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BtnNew;
        private System.Windows.Forms.Panel PnlTilePicker;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel HoverLabel;
        private System.Windows.Forms.ToolStripButton BtnCopy;
        private System.Windows.Forms.ToolStripButton BtnPaste;
        private System.Windows.Forms.ToolStripButton BtnReset;
        private System.Windows.Forms.ToolStripButton BtnExport;
        private System.Windows.Forms.ToolStripButton BtnImport;
    }
}
