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
            this.BtnViewCode = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.TxtStringRep = new System.Windows.Forms.TextBox();
            this.TilePanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(426, 396);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel,
            this.HoverLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 372);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(426, 24);
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
            this.toolStripSeparator2,
            this.BtnViewCode});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(426, 25);
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
            // BtnViewCode
            // 
            this.BtnViewCode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnViewCode.Image = global::TileGameMaker.Properties.Resources.script_code;
            this.BtnViewCode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnViewCode.Name = "BtnViewCode";
            this.BtnViewCode.Size = new System.Drawing.Size(23, 22);
            this.BtnViewCode.Text = "toolStripButton1";
            this.BtnViewCode.ToolTipText = "View code";
            this.BtnViewCode.Click += new System.EventHandler(this.BtnViewCode_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.TxtStringRep, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.TilePanel, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 28);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78.88563F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.11437F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(420, 341);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // TxtStringRep
            // 
            this.TxtStringRep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtStringRep.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtStringRep.Location = new System.Drawing.Point(3, 271);
            this.TxtStringRep.Multiline = true;
            this.TxtStringRep.Name = "TxtStringRep";
            this.TxtStringRep.ReadOnly = true;
            this.TxtStringRep.Size = new System.Drawing.Size(414, 67);
            this.TxtStringRep.TabIndex = 5;
            this.TxtStringRep.Text = "String representations";
            // 
            // TilePanel
            // 
            this.TilePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TilePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TilePanel.Location = new System.Drawing.Point(113, 37);
            this.TilePanel.Margin = new System.Windows.Forms.Padding(113, 37, 113, 37);
            this.TilePanel.Name = "TilePanel";
            this.TilePanel.Size = new System.Drawing.Size(194, 194);
            this.TilePanel.TabIndex = 4;
            // 
            // TileEditor8x8Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 396);
            this.ControlBox = false;
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
            this.tableLayoutPanel2.PerformLayout();
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
        private System.Windows.Forms.TextBox TxtStringRep;
        private System.Windows.Forms.Panel TilePanel;
        private System.Windows.Forms.ToolStripButton BtnViewCode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}