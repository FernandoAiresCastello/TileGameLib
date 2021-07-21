namespace TileGameMaker.Windows
{
    partial class RangeInputWindow
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
            this.Txt1 = new System.Windows.Forms.NumericUpDown();
            this.Txt2 = new System.Windows.Forms.NumericUpDown();
            this.Lb1 = new System.Windows.Forms.Label();
            this.Lb2 = new System.Windows.Forms.Label();
            this.LbCaption = new System.Windows.Forms.Label();
            this.BtnOk = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Txt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt2)).BeginInit();
            this.SuspendLayout();
            // 
            // Txt1
            // 
            this.Txt1.Location = new System.Drawing.Point(48, 37);
            this.Txt1.Name = "Txt1";
            this.Txt1.Size = new System.Drawing.Size(70, 20);
            this.Txt1.TabIndex = 0;
            // 
            // Txt2
            // 
            this.Txt2.Location = new System.Drawing.Point(150, 37);
            this.Txt2.Name = "Txt2";
            this.Txt2.Size = new System.Drawing.Size(70, 20);
            this.Txt2.TabIndex = 1;
            // 
            // Lb1
            // 
            this.Lb1.AutoSize = true;
            this.Lb1.Location = new System.Drawing.Point(12, 39);
            this.Lb1.Name = "Lb1";
            this.Lb1.Size = new System.Drawing.Size(30, 13);
            this.Lb1.TabIndex = 2;
            this.Lb1.Text = "From";
            // 
            // Lb2
            // 
            this.Lb2.AutoSize = true;
            this.Lb2.Location = new System.Drawing.Point(124, 39);
            this.Lb2.Name = "Lb2";
            this.Lb2.Size = new System.Drawing.Size(20, 13);
            this.Lb2.TabIndex = 3;
            this.Lb2.Text = "To";
            // 
            // LbCaption
            // 
            this.LbCaption.AutoSize = true;
            this.LbCaption.Location = new System.Drawing.Point(12, 9);
            this.LbCaption.Name = "LbCaption";
            this.LbCaption.Size = new System.Drawing.Size(65, 13);
            this.LbCaption.TabIndex = 4;
            this.LbCaption.Text = "Enter range:";
            // 
            // BtnOk
            // 
            this.BtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOk.Image = global::TileGameMaker.Properties.Resources.tick;
            this.BtnOk.Location = new System.Drawing.Point(12, 81);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(100, 28);
            this.BtnOk.TabIndex = 5;
            this.BtnOk.UseVisualStyleBackColor = true;
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Image = global::TileGameMaker.Properties.Resources.cross;
            this.BtnCancel.Location = new System.Drawing.Point(123, 81);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(100, 28);
            this.BtnCancel.TabIndex = 6;
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // RangeInputWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 119);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.LbCaption);
            this.Controls.Add(this.Lb2);
            this.Controls.Add(this.Lb1);
            this.Controls.Add(this.Txt2);
            this.Controls.Add(this.Txt1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RangeInputWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.Txt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown Txt1;
        private System.Windows.Forms.NumericUpDown Txt2;
        private System.Windows.Forms.Label Lb1;
        private System.Windows.Forms.Label Lb2;
        private System.Windows.Forms.Label LbCaption;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Button BtnCancel;
    }
}