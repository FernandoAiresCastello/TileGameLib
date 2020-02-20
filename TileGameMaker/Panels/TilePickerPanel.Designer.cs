﻿namespace TileGameMaker.Panels
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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.PnlTilePicker = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.HoverLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.BtnImportRawBytes = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnImportFromImage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.BtnExportRawBytes = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnExportBinaryStrings = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnExportHex = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnExportToImage = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnCopy = new System.Windows.Forms.ToolStripButton();
            this.BtnPaste = new System.Windows.Forms.ToolStripButton();
            this.BtnClear = new System.Windows.Forms.ToolStripDropDownButton();
            this.BtnClearAll = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnClearRange = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnRestoreDefault = new System.Windows.Forms.ToolStripDropDownButton();
            this.BtnUse16x16TileEditor = new System.Windows.Forms.ToolStripButton();
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
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton1,
            this.toolStripSeparator1,
            this.BtnCopy,
            this.BtnPaste,
            this.BtnClear,
            this.BtnRestoreDefault,
            this.BtnUse16x16TileEditor});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(8, 5, 1, 2);
            this.toolStrip1.Size = new System.Drawing.Size(235, 30);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
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
            this.BtnImportRawBytes.Size = new System.Drawing.Size(138, 22);
            this.BtnImportRawBytes.Text = "Raw bytes";
            this.BtnImportRawBytes.Click += new System.EventHandler(this.BtnImportRawBytes_Click);
            // 
            // BtnImportFromImage
            // 
            this.BtnImportFromImage.Name = "BtnImportFromImage";
            this.BtnImportFromImage.Size = new System.Drawing.Size(138, 22);
            this.BtnImportFromImage.Text = "From image";
            this.BtnImportFromImage.Click += new System.EventHandler(this.BtnImportFromImage_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.AutoToolTip = false;
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnExportRawBytes,
            this.BtnExportBinaryStrings,
            this.BtnExportHex,
            this.BtnExportToImage});
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
            // BtnExportToImage
            // 
            this.BtnExportToImage.Name = "BtnExportToImage";
            this.BtnExportToImage.Size = new System.Drawing.Size(166, 22);
            this.BtnExportToImage.Text = "To image";
            this.BtnExportToImage.Click += new System.EventHandler(this.BtnExportToImage_Click);
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
            // BtnClear
            // 
            this.BtnClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnClear.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnClearAll,
            this.BtnClearRange});
            this.BtnClear.Image = global::TileGameMaker.Properties.Resources.broom;
            this.BtnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(29, 20);
            // 
            // BtnClearAll
            // 
            this.BtnClearAll.Name = "BtnClearAll";
            this.BtnClearAll.Size = new System.Drawing.Size(180, 22);
            this.BtnClearAll.Text = "Clear all";
            this.BtnClearAll.Click += new System.EventHandler(this.BtnClearAll_Click);
            // 
            // BtnClearRange
            // 
            this.BtnClearRange.Name = "BtnClearRange";
            this.BtnClearRange.Size = new System.Drawing.Size(180, 22);
            this.BtnClearRange.Text = "Clear range";
            this.BtnClearRange.Click += new System.EventHandler(this.BtnClearRange_Click);
            // 
            // BtnRestoreDefault
            // 
            this.BtnRestoreDefault.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnRestoreDefault.Image = global::TileGameMaker.Properties.Resources.site_backup_and_restore;
            this.BtnRestoreDefault.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnRestoreDefault.Name = "BtnRestoreDefault";
            this.BtnRestoreDefault.Size = new System.Drawing.Size(29, 20);
            // 
            // BtnUse16x16TileEditor
            // 
            this.BtnUse16x16TileEditor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnUse16x16TileEditor.Image = global::TileGameMaker.Properties.Resources.layouts_four_grid;
            this.BtnUse16x16TileEditor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnUse16x16TileEditor.Name = "BtnUse16x16TileEditor";
            this.BtnUse16x16TileEditor.Size = new System.Drawing.Size(23, 20);
            this.BtnUse16x16TileEditor.Text = "toolStripButton1";
            this.BtnUse16x16TileEditor.ToolTipText = "Use 16x16 editor";
            this.BtnUse16x16TileEditor.Click += new System.EventHandler(this.BtnSwitchTileEditor_Click);
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
        private System.Windows.Forms.Panel PnlTilePicker;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel HoverLabel;
        private System.Windows.Forms.ToolStripButton BtnCopy;
        private System.Windows.Forms.ToolStripButton BtnPaste;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem BtnExportRawBytes;
        private System.Windows.Forms.ToolStripMenuItem BtnExportBinaryStrings;
        private System.Windows.Forms.ToolStripMenuItem BtnExportHex;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem BtnImportRawBytes;
        private System.Windows.Forms.ToolStripMenuItem BtnImportFromImage;
        private System.Windows.Forms.ToolStripMenuItem BtnExportToImage;
        private System.Windows.Forms.ToolStripButton BtnUse16x16TileEditor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton BtnClear;
        private System.Windows.Forms.ToolStripMenuItem BtnClearAll;
        private System.Windows.Forms.ToolStripMenuItem BtnClearRange;
        private System.Windows.Forms.ToolStripDropDownButton BtnRestoreDefault;
    }
}
