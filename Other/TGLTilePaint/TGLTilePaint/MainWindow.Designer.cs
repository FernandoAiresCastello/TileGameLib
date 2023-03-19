
namespace TGLTilePaint
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TileEditPanelContainer = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnCurrentColor = new System.Windows.Forms.Button();
            this.BtnReplace = new System.Windows.Forms.Button();
            this.TxtCurrentColor = new System.Windows.Forms.TextBox();
            this.TxtReplaceDst = new System.Windows.Forms.TextBox();
            this.BtnFillLeft = new System.Windows.Forms.Button();
            this.TxtReplaceSrc = new System.Windows.Forms.TextBox();
            this.BtnResetPal = new System.Windows.Forms.Button();
            this.TxtColor3 = new System.Windows.Forms.TextBox();
            this.BtnParsePal = new System.Windows.Forms.Button();
            this.TxtColor2 = new System.Windows.Forms.TextBox();
            this.Btn0 = new System.Windows.Forms.Button();
            this.TxtColor1 = new System.Windows.Forms.TextBox();
            this.Btn1 = new System.Windows.Forms.Button();
            this.TxtColor0 = new System.Windows.Forms.TextBox();
            this.Btn2 = new System.Windows.Forms.Button();
            this.Btn3 = new System.Windows.Forms.Button();
            this.BtnNew2 = new System.Windows.Forms.Button();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnNew = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnLoadBmp = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnSaveBmp = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnTileSize8x8 = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnTileSize16x16 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnToggleMode = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnToggleSubGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnToggleMainGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 466);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(771, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(67, 17);
            this.StatusLabel.Text = "StatusLabel";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.53846F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.46154F));
            this.tableLayoutPanel1.Controls.Add(this.TileEditPanelContainer, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(771, 442);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // TileEditPanelContainer
            // 
            this.TileEditPanelContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TileEditPanelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TileEditPanelContainer.Location = new System.Drawing.Point(3, 3);
            this.TileEditPanelContainer.Name = "TileEditPanelContainer";
            this.TileEditPanelContainer.Size = new System.Drawing.Size(468, 436);
            this.TileEditPanelContainer.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.BtnNew2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(474, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(297, 442);
            this.panel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnCurrentColor);
            this.groupBox1.Controls.Add(this.BtnReplace);
            this.groupBox1.Controls.Add(this.TxtCurrentColor);
            this.groupBox1.Controls.Add(this.TxtReplaceDst);
            this.groupBox1.Controls.Add(this.BtnFillLeft);
            this.groupBox1.Controls.Add(this.TxtReplaceSrc);
            this.groupBox1.Controls.Add(this.BtnResetPal);
            this.groupBox1.Controls.Add(this.TxtColor3);
            this.groupBox1.Controls.Add(this.BtnParsePal);
            this.groupBox1.Controls.Add(this.TxtColor2);
            this.groupBox1.Controls.Add(this.Btn0);
            this.groupBox1.Controls.Add(this.TxtColor1);
            this.groupBox1.Controls.Add(this.Btn1);
            this.groupBox1.Controls.Add(this.TxtColor0);
            this.groupBox1.Controls.Add(this.Btn2);
            this.groupBox1.Controls.Add(this.Btn3);
            this.groupBox1.Location = new System.Drawing.Point(13, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 381);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Color";
            // 
            // BtnCurrentColor
            // 
            this.BtnCurrentColor.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtnCurrentColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCurrentColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCurrentColor.Location = new System.Drawing.Point(34, 61);
            this.BtnCurrentColor.Name = "BtnCurrentColor";
            this.BtnCurrentColor.Size = new System.Drawing.Size(60, 64);
            this.BtnCurrentColor.TabIndex = 5;
            this.BtnCurrentColor.UseVisualStyleBackColor = true;
            this.BtnCurrentColor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnDigit_Click);
            // 
            // BtnReplace
            // 
            this.BtnReplace.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReplace.Location = new System.Drawing.Point(21, 332);
            this.BtnReplace.Name = "BtnReplace";
            this.BtnReplace.Size = new System.Drawing.Size(90, 30);
            this.BtnReplace.TabIndex = 24;
            this.BtnReplace.Text = "Replace";
            this.BtnReplace.UseVisualStyleBackColor = true;
            this.BtnReplace.Click += new System.EventHandler(this.BtnReplace_Click);
            // 
            // TxtCurrentColor
            // 
            this.TxtCurrentColor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtCurrentColor.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCurrentColor.Location = new System.Drawing.Point(34, 131);
            this.TxtCurrentColor.MaxLength = 6;
            this.TxtCurrentColor.Name = "TxtCurrentColor";
            this.TxtCurrentColor.Size = new System.Drawing.Size(60, 20);
            this.TxtCurrentColor.TabIndex = 19;
            this.TxtCurrentColor.Text = "FFFFFF";
            this.TxtCurrentColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtCurrentColor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtColor_KeyDown);
            this.TxtCurrentColor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtColor_KeyUp);
            // 
            // TxtReplaceDst
            // 
            this.TxtReplaceDst.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtReplaceDst.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtReplaceDst.Location = new System.Drawing.Point(34, 306);
            this.TxtReplaceDst.MaxLength = 6;
            this.TxtReplaceDst.Name = "TxtReplaceDst";
            this.TxtReplaceDst.Size = new System.Drawing.Size(60, 20);
            this.TxtReplaceDst.TabIndex = 23;
            this.TxtReplaceDst.Text = "FFFFFF";
            this.TxtReplaceDst.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtReplaceDst.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtColor_KeyDown);
            // 
            // BtnFillLeft
            // 
            this.BtnFillLeft.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFillLeft.Location = new System.Drawing.Point(21, 157);
            this.BtnFillLeft.Name = "BtnFillLeft";
            this.BtnFillLeft.Size = new System.Drawing.Size(90, 30);
            this.BtnFillLeft.TabIndex = 4;
            this.BtnFillLeft.Text = "Fill";
            this.BtnFillLeft.UseVisualStyleBackColor = true;
            this.BtnFillLeft.Click += new System.EventHandler(this.BtnFill_Click);
            // 
            // TxtReplaceSrc
            // 
            this.TxtReplaceSrc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtReplaceSrc.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtReplaceSrc.Location = new System.Drawing.Point(34, 283);
            this.TxtReplaceSrc.MaxLength = 6;
            this.TxtReplaceSrc.Name = "TxtReplaceSrc";
            this.TxtReplaceSrc.Size = new System.Drawing.Size(60, 20);
            this.TxtReplaceSrc.TabIndex = 22;
            this.TxtReplaceSrc.Text = "FFFFFF";
            this.TxtReplaceSrc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtReplaceSrc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtColor_KeyDown);
            // 
            // BtnResetPal
            // 
            this.BtnResetPal.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnResetPal.Location = new System.Drawing.Point(155, 243);
            this.BtnResetPal.Name = "BtnResetPal";
            this.BtnResetPal.Size = new System.Drawing.Size(90, 30);
            this.BtnResetPal.TabIndex = 17;
            this.BtnResetPal.Text = "Grayscale";
            this.BtnResetPal.UseVisualStyleBackColor = true;
            this.BtnResetPal.Click += new System.EventHandler(this.BtnResetPal_Click);
            // 
            // TxtColor3
            // 
            this.TxtColor3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtColor3.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtColor3.Location = new System.Drawing.Point(198, 181);
            this.TxtColor3.MaxLength = 6;
            this.TxtColor3.Name = "TxtColor3";
            this.TxtColor3.Size = new System.Drawing.Size(60, 20);
            this.TxtColor3.TabIndex = 11;
            this.TxtColor3.Text = "FFFFFF";
            this.TxtColor3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtColor3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtColor_KeyDown);
            this.TxtColor3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtColor_KeyUp);
            // 
            // BtnParsePal
            // 
            this.BtnParsePal.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnParsePal.Location = new System.Drawing.Point(155, 211);
            this.BtnParsePal.Name = "BtnParsePal";
            this.BtnParsePal.Size = new System.Drawing.Size(90, 30);
            this.BtnParsePal.TabIndex = 20;
            this.BtnParsePal.Text = "Parse";
            this.BtnParsePal.UseVisualStyleBackColor = true;
            this.BtnParsePal.Click += new System.EventHandler(this.BtnParsePal_Click);
            // 
            // TxtColor2
            // 
            this.TxtColor2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtColor2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtColor2.Location = new System.Drawing.Point(132, 181);
            this.TxtColor2.MaxLength = 6;
            this.TxtColor2.Name = "TxtColor2";
            this.TxtColor2.Size = new System.Drawing.Size(60, 20);
            this.TxtColor2.TabIndex = 10;
            this.TxtColor2.Text = "FFFFFF";
            this.TxtColor2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtColor2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtColor_KeyDown);
            this.TxtColor2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtColor_KeyUp);
            // 
            // Btn0
            // 
            this.Btn0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn0.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn0.ForeColor = System.Drawing.Color.Black;
            this.Btn0.Location = new System.Drawing.Point(132, 19);
            this.Btn0.Name = "Btn0";
            this.Btn0.Size = new System.Drawing.Size(60, 64);
            this.Btn0.TabIndex = 0;
            this.Btn0.Text = "1";
            this.Btn0.UseVisualStyleBackColor = true;
            this.Btn0.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnDigit_Click);
            // 
            // TxtColor1
            // 
            this.TxtColor1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtColor1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtColor1.Location = new System.Drawing.Point(198, 87);
            this.TxtColor1.MaxLength = 6;
            this.TxtColor1.Name = "TxtColor1";
            this.TxtColor1.Size = new System.Drawing.Size(60, 20);
            this.TxtColor1.TabIndex = 9;
            this.TxtColor1.Text = "FFFFFF";
            this.TxtColor1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtColor1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtColor_KeyDown);
            this.TxtColor1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtColor_KeyUp);
            // 
            // Btn1
            // 
            this.Btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn1.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn1.ForeColor = System.Drawing.Color.Black;
            this.Btn1.Location = new System.Drawing.Point(198, 19);
            this.Btn1.Name = "Btn1";
            this.Btn1.Size = new System.Drawing.Size(60, 64);
            this.Btn1.TabIndex = 1;
            this.Btn1.Text = "2";
            this.Btn1.UseVisualStyleBackColor = true;
            this.Btn1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnDigit_Click);
            // 
            // TxtColor0
            // 
            this.TxtColor0.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtColor0.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtColor0.Location = new System.Drawing.Point(132, 87);
            this.TxtColor0.MaxLength = 6;
            this.TxtColor0.Name = "TxtColor0";
            this.TxtColor0.Size = new System.Drawing.Size(60, 20);
            this.TxtColor0.TabIndex = 8;
            this.TxtColor0.Text = "FFFFFF";
            this.TxtColor0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtColor0.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtColor_KeyDown);
            this.TxtColor0.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtColor_KeyUp);
            // 
            // Btn2
            // 
            this.Btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn2.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn2.ForeColor = System.Drawing.Color.Black;
            this.Btn2.Location = new System.Drawing.Point(132, 113);
            this.Btn2.Name = "Btn2";
            this.Btn2.Size = new System.Drawing.Size(60, 64);
            this.Btn2.TabIndex = 2;
            this.Btn2.Text = "3";
            this.Btn2.UseVisualStyleBackColor = true;
            this.Btn2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnDigit_Click);
            // 
            // Btn3
            // 
            this.Btn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn3.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn3.ForeColor = System.Drawing.Color.Black;
            this.Btn3.Location = new System.Drawing.Point(198, 113);
            this.Btn3.Name = "Btn3";
            this.Btn3.Size = new System.Drawing.Size(60, 64);
            this.Btn3.TabIndex = 3;
            this.Btn3.Text = "4";
            this.Btn3.UseVisualStyleBackColor = true;
            this.Btn3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnDigit_Click);
            // 
            // BtnNew2
            // 
            this.BtnNew2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNew2.Location = new System.Drawing.Point(88, 10);
            this.BtnNew2.Name = "BtnNew2";
            this.BtnNew2.Size = new System.Drawing.Size(126, 30);
            this.BtnNew2.TabIndex = 18;
            this.BtnNew2.Text = "New tile";
            this.BtnNew2.UseVisualStyleBackColor = true;
            this.BtnNew2.Click += new System.EventHandler(this.BtnNew2_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnNew,
            this.BtnLoadBmp,
            this.BtnOpenFolder,
            this.BtnSaveBmp,
            this.BtnSaveAs,
            this.toolStripSeparator2,
            this.BtnExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // BtnNew
            // 
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.BtnNew.Size = new System.Drawing.Size(212, 22);
            this.BtnNew.Text = "New";
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // BtnLoadBmp
            // 
            this.BtnLoadBmp.Name = "BtnLoadBmp";
            this.BtnLoadBmp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.BtnLoadBmp.Size = new System.Drawing.Size(212, 22);
            this.BtnLoadBmp.Text = "Open";
            this.BtnLoadBmp.Click += new System.EventHandler(this.BtnLoadBmp_Click);
            // 
            // BtnOpenFolder
            // 
            this.BtnOpenFolder.Name = "BtnOpenFolder";
            this.BtnOpenFolder.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.BtnOpenFolder.Size = new System.Drawing.Size(212, 22);
            this.BtnOpenFolder.Text = "Open folder";
            this.BtnOpenFolder.Click += new System.EventHandler(this.BtnOpenFolder_Click);
            // 
            // BtnSaveBmp
            // 
            this.BtnSaveBmp.Name = "BtnSaveBmp";
            this.BtnSaveBmp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.BtnSaveBmp.Size = new System.Drawing.Size(212, 22);
            this.BtnSaveBmp.Text = "Save";
            this.BtnSaveBmp.Click += new System.EventHandler(this.BtnSaveBmp_Click);
            // 
            // BtnSaveAs
            // 
            this.BtnSaveAs.Name = "BtnSaveAs";
            this.BtnSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.BtnSaveAs.Size = new System.Drawing.Size(212, 22);
            this.BtnSaveAs.Text = "Save as";
            this.BtnSaveAs.Click += new System.EventHandler(this.BtnSaveAs_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(209, 6);
            // 
            // BtnExit
            // 
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(212, 22);
            this.BtnExit.Text = "Exit";
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnTileSize8x8,
            this.BtnTileSize16x16,
            this.toolStripSeparator1,
            this.BtnToggleMode,
            this.BtnToggleSubGrid,
            this.BtnToggleMainGrid});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // BtnTileSize8x8
            // 
            this.BtnTileSize8x8.Name = "BtnTileSize8x8";
            this.BtnTileSize8x8.Size = new System.Drawing.Size(184, 22);
            this.BtnTileSize8x8.Text = "Single (8x8)";
            this.BtnTileSize8x8.Click += new System.EventHandler(this.BtnTileSize8x8_Click);
            // 
            // BtnTileSize16x16
            // 
            this.BtnTileSize16x16.Name = "BtnTileSize16x16";
            this.BtnTileSize16x16.Size = new System.Drawing.Size(184, 22);
            this.BtnTileSize16x16.Text = "Composite (4x 8x8)";
            this.BtnTileSize16x16.Click += new System.EventHandler(this.BtnTileSize16x16_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // BtnToggleMode
            // 
            this.BtnToggleMode.Name = "BtnToggleMode";
            this.BtnToggleMode.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.BtnToggleMode.Size = new System.Drawing.Size(184, 22);
            this.BtnToggleMode.Text = "Toggle mode";
            this.BtnToggleMode.Click += new System.EventHandler(this.BtnToggleMode_Click);
            // 
            // BtnToggleSubGrid
            // 
            this.BtnToggleSubGrid.Checked = true;
            this.BtnToggleSubGrid.CheckOnClick = true;
            this.BtnToggleSubGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BtnToggleSubGrid.Name = "BtnToggleSubGrid";
            this.BtnToggleSubGrid.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.BtnToggleSubGrid.Size = new System.Drawing.Size(184, 22);
            this.BtnToggleSubGrid.Text = "Toggle sub grid";
            this.BtnToggleSubGrid.Click += new System.EventHandler(this.BtnToggleSubGrid_Click);
            // 
            // BtnToggleMainGrid
            // 
            this.BtnToggleMainGrid.Checked = true;
            this.BtnToggleMainGrid.CheckOnClick = true;
            this.BtnToggleMainGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BtnToggleMainGrid.Name = "BtnToggleMainGrid";
            this.BtnToggleMainGrid.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.BtnToggleMainGrid.Size = new System.Drawing.Size(184, 22);
            this.BtnToggleMainGrid.Text = "Toggle main grid";
            this.BtnToggleMainGrid.Click += new System.EventHandler(this.BtnToggleMainGrid_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(771, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // BtnAbout
            // 
            this.BtnAbout.Name = "BtnAbout";
            this.BtnAbout.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.BtnAbout.Size = new System.Drawing.Size(126, 22);
            this.BtnAbout.Text = "About";
            this.BtnAbout.Click += new System.EventHandler(this.BtnAbout_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 488);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel TileEditPanelContainer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Btn3;
        private System.Windows.Forms.Button Btn2;
        private System.Windows.Forms.Button Btn1;
        private System.Windows.Forms.Button Btn0;
        private System.Windows.Forms.Button BtnFillLeft;
        private System.Windows.Forms.Button BtnCurrentColor;
        private System.Windows.Forms.TextBox TxtColor0;
        private System.Windows.Forms.TextBox TxtColor3;
        private System.Windows.Forms.TextBox TxtColor2;
        private System.Windows.Forms.TextBox TxtColor1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BtnExit;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BtnTileSize8x8;
        private System.Windows.Forms.ToolStripMenuItem BtnTileSize16x16;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem BtnToggleMainGrid;
        private System.Windows.Forms.ToolStripMenuItem BtnToggleSubGrid;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem BtnLoadBmp;
        private System.Windows.Forms.ToolStripMenuItem BtnSaveBmp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Button BtnResetPal;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ToolStripMenuItem BtnToggleMode;
        private System.Windows.Forms.ToolStripMenuItem BtnNew;
        private System.Windows.Forms.ToolStripMenuItem BtnSaveAs;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BtnAbout;
        private System.Windows.Forms.Button BtnNew2;
        private System.Windows.Forms.ToolStripMenuItem BtnOpenFolder;
        private System.Windows.Forms.TextBox TxtCurrentColor;
        private System.Windows.Forms.Button BtnParsePal;
        private System.Windows.Forms.Button BtnReplace;
        private System.Windows.Forms.TextBox TxtReplaceDst;
        private System.Windows.Forms.TextBox TxtReplaceSrc;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

