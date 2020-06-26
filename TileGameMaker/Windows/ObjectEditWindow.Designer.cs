namespace TileGameMaker.Windows
{
    partial class ObjectEditWindow
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.TxtFrames = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnClearAnim = new System.Windows.Forms.Button();
            this.AnimationPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ChkVisible = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PropertyGrid = new TileGameMaker.Panels.ObjectPropertyGridPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnRevert = new System.Windows.Forms.Button();
            this.BtnClear = new System.Windows.Forms.Button();
            this.BtnApply = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFrames)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.PropertyGrid, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 159F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 146F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(242, 290);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TxtFrames);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(5, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(232, 31);
            this.panel2.TabIndex = 11;
            // 
            // TxtFrames
            // 
            this.TxtFrames.Location = new System.Drawing.Point(150, 6);
            this.TxtFrames.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.TxtFrames.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TxtFrames.Name = "TxtFrames";
            this.TxtFrames.Size = new System.Drawing.Size(82, 20);
            this.TxtFrames.TabIndex = 6;
            this.TxtFrames.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Frames";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 196F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.BtnClearAnim, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.AnimationPanel, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(5, 31);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(232, 30);
            this.tableLayoutPanel3.TabIndex = 10;
            // 
            // BtnClearAnim
            // 
            this.BtnClearAnim.Image = global::TileGameMaker.Properties.Resources.broom;
            this.BtnClearAnim.Location = new System.Drawing.Point(198, 0);
            this.BtnClearAnim.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.BtnClearAnim.Name = "BtnClearAnim";
            this.BtnClearAnim.Size = new System.Drawing.Size(34, 28);
            this.BtnClearAnim.TabIndex = 6;
            this.BtnClearAnim.UseVisualStyleBackColor = true;
            this.BtnClearAnim.Click += new System.EventHandler(this.BtnClearAnim_Click);
            // 
            // AnimationPanel
            // 
            this.AnimationPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.AnimationPanel.Location = new System.Drawing.Point(0, 0);
            this.AnimationPanel.Margin = new System.Windows.Forms.Padding(0);
            this.AnimationPanel.Name = "AnimationPanel";
            this.AnimationPanel.Size = new System.Drawing.Size(196, 28);
            this.AnimationPanel.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ChkVisible);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(5, 61);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(232, 31);
            this.panel1.TabIndex = 4;
            // 
            // ChkVisible
            // 
            this.ChkVisible.AutoSize = true;
            this.ChkVisible.Location = new System.Drawing.Point(172, 9);
            this.ChkVisible.Margin = new System.Windows.Forms.Padding(0);
            this.ChkVisible.Name = "ChkVisible";
            this.ChkVisible.Size = new System.Drawing.Size(56, 17);
            this.ChkVisible.TabIndex = 6;
            this.ChkVisible.Text = "Visible";
            this.ChkVisible.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Properties";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PropertyGrid
            // 
            this.PropertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PropertyGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PropertyGrid.Location = new System.Drawing.Point(5, 92);
            this.PropertyGrid.Margin = new System.Windows.Forms.Padding(0);
            this.PropertyGrid.Name = "PropertyGrid";
            this.PropertyGrid.Size = new System.Drawing.Size(232, 159);
            this.PropertyGrid.TabIndex = 8;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.99813F));
            this.tableLayoutPanel2.Controls.Add(this.BtnRevert, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnClear, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnApply, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(5, 251);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(232, 33);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // BtnRevert
            // 
            this.BtnRevert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnRevert.Image = global::TileGameMaker.Properties.Resources.undo;
            this.BtnRevert.Location = new System.Drawing.Point(116, 4);
            this.BtnRevert.Margin = new System.Windows.Forms.Padding(0);
            this.BtnRevert.Name = "BtnRevert";
            this.BtnRevert.Size = new System.Drawing.Size(58, 29);
            this.BtnRevert.TabIndex = 2;
            this.BtnRevert.UseVisualStyleBackColor = true;
            this.BtnRevert.Click += new System.EventHandler(this.BtnRevert_Click);
            // 
            // BtnClear
            // 
            this.BtnClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnClear.Image = global::TileGameMaker.Properties.Resources.draw_eraser;
            this.BtnClear.Location = new System.Drawing.Point(174, 4);
            this.BtnClear.Margin = new System.Windows.Forms.Padding(0);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(58, 29);
            this.BtnClear.TabIndex = 1;
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // BtnApply
            // 
            this.BtnApply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnApply.Image = global::TileGameMaker.Properties.Resources.tick;
            this.BtnApply.Location = new System.Drawing.Point(0, 4);
            this.BtnApply.Margin = new System.Windows.Forms.Padding(0);
            this.BtnApply.Name = "BtnApply";
            this.BtnApply.Size = new System.Drawing.Size(58, 29);
            this.BtnApply.TabIndex = 0;
            this.BtnApply.UseVisualStyleBackColor = true;
            this.BtnApply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // ObjectEditWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 290);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ObjectEditWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFrames)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private Panels.ObjectPropertyGridPanel PropertyGrid;
        private System.Windows.Forms.CheckBox ChkVisible;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button BtnApply;
        private System.Windows.Forms.Button BtnRevert;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown TxtFrames;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button BtnClearAnim;
        private System.Windows.Forms.Panel AnimationPanel;
    }
}