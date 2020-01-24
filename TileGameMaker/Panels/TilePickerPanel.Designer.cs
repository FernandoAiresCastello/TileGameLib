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
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.BtnExportRawBytes = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnExportBinaryStrings = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnExportHex = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.BtnImportRawBytes = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnReset = new System.Windows.Forms.ToolStripButton();
            this.TxtTilesPerRow = new System.Windows.Forms.ToolStripTextBox();
            this.PnlTilePicker = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.HoverLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.BtnImportFromImage = new System.Windows.Forms.ToolStripMenuItem();
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
            this.toolStrip1.CanOverflow = false;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnNew,
            this.BtnCopy,
            this.BtnPaste,
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.BtnReset,
            this.TxtTilesPerRow});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(8, 5, 1, 2);
            this.toolStrip1.Size = new System.Drawing.Size(235, 30);
            this.toolStrip1.TabIndex = 2;
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
            this.BtnNew.ToolTipText = "Clear tileset";
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // BtnCopy
            // 
            this.BtnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnCopy.Image = global::TileGameMaker.Properties.Resources.page_white_copy;
            this.BtnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnCopy.Name = "BtnCopy";
            this.BtnCopy.Size = new System.Drawing.Size(23, 20);
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
            this.BtnPaste.Size = new System.Drawing.Size(23, 20);
            this.BtnPaste.Text = "toolStripButton1";
            this.BtnPaste.ToolTipText = "Paste tile";
            this.BtnPaste.Click += new System.EventHandler(this.BtnPaste_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.AutoToolTip = false;
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnExportRawBytes,
            this.BtnExportBinaryStrings,
            this.BtnExportHex});
            this.toolStripDropDownButton1.Image = global::TileGameMaker.Properties.Resources.diskette;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 20);
            this.toolStripDropDownButton1.Text = "Export tileset";
            // 
            // BtnExportRawBytes
            // 
            this.BtnExportRawBytes.Name = "BtnExportRawBytes";
            this.BtnExportRawBytes.Size = new System.Drawing.Size(166, 22);
            this.BtnExportRawBytes.Text = "Raw bytes";
            this.BtnExportRawBytes.Click += new System.EventHandler(this.BtnExportRawBytes_Click);
            // 
            // BtnExportBinaryStrings
            // 
            this.BtnExportBinaryStrings.Name = "BtnExportBinaryStrings";
            this.BtnExportBinaryStrings.Size = new System.Drawing.Size(166, 22);
            this.BtnExportBinaryStrings.Text = "Binary strings";
            this.BtnExportBinaryStrings.Click += new System.EventHandler(this.BtnExportBinaryStrings_Click);
            // 
            // BtnExportHex
            // 
            this.BtnExportHex.Name = "BtnExportHex";
            this.BtnExportHex.Size = new System.Drawing.Size(166, 22);
            this.BtnExportHex.Text = "Hexadecimal CSV";
            this.BtnExportHex.Click += new System.EventHandler(this.BtnExportHex_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.AutoToolTip = false;
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnImportRawBytes,
            this.BtnImportFromImage});
            this.toolStripDropDownButton2.Image = global::TileGameMaker.Properties.Resources.folder;
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(29, 20);
            this.toolStripDropDownButton2.Text = "toolStripDropDownButton2";
            // 
            // BtnImportRawBytes
            // 
            this.BtnImportRawBytes.Name = "BtnImportRawBytes";
            this.BtnImportRawBytes.Size = new System.Drawing.Size(180, 22);
            this.BtnImportRawBytes.Text = "Raw bytes";
            this.BtnImportRawBytes.Click += new System.EventHandler(this.BtnImportRawBytes_Click);
            // 
            // BtnReset
            // 
            this.BtnReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnReset.Image = global::TileGameMaker.Properties.Resources.undo;
            this.BtnReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(23, 20);
            this.BtnReset.Text = "toolStripButton1";
            this.BtnReset.ToolTipText = "Reset tileset to default";
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // TxtTilesPerRow
            // 
            this.TxtTilesPerRow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtTilesPerRow.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTilesPerRow.MaxLength = 2;
            this.TxtTilesPerRow.Name = "TxtTilesPerRow";
            this.TxtTilesPerRow.Size = new System.Drawing.Size(30, 23);
            this.TxtTilesPerRow.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtTilesPerRow.ToolTipText = "Tiles per row to display";
            this.TxtTilesPerRow.Leave += new System.EventHandler(this.TxtTilesPerRow_Leave);
            this.TxtTilesPerRow.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtTilesPerRow_KeyUp);
            // 
            // PnlTilePicker
            // 
            this.PnlTilePicker.AutoScroll = true;
            this.PnlTilePicker.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PnlTilePicker.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PnlTilePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlTilePicker.Location = new System.Drawing.Point(3, 33);
            this.PnlTilePicker.Name = "PnlTilePicker";
            this.PnlTilePicker.Size = new System.Drawing.Size(229, 320);
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
            this.statusStrip1.SizingGrip = false;
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
            // BtnImportFromImage
            // 
            this.BtnImportFromImage.Name = "BtnImportFromImage";
            this.BtnImportFromImage.Size = new System.Drawing.Size(180, 22);
            this.BtnImportFromImage.Text = "From image";
            this.BtnImportFromImage.Click += new System.EventHandler(this.BtnImportFromImage_Click);
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
        private System.Windows.Forms.ToolStripTextBox TxtTilesPerRow;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem BtnExportRawBytes;
        private System.Windows.Forms.ToolStripMenuItem BtnExportBinaryStrings;
        private System.Windows.Forms.ToolStripMenuItem BtnExportHex;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem BtnImportRawBytes;
        private System.Windows.Forms.ToolStripMenuItem BtnImportFromImage;
    }
}
