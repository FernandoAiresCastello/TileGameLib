
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TileEditPanelContainer = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnPaste = new System.Windows.Forms.Button();
            this.BtnCopy8x8 = new System.Windows.Forms.Button();
            this.TxtColor3 = new System.Windows.Forms.TextBox();
            this.TxtColor2 = new System.Windows.Forms.TextBox();
            this.TxtColor1 = new System.Windows.Forms.TextBox();
            this.TxtColor0 = new System.Windows.Forms.TextBox();
            this.BtnFillRight = new System.Windows.Forms.Button();
            this.BtnRight = new System.Windows.Forms.Button();
            this.BtnLeft = new System.Windows.Forms.Button();
            this.BtnFillLeft = new System.Windows.Forms.Button();
            this.Btn3 = new System.Windows.Forms.Button();
            this.Btn2 = new System.Windows.Forms.Button();
            this.Btn1 = new System.Windows.Forms.Button();
            this.Btn0 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnTileSize8x8 = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnTileSize16x16 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnTogglePixelCodes = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnToggleMainGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnToggleSubGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.clipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuBtnCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuBtnPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.BtnSaveBmp = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnLoadBmp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnExportBmp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnPermutate = new System.Windows.Forms.Button();
            this.BtnResetPal = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.BtnToggleMode = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnNew = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.BtnResetPal);
            this.panel1.Controls.Add(this.BtnPermutate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.BtnPaste);
            this.panel1.Controls.Add(this.BtnCopy8x8);
            this.panel1.Controls.Add(this.TxtColor3);
            this.panel1.Controls.Add(this.TxtColor2);
            this.panel1.Controls.Add(this.TxtColor1);
            this.panel1.Controls.Add(this.TxtColor0);
            this.panel1.Controls.Add(this.BtnFillRight);
            this.panel1.Controls.Add(this.BtnRight);
            this.panel1.Controls.Add(this.BtnLeft);
            this.panel1.Controls.Add(this.BtnFillLeft);
            this.panel1.Controls.Add(this.Btn3);
            this.panel1.Controls.Add(this.Btn2);
            this.panel1.Controls.Add(this.Btn1);
            this.panel1.Controls.Add(this.Btn0);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(477, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(291, 436);
            this.panel1.TabIndex = 2;
            // 
            // BtnPaste
            // 
            this.BtnPaste.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPaste.Location = new System.Drawing.Point(149, 392);
            this.BtnPaste.Name = "BtnPaste";
            this.BtnPaste.Size = new System.Drawing.Size(126, 30);
            this.BtnPaste.TabIndex = 14;
            this.BtnPaste.Text = "Parse 8x8";
            this.BtnPaste.UseVisualStyleBackColor = true;
            this.BtnPaste.Click += new System.EventHandler(this.BtnPaste_Click);
            // 
            // BtnCopy8x8
            // 
            this.BtnCopy8x8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCopy8x8.Location = new System.Drawing.Point(17, 392);
            this.BtnCopy8x8.Name = "BtnCopy8x8";
            this.BtnCopy8x8.Size = new System.Drawing.Size(126, 30);
            this.BtnCopy8x8.TabIndex = 13;
            this.BtnCopy8x8.Text = "Copy 8x8";
            this.BtnCopy8x8.UseVisualStyleBackColor = true;
            this.BtnCopy8x8.Click += new System.EventHandler(this.BtnCopy8x8_Click);
            // 
            // TxtColor3
            // 
            this.TxtColor3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtColor3.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtColor3.Location = new System.Drawing.Point(215, 158);
            this.TxtColor3.MaxLength = 6;
            this.TxtColor3.Name = "TxtColor3";
            this.TxtColor3.Size = new System.Drawing.Size(60, 20);
            this.TxtColor3.TabIndex = 11;
            this.TxtColor3.Text = "FFFFFF";
            this.TxtColor3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtColor3.Enter += new System.EventHandler(this.TxtColor_Enter);
            this.TxtColor3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtColor_KeyDown);
            this.TxtColor3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtColor_KeyUp);
            // 
            // TxtColor2
            // 
            this.TxtColor2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtColor2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtColor2.Location = new System.Drawing.Point(149, 158);
            this.TxtColor2.MaxLength = 6;
            this.TxtColor2.Name = "TxtColor2";
            this.TxtColor2.Size = new System.Drawing.Size(60, 20);
            this.TxtColor2.TabIndex = 10;
            this.TxtColor2.Text = "FFFFFF";
            this.TxtColor2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtColor2.Enter += new System.EventHandler(this.TxtColor_Enter);
            this.TxtColor2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtColor_KeyDown);
            this.TxtColor2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtColor_KeyUp);
            // 
            // TxtColor1
            // 
            this.TxtColor1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtColor1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtColor1.Location = new System.Drawing.Point(83, 158);
            this.TxtColor1.MaxLength = 6;
            this.TxtColor1.Name = "TxtColor1";
            this.TxtColor1.Size = new System.Drawing.Size(60, 20);
            this.TxtColor1.TabIndex = 9;
            this.TxtColor1.Text = "FFFFFF";
            this.TxtColor1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtColor1.Enter += new System.EventHandler(this.TxtColor_Enter);
            this.TxtColor1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtColor_KeyDown);
            this.TxtColor1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtColor_KeyUp);
            // 
            // TxtColor0
            // 
            this.TxtColor0.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtColor0.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtColor0.Location = new System.Drawing.Point(17, 158);
            this.TxtColor0.MaxLength = 6;
            this.TxtColor0.Name = "TxtColor0";
            this.TxtColor0.Size = new System.Drawing.Size(60, 20);
            this.TxtColor0.TabIndex = 8;
            this.TxtColor0.Text = "FFFFFF";
            this.TxtColor0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtColor0.Enter += new System.EventHandler(this.TxtColor_Enter);
            this.TxtColor0.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtColor_KeyDown);
            this.TxtColor0.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtColor_KeyUp);
            // 
            // BtnFillRight
            // 
            this.BtnFillRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFillRight.Location = new System.Drawing.Point(149, 48);
            this.BtnFillRight.Name = "BtnFillRight";
            this.BtnFillRight.Size = new System.Drawing.Size(126, 30);
            this.BtnFillRight.TabIndex = 7;
            this.BtnFillRight.Text = "Fill";
            this.BtnFillRight.UseVisualStyleBackColor = true;
            this.BtnFillRight.Click += new System.EventHandler(this.BtnFillRight_Click);
            // 
            // BtnRight
            // 
            this.BtnRight.Enabled = false;
            this.BtnRight.FlatAppearance.BorderSize = 0;
            this.BtnRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRight.Location = new System.Drawing.Point(149, 12);
            this.BtnRight.Name = "BtnRight";
            this.BtnRight.Size = new System.Drawing.Size(126, 30);
            this.BtnRight.TabIndex = 6;
            this.BtnRight.Text = "RMB";
            this.BtnRight.UseVisualStyleBackColor = true;
            // 
            // BtnLeft
            // 
            this.BtnLeft.Enabled = false;
            this.BtnLeft.FlatAppearance.BorderSize = 0;
            this.BtnLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLeft.Location = new System.Drawing.Point(17, 12);
            this.BtnLeft.Name = "BtnLeft";
            this.BtnLeft.Size = new System.Drawing.Size(126, 30);
            this.BtnLeft.TabIndex = 5;
            this.BtnLeft.Text = "LMB";
            this.BtnLeft.UseVisualStyleBackColor = true;
            // 
            // BtnFillLeft
            // 
            this.BtnFillLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFillLeft.Location = new System.Drawing.Point(17, 48);
            this.BtnFillLeft.Name = "BtnFillLeft";
            this.BtnFillLeft.Size = new System.Drawing.Size(126, 30);
            this.BtnFillLeft.TabIndex = 4;
            this.BtnFillLeft.Text = "Fill";
            this.BtnFillLeft.UseVisualStyleBackColor = true;
            this.BtnFillLeft.Click += new System.EventHandler(this.BtnFill_Click);
            // 
            // Btn3
            // 
            this.Btn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn3.Location = new System.Drawing.Point(215, 90);
            this.Btn3.Name = "Btn3";
            this.Btn3.Size = new System.Drawing.Size(60, 64);
            this.Btn3.TabIndex = 3;
            this.Btn3.Text = "3";
            this.Btn3.UseVisualStyleBackColor = true;
            this.Btn3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnDigit_Click);
            // 
            // Btn2
            // 
            this.Btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn2.Location = new System.Drawing.Point(149, 90);
            this.Btn2.Name = "Btn2";
            this.Btn2.Size = new System.Drawing.Size(60, 64);
            this.Btn2.TabIndex = 2;
            this.Btn2.Text = "2";
            this.Btn2.UseVisualStyleBackColor = true;
            this.Btn2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnDigit_Click);
            // 
            // Btn1
            // 
            this.Btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn1.Location = new System.Drawing.Point(83, 90);
            this.Btn1.Name = "Btn1";
            this.Btn1.Size = new System.Drawing.Size(60, 64);
            this.Btn1.TabIndex = 1;
            this.Btn1.Text = "1";
            this.Btn1.UseVisualStyleBackColor = true;
            this.Btn1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnDigit_Click);
            // 
            // Btn0
            // 
            this.Btn0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn0.Location = new System.Drawing.Point(17, 90);
            this.Btn0.Name = "Btn0";
            this.Btn0.Size = new System.Drawing.Size(60, 64);
            this.Btn0.TabIndex = 0;
            this.Btn0.Text = "0";
            this.Btn0.UseVisualStyleBackColor = true;
            this.Btn0.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnDigit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(96, 367);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "String pattern";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnNew,
            this.BtnLoadBmp,
            this.BtnSaveBmp,
            this.BtnSaveAs,
            this.toolStripSeparator3,
            this.BtnExportBmp,
            this.toolStripSeparator2,
            this.BtnExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // BtnExit
            // 
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(184, 22);
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
            this.BtnTogglePixelCodes,
            this.BtnToggleSubGrid,
            this.BtnToggleMainGrid});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // BtnTileSize8x8
            // 
            this.BtnTileSize8x8.Name = "BtnTileSize8x8";
            this.BtnTileSize8x8.Size = new System.Drawing.Size(191, 22);
            this.BtnTileSize8x8.Text = "Single (8x8)";
            this.BtnTileSize8x8.Click += new System.EventHandler(this.BtnTileSize8x8_Click);
            // 
            // BtnTileSize16x16
            // 
            this.BtnTileSize16x16.Name = "BtnTileSize16x16";
            this.BtnTileSize16x16.Size = new System.Drawing.Size(191, 22);
            this.BtnTileSize16x16.Text = "Composite (4x 8x8)";
            this.BtnTileSize16x16.Click += new System.EventHandler(this.BtnTileSize16x16_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(188, 6);
            // 
            // BtnTogglePixelCodes
            // 
            this.BtnTogglePixelCodes.Checked = true;
            this.BtnTogglePixelCodes.CheckOnClick = true;
            this.BtnTogglePixelCodes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BtnTogglePixelCodes.Name = "BtnTogglePixelCodes";
            this.BtnTogglePixelCodes.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.BtnTogglePixelCodes.Size = new System.Drawing.Size(191, 22);
            this.BtnTogglePixelCodes.Text = "Toggle pixel codes";
            this.BtnTogglePixelCodes.Click += new System.EventHandler(this.BtnTogglePixelCodes_Click);
            // 
            // BtnToggleMainGrid
            // 
            this.BtnToggleMainGrid.Checked = true;
            this.BtnToggleMainGrid.CheckOnClick = true;
            this.BtnToggleMainGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BtnToggleMainGrid.Name = "BtnToggleMainGrid";
            this.BtnToggleMainGrid.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.BtnToggleMainGrid.Size = new System.Drawing.Size(191, 22);
            this.BtnToggleMainGrid.Text = "Toggle main grid";
            this.BtnToggleMainGrid.Click += new System.EventHandler(this.BtnToggleMainGrid_Click);
            // 
            // BtnToggleSubGrid
            // 
            this.BtnToggleSubGrid.Checked = true;
            this.BtnToggleSubGrid.CheckOnClick = true;
            this.BtnToggleSubGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BtnToggleSubGrid.Name = "BtnToggleSubGrid";
            this.BtnToggleSubGrid.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.BtnToggleSubGrid.Size = new System.Drawing.Size(191, 22);
            this.BtnToggleSubGrid.Text = "Toggle sub grid";
            this.BtnToggleSubGrid.Click += new System.EventHandler(this.BtnToggleSubGrid_Click);
            // 
            // clipboardToolStripMenuItem
            // 
            this.clipboardToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuBtnCopy,
            this.MenuBtnPaste});
            this.clipboardToolStripMenuItem.Name = "clipboardToolStripMenuItem";
            this.clipboardToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.clipboardToolStripMenuItem.Text = "Pattern";
            // 
            // MenuBtnCopy
            // 
            this.MenuBtnCopy.Name = "MenuBtnCopy";
            this.MenuBtnCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.MenuBtnCopy.Size = new System.Drawing.Size(180, 22);
            this.MenuBtnCopy.Text = "Copy 8x8";
            this.MenuBtnCopy.Click += new System.EventHandler(this.MenuBtnCopy_Click);
            // 
            // MenuBtnPaste
            // 
            this.MenuBtnPaste.Name = "MenuBtnPaste";
            this.MenuBtnPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.MenuBtnPaste.Size = new System.Drawing.Size(180, 22);
            this.MenuBtnPaste.Text = "Parse 8x8";
            this.MenuBtnPaste.Click += new System.EventHandler(this.MenuBtnPaste_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.clipboardToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(771, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // BtnSaveBmp
            // 
            this.BtnSaveBmp.Name = "BtnSaveBmp";
            this.BtnSaveBmp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.BtnSaveBmp.Size = new System.Drawing.Size(184, 22);
            this.BtnSaveBmp.Text = "Save";
            this.BtnSaveBmp.Click += new System.EventHandler(this.BtnSaveBmp_Click);
            // 
            // BtnLoadBmp
            // 
            this.BtnLoadBmp.Name = "BtnLoadBmp";
            this.BtnLoadBmp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.BtnLoadBmp.Size = new System.Drawing.Size(184, 22);
            this.BtnLoadBmp.Text = "Open";
            this.BtnLoadBmp.Click += new System.EventHandler(this.BtnLoadBmp_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(181, 6);
            // 
            // BtnExportBmp
            // 
            this.BtnExportBmp.Name = "BtnExportBmp";
            this.BtnExportBmp.Size = new System.Drawing.Size(184, 22);
            this.BtnExportBmp.Text = "Export RGB bitmap";
            this.BtnExportBmp.Click += new System.EventHandler(this.BtnExportBmp_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(181, 6);
            // 
            // BtnPermutate
            // 
            this.BtnPermutate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPermutate.Location = new System.Drawing.Point(17, 321);
            this.BtnPermutate.Name = "BtnPermutate";
            this.BtnPermutate.Size = new System.Drawing.Size(126, 30);
            this.BtnPermutate.TabIndex = 16;
            this.BtnPermutate.Text = "Permutate";
            this.BtnPermutate.UseVisualStyleBackColor = true;
            this.BtnPermutate.Click += new System.EventHandler(this.BtnPermutate_Click);
            // 
            // BtnResetPal
            // 
            this.BtnResetPal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnResetPal.Location = new System.Drawing.Point(149, 321);
            this.BtnResetPal.Name = "BtnResetPal";
            this.BtnResetPal.Size = new System.Drawing.Size(126, 30);
            this.BtnResetPal.TabIndex = 17;
            this.BtnResetPal.Text = "Reset";
            this.BtnResetPal.UseVisualStyleBackColor = true;
            this.BtnResetPal.Click += new System.EventHandler(this.BtnResetPal_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(98, 297);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Color palette";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(67, 17);
            this.StatusLabel.Text = "StatusLabel";
            // 
            // BtnToggleMode
            // 
            this.BtnToggleMode.Name = "BtnToggleMode";
            this.BtnToggleMode.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.BtnToggleMode.Size = new System.Drawing.Size(191, 22);
            this.BtnToggleMode.Text = "Toggle mode";
            this.BtnToggleMode.Click += new System.EventHandler(this.BtnToggleMode_Click);
            // 
            // BtnNew
            // 
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.BtnNew.Size = new System.Drawing.Size(184, 22);
            this.BtnNew.Text = "New";
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // BtnSaveAs
            // 
            this.BtnSaveAs.Name = "BtnSaveAs";
            this.BtnSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.BtnSaveAs.Size = new System.Drawing.Size(184, 22);
            this.BtnSaveAs.Text = "Save as";
            this.BtnSaveAs.Click += new System.EventHandler(this.BtnSaveAs_Click);
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
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Button BtnRight;
        private System.Windows.Forms.Button BtnLeft;
        private System.Windows.Forms.Button BtnFillRight;
        private System.Windows.Forms.TextBox TxtColor0;
        private System.Windows.Forms.TextBox TxtColor3;
        private System.Windows.Forms.TextBox TxtColor2;
        private System.Windows.Forms.TextBox TxtColor1;
        private System.Windows.Forms.Button BtnCopy8x8;
        private System.Windows.Forms.Button BtnPaste;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BtnExit;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BtnTileSize8x8;
        private System.Windows.Forms.ToolStripMenuItem BtnTileSize16x16;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem BtnTogglePixelCodes;
        private System.Windows.Forms.ToolStripMenuItem BtnToggleMainGrid;
        private System.Windows.Forms.ToolStripMenuItem BtnToggleSubGrid;
        private System.Windows.Forms.ToolStripMenuItem clipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuBtnCopy;
        private System.Windows.Forms.ToolStripMenuItem MenuBtnPaste;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem BtnLoadBmp;
        private System.Windows.Forms.ToolStripMenuItem BtnSaveBmp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem BtnExportBmp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnResetPal;
        private System.Windows.Forms.Button BtnPermutate;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ToolStripMenuItem BtnToggleMode;
        private System.Windows.Forms.ToolStripMenuItem BtnNew;
        private System.Windows.Forms.ToolStripMenuItem BtnSaveAs;
    }
}

