namespace TileGameEngine.Windows
{
    partial class DebuggerWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DebuggerWindow));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LstScript = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnReset = new System.Windows.Forms.Button();
            this.BtnJump = new System.Windows.Forms.Button();
            this.BtnSkip = new System.Windows.Forms.Button();
            this.BtnExecute = new System.Windows.Forms.Button();
            this.TxtCurrentLine = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TxtLog = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtVariables = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.LstParamStack = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.LstCallStack = new System.Windows.Forms.ListBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.LstLabels = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MiClose = new System.Windows.Forms.ToolStripMenuItem();
            this.MiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MiExecute = new System.Windows.Forms.ToolStripMenuItem();
            this.MiSkip = new System.Windows.Forms.ToolStripMenuItem();
            this.MiJump = new System.Windows.Forms.ToolStripMenuItem();
            this.MiReset = new System.Windows.Forms.ToolStripMenuItem();
            this.gameWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnGameWinAlwaysOnTop = new System.Windows.Forms.ToolStripMenuItem();
            this.TxtMapCursor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.LstScript);
            this.groupBox1.Location = new System.Drawing.Point(12, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox1.Size = new System.Drawing.Size(429, 193);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Script";
            // 
            // LstScript
            // 
            this.LstScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LstScript.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstScript.FormattingEnabled = true;
            this.LstScript.Items.AddRange(new object[] {
            "00 SCRIPT test"});
            this.LstScript.Location = new System.Drawing.Point(10, 23);
            this.LstScript.Name = "LstScript";
            this.LstScript.Size = new System.Drawing.Size(409, 160);
            this.LstScript.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.BtnReset);
            this.groupBox2.Controls.Add(this.BtnJump);
            this.groupBox2.Controls.Add(this.BtnSkip);
            this.groupBox2.Controls.Add(this.BtnExecute);
            this.groupBox2.Controls.Add(this.TxtCurrentLine);
            this.groupBox2.Location = new System.Drawing.Point(447, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox2.Size = new System.Drawing.Size(530, 89);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Current line";
            // 
            // BtnReset
            // 
            this.BtnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnReset.Location = new System.Drawing.Point(412, 48);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(105, 28);
            this.BtnReset.TabIndex = 4;
            this.BtnReset.Text = "Reset [CTRL+R]";
            this.BtnReset.UseVisualStyleBackColor = true;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // BtnJump
            // 
            this.BtnJump.Location = new System.Drawing.Point(193, 49);
            this.BtnJump.Name = "BtnJump";
            this.BtnJump.Size = new System.Drawing.Size(84, 28);
            this.BtnJump.TabIndex = 3;
            this.BtnJump.Text = "Jump [F7]";
            this.BtnJump.UseVisualStyleBackColor = true;
            this.BtnJump.Click += new System.EventHandler(this.BtnJump_Click);
            // 
            // BtnSkip
            // 
            this.BtnSkip.Location = new System.Drawing.Point(103, 49);
            this.BtnSkip.Name = "BtnSkip";
            this.BtnSkip.Size = new System.Drawing.Size(84, 28);
            this.BtnSkip.TabIndex = 2;
            this.BtnSkip.Text = "Skip [F6]";
            this.BtnSkip.UseVisualStyleBackColor = true;
            this.BtnSkip.Click += new System.EventHandler(this.BtnSkip_Click);
            // 
            // BtnExecute
            // 
            this.BtnExecute.Location = new System.Drawing.Point(13, 49);
            this.BtnExecute.Name = "BtnExecute";
            this.BtnExecute.Size = new System.Drawing.Size(84, 28);
            this.BtnExecute.TabIndex = 1;
            this.BtnExecute.Text = "Execute [F5]";
            this.BtnExecute.UseVisualStyleBackColor = true;
            this.BtnExecute.Click += new System.EventHandler(this.BtnExecute_Click);
            // 
            // TxtCurrentLine
            // 
            this.TxtCurrentLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtCurrentLine.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCurrentLine.Location = new System.Drawing.Point(13, 23);
            this.TxtCurrentLine.Name = "TxtCurrentLine";
            this.TxtCurrentLine.ReadOnly = true;
            this.TxtCurrentLine.Size = new System.Drawing.Size(504, 20);
            this.TxtCurrentLine.TabIndex = 0;
            this.TxtCurrentLine.Text = "00 SCRIPT test";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.TxtMapCursor);
            this.groupBox3.Controls.Add(this.TxtLog);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.TxtVariables);
            this.groupBox3.Location = new System.Drawing.Point(447, 133);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox3.Size = new System.Drawing.Size(530, 497);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Environment";
            // 
            // TxtLog
            // 
            this.TxtLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtLog.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLog.Location = new System.Drawing.Point(13, 339);
            this.TxtLog.MaxLength = 65536;
            this.TxtLog.Multiline = true;
            this.TxtLog.Name = "TxtLog";
            this.TxtLog.ReadOnly = true;
            this.TxtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtLog.Size = new System.Drawing.Size(504, 145);
            this.TxtLog.TabIndex = 5;
            this.TxtLog.Text = "This is a log message";
            this.TxtLog.WordWrap = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 316);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Log";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(167, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Variables";
            // 
            // TxtVariables
            // 
            this.TxtVariables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtVariables.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtVariables.Location = new System.Drawing.Point(170, 54);
            this.TxtVariables.MaxLength = 65536;
            this.TxtVariables.Multiline = true;
            this.TxtVariables.Name = "TxtVariables";
            this.TxtVariables.ReadOnly = true;
            this.TxtVariables.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtVariables.Size = new System.Drawing.Size(341, 251);
            this.TxtVariables.TabIndex = 2;
            this.TxtVariables.Text = "env.variable_test = 0";
            this.TxtVariables.WordWrap = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.LstParamStack);
            this.groupBox4.Location = new System.Drawing.Point(12, 237);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox4.Size = new System.Drawing.Size(429, 206);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Parameter stack";
            // 
            // LstParamStack
            // 
            this.LstParamStack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LstParamStack.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstParamStack.FormattingEnabled = true;
            this.LstParamStack.Items.AddRange(new object[] {
            "test"});
            this.LstParamStack.Location = new System.Drawing.Point(10, 23);
            this.LstParamStack.Name = "LstParamStack";
            this.LstParamStack.Size = new System.Drawing.Size(409, 173);
            this.LstParamStack.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.LstCallStack);
            this.groupBox5.Location = new System.Drawing.Point(313, 449);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox5.Size = new System.Drawing.Size(128, 181);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Call stack";
            // 
            // LstCallStack
            // 
            this.LstCallStack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LstCallStack.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstCallStack.FormattingEnabled = true;
            this.LstCallStack.Items.AddRange(new object[] {
            "test"});
            this.LstCallStack.Location = new System.Drawing.Point(10, 23);
            this.LstCallStack.Name = "LstCallStack";
            this.LstCallStack.Size = new System.Drawing.Size(108, 148);
            this.LstCallStack.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.LstLabels);
            this.groupBox6.Location = new System.Drawing.Point(12, 449);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox6.Size = new System.Drawing.Size(295, 181);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Labels";
            // 
            // LstLabels
            // 
            this.LstLabels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LstLabels.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstLabels.FormattingEnabled = true;
            this.LstLabels.Items.AddRange(new object[] {
            "test"});
            this.LstLabels.Location = new System.Drawing.Point(10, 23);
            this.LstLabels.Name = "LstLabels";
            this.LstLabels.Size = new System.Drawing.Size(275, 148);
            this.LstLabels.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.fileToolStripMenuItem,
            this.gameWindowToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(990, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiClose,
            this.MiExit});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem1.Text = "File";
            // 
            // MiClose
            // 
            this.MiClose.Name = "MiClose";
            this.MiClose.Size = new System.Drawing.Size(165, 22);
            this.MiClose.Text = "Close";
            this.MiClose.Click += new System.EventHandler(this.MiClose_Click);
            // 
            // MiExit
            // 
            this.MiExit.Name = "MiExit";
            this.MiExit.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.X)));
            this.MiExit.Size = new System.Drawing.Size(165, 22);
            this.MiExit.Text = "Exit";
            this.MiExit.Click += new System.EventHandler(this.MiExit_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiExecute,
            this.MiSkip,
            this.MiJump,
            this.MiReset});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.fileToolStripMenuItem.Text = "Debug";
            // 
            // MiExecute
            // 
            this.MiExecute.Name = "MiExecute";
            this.MiExecute.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.MiExecute.Size = new System.Drawing.Size(196, 22);
            this.MiExecute.Text = "Execute current line";
            this.MiExecute.Click += new System.EventHandler(this.BtnExecute_Click);
            // 
            // MiSkip
            // 
            this.MiSkip.Name = "MiSkip";
            this.MiSkip.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.MiSkip.Size = new System.Drawing.Size(196, 22);
            this.MiSkip.Text = "Skip current line";
            this.MiSkip.Click += new System.EventHandler(this.BtnSkip_Click);
            // 
            // MiJump
            // 
            this.MiJump.Name = "MiJump";
            this.MiJump.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.MiJump.Size = new System.Drawing.Size(196, 22);
            this.MiJump.Text = "Jump to line";
            this.MiJump.Click += new System.EventHandler(this.BtnJump_Click);
            // 
            // MiReset
            // 
            this.MiReset.Name = "MiReset";
            this.MiReset.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.MiReset.Size = new System.Drawing.Size(196, 22);
            this.MiReset.Text = "Reset";
            this.MiReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // gameWindowToolStripMenuItem
            // 
            this.gameWindowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnGameWinAlwaysOnTop});
            this.gameWindowToolStripMenuItem.Name = "gameWindowToolStripMenuItem";
            this.gameWindowToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.gameWindowToolStripMenuItem.Text = "Game Window";
            // 
            // BtnGameWinAlwaysOnTop
            // 
            this.BtnGameWinAlwaysOnTop.Name = "BtnGameWinAlwaysOnTop";
            this.BtnGameWinAlwaysOnTop.Size = new System.Drawing.Size(149, 22);
            this.BtnGameWinAlwaysOnTop.Text = "Always on top";
            this.BtnGameWinAlwaysOnTop.Click += new System.EventHandler(this.BtnGameWinAlwaysOnTop_Click);
            // 
            // TxtMapCursor
            // 
            this.TxtMapCursor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtMapCursor.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMapCursor.Location = new System.Drawing.Point(13, 54);
            this.TxtMapCursor.MaxLength = 65536;
            this.TxtMapCursor.Multiline = true;
            this.TxtMapCursor.Name = "TxtMapCursor";
            this.TxtMapCursor.ReadOnly = true;
            this.TxtMapCursor.Size = new System.Drawing.Size(151, 251);
            this.TxtMapCursor.TabIndex = 6;
            this.TxtMapCursor.Text = "Map cursor";
            this.TxtMapCursor.WordWrap = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Map cursor";
            // 
            // DebuggerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 642);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DebuggerWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tile Game Debugger";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.ListBox LstScript;
        private System.Windows.Forms.TextBox TxtCurrentLine;
        private System.Windows.Forms.Button BtnExecute;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtVariables;
        public System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.ListBox LstParamStack;
        public System.Windows.Forms.GroupBox groupBox5;
        public System.Windows.Forms.ListBox LstCallStack;
        public System.Windows.Forms.GroupBox groupBox6;
        public System.Windows.Forms.ListBox LstLabels;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MiExecute;
        private System.Windows.Forms.ToolStripMenuItem MiReset;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.Button BtnJump;
        private System.Windows.Forms.Button BtnSkip;
        private System.Windows.Forms.ToolStripMenuItem MiSkip;
        private System.Windows.Forms.ToolStripMenuItem MiJump;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem MiExit;
        private System.Windows.Forms.ToolStripMenuItem MiClose;
        private System.Windows.Forms.TextBox TxtLog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem gameWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BtnGameWinAlwaysOnTop;
        private System.Windows.Forms.TextBox TxtMapCursor;
        private System.Windows.Forms.Label label3;
    }
}