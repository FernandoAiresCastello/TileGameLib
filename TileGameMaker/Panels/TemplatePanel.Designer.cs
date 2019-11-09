namespace TileGameMaker.Panels
{
    partial class TemplatePanel
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
            this.AnimationPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PropertyGrid = new TileGameMaker.Panels.ObjectPropertyGridPanel();
            this.ChkVisible = new System.Windows.Forms.CheckBox();
            this.TxtTag = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtFrames = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnClear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.AnimationPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(288, 328);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // AnimationPanel
            // 
            this.AnimationPanel.BackColor = System.Drawing.Color.White;
            this.AnimationPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.AnimationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AnimationPanel.Location = new System.Drawing.Point(3, 3);
            this.AnimationPanel.Name = "AnimationPanel";
            this.AnimationPanel.Size = new System.Drawing.Size(282, 28);
            this.AnimationPanel.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.PropertyGrid);
            this.panel2.Controls.Add(this.ChkVisible);
            this.panel2.Controls.Add(this.TxtTag);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.TxtFrames);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.BtnClear);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 37);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10, 10, 10, 15);
            this.panel2.Size = new System.Drawing.Size(282, 288);
            this.panel2.TabIndex = 2;
            // 
            // PropertyGrid
            // 
            this.PropertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PropertyGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PropertyGrid.Location = new System.Drawing.Point(11, 94);
            this.PropertyGrid.Margin = new System.Windows.Forms.Padding(0);
            this.PropertyGrid.Name = "PropertyGrid";
            this.PropertyGrid.Size = new System.Drawing.Size(258, 138);
            this.PropertyGrid.TabIndex = 15;
            // 
            // ChkVisible
            // 
            this.ChkVisible.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ChkVisible.AutoSize = true;
            this.ChkVisible.Checked = true;
            this.ChkVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkVisible.Location = new System.Drawing.Point(207, 70);
            this.ChkVisible.Name = "ChkVisible";
            this.ChkVisible.Size = new System.Drawing.Size(62, 19);
            this.ChkVisible.TabIndex = 14;
            this.ChkVisible.Text = "Visible";
            this.ChkVisible.UseVisualStyleBackColor = true;
            this.ChkVisible.CheckedChanged += new System.EventHandler(this.ChkVisible_CheckedChanged);
            // 
            // TxtTag
            // 
            this.TxtTag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtTag.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTag.Location = new System.Drawing.Point(64, 32);
            this.TxtTag.MaxLength = 256;
            this.TxtTag.Name = "TxtTag";
            this.TxtTag.Size = new System.Drawing.Size(205, 23);
            this.TxtTag.TabIndex = 13;
            this.TxtTag.Text = "Tag";
            this.TxtTag.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtTag.Leave += new System.EventHandler(this.TxtTag_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Tag";
            // 
            // TxtFrames
            // 
            this.TxtFrames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtFrames.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFrames.Location = new System.Drawing.Point(64, 3);
            this.TxtFrames.MaxLength = 2;
            this.TxtFrames.Name = "TxtFrames";
            this.TxtFrames.Size = new System.Drawing.Size(205, 23);
            this.TxtFrames.TabIndex = 8;
            this.TxtFrames.Text = "0";
            this.TxtFrames.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtFrames.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBox_KeyPress);
            this.TxtFrames.Leave += new System.EventHandler(this.TxtFrames_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Frames";
            // 
            // BtnClear
            // 
            this.BtnClear.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnClear.Image = global::TileGameMaker.Properties.Resources.draw_eraser;
            this.BtnClear.Location = new System.Drawing.Point(10, 243);
            this.BtnClear.Margin = new System.Windows.Forms.Padding(0, 3, 0, 5);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(262, 30);
            this.BtnClear.TabIndex = 6;
            this.BtnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Properties";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TemplatePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TemplatePanel";
            this.Size = new System.Drawing.Size(288, 328);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel AnimationPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox TxtFrames;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtTag;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ChkVisible;
        private ObjectPropertyGridPanel PropertyGrid;
    }
}
