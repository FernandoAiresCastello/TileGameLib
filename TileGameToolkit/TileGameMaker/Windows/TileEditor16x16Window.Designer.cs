namespace TileGameMaker.Windows
{
    partial class TileEditor16x16Window
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
            this.TilePanel = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BtnOk = new System.Windows.Forms.ToolStripButton();
            this.BtnCancel = new System.Windows.Forms.ToolStripButton();
            this.BtnUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnClear = new System.Windows.Forms.ToolStripButton();
            this.BtnInvert = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TilePanel
            // 
            this.TilePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TilePanel.Location = new System.Drawing.Point(12, 38);
            this.TilePanel.Name = "TilePanel";
            this.TilePanel.Size = new System.Drawing.Size(386, 386);
            this.TilePanel.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnOk,
            this.BtnCancel,
            this.BtnUndo,
            this.toolStripSeparator1,
            this.BtnClear,
            this.BtnInvert});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(410, 25);
            this.toolStrip1.TabIndex = 2;
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
            // TileEditor16x16Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 436);
            this.ControlBox = false;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.TilePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TileEditor16x16Window";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tile Editor";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel TilePanel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BtnOk;
        private System.Windows.Forms.ToolStripButton BtnCancel;
        private System.Windows.Forms.ToolStripButton BtnUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BtnClear;
        private System.Windows.Forms.ToolStripButton BtnInvert;
    }
}