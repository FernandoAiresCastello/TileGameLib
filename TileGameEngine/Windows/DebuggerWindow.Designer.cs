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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LstScript = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnExecute = new System.Windows.Forms.Button();
            this.TxtCurrentLine = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtVariables = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.LstParamStack = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.LstCallStack = new System.Windows.Forms.ListBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.LstLabels = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MiReset = new System.Windows.Forms.ToolStripMenuItem();
            this.MiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MiExecute = new System.Windows.Forms.ToolStripMenuItem();
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
            this.groupBox1.Controls.Add(this.LstScript);
            this.groupBox1.Location = new System.Drawing.Point(12, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox1.Size = new System.Drawing.Size(215, 260);
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
            this.LstScript.Size = new System.Drawing.Size(195, 227);
            this.LstScript.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnExecute);
            this.groupBox2.Controls.Add(this.TxtCurrentLine);
            this.groupBox2.Location = new System.Drawing.Point(233, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox2.Size = new System.Drawing.Size(620, 59);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Current line";
            // 
            // BtnExecute
            // 
            this.BtnExecute.Location = new System.Drawing.Point(523, 18);
            this.BtnExecute.Name = "BtnExecute";
            this.BtnExecute.Size = new System.Drawing.Size(84, 28);
            this.BtnExecute.TabIndex = 1;
            this.BtnExecute.Text = "Execute";
            this.BtnExecute.UseVisualStyleBackColor = true;
            this.BtnExecute.Click += new System.EventHandler(this.BtnExecute_Click);
            // 
            // TxtCurrentLine
            // 
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
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.TxtVariables);
            this.groupBox3.Location = new System.Drawing.Point(233, 103);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox3.Size = new System.Drawing.Size(620, 474);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Environment";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Variables";
            // 
            // TxtVariables
            // 
            this.TxtVariables.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtVariables.Location = new System.Drawing.Point(13, 49);
            this.TxtVariables.Multiline = true;
            this.TxtVariables.Name = "TxtVariables";
            this.TxtVariables.ReadOnly = true;
            this.TxtVariables.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtVariables.Size = new System.Drawing.Size(594, 412);
            this.TxtVariables.TabIndex = 2;
            this.TxtVariables.Text = "env.variable_test = 0";
            this.TxtVariables.WordWrap = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.LstParamStack);
            this.groupBox4.Location = new System.Drawing.Point(859, 38);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox4.Size = new System.Drawing.Size(215, 260);
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
            this.LstParamStack.Size = new System.Drawing.Size(195, 227);
            this.LstParamStack.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.LstCallStack);
            this.groupBox5.Location = new System.Drawing.Point(859, 304);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox5.Size = new System.Drawing.Size(215, 273);
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
            this.LstCallStack.Size = new System.Drawing.Size(195, 240);
            this.LstCallStack.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.LstLabels);
            this.groupBox6.Location = new System.Drawing.Point(12, 304);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox6.Size = new System.Drawing.Size(215, 273);
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
            this.LstLabels.Size = new System.Drawing.Size(195, 240);
            this.LstLabels.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1090, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiExecute,
            this.MiReset,
            this.toolStripSeparator1,
            this.MiExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.fileToolStripMenuItem.Text = "Menu";
            // 
            // MiReset
            // 
            this.MiReset.Name = "MiReset";
            this.MiReset.Size = new System.Drawing.Size(180, 22);
            this.MiReset.Text = "Reset";
            this.MiReset.Click += new System.EventHandler(this.MiReset_Click);
            // 
            // MiExit
            // 
            this.MiExit.Name = "MiExit";
            this.MiExit.Size = new System.Drawing.Size(180, 22);
            this.MiExit.Text = "Exit";
            this.MiExit.Click += new System.EventHandler(this.MiExit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // MiExecute
            // 
            this.MiExecute.Name = "MiExecute";
            this.MiExecute.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.MiExecute.Size = new System.Drawing.Size(196, 22);
            this.MiExecute.Text = "Execute current line";
            this.MiExecute.Click += new System.EventHandler(this.MiExecute_Click);
            // 
            // DebuggerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 596);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "DebuggerWindow";
            this.Text = "Debugger";
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MiExit;
    }
}