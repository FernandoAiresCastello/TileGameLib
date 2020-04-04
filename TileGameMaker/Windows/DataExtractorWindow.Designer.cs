namespace TileGameMaker.Windows
{
    partial class DataExtractorWindow
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
            this.BtnCopyOutput = new System.Windows.Forms.Button();
            this.TxtOutput = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.TxtObjectDataItemSeparator = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtObjectLineSuffix = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtObjectLinePrefix = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtObjectEmptyCell = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ChkObject1stTileBackColor = new System.Windows.Forms.CheckBox();
            this.ChkObject1stTileForeColor = new System.Windows.Forms.CheckBox();
            this.ChkObject1stTileIndex = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnExtractMapData = new System.Windows.Forms.Button();
            this.CmbLayer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.PaletteRangeLast = new System.Windows.Forms.NumericUpDown();
            this.PaletteRangeFirst = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.TxtColorComponentSeparator = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ChkColorAppendAlpha = new System.Windows.Forms.CheckBox();
            this.TxtColorHexPrefix = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtColorLineSuffix = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtColorLinePrefix = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RbPaletteFmtHexRgb = new System.Windows.Forms.RadioButton();
            this.RbPaletteFmtDecRgb = new System.Windows.Forms.RadioButton();
            this.RbPaletteFmtHexInt = new System.Windows.Forms.RadioButton();
            this.RbPaletteFmtDecInt = new System.Windows.Forms.RadioButton();
            this.BtnExtractPaletteData = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.TilesetRangeLast = new System.Windows.Forms.NumericUpDown();
            this.TilesetRangeFirst = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.TxtTileByteSeparator = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtTileHexPrefix = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtTileLineSuffix = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.TxtTileLinePrefix = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RbTileBase64 = new System.Windows.Forms.RadioButton();
            this.RbTileBinaryString = new System.Windows.Forms.RadioButton();
            this.RbTileHexadecimal = new System.Windows.Forms.RadioButton();
            this.RbTileDecimal = new System.Windows.Forms.RadioButton();
            this.BtnExtractTilesetData = new System.Windows.Forms.Button();
            this.RootPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PaletteRangeLast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaletteRangeFirst)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TilesetRangeLast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TilesetRangeFirst)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.RootPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.BtnCopyOutput, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.TxtOutput, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(464, 502);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // BtnCopyOutput
            // 
            this.BtnCopyOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCopyOutput.Location = new System.Drawing.Point(355, 472);
            this.BtnCopyOutput.Name = "BtnCopyOutput";
            this.BtnCopyOutput.Size = new System.Drawing.Size(106, 27);
            this.BtnCopyOutput.TabIndex = 3;
            this.BtnCopyOutput.Text = "Copy output";
            this.BtnCopyOutput.UseVisualStyleBackColor = true;
            this.BtnCopyOutput.Click += new System.EventHandler(this.BtnCopyOutput_Click);
            // 
            // TxtOutput
            // 
            this.TxtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtOutput.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtOutput.Location = new System.Drawing.Point(3, 237);
            this.TxtOutput.Multiline = true;
            this.TxtOutput.Name = "TxtOutput";
            this.TxtOutput.ReadOnly = true;
            this.TxtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtOutput.Size = new System.Drawing.Size(458, 228);
            this.TxtOutput.TabIndex = 0;
            this.TxtOutput.WordWrap = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(458, 228);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.TxtObjectDataItemSeparator);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.TxtObjectLineSuffix);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.TxtObjectLinePrefix);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.TxtObjectEmptyCell);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.ChkObject1stTileBackColor);
            this.tabPage1.Controls.Add(this.ChkObject1stTileForeColor);
            this.tabPage1.Controls.Add(this.ChkObject1stTileIndex);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.BtnExtractMapData);
            this.tabPage1.Controls.Add(this.CmbLayer);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(10);
            this.tabPage1.Size = new System.Drawing.Size(450, 202);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Map";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // TxtObjectDataItemSeparator
            // 
            this.TxtObjectDataItemSeparator.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtObjectDataItemSeparator.Location = new System.Drawing.Point(225, 70);
            this.TxtObjectDataItemSeparator.Name = "TxtObjectDataItemSeparator";
            this.TxtObjectDataItemSeparator.Size = new System.Drawing.Size(52, 20);
            this.TxtObjectDataItemSeparator.TabIndex = 15;
            this.TxtObjectDataItemSeparator.Text = ",";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(222, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Separator";
            // 
            // TxtObjectLineSuffix
            // 
            this.TxtObjectLineSuffix.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtObjectLineSuffix.Location = new System.Drawing.Point(286, 116);
            this.TxtObjectLineSuffix.Name = "TxtObjectLineSuffix";
            this.TxtObjectLineSuffix.Size = new System.Drawing.Size(52, 20);
            this.TxtObjectLineSuffix.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(283, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Line suffix";
            // 
            // TxtObjectLinePrefix
            // 
            this.TxtObjectLinePrefix.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtObjectLinePrefix.Location = new System.Drawing.Point(225, 116);
            this.TxtObjectLinePrefix.Name = "TxtObjectLinePrefix";
            this.TxtObjectLinePrefix.Size = new System.Drawing.Size(52, 20);
            this.TxtObjectLinePrefix.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(222, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Line prefix";
            // 
            // TxtObjectEmptyCell
            // 
            this.TxtObjectEmptyCell.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtObjectEmptyCell.Location = new System.Drawing.Point(285, 70);
            this.TxtObjectEmptyCell.Name = "TxtObjectEmptyCell";
            this.TxtObjectEmptyCell.Size = new System.Drawing.Size(52, 20);
            this.TxtObjectEmptyCell.TabIndex = 9;
            this.TxtObjectEmptyCell.Text = "-1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(282, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Empty cell";
            // 
            // ChkObject1stTileBackColor
            // 
            this.ChkObject1stTileBackColor.AutoSize = true;
            this.ChkObject1stTileBackColor.Location = new System.Drawing.Point(86, 96);
            this.ChkObject1stTileBackColor.Name = "ChkObject1stTileBackColor";
            this.ChkObject1stTileBackColor.Size = new System.Drawing.Size(106, 17);
            this.ChkObject1stTileBackColor.TabIndex = 7;
            this.ChkObject1stTileBackColor.Text = "1st tile backcolor";
            this.ChkObject1stTileBackColor.UseVisualStyleBackColor = true;
            // 
            // ChkObject1stTileForeColor
            // 
            this.ChkObject1stTileForeColor.AutoSize = true;
            this.ChkObject1stTileForeColor.Location = new System.Drawing.Point(86, 73);
            this.ChkObject1stTileForeColor.Name = "ChkObject1stTileForeColor";
            this.ChkObject1stTileForeColor.Size = new System.Drawing.Size(100, 17);
            this.ChkObject1stTileForeColor.TabIndex = 6;
            this.ChkObject1stTileForeColor.Text = "1st tile forecolor";
            this.ChkObject1stTileForeColor.UseVisualStyleBackColor = true;
            // 
            // ChkObject1stTileIndex
            // 
            this.ChkObject1stTileIndex.AutoSize = true;
            this.ChkObject1stTileIndex.Checked = true;
            this.ChkObject1stTileIndex.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkObject1stTileIndex.Location = new System.Drawing.Point(86, 50);
            this.ChkObject1stTileIndex.Name = "ChkObject1stTileIndex";
            this.ChkObject1stTileIndex.Size = new System.Drawing.Size(84, 17);
            this.ChkObject1stTileIndex.TabIndex = 5;
            this.ChkObject1stTileIndex.Text = "1st tile index";
            this.ChkObject1stTileIndex.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Object data";
            // 
            // BtnExtractMapData
            // 
            this.BtnExtractMapData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExtractMapData.Location = new System.Drawing.Point(331, 162);
            this.BtnExtractMapData.Name = "BtnExtractMapData";
            this.BtnExtractMapData.Size = new System.Drawing.Size(106, 27);
            this.BtnExtractMapData.TabIndex = 2;
            this.BtnExtractMapData.Text = "Extract data";
            this.BtnExtractMapData.UseVisualStyleBackColor = true;
            this.BtnExtractMapData.Click += new System.EventHandler(this.BtnExtractMapData_Click);
            // 
            // CmbLayer
            // 
            this.CmbLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbLayer.FormattingEnabled = true;
            this.CmbLayer.Location = new System.Drawing.Point(86, 13);
            this.CmbLayer.Name = "CmbLayer";
            this.CmbLayer.Size = new System.Drawing.Size(121, 21);
            this.CmbLayer.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Layer";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.PaletteRangeLast);
            this.tabPage2.Controls.Add(this.PaletteRangeFirst);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.TxtColorComponentSeparator);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.ChkColorAppendAlpha);
            this.tabPage2.Controls.Add(this.TxtColorHexPrefix);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.TxtColorLineSuffix);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.TxtColorLinePrefix);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.BtnExtractPaletteData);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(10);
            this.tabPage2.Size = new System.Drawing.Size(450, 202);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Palette";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // PaletteRangeLast
            // 
            this.PaletteRangeLast.Location = new System.Drawing.Point(251, 127);
            this.PaletteRangeLast.Name = "PaletteRangeLast";
            this.PaletteRangeLast.Size = new System.Drawing.Size(52, 20);
            this.PaletteRangeLast.TabIndex = 25;
            // 
            // PaletteRangeFirst
            // 
            this.PaletteRangeFirst.Location = new System.Drawing.Point(190, 127);
            this.PaletteRangeFirst.Name = "PaletteRangeFirst";
            this.PaletteRangeFirst.Size = new System.Drawing.Size(52, 20);
            this.PaletteRangeFirst.TabIndex = 24;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(187, 107);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(39, 13);
            this.label16.TabIndex = 23;
            this.label16.Text = "Range";
            // 
            // TxtColorComponentSeparator
            // 
            this.TxtColorComponentSeparator.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtColorComponentSeparator.Location = new System.Drawing.Point(251, 79);
            this.TxtColorComponentSeparator.Name = "TxtColorComponentSeparator";
            this.TxtColorComponentSeparator.Size = new System.Drawing.Size(52, 20);
            this.TxtColorComponentSeparator.TabIndex = 22;
            this.TxtColorComponentSeparator.Text = ",";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(248, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Separator";
            // 
            // ChkColorAppendAlpha
            // 
            this.ChkColorAppendAlpha.AutoSize = true;
            this.ChkColorAppendAlpha.Location = new System.Drawing.Point(18, 145);
            this.ChkColorAppendAlpha.Name = "ChkColorAppendAlpha";
            this.ChkColorAppendAlpha.Size = new System.Drawing.Size(148, 17);
            this.ChkColorAppendAlpha.TabIndex = 20;
            this.ChkColorAppendAlpha.Text = "Append alpha component";
            this.ChkColorAppendAlpha.UseVisualStyleBackColor = true;
            // 
            // TxtColorHexPrefix
            // 
            this.TxtColorHexPrefix.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtColorHexPrefix.Location = new System.Drawing.Point(190, 79);
            this.TxtColorHexPrefix.Name = "TxtColorHexPrefix";
            this.TxtColorHexPrefix.Size = new System.Drawing.Size(52, 20);
            this.TxtColorHexPrefix.TabIndex = 19;
            this.TxtColorHexPrefix.Text = "0x";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(187, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Hex. prefix";
            // 
            // TxtColorLineSuffix
            // 
            this.TxtColorLineSuffix.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtColorLineSuffix.Location = new System.Drawing.Point(251, 31);
            this.TxtColorLineSuffix.Name = "TxtColorLineSuffix";
            this.TxtColorLineSuffix.Size = new System.Drawing.Size(52, 20);
            this.TxtColorLineSuffix.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(248, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Line suffix";
            // 
            // TxtColorLinePrefix
            // 
            this.TxtColorLinePrefix.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtColorLinePrefix.Location = new System.Drawing.Point(190, 31);
            this.TxtColorLinePrefix.Name = "TxtColorLinePrefix";
            this.TxtColorLinePrefix.Size = new System.Drawing.Size(52, 20);
            this.TxtColorLinePrefix.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(187, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Line prefix";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RbPaletteFmtHexRgb);
            this.groupBox1.Controls.Add(this.RbPaletteFmtDecRgb);
            this.groupBox1.Controls.Add(this.RbPaletteFmtHexInt);
            this.groupBox1.Controls.Add(this.RbPaletteFmtDecInt);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10, 5, 5, 5);
            this.groupBox1.Size = new System.Drawing.Size(162, 121);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Color format";
            // 
            // RbPaletteFmtHexRgb
            // 
            this.RbPaletteFmtHexRgb.AutoSize = true;
            this.RbPaletteFmtHexRgb.Location = new System.Drawing.Point(13, 90);
            this.RbPaletteFmtHexRgb.Name = "RbPaletteFmtHexRgb";
            this.RbPaletteFmtHexRgb.Size = new System.Drawing.Size(140, 17);
            this.RbPaletteFmtHexRgb.TabIndex = 3;
            this.RbPaletteFmtHexRgb.Text = "Hexadecimal RGB triplet";
            this.RbPaletteFmtHexRgb.UseVisualStyleBackColor = true;
            // 
            // RbPaletteFmtDecRgb
            // 
            this.RbPaletteFmtDecRgb.AutoSize = true;
            this.RbPaletteFmtDecRgb.Location = new System.Drawing.Point(13, 67);
            this.RbPaletteFmtDecRgb.Name = "RbPaletteFmtDecRgb";
            this.RbPaletteFmtDecRgb.Size = new System.Drawing.Size(117, 17);
            this.RbPaletteFmtDecRgb.TabIndex = 2;
            this.RbPaletteFmtDecRgb.Text = "Decimal RGB triplet";
            this.RbPaletteFmtDecRgb.UseVisualStyleBackColor = true;
            // 
            // RbPaletteFmtHexInt
            // 
            this.RbPaletteFmtHexInt.AutoSize = true;
            this.RbPaletteFmtHexInt.Checked = true;
            this.RbPaletteFmtHexInt.Location = new System.Drawing.Point(13, 44);
            this.RbPaletteFmtHexInt.Name = "RbPaletteFmtHexInt";
            this.RbPaletteFmtHexInt.Size = new System.Drawing.Size(121, 17);
            this.RbPaletteFmtHexInt.TabIndex = 1;
            this.RbPaletteFmtHexInt.TabStop = true;
            this.RbPaletteFmtHexInt.Text = "Hexadecimal integer";
            this.RbPaletteFmtHexInt.UseVisualStyleBackColor = true;
            // 
            // RbPaletteFmtDecInt
            // 
            this.RbPaletteFmtDecInt.AutoSize = true;
            this.RbPaletteFmtDecInt.Location = new System.Drawing.Point(13, 21);
            this.RbPaletteFmtDecInt.Name = "RbPaletteFmtDecInt";
            this.RbPaletteFmtDecInt.Size = new System.Drawing.Size(98, 17);
            this.RbPaletteFmtDecInt.TabIndex = 0;
            this.RbPaletteFmtDecInt.Text = "Decimal integer";
            this.RbPaletteFmtDecInt.UseVisualStyleBackColor = true;
            // 
            // BtnExtractPaletteData
            // 
            this.BtnExtractPaletteData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExtractPaletteData.Location = new System.Drawing.Point(331, 179);
            this.BtnExtractPaletteData.Name = "BtnExtractPaletteData";
            this.BtnExtractPaletteData.Size = new System.Drawing.Size(106, 27);
            this.BtnExtractPaletteData.TabIndex = 3;
            this.BtnExtractPaletteData.Text = "Extract data";
            this.BtnExtractPaletteData.UseVisualStyleBackColor = true;
            this.BtnExtractPaletteData.Click += new System.EventHandler(this.BtnExtractPaletteData_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.TilesetRangeLast);
            this.tabPage3.Controls.Add(this.TilesetRangeFirst);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.TxtTileByteSeparator);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.TxtTileHexPrefix);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.TxtTileLineSuffix);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.TxtTileLinePrefix);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.BtnExtractTilesetData);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(10);
            this.tabPage3.Size = new System.Drawing.Size(450, 202);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Tileset";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // TilesetRangeLast
            // 
            this.TilesetRangeLast.Location = new System.Drawing.Point(251, 127);
            this.TilesetRangeLast.Name = "TilesetRangeLast";
            this.TilesetRangeLast.Size = new System.Drawing.Size(52, 20);
            this.TilesetRangeLast.TabIndex = 34;
            // 
            // TilesetRangeFirst
            // 
            this.TilesetRangeFirst.Location = new System.Drawing.Point(190, 127);
            this.TilesetRangeFirst.Name = "TilesetRangeFirst";
            this.TilesetRangeFirst.Size = new System.Drawing.Size(52, 20);
            this.TilesetRangeFirst.TabIndex = 33;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(187, 107);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(39, 13);
            this.label15.TabIndex = 32;
            this.label15.Text = "Range";
            // 
            // TxtTileByteSeparator
            // 
            this.TxtTileByteSeparator.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTileByteSeparator.Location = new System.Drawing.Point(251, 79);
            this.TxtTileByteSeparator.Name = "TxtTileByteSeparator";
            this.TxtTileByteSeparator.Size = new System.Drawing.Size(52, 20);
            this.TxtTileByteSeparator.TabIndex = 31;
            this.TxtTileByteSeparator.Text = ",";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(248, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "Separator";
            // 
            // TxtTileHexPrefix
            // 
            this.TxtTileHexPrefix.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTileHexPrefix.Location = new System.Drawing.Point(190, 79);
            this.TxtTileHexPrefix.Name = "TxtTileHexPrefix";
            this.TxtTileHexPrefix.Size = new System.Drawing.Size(52, 20);
            this.TxtTileHexPrefix.TabIndex = 29;
            this.TxtTileHexPrefix.Text = "0x";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(187, 59);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "Hex. prefix";
            // 
            // TxtTileLineSuffix
            // 
            this.TxtTileLineSuffix.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTileLineSuffix.Location = new System.Drawing.Point(251, 31);
            this.TxtTileLineSuffix.Name = "TxtTileLineSuffix";
            this.TxtTileLineSuffix.Size = new System.Drawing.Size(52, 20);
            this.TxtTileLineSuffix.TabIndex = 27;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(248, 11);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 26;
            this.label13.Text = "Line suffix";
            // 
            // TxtTileLinePrefix
            // 
            this.TxtTileLinePrefix.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTileLinePrefix.Location = new System.Drawing.Point(190, 31);
            this.TxtTileLinePrefix.Name = "TxtTileLinePrefix";
            this.TxtTileLinePrefix.Size = new System.Drawing.Size(52, 20);
            this.TxtTileLinePrefix.TabIndex = 25;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(187, 11);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 13);
            this.label14.TabIndex = 24;
            this.label14.Text = "Line prefix";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RbTileBase64);
            this.groupBox2.Controls.Add(this.RbTileBinaryString);
            this.groupBox2.Controls.Add(this.RbTileHexadecimal);
            this.groupBox2.Controls.Add(this.RbTileDecimal);
            this.groupBox2.Location = new System.Drawing.Point(13, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(10, 5, 5, 5);
            this.groupBox2.Size = new System.Drawing.Size(162, 121);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tile format";
            // 
            // RbTileBase64
            // 
            this.RbTileBase64.AutoSize = true;
            this.RbTileBase64.Location = new System.Drawing.Point(13, 90);
            this.RbTileBase64.Name = "RbTileBase64";
            this.RbTileBase64.Size = new System.Drawing.Size(61, 17);
            this.RbTileBase64.TabIndex = 3;
            this.RbTileBase64.Text = "Base64";
            this.RbTileBase64.UseVisualStyleBackColor = true;
            // 
            // RbTileBinaryString
            // 
            this.RbTileBinaryString.AutoSize = true;
            this.RbTileBinaryString.Location = new System.Drawing.Point(13, 67);
            this.RbTileBinaryString.Name = "RbTileBinaryString";
            this.RbTileBinaryString.Size = new System.Drawing.Size(82, 17);
            this.RbTileBinaryString.TabIndex = 2;
            this.RbTileBinaryString.Text = "Binary string";
            this.RbTileBinaryString.UseVisualStyleBackColor = true;
            // 
            // RbTileHexadecimal
            // 
            this.RbTileHexadecimal.AutoSize = true;
            this.RbTileHexadecimal.Location = new System.Drawing.Point(13, 44);
            this.RbTileHexadecimal.Name = "RbTileHexadecimal";
            this.RbTileHexadecimal.Size = new System.Drawing.Size(123, 17);
            this.RbTileHexadecimal.TabIndex = 1;
            this.RbTileHexadecimal.Text = "Hexadecimal 8 bytes";
            this.RbTileHexadecimal.UseVisualStyleBackColor = true;
            // 
            // RbTileDecimal
            // 
            this.RbTileDecimal.AutoSize = true;
            this.RbTileDecimal.Checked = true;
            this.RbTileDecimal.Location = new System.Drawing.Point(13, 21);
            this.RbTileDecimal.Name = "RbTileDecimal";
            this.RbTileDecimal.Size = new System.Drawing.Size(100, 17);
            this.RbTileDecimal.TabIndex = 0;
            this.RbTileDecimal.TabStop = true;
            this.RbTileDecimal.Text = "Decimal 8 bytes";
            this.RbTileDecimal.UseVisualStyleBackColor = true;
            // 
            // BtnExtractTilesetData
            // 
            this.BtnExtractTilesetData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExtractTilesetData.Location = new System.Drawing.Point(331, 179);
            this.BtnExtractTilesetData.Name = "BtnExtractTilesetData";
            this.BtnExtractTilesetData.Size = new System.Drawing.Size(106, 27);
            this.BtnExtractTilesetData.TabIndex = 3;
            this.BtnExtractTilesetData.Text = "Extract data";
            this.BtnExtractTilesetData.UseVisualStyleBackColor = true;
            this.BtnExtractTilesetData.Click += new System.EventHandler(this.BtnExtractTilesetData_Click);
            // 
            // RootPanel
            // 
            this.RootPanel.Controls.Add(this.tableLayoutPanel1);
            this.RootPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RootPanel.Location = new System.Drawing.Point(0, 0);
            this.RootPanel.Name = "RootPanel";
            this.RootPanel.Padding = new System.Windows.Forms.Padding(5);
            this.RootPanel.Size = new System.Drawing.Size(474, 512);
            this.RootPanel.TabIndex = 1;
            // 
            // DataExtractorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 512);
            this.Controls.Add(this.RootPanel);
            this.Name = "DataExtractorWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data extractor";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PaletteRangeLast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaletteRangeFirst)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TilesetRangeLast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TilesetRangeFirst)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.RootPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel RootPanel;
        private System.Windows.Forms.TextBox TxtOutput;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbLayer;
        private System.Windows.Forms.Button BtnExtractMapData;
        private System.Windows.Forms.Button BtnExtractPaletteData;
        private System.Windows.Forms.Button BtnExtractTilesetData;
        private System.Windows.Forms.CheckBox ChkObject1stTileIndex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ChkObject1stTileBackColor;
        private System.Windows.Forms.CheckBox ChkObject1stTileForeColor;
        private System.Windows.Forms.TextBox TxtObjectEmptyCell;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtObjectLineSuffix;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtObjectLinePrefix;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtObjectDataItemSeparator;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RbPaletteFmtDecInt;
        private System.Windows.Forms.RadioButton RbPaletteFmtHexInt;
        private System.Windows.Forms.TextBox TxtColorLineSuffix;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtColorLinePrefix;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton RbPaletteFmtHexRgb;
        private System.Windows.Forms.RadioButton RbPaletteFmtDecRgb;
        private System.Windows.Forms.TextBox TxtColorHexPrefix;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox ChkColorAppendAlpha;
        private System.Windows.Forms.TextBox TxtColorComponentSeparator;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtTileByteSeparator;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TxtTileHexPrefix;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TxtTileLineSuffix;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox TxtTileLinePrefix;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RbTileBase64;
        private System.Windows.Forms.RadioButton RbTileBinaryString;
        private System.Windows.Forms.RadioButton RbTileHexadecimal;
        private System.Windows.Forms.RadioButton RbTileDecimal;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown PaletteRangeLast;
        private System.Windows.Forms.NumericUpDown PaletteRangeFirst;
        private System.Windows.Forms.NumericUpDown TilesetRangeLast;
        private System.Windows.Forms.NumericUpDown TilesetRangeFirst;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button BtnCopyOutput;
    }
}