namespace TileGameMaker.Windows
{
    partial class ColorEditorWindow
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
            this.BtnOk = new System.Windows.Forms.Button();
            this.BtnUndo = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.RedSlider = new System.Windows.Forms.TrackBar();
            this.RedTextBox = new System.Windows.Forms.TextBox();
            this.GreenTextBox = new System.Windows.Forms.TextBox();
            this.GreenSlider = new System.Windows.Forms.TrackBar();
            this.BlueTextBox = new System.Windows.Forms.TextBox();
            this.BlueSlider = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ColorHex = new System.Windows.Forms.TextBox();
            this.OriginalColorHex = new System.Windows.Forms.TextBox();
            this.ColorPanel = new System.Windows.Forms.Panel();
            this.OriginalColorPanel = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.RedSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueSlider)).BeginInit();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnOk
            // 
            this.BtnOk.Image = global::TileGameMaker.Properties.Resources.tick;
            this.BtnOk.Location = new System.Drawing.Point(3, 3);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(96, 32);
            this.BtnOk.TabIndex = 1;
            this.BtnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // BtnUndo
            // 
            this.BtnUndo.Image = global::TileGameMaker.Properties.Resources.undo;
            this.BtnUndo.Location = new System.Drawing.Point(105, 3);
            this.BtnUndo.Name = "BtnUndo";
            this.BtnUndo.Size = new System.Drawing.Size(96, 32);
            this.BtnUndo.TabIndex = 2;
            this.BtnUndo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnUndo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnUndo.UseVisualStyleBackColor = true;
            this.BtnUndo.Click += new System.EventHandler(this.BtnUndo_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Image = global::TileGameMaker.Properties.Resources.cross;
            this.BtnCancel.Location = new System.Drawing.Point(207, 3);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(96, 32);
            this.BtnCancel.TabIndex = 3;
            this.BtnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // RedSlider
            // 
            this.RedSlider.AutoSize = false;
            this.RedSlider.LargeChange = 8;
            this.RedSlider.Location = new System.Drawing.Point(29, 8);
            this.RedSlider.Maximum = 255;
            this.RedSlider.Name = "RedSlider";
            this.RedSlider.Size = new System.Drawing.Size(220, 20);
            this.RedSlider.TabIndex = 4;
            this.RedSlider.TickFrequency = 8;
            this.RedSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // RedTextBox
            // 
            this.RedTextBox.Location = new System.Drawing.Point(253, 8);
            this.RedTextBox.MaxLength = 3;
            this.RedTextBox.Name = "RedTextBox";
            this.RedTextBox.Size = new System.Drawing.Size(41, 20);
            this.RedTextBox.TabIndex = 5;
            this.RedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GreenTextBox
            // 
            this.GreenTextBox.Location = new System.Drawing.Point(254, 34);
            this.GreenTextBox.MaxLength = 3;
            this.GreenTextBox.Name = "GreenTextBox";
            this.GreenTextBox.Size = new System.Drawing.Size(41, 20);
            this.GreenTextBox.TabIndex = 7;
            this.GreenTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GreenSlider
            // 
            this.GreenSlider.AutoSize = false;
            this.GreenSlider.LargeChange = 8;
            this.GreenSlider.Location = new System.Drawing.Point(30, 34);
            this.GreenSlider.Maximum = 255;
            this.GreenSlider.Name = "GreenSlider";
            this.GreenSlider.Size = new System.Drawing.Size(220, 20);
            this.GreenSlider.TabIndex = 6;
            this.GreenSlider.TickFrequency = 8;
            this.GreenSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // BlueTextBox
            // 
            this.BlueTextBox.Location = new System.Drawing.Point(254, 60);
            this.BlueTextBox.MaxLength = 3;
            this.BlueTextBox.Name = "BlueTextBox";
            this.BlueTextBox.Size = new System.Drawing.Size(41, 20);
            this.BlueTextBox.TabIndex = 9;
            this.BlueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BlueSlider
            // 
            this.BlueSlider.AutoSize = false;
            this.BlueSlider.LargeChange = 8;
            this.BlueSlider.Location = new System.Drawing.Point(30, 60);
            this.BlueSlider.Maximum = 255;
            this.BlueSlider.Name = "BlueSlider";
            this.BlueSlider.Size = new System.Drawing.Size(220, 20);
            this.BlueSlider.TabIndex = 8;
            this.BlueSlider.TickFrequency = 8;
            this.BlueSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.RedSlider);
            this.panel1.Controls.Add(this.BlueTextBox);
            this.panel1.Controls.Add(this.RedTextBox);
            this.panel1.Controls.Add(this.BlueSlider);
            this.panel1.Controls.Add(this.GreenSlider);
            this.panel1.Controls.Add(this.GreenTextBox);
            this.panel1.Location = new System.Drawing.Point(3, 148);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(306, 89);
            this.panel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "B";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "G";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "R";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.BtnOk);
            this.flowLayoutPanel1.Controls.Add(this.BtnUndo);
            this.flowLayoutPanel1.Controls.Add(this.BtnCancel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 243);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(306, 38);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ColorHex);
            this.panel2.Controls.Add(this.OriginalColorHex);
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(312, 285);
            this.panel2.TabIndex = 5;
            // 
            // ColorHex
            // 
            this.ColorHex.Location = new System.Drawing.Point(175, 10);
            this.ColorHex.MaxLength = 6;
            this.ColorHex.Name = "ColorHex";
            this.ColorHex.Size = new System.Drawing.Size(112, 20);
            this.ColorHex.TabIndex = 14;
            this.ColorHex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // OriginalColorHex
            // 
            this.OriginalColorHex.Location = new System.Drawing.Point(26, 9);
            this.OriginalColorHex.Name = "OriginalColorHex";
            this.OriginalColorHex.ReadOnly = true;
            this.OriginalColorHex.Size = new System.Drawing.Size(112, 20);
            this.OriginalColorHex.TabIndex = 13;
            this.OriginalColorHex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ColorPanel
            // 
            this.ColorPanel.Location = new System.Drawing.Point(153, 0);
            this.ColorPanel.Name = "ColorPanel";
            this.ColorPanel.Size = new System.Drawing.Size(155, 96);
            this.ColorPanel.TabIndex = 5;
            // 
            // OriginalColorPanel
            // 
            this.OriginalColorPanel.Location = new System.Drawing.Point(0, 0);
            this.OriginalColorPanel.Name = "OriginalColorPanel";
            this.OriginalColorPanel.Size = new System.Drawing.Size(155, 96);
            this.OriginalColorPanel.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.OriginalColorPanel);
            this.panel4.Controls.Add(this.ColorPanel);
            this.panel4.Location = new System.Drawing.Point(3, 42);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(312, 100);
            this.panel4.TabIndex = 7;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 321);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(332, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(67, 17);
            this.StatusLabel.Text = "StatusLabel";
            // 
            // ColorEditorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 343);
            this.ControlBox = false;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColorEditorWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Color Editor";
            ((System.ComponentModel.ISupportInitialize)(this.RedSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueSlider)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Button BtnUndo;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.TrackBar RedSlider;
        private System.Windows.Forms.TextBox RedTextBox;
        private System.Windows.Forms.TextBox GreenTextBox;
        private System.Windows.Forms.TrackBar GreenSlider;
        private System.Windows.Forms.TextBox BlueTextBox;
        private System.Windows.Forms.TrackBar BlueSlider;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel ColorPanel;
        private System.Windows.Forms.Panel OriginalColorPanel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ColorHex;
        private System.Windows.Forms.TextBox OriginalColorHex;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
    }
}