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
            this.TxtTag = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnExpandData = new System.Windows.Forms.Button();
            this.TxtFrames = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnClear = new System.Windows.Forms.Button();
            this.TxtProperties = new System.Windows.Forms.TextBox();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(288, 324);
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
            this.panel2.Controls.Add(this.TxtTag);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.BtnExpandData);
            this.panel2.Controls.Add(this.TxtFrames);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.BtnClear);
            this.panel2.Controls.Add(this.TxtProperties);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 37);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(282, 284);
            this.panel2.TabIndex = 2;
            // 
            // TxtTag
            // 
            this.TxtTag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtTag.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTag.Location = new System.Drawing.Point(61, 32);
            this.TxtTag.MaxLength = 256;
            this.TxtTag.Name = "TxtTag";
            this.TxtTag.Size = new System.Drawing.Size(208, 23);
            this.TxtTag.TabIndex = 13;
            this.TxtTag.Text = "Tag";
            this.TxtTag.Leave += new System.EventHandler(this.TxtTag_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Tag";
            // 
            // BtnExpandData
            // 
            this.BtnExpandData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnExpandData.Image = global::TileGameMaker.Properties.Resources.scroll_pane_text;
            this.BtnExpandData.Location = new System.Drawing.Point(9, 241);
            this.BtnExpandData.Name = "BtnExpandData";
            this.BtnExpandData.Size = new System.Drawing.Size(41, 30);
            this.BtnExpandData.TabIndex = 11;
            this.BtnExpandData.UseVisualStyleBackColor = true;
            this.BtnExpandData.Click += new System.EventHandler(this.BtnExpandData_Click);
            // 
            // TxtFrames
            // 
            this.TxtFrames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtFrames.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFrames.Location = new System.Drawing.Point(61, 3);
            this.TxtFrames.MaxLength = 2;
            this.TxtFrames.Name = "TxtFrames";
            this.TxtFrames.Size = new System.Drawing.Size(208, 23);
            this.TxtFrames.TabIndex = 8;
            this.TxtFrames.Text = "0";
            this.TxtFrames.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBox_KeyPress);
            this.TxtFrames.Leave += new System.EventHandler(this.TxtFrames_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Frames";
            // 
            // BtnClear
            // 
            this.BtnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnClear.Image = global::TileGameMaker.Properties.Resources.cross;
            this.BtnClear.Location = new System.Drawing.Point(56, 241);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(41, 30);
            this.BtnClear.TabIndex = 6;
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // TxtProperties
            // 
            this.TxtProperties.AcceptsReturn = true;
            this.TxtProperties.AcceptsTab = true;
            this.TxtProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtProperties.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProperties.Location = new System.Drawing.Point(9, 94);
            this.TxtProperties.MaxLength = 65536;
            this.TxtProperties.Multiline = true;
            this.TxtProperties.Name = "TxtProperties";
            this.TxtProperties.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtProperties.Size = new System.Drawing.Size(262, 141);
            this.TxtProperties.TabIndex = 5;
            this.TxtProperties.WordWrap = false;
            this.TxtProperties.Leave += new System.EventHandler(this.TxtProperties_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Properties";
            // 
            // TemplatePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TemplatePanel";
            this.Size = new System.Drawing.Size(288, 324);
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
        private System.Windows.Forms.TextBox TxtProperties;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnExpandData;
        private System.Windows.Forms.TextBox TxtTag;
        private System.Windows.Forms.Label label1;
    }
}
