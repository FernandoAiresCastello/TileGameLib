namespace TileGameMaker.Windows
{
    partial class SplashWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashWindow));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LbCopyright = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LbTitle = new System.Windows.Forms.Label();
            this.LbVersionBuild = new System.Windows.Forms.Label();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.LbCopyright, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.LbTitle, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.LbVersionBuild, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(457, 430);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Click += new System.EventHandler(this.OnClick);
            // 
            // LbCopyright
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.LbCopyright, 3);
            this.LbCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbCopyright.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbCopyright.Location = new System.Drawing.Point(1, 277);
            this.LbCopyright.Margin = new System.Windows.Forms.Padding(1);
            this.LbCopyright.Name = "LbCopyright";
            this.LbCopyright.Size = new System.Drawing.Size(455, 50);
            this.LbCopyright.TabIndex = 3;
            this.LbCopyright.Text = "2019\r\nDeveloped by Fernando Aires Castello";
            this.LbCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(155, 51);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(146, 157);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.OnClick);
            // 
            // LbTitle
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.LbTitle, 3);
            this.LbTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbTitle.Font = new System.Drawing.Font("Courier New", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbTitle.Location = new System.Drawing.Point(10, 221);
            this.LbTitle.Margin = new System.Windows.Forms.Padding(10);
            this.LbTitle.Name = "LbTitle";
            this.LbTitle.Size = new System.Drawing.Size(437, 45);
            this.LbTitle.TabIndex = 1;
            this.LbTitle.Text = "TILE GAME MAKER";
            this.LbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LbTitle.Click += new System.EventHandler(this.OnClick);
            // 
            // LbVersionBuild
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.LbVersionBuild, 3);
            this.LbVersionBuild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbVersionBuild.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbVersionBuild.Location = new System.Drawing.Point(1, 329);
            this.LbVersionBuild.Margin = new System.Windows.Forms.Padding(1);
            this.LbVersionBuild.Name = "LbVersionBuild";
            this.LbVersionBuild.Size = new System.Drawing.Size(455, 50);
            this.LbVersionBuild.TabIndex = 2;
            this.LbVersionBuild.Text = "Version {version}\r\nBuild {build}";
            this.LbVersionBuild.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LbVersionBuild.Click += new System.EventHandler(this.OnClick);
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.RoyalBlue;
            this.MainPanel.Controls.Add(this.tableLayoutPanel1);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Padding = new System.Windows.Forms.Padding(10);
            this.MainPanel.Size = new System.Drawing.Size(477, 450);
            this.MainPanel.TabIndex = 1;
            this.MainPanel.Click += new System.EventHandler(this.OnClick);
            // 
            // SplashWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 450);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tile Game Maker";
            this.Click += new System.EventHandler(this.OnClick);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.MainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LbTitle;
        private System.Windows.Forms.Label LbVersionBuild;
        private System.Windows.Forms.Label LbCopyright;
    }
}