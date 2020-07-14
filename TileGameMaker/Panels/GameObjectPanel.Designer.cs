namespace TileGameMaker.Panels
{
    partial class GameObjectPanel
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TxtObject = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.TxtClipboard = new System.Windows.Forms.TextBox();
            this.ClipboardPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(224, 342);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.TxtObject, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.02924F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.97076F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(224, 342);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // TxtObject
            // 
            this.TxtObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtObject.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtObject.Location = new System.Drawing.Point(0, 0);
            this.TxtObject.Margin = new System.Windows.Forms.Padding(0);
            this.TxtObject.Multiline = true;
            this.TxtObject.Name = "TxtObject";
            this.TxtObject.ReadOnly = true;
            this.TxtObject.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtObject.Size = new System.Drawing.Size(224, 153);
            this.TxtObject.TabIndex = 2;
            this.TxtObject.WordWrap = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.TxtClipboard, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ClipboardPanel, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 153);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.83099F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.16901F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(224, 189);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // TxtClipboard
            // 
            this.TxtClipboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtClipboard.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtClipboard.Location = new System.Drawing.Point(0, 0);
            this.TxtClipboard.Margin = new System.Windows.Forms.Padding(0);
            this.TxtClipboard.Multiline = true;
            this.TxtClipboard.Name = "TxtClipboard";
            this.TxtClipboard.ReadOnly = true;
            this.TxtClipboard.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtClipboard.Size = new System.Drawing.Size(224, 135);
            this.TxtClipboard.TabIndex = 4;
            this.TxtClipboard.WordWrap = false;
            // 
            // ClipboardPanel
            // 
            this.ClipboardPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClipboardPanel.Location = new System.Drawing.Point(3, 138);
            this.ClipboardPanel.Name = "ClipboardPanel";
            this.ClipboardPanel.Size = new System.Drawing.Size(218, 48);
            this.ClipboardPanel.TabIndex = 5;
            // 
            // GameObjectPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "GameObjectPanel";
            this.Size = new System.Drawing.Size(224, 342);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox TxtObject;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox TxtClipboard;
        private System.Windows.Forms.Panel ClipboardPanel;
    }
}
