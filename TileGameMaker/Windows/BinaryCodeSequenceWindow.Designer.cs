namespace TileGameMaker.Windows
{
    partial class BinaryCodeSequenceWindow
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
            this.BtnViewBytes = new System.Windows.Forms.Button();
            this.LbCaption = new System.Windows.Forms.Label();
            this.Lb2 = new System.Windows.Forms.Label();
            this.Lb1 = new System.Windows.Forms.Label();
            this.Txt2 = new System.Windows.Forms.NumericUpDown();
            this.Txt1 = new System.Windows.Forms.NumericUpDown();
            this.BtnSetBytes = new System.Windows.Forms.Button();
            this.TxtBytes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LbValidLineFormat = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Txt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt1)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnViewBytes
            // 
            this.BtnViewBytes.Image = global::TileGameMaker.Properties.Resources.eye;
            this.BtnViewBytes.Location = new System.Drawing.Point(15, 73);
            this.BtnViewBytes.Name = "BtnViewBytes";
            this.BtnViewBytes.Size = new System.Drawing.Size(120, 28);
            this.BtnViewBytes.TabIndex = 12;
            this.BtnViewBytes.Text = "   View bytes";
            this.BtnViewBytes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnViewBytes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnViewBytes.UseVisualStyleBackColor = true;
            this.BtnViewBytes.Click += new System.EventHandler(this.BtnViewBytes_Click);
            // 
            // LbCaption
            // 
            this.LbCaption.AutoSize = true;
            this.LbCaption.Location = new System.Drawing.Point(12, 11);
            this.LbCaption.Name = "LbCaption";
            this.LbCaption.Size = new System.Drawing.Size(65, 13);
            this.LbCaption.TabIndex = 11;
            this.LbCaption.Text = "Enter range:";
            // 
            // Lb2
            // 
            this.Lb2.AutoSize = true;
            this.Lb2.Location = new System.Drawing.Point(124, 39);
            this.Lb2.Name = "Lb2";
            this.Lb2.Size = new System.Drawing.Size(20, 13);
            this.Lb2.TabIndex = 10;
            this.Lb2.Text = "To";
            // 
            // Lb1
            // 
            this.Lb1.AutoSize = true;
            this.Lb1.Location = new System.Drawing.Point(12, 39);
            this.Lb1.Name = "Lb1";
            this.Lb1.Size = new System.Drawing.Size(30, 13);
            this.Lb1.TabIndex = 9;
            this.Lb1.Text = "From";
            // 
            // Txt2
            // 
            this.Txt2.Location = new System.Drawing.Point(150, 37);
            this.Txt2.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.Txt2.Name = "Txt2";
            this.Txt2.Size = new System.Drawing.Size(70, 20);
            this.Txt2.TabIndex = 8;
            // 
            // Txt1
            // 
            this.Txt1.Location = new System.Drawing.Point(48, 37);
            this.Txt1.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.Txt1.Name = "Txt1";
            this.Txt1.Size = new System.Drawing.Size(70, 20);
            this.Txt1.TabIndex = 7;
            // 
            // BtnSetBytes
            // 
            this.BtnSetBytes.Image = global::TileGameMaker.Properties.Resources.pencil;
            this.BtnSetBytes.Location = new System.Drawing.Point(141, 73);
            this.BtnSetBytes.Name = "BtnSetBytes";
            this.BtnSetBytes.Size = new System.Drawing.Size(120, 28);
            this.BtnSetBytes.TabIndex = 13;
            this.BtnSetBytes.Text = "   Set bytes";
            this.BtnSetBytes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSetBytes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnSetBytes.UseVisualStyleBackColor = true;
            this.BtnSetBytes.Click += new System.EventHandler(this.BtnSetBytes_Click);
            // 
            // TxtBytes
            // 
            this.TxtBytes.AcceptsReturn = true;
            this.TxtBytes.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBytes.Location = new System.Drawing.Point(15, 118);
            this.TxtBytes.Multiline = true;
            this.TxtBytes.Name = "TxtBytes";
            this.TxtBytes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtBytes.Size = new System.Drawing.Size(246, 320);
            this.TxtBytes.TabIndex = 14;
            this.TxtBytes.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 447);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "The valid format for each line is:";
            // 
            // LbValidLineFormat
            // 
            this.LbValidLineFormat.AutoSize = true;
            this.LbValidLineFormat.Location = new System.Drawing.Point(15, 464);
            this.LbValidLineFormat.Name = "LbValidLineFormat";
            this.LbValidLineFormat.Size = new System.Drawing.Size(10, 13);
            this.LbValidLineFormat.TabIndex = 16;
            this.LbValidLineFormat.Text = "-";
            // 
            // BinaryCodeSequenceWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 492);
            this.Controls.Add(this.LbValidLineFormat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtBytes);
            this.Controls.Add(this.BtnSetBytes);
            this.Controls.Add(this.BtnViewBytes);
            this.Controls.Add(this.LbCaption);
            this.Controls.Add(this.Lb2);
            this.Controls.Add(this.Lb1);
            this.Controls.Add(this.Txt2);
            this.Controls.Add(this.Txt1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BinaryCodeSequenceWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.Txt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnViewBytes;
        private System.Windows.Forms.Label LbCaption;
        private System.Windows.Forms.Label Lb2;
        private System.Windows.Forms.Label Lb1;
        private System.Windows.Forms.NumericUpDown Txt2;
        private System.Windows.Forms.NumericUpDown Txt1;
        private System.Windows.Forms.Button BtnSetBytes;
        private System.Windows.Forms.TextBox TxtBytes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LbValidLineFormat;
    }
}