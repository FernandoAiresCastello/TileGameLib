namespace TileGameMaker.Windows
{
    partial class ProjectSettingsWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.TxtProjectName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtCols = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtRows = new System.Windows.Forms.NumericUpDown();
            this.TxtMagnification = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnOk = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtHeight = new System.Windows.Forms.NumericUpDown();
            this.TxtWidth = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCols)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMagnification)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Project name:";
            // 
            // TxtProjectName
            // 
            this.TxtProjectName.Location = new System.Drawing.Point(91, 10);
            this.TxtProjectName.Name = "TxtProjectName";
            this.TxtProjectName.Size = new System.Drawing.Size(288, 20);
            this.TxtProjectName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Columns:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(124, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Rows:";
            // 
            // TxtCols
            // 
            this.TxtCols.Location = new System.Drawing.Point(68, 22);
            this.TxtCols.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.TxtCols.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TxtCols.Name = "TxtCols";
            this.TxtCols.Size = new System.Drawing.Size(50, 20);
            this.TxtCols.TabIndex = 5;
            this.TxtCols.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(223, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Magnification:";
            // 
            // TxtRows
            // 
            this.TxtRows.Location = new System.Drawing.Point(167, 22);
            this.TxtRows.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.TxtRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TxtRows.Name = "TxtRows";
            this.TxtRows.Size = new System.Drawing.Size(50, 20);
            this.TxtRows.TabIndex = 7;
            this.TxtRows.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // TxtMagnification
            // 
            this.TxtMagnification.Location = new System.Drawing.Point(302, 22);
            this.TxtMagnification.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.TxtMagnification.Name = "TxtMagnification";
            this.TxtMagnification.Size = new System.Drawing.Size(50, 20);
            this.TxtMagnification.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.TxtHeight);
            this.groupBox1.Controls.Add(this.TxtWidth);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TxtMagnification);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TxtRows);
            this.groupBox1.Controls.Add(this.TxtCols);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(13, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 78);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Engine window size";
            // 
            // BtnOk
            // 
            this.BtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOk.Image = global::TileGameMaker.Properties.Resources.tick;
            this.BtnOk.Location = new System.Drawing.Point(116, 129);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(75, 32);
            this.BtnOk.TabIndex = 10;
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Image = global::TileGameMaker.Properties.Resources.cross;
            this.BtnCancel.Location = new System.Drawing.Point(197, 129);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 32);
            this.BtnCancel.TabIndex = 11;
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Width:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(124, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Height";
            // 
            // TxtHeight
            // 
            this.TxtHeight.Location = new System.Drawing.Point(167, 47);
            this.TxtHeight.Maximum = new decimal(new int[] {
            768,
            0,
            0,
            0});
            this.TxtHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TxtHeight.Name = "TxtHeight";
            this.TxtHeight.Size = new System.Drawing.Size(50, 20);
            this.TxtHeight.TabIndex = 12;
            this.TxtHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // TxtWidth
            // 
            this.TxtWidth.Location = new System.Drawing.Point(68, 47);
            this.TxtWidth.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.TxtWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TxtWidth.Name = "TxtWidth";
            this.TxtWidth.Size = new System.Drawing.Size(50, 20);
            this.TxtWidth.TabIndex = 11;
            this.TxtWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ProjectSettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 171);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TxtProjectName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ProjectSettingsWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Settings";
            ((System.ComponentModel.ISupportInitialize)(this.TxtCols)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMagnification)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtProjectName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown TxtCols;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown TxtRows;
        private System.Windows.Forms.NumericUpDown TxtMagnification;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown TxtHeight;
        private System.Windows.Forms.NumericUpDown TxtWidth;
    }
}