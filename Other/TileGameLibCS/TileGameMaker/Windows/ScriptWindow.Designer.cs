namespace TileGameMaker.Windows
{
    partial class ScriptWindow
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
            this.TxtScript = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnRun = new System.Windows.Forms.Button();
            this.TxtOutput = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.TxtOutput, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TxtScript, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(368, 374);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // TxtScript
            // 
            this.TxtScript.AcceptsTab = true;
            this.TxtScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtScript.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtScript.Location = new System.Drawing.Point(3, 3);
            this.TxtScript.Multiline = true;
            this.TxtScript.Name = "TxtScript";
            this.TxtScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtScript.Size = new System.Drawing.Size(362, 228);
            this.TxtScript.TabIndex = 0;
            this.TxtScript.WordWrap = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnRun);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 328);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(362, 43);
            this.panel1.TabIndex = 1;
            // 
            // BtnRun
            // 
            this.BtnRun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnRun.Image = global::TileGameMaker.Properties.Resources.script_lightning1;
            this.BtnRun.Location = new System.Drawing.Point(0, 0);
            this.BtnRun.Name = "BtnRun";
            this.BtnRun.Size = new System.Drawing.Size(362, 43);
            this.BtnRun.TabIndex = 2;
            this.BtnRun.UseVisualStyleBackColor = true;
            this.BtnRun.Click += new System.EventHandler(this.BtnRun_Click);
            // 
            // TxtOutput
            // 
            this.TxtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtOutput.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtOutput.Location = new System.Drawing.Point(3, 237);
            this.TxtOutput.Multiline = true;
            this.TxtOutput.Name = "TxtOutput";
            this.TxtOutput.ReadOnly = true;
            this.TxtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtOutput.Size = new System.Drawing.Size(362, 85);
            this.TxtOutput.TabIndex = 2;
            this.TxtOutput.WordWrap = false;
            // 
            // ScriptWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 374);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.Name = "ScriptWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Run editor script";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ScriptWindow_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox TxtScript;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnRun;
        private System.Windows.Forms.TextBox TxtOutput;
    }
}