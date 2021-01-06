namespace TileGameMaker.Windows
{
    partial class StartWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartWindow));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.LbCopyright = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LbTitle = new System.Windows.Forms.Label();
            this.LbVersionBuild = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnOpen = new System.Windows.Forms.Button();
            this.BtnNew = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.LstRecent = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CtxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.BtnOpenFileLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnRemoveFromList = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.CtxMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.18307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.81692F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(454, 533);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.MainPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(454, 377);
            this.panel1.TabIndex = 0;
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.RoyalBlue;
            this.MainPanel.Controls.Add(this.tableLayoutPanel2);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Padding = new System.Windows.Forms.Padding(10);
            this.MainPanel.Size = new System.Drawing.Size(454, 377);
            this.MainPanel.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel2.Controls.Add(this.LbCopyright, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.pictureBox1, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.LbTitle, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.LbVersionBuild, 0, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(434, 357);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // LbCopyright
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.LbCopyright, 3);
            this.LbCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbCopyright.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbCopyright.Location = new System.Drawing.Point(1, 214);
            this.LbCopyright.Margin = new System.Windows.Forms.Padding(1);
            this.LbCopyright.Name = "LbCopyright";
            this.LbCopyright.Size = new System.Drawing.Size(432, 50);
            this.LbCopyright.TabIndex = 3;
            this.LbCopyright.Text = "2019 - 2021\r\nDeveloped by Fernando Aires Castello";
            this.LbCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(147, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(138, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // LbTitle
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.LbTitle, 3);
            this.LbTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbTitle.Font = new System.Drawing.Font("Courier New", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbTitle.Location = new System.Drawing.Point(10, 173);
            this.LbTitle.Margin = new System.Windows.Forms.Padding(10);
            this.LbTitle.Name = "LbTitle";
            this.LbTitle.Size = new System.Drawing.Size(414, 30);
            this.LbTitle.TabIndex = 1;
            this.LbTitle.Text = "TILE GAME MAKER";
            this.LbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LbVersionBuild
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.LbVersionBuild, 3);
            this.LbVersionBuild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbVersionBuild.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbVersionBuild.Location = new System.Drawing.Point(1, 266);
            this.LbVersionBuild.Margin = new System.Windows.Forms.Padding(1);
            this.LbVersionBuild.Name = "LbVersionBuild";
            this.LbVersionBuild.Size = new System.Drawing.Size(432, 50);
            this.LbVersionBuild.TabIndex = 2;
            this.LbVersionBuild.Text = "Version {version}\r\nBuild {build}";
            this.LbVersionBuild.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.RoyalBlue;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Controls.Add(this.BtnOpen, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.BtnNew, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 377);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(454, 55);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // BtnOpen
            // 
            this.BtnOpen.BackColor = System.Drawing.Color.CornflowerBlue;
            this.BtnOpen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnOpen.Image = global::TileGameMaker.Properties.Resources.folder1;
            this.BtnOpen.Location = new System.Drawing.Point(232, 0);
            this.BtnOpen.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.BtnOpen.Name = "BtnOpen";
            this.BtnOpen.Size = new System.Drawing.Size(212, 45);
            this.BtnOpen.TabIndex = 1;
            this.BtnOpen.Text = "Open Project";
            this.BtnOpen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnOpen.UseVisualStyleBackColor = false;
            this.BtnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // BtnNew
            // 
            this.BtnNew.BackColor = System.Drawing.Color.CornflowerBlue;
            this.BtnNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnNew.Image = global::TileGameMaker.Properties.Resources.flag_new;
            this.BtnNew.Location = new System.Drawing.Point(10, 0);
            this.BtnNew.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(212, 45);
            this.BtnNew.TabIndex = 0;
            this.BtnNew.Text = "New Project";
            this.BtnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnNew.UseVisualStyleBackColor = false;
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.RoyalBlue;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.LstRecent, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 432);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(454, 101);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // LstRecent
            // 
            this.LstRecent.BackColor = System.Drawing.Color.CornflowerBlue;
            this.LstRecent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LstRecent.ContextMenuStrip = this.CtxMenu;
            this.LstRecent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LstRecent.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstRecent.FormattingEnabled = true;
            this.LstRecent.Location = new System.Drawing.Point(13, 19);
            this.LstRecent.Name = "LstRecent";
            this.LstRecent.ScrollAlwaysVisible = true;
            this.LstRecent.Size = new System.Drawing.Size(428, 69);
            this.LstRecent.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Recent projects:";
            // 
            // CtxMenu
            // 
            this.CtxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnOpenFileLocation,
            this.BtnRemoveFromList});
            this.CtxMenu.Name = "contextMenuStrip1";
            this.CtxMenu.Size = new System.Drawing.Size(169, 48);
            // 
            // BtnOpenFileLocation
            // 
            this.BtnOpenFileLocation.Name = "BtnOpenFileLocation";
            this.BtnOpenFileLocation.Size = new System.Drawing.Size(180, 22);
            this.BtnOpenFileLocation.Text = "Open file location";
            this.BtnOpenFileLocation.Click += new System.EventHandler(this.BtnOpenFileLocation_Click);
            // 
            // BtnRemoveFromList
            // 
            this.BtnRemoveFromList.Name = "BtnRemoveFromList";
            this.BtnRemoveFromList.Size = new System.Drawing.Size(180, 22);
            this.BtnRemoveFromList.Text = "Remove from list";
            this.BtnRemoveFromList.Click += new System.EventHandler(this.BtnRemoveFromList_Click);
            // 
            // StartWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 533);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome!";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.MainPanel.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.CtxMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label LbCopyright;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LbTitle;
        private System.Windows.Forms.Label LbVersionBuild;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button BtnNew;
        private System.Windows.Forms.Button BtnOpen;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox LstRecent;
        private System.Windows.Forms.ContextMenuStrip CtxMenu;
        private System.Windows.Forms.ToolStripMenuItem BtnOpenFileLocation;
        private System.Windows.Forms.ToolStripMenuItem BtnRemoveFromList;
    }
}