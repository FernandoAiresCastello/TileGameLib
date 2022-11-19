namespace TileGameMaker.Windows
{
    partial class TileEditor8x8Window
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.HoverLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BtnOk = new System.Windows.Forms.ToolStripButton();
            this.BtnCancel = new System.Windows.Forms.ToolStripButton();
            this.BtnUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnClear = new System.Windows.Forms.ToolStripButton();
            this.BtnInvert = new System.Windows.Forms.ToolStripButton();
            this.BtnFlipH = new System.Windows.Forms.ToolStripButton();
            this.BtnFlipV = new System.Windows.Forms.ToolStripButton();
            this.BtnRotateLeft = new System.Windows.Forms.ToolStripButton();
            this.BtnRotateRight = new System.Windows.Forms.ToolStripButton();
            this.BtnRotateDown = new System.Windows.Forms.ToolStripButton();
            this.BtnRotateUp = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.TilePanel = new System.Windows.Forms.Panel();
            this.PnlStrings = new System.Windows.Forms.Panel();
            this.ChkHexIndex = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtBinaryBlock = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtCsvDec = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtCsvHex = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtBinaryString = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.PnlStrings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.statusStrip1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(878, 341);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel,
            this.HoverLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 317);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(878, 24);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 0;
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
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnOk,
            this.BtnCancel,
            this.BtnUndo,
            this.toolStripSeparator1,
            this.BtnClear,
            this.BtnInvert,
            this.BtnFlipH,
            this.BtnFlipV,
            this.BtnRotateLeft,
            this.BtnRotateRight,
            this.BtnRotateDown,
            this.BtnRotateUp,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(878, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BtnOk
            // 
            this.BtnOk.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnOk.Image = global::TileGameMaker.Properties.Resources.tick;
            this.BtnOk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(23, 22);
            this.BtnOk.Text = "toolStripButton1";
            this.BtnOk.ToolTipText = "Confirm changes";
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnCancel.Image = global::TileGameMaker.Properties.Resources.cross;
            this.BtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(23, 22);
            this.BtnCancel.Text = "toolStripButton1";
            this.BtnCancel.ToolTipText = "Cancel";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnUndo
            // 
            this.BtnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnUndo.Image = global::TileGameMaker.Properties.Resources.undo;
            this.BtnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnUndo.Name = "BtnUndo";
            this.BtnUndo.Size = new System.Drawing.Size(23, 22);
            this.BtnUndo.Text = "toolStripButton1";
            this.BtnUndo.ToolTipText = "Undo changes";
            this.BtnUndo.Click += new System.EventHandler(this.BtnUndo_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // BtnClear
            // 
            this.BtnClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnClear.Image = global::TileGameMaker.Properties.Resources.page_white;
            this.BtnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(23, 22);
            this.BtnClear.Text = "toolStripButton1";
            this.BtnClear.ToolTipText = "Clear tile";
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // BtnInvert
            // 
            this.BtnInvert.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnInvert.Image = global::TileGameMaker.Properties.Resources.color_picker_default;
            this.BtnInvert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnInvert.Name = "BtnInvert";
            this.BtnInvert.Size = new System.Drawing.Size(23, 22);
            this.BtnInvert.Text = "toolStripButton1";
            this.BtnInvert.ToolTipText = "Invert pixels";
            this.BtnInvert.Click += new System.EventHandler(this.BtnInvert_Click);
            // 
            // BtnFlipH
            // 
            this.BtnFlipH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnFlipH.Image = global::TileGameMaker.Properties.Resources.shape_flip_horizontal;
            this.BtnFlipH.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnFlipH.Name = "BtnFlipH";
            this.BtnFlipH.Size = new System.Drawing.Size(23, 22);
            this.BtnFlipH.Text = "toolStripButton1";
            this.BtnFlipH.ToolTipText = "Flip horizontal";
            this.BtnFlipH.Click += new System.EventHandler(this.BtnFlipH_Click);
            // 
            // BtnFlipV
            // 
            this.BtnFlipV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnFlipV.Image = global::TileGameMaker.Properties.Resources.shape_flip_vertical;
            this.BtnFlipV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnFlipV.Name = "BtnFlipV";
            this.BtnFlipV.Size = new System.Drawing.Size(23, 22);
            this.BtnFlipV.Text = "toolStripButton1";
            this.BtnFlipV.ToolTipText = "Flip vertical";
            this.BtnFlipV.Click += new System.EventHandler(this.BtnFlipV_Click);
            // 
            // BtnRotateLeft
            // 
            this.BtnRotateLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnRotateLeft.Image = global::TileGameMaker.Properties.Resources.arrow_left;
            this.BtnRotateLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnRotateLeft.Name = "BtnRotateLeft";
            this.BtnRotateLeft.Size = new System.Drawing.Size(23, 22);
            this.BtnRotateLeft.Text = "toolStripButton1";
            this.BtnRotateLeft.ToolTipText = "Rotate left";
            this.BtnRotateLeft.Click += new System.EventHandler(this.BtnRotateLeft_Click);
            // 
            // BtnRotateRight
            // 
            this.BtnRotateRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnRotateRight.Image = global::TileGameMaker.Properties.Resources.arrow_right;
            this.BtnRotateRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnRotateRight.Name = "BtnRotateRight";
            this.BtnRotateRight.Size = new System.Drawing.Size(23, 22);
            this.BtnRotateRight.Text = "toolStripButton1";
            this.BtnRotateRight.ToolTipText = "Rotate right";
            this.BtnRotateRight.Click += new System.EventHandler(this.BtnRotateRight_Click);
            // 
            // BtnRotateDown
            // 
            this.BtnRotateDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnRotateDown.Image = global::TileGameMaker.Properties.Resources.arrow_down;
            this.BtnRotateDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnRotateDown.Name = "BtnRotateDown";
            this.BtnRotateDown.Size = new System.Drawing.Size(23, 22);
            this.BtnRotateDown.Text = "toolStripButton1";
            this.BtnRotateDown.ToolTipText = "Rotate down";
            this.BtnRotateDown.Click += new System.EventHandler(this.BtnRotateDown_Click);
            // 
            // BtnRotateUp
            // 
            this.BtnRotateUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnRotateUp.Image = global::TileGameMaker.Properties.Resources.arrow_up;
            this.BtnRotateUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnRotateUp.Name = "BtnRotateUp";
            this.BtnRotateUp.Size = new System.Drawing.Size(23, 22);
            this.BtnRotateUp.Text = "toolStripButton1";
            this.BtnRotateUp.ToolTipText = "Rotate up";
            this.BtnRotateUp.Click += new System.EventHandler(this.BtnRotateUp_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.27582F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.72418F));
            this.tableLayoutPanel2.Controls.Add(this.TilePanel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.PnlStrings, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 28);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76.99115F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(872, 286);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // TilePanel
            // 
            this.TilePanel.Location = new System.Drawing.Point(115, 39);
            this.TilePanel.Margin = new System.Windows.Forms.Padding(113, 37, 113, 37);
            this.TilePanel.Name = "TilePanel";
            this.TilePanel.Size = new System.Drawing.Size(212, 208);
            this.TilePanel.TabIndex = 4;
            // 
            // PnlStrings
            // 
            this.PnlStrings.Controls.Add(this.ChkHexIndex);
            this.PnlStrings.Controls.Add(this.label4);
            this.PnlStrings.Controls.Add(this.TxtBinaryBlock);
            this.PnlStrings.Controls.Add(this.label3);
            this.PnlStrings.Controls.Add(this.TxtCsvDec);
            this.PnlStrings.Controls.Add(this.label2);
            this.PnlStrings.Controls.Add(this.TxtCsvHex);
            this.PnlStrings.Controls.Add(this.label1);
            this.PnlStrings.Controls.Add(this.TxtBinaryString);
            this.PnlStrings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlStrings.Location = new System.Drawing.Point(448, 2);
            this.PnlStrings.Margin = new System.Windows.Forms.Padding(0);
            this.PnlStrings.Name = "PnlStrings";
            this.PnlStrings.Size = new System.Drawing.Size(422, 282);
            this.PnlStrings.TabIndex = 5;
            this.PnlStrings.Click += new System.EventHandler(this.PnlStrings_Click);
            // 
            // ChkHexIndex
            // 
            this.ChkHexIndex.AutoSize = true;
            this.ChkHexIndex.Location = new System.Drawing.Point(334, 78);
            this.ChkHexIndex.Name = "ChkHexIndex";
            this.ChkHexIndex.Size = new System.Drawing.Size(76, 17);
            this.ChkHexIndex.TabIndex = 9;
            this.ChkHexIndex.Text = "Hex. index";
            this.ChkHexIndex.UseVisualStyleBackColor = true;
            this.ChkHexIndex.CheckedChanged += new System.EventHandler(this.ChkHexIndex_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "PTM format";
            // 
            // TxtBinaryBlock
            // 
            this.TxtBinaryBlock.BackColor = System.Drawing.SystemColors.Control;
            this.TxtBinaryBlock.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBinaryBlock.Location = new System.Drawing.Point(9, 101);
            this.TxtBinaryBlock.Multiline = true;
            this.TxtBinaryBlock.Name = "TxtBinaryBlock";
            this.TxtBinaryBlock.ReadOnly = true;
            this.TxtBinaryBlock.Size = new System.Drawing.Size(401, 174);
            this.TxtBinaryBlock.TabIndex = 7;
            this.TxtBinaryBlock.TabStop = false;
            this.TxtBinaryBlock.Text = "Row 0\r\nRow 1\r\nRow 2\r\nRow 3\r\nRow 4\r\nRow 5\r\nRow 6\r\nRow 7";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "D";
            // 
            // TxtCsvDec
            // 
            this.TxtCsvDec.BackColor = System.Drawing.SystemColors.Control;
            this.TxtCsvDec.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtCsvDec.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCsvDec.Location = new System.Drawing.Point(28, 34);
            this.TxtCsvDec.Name = "TxtCsvDec";
            this.TxtCsvDec.ReadOnly = true;
            this.TxtCsvDec.Size = new System.Drawing.Size(390, 13);
            this.TxtCsvDec.TabIndex = 5;
            this.TxtCsvDec.TabStop = false;
            this.TxtCsvDec.Text = "0, 0, 0, 0, 0, 0, 0, 0\r\n\r\n";
            this.TxtCsvDec.Click += new System.EventHandler(this.Txt_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "H";
            // 
            // TxtCsvHex
            // 
            this.TxtCsvHex.BackColor = System.Drawing.SystemColors.Control;
            this.TxtCsvHex.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtCsvHex.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCsvHex.Location = new System.Drawing.Point(28, 20);
            this.TxtCsvHex.Name = "TxtCsvHex";
            this.TxtCsvHex.ReadOnly = true;
            this.TxtCsvHex.Size = new System.Drawing.Size(390, 13);
            this.TxtCsvHex.TabIndex = 3;
            this.TxtCsvHex.TabStop = false;
            this.TxtCsvHex.Text = "0x00, 0x00, 0x00, 0x7e, 0x00, 0x00, 0x00, 0x00";
            this.TxtCsvHex.Click += new System.EventHandler(this.Txt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "B";
            // 
            // TxtBinaryString
            // 
            this.TxtBinaryString.BackColor = System.Drawing.SystemColors.Control;
            this.TxtBinaryString.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtBinaryString.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBinaryString.Location = new System.Drawing.Point(28, 6);
            this.TxtBinaryString.Name = "TxtBinaryString";
            this.TxtBinaryString.ReadOnly = true;
            this.TxtBinaryString.Size = new System.Drawing.Size(390, 13);
            this.TxtBinaryString.TabIndex = 1;
            this.TxtBinaryString.TabStop = false;
            this.TxtBinaryString.Text = "0000000000000000000000000000000000000000000000000000000000000000";
            this.TxtBinaryString.Click += new System.EventHandler(this.Txt_Click);
            // 
            // TileEditor8x8Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 341);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(220, 286);
            this.Name = "TileEditor8x8Window";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tile Editor";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.PnlStrings.ResumeLayout(false);
            this.PnlStrings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripStatusLabel HoverLabel;
        private System.Windows.Forms.ToolStripButton BtnClear;
        private System.Windows.Forms.ToolStripButton BtnUndo;
        private System.Windows.Forms.ToolStripButton BtnOk;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BtnCancel;
        private System.Windows.Forms.ToolStripButton BtnInvert;
        private System.Windows.Forms.ToolStripButton BtnFlipH;
        private System.Windows.Forms.ToolStripButton BtnFlipV;
        private System.Windows.Forms.ToolStripButton BtnRotateRight;
        private System.Windows.Forms.ToolStripButton BtnRotateLeft;
        private System.Windows.Forms.ToolStripButton BtnRotateDown;
        private System.Windows.Forms.ToolStripButton BtnRotateUp;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel TilePanel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel PnlStrings;
        private System.Windows.Forms.TextBox TxtBinaryString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtCsvHex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtCsvDec;
        private System.Windows.Forms.TextBox TxtBinaryBlock;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.CheckBox ChkHexIndex;
    }
}