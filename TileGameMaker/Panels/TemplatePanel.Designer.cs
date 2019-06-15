namespace TileGameMaker.Panels
{
    partial class TemplateControl
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
            this.LblParamHex = new System.Windows.Forms.Label();
            this.LblTypeHex = new System.Windows.Forms.Label();
            this.TxtFrames = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtData = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtParam = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtType = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnExpandData = new System.Windows.Forms.Button();
            this.BtnClear = new System.Windows.Forms.Button();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(288, 317);
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
            this.panel2.Controls.Add(this.BtnExpandData);
            this.panel2.Controls.Add(this.LblParamHex);
            this.panel2.Controls.Add(this.LblTypeHex);
            this.panel2.Controls.Add(this.TxtFrames);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.BtnClear);
            this.panel2.Controls.Add(this.TxtData);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.TxtParam);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.TxtType);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 37);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(282, 277);
            this.panel2.TabIndex = 2;
            // 
            // LblParamHex
            // 
            this.LblParamHex.AutoSize = true;
            this.LblParamHex.Font = new System.Drawing.Font("Consolas", 9F);
            this.LblParamHex.Location = new System.Drawing.Point(123, 61);
            this.LblParamHex.Name = "LblParamHex";
            this.LblParamHex.Size = new System.Drawing.Size(35, 14);
            this.LblParamHex.TabIndex = 10;
            this.LblParamHex.Text = "0x00";
            // 
            // LblTypeHex
            // 
            this.LblTypeHex.AutoSize = true;
            this.LblTypeHex.Font = new System.Drawing.Font("Consolas", 9F);
            this.LblTypeHex.Location = new System.Drawing.Point(123, 35);
            this.LblTypeHex.Name = "LblTypeHex";
            this.LblTypeHex.Size = new System.Drawing.Size(35, 14);
            this.LblTypeHex.TabIndex = 9;
            this.LblTypeHex.Text = "0x00";
            // 
            // TxtFrames
            // 
            this.TxtFrames.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFrames.Location = new System.Drawing.Point(59, 6);
            this.TxtFrames.MaxLength = 2;
            this.TxtFrames.Name = "TxtFrames";
            this.TxtFrames.Size = new System.Drawing.Size(58, 23);
            this.TxtFrames.TabIndex = 8;
            this.TxtFrames.Text = "0";
            this.TxtFrames.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBox_KeyPress);
            this.TxtFrames.Leave += new System.EventHandler(this.TxtFrames_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Frames";
            // 
            // TxtData
            // 
            this.TxtData.AcceptsReturn = true;
            this.TxtData.AcceptsTab = true;
            this.TxtData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtData.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtData.Location = new System.Drawing.Point(59, 85);
            this.TxtData.MaxLength = 65536;
            this.TxtData.Multiline = true;
            this.TxtData.Name = "TxtData";
            this.TxtData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtData.Size = new System.Drawing.Size(212, 179);
            this.TxtData.TabIndex = 5;
            this.TxtData.WordWrap = false;
            this.TxtData.Leave += new System.EventHandler(this.TxtBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Data";
            // 
            // TxtParam
            // 
            this.TxtParam.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtParam.Location = new System.Drawing.Point(59, 58);
            this.TxtParam.MaxLength = 3;
            this.TxtParam.Name = "TxtParam";
            this.TxtParam.Size = new System.Drawing.Size(58, 23);
            this.TxtParam.TabIndex = 3;
            this.TxtParam.Text = "0";
            this.TxtParam.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBox_KeyPress);
            this.TxtParam.Leave += new System.EventHandler(this.TxtBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Param";
            // 
            // TxtType
            // 
            this.TxtType.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtType.Location = new System.Drawing.Point(59, 32);
            this.TxtType.MaxLength = 3;
            this.TxtType.Name = "TxtType";
            this.TxtType.Size = new System.Drawing.Size(58, 23);
            this.TxtType.TabIndex = 1;
            this.TxtType.Text = "0";
            this.TxtType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBox_KeyPress);
            this.TxtType.Leave += new System.EventHandler(this.TxtBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Type";
            // 
            // BtnExpandData
            // 
            this.BtnExpandData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnExpandData.Image = global::TileGameMaker.Properties.Resources.scroll_pane_text;
            this.BtnExpandData.Location = new System.Drawing.Point(7, 198);
            this.BtnExpandData.Name = "BtnExpandData";
            this.BtnExpandData.Size = new System.Drawing.Size(41, 30);
            this.BtnExpandData.TabIndex = 11;
            this.BtnExpandData.UseVisualStyleBackColor = true;
            this.BtnExpandData.Click += new System.EventHandler(this.BtnExpandData_Click);
            // 
            // BtnClear
            // 
            this.BtnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnClear.Image = global::TileGameMaker.Properties.Resources.cross;
            this.BtnClear.Location = new System.Drawing.Point(7, 234);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(41, 30);
            this.BtnClear.TabIndex = 6;
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // TemplateControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TemplateControl";
            this.Size = new System.Drawing.Size(288, 317);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel AnimationPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LblParamHex;
        private System.Windows.Forms.Label LblTypeHex;
        private System.Windows.Forms.TextBox TxtFrames;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.TextBox TxtData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtParam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnExpandData;
    }
}
