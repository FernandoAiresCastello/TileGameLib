namespace TileGameMaker.Windows
{
    partial class GridSetupWindow
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
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtAuxIntervalX = new System.Windows.Forms.NumericUpDown();
            this.BtnMainColor = new System.Windows.Forms.Button();
            this.BtnAuxColor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtMainOpacity = new System.Windows.Forms.NumericUpDown();
            this.TxtAuxOpacity = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtAuxIntervalY = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAuxIntervalX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMainOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAuxOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAuxIntervalY)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Main grid";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Aux. grid interval";
            // 
            // TxtAuxIntervalX
            // 
            this.TxtAuxIntervalX.Location = new System.Drawing.Point(150, 76);
            this.TxtAuxIntervalX.Name = "TxtAuxIntervalX";
            this.TxtAuxIntervalX.Size = new System.Drawing.Size(75, 20);
            this.TxtAuxIntervalX.TabIndex = 9;
            // 
            // BtnMainColor
            // 
            this.BtnMainColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnMainColor.Location = new System.Drawing.Point(108, 9);
            this.BtnMainColor.Name = "BtnMainColor";
            this.BtnMainColor.Size = new System.Drawing.Size(75, 23);
            this.BtnMainColor.TabIndex = 14;
            this.BtnMainColor.UseVisualStyleBackColor = true;
            this.BtnMainColor.Click += new System.EventHandler(this.BtnMainColor_Click);
            // 
            // BtnAuxColor
            // 
            this.BtnAuxColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnAuxColor.Location = new System.Drawing.Point(108, 41);
            this.BtnAuxColor.Name = "BtnAuxColor";
            this.BtnAuxColor.Size = new System.Drawing.Size(75, 23);
            this.BtnAuxColor.TabIndex = 16;
            this.BtnAuxColor.UseVisualStyleBackColor = true;
            this.BtnAuxColor.Click += new System.EventHandler(this.BtnAuxColor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Auxiliar grid";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(198, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Opacity";
            // 
            // TxtMainOpacity
            // 
            this.TxtMainOpacity.Location = new System.Drawing.Point(251, 12);
            this.TxtMainOpacity.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.TxtMainOpacity.Name = "TxtMainOpacity";
            this.TxtMainOpacity.Size = new System.Drawing.Size(75, 20);
            this.TxtMainOpacity.TabIndex = 19;
            // 
            // TxtAuxOpacity
            // 
            this.TxtAuxOpacity.Location = new System.Drawing.Point(251, 44);
            this.TxtAuxOpacity.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.TxtAuxOpacity.Name = "TxtAuxOpacity";
            this.TxtAuxOpacity.Size = new System.Drawing.Size(75, 20);
            this.TxtAuxOpacity.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(198, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Opacity";
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Image = global::TileGameMaker.Properties.Resources.cross;
            this.BtnCancel.Location = new System.Drawing.Point(181, 117);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(100, 28);
            this.BtnCancel.TabIndex = 8;
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnOk
            // 
            this.BtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOk.Image = global::TileGameMaker.Properties.Resources.tick;
            this.BtnOk.Location = new System.Drawing.Point(65, 117);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(100, 28);
            this.BtnOk.TabIndex = 7;
            this.BtnOk.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(130, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "X";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(231, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Y";
            // 
            // TxtAuxIntervalY
            // 
            this.TxtAuxIntervalY.Location = new System.Drawing.Point(251, 76);
            this.TxtAuxIntervalY.Name = "TxtAuxIntervalY";
            this.TxtAuxIntervalY.Size = new System.Drawing.Size(75, 20);
            this.TxtAuxIntervalY.TabIndex = 24;
            // 
            // GridSetupWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 156);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TxtAuxIntervalY);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TxtAuxOpacity);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtMainOpacity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BtnAuxColor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnMainColor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtAuxIntervalX);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GridSetupWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setup grid";
            ((System.ComponentModel.ISupportInitialize)(this.TxtAuxIntervalX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMainOpacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAuxOpacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAuxIntervalY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown TxtAuxIntervalX;
        private System.Windows.Forms.Button BtnMainColor;
        private System.Windows.Forms.Button BtnAuxColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown TxtMainOpacity;
        private System.Windows.Forms.NumericUpDown TxtAuxOpacity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown TxtAuxIntervalY;
    }
}