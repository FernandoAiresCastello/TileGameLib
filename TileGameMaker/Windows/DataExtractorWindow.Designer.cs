﻿namespace TileGameMaker.Windows
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
            this.TxtOutput = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.CmbLayer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.RootPanel = new System.Windows.Forms.Panel();
            this.BtnExtractMapData = new System.Windows.Forms.Button();
            this.BtnExtractPaletteData = new System.Windows.Forms.Button();
            this.BtnExtractTilesetData = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ChkObjectTag = new System.Windows.Forms.CheckBox();
            this.ChkObject1stTileIndex = new System.Windows.Forms.CheckBox();
            this.ChkObject1stTileForeColor = new System.Windows.Forms.CheckBox();
            this.ChkObject1stTileBackColor = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtObjectEmptyCell = new System.Windows.Forms.TextBox();
            this.TxtObjectLinePrefix = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtObjectLineSuffix = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtObjectDataItemSeparator = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.RootPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.TxtOutput, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(475, 508);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // TxtOutput
            // 
            this.TxtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtOutput.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtOutput.Location = new System.Drawing.Point(3, 257);
            this.TxtOutput.Multiline = true;
            this.TxtOutput.Name = "TxtOutput";
            this.TxtOutput.ReadOnly = true;
            this.TxtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtOutput.Size = new System.Drawing.Size(469, 248);
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
            this.tabControl1.Size = new System.Drawing.Size(469, 248);
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
            this.tabPage1.Controls.Add(this.ChkObjectTag);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.BtnExtractMapData);
            this.tabPage1.Controls.Add(this.CmbLayer);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(10);
            this.tabPage1.Size = new System.Drawing.Size(461, 222);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Map";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.tabPage2.Controls.Add(this.BtnExtractPaletteData);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(10);
            this.tabPage2.Size = new System.Drawing.Size(461, 283);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Palette";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.BtnExtractTilesetData);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(10);
            this.tabPage3.Size = new System.Drawing.Size(461, 283);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Tileset";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // RootPanel
            // 
            this.RootPanel.Controls.Add(this.tableLayoutPanel1);
            this.RootPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RootPanel.Location = new System.Drawing.Point(0, 0);
            this.RootPanel.Name = "RootPanel";
            this.RootPanel.Padding = new System.Windows.Forms.Padding(5);
            this.RootPanel.Size = new System.Drawing.Size(485, 518);
            this.RootPanel.TabIndex = 1;
            // 
            // BtnExtractMapData
            // 
            this.BtnExtractMapData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExtractMapData.Location = new System.Drawing.Point(342, 182);
            this.BtnExtractMapData.Name = "BtnExtractMapData";
            this.BtnExtractMapData.Size = new System.Drawing.Size(106, 27);
            this.BtnExtractMapData.TabIndex = 2;
            this.BtnExtractMapData.Text = "Extract data";
            this.BtnExtractMapData.UseVisualStyleBackColor = true;
            this.BtnExtractMapData.Click += new System.EventHandler(this.BtnExtractMapData_Click);
            // 
            // BtnExtractPaletteData
            // 
            this.BtnExtractPaletteData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExtractPaletteData.Location = new System.Drawing.Point(342, 243);
            this.BtnExtractPaletteData.Name = "BtnExtractPaletteData";
            this.BtnExtractPaletteData.Size = new System.Drawing.Size(106, 27);
            this.BtnExtractPaletteData.TabIndex = 3;
            this.BtnExtractPaletteData.Text = "Extract data";
            this.BtnExtractPaletteData.UseVisualStyleBackColor = true;
            this.BtnExtractPaletteData.Click += new System.EventHandler(this.BtnExtractPaletteData_Click);
            // 
            // BtnExtractTilesetData
            // 
            this.BtnExtractTilesetData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExtractTilesetData.Location = new System.Drawing.Point(342, 243);
            this.BtnExtractTilesetData.Name = "BtnExtractTilesetData";
            this.BtnExtractTilesetData.Size = new System.Drawing.Size(106, 27);
            this.BtnExtractTilesetData.TabIndex = 3;
            this.BtnExtractTilesetData.Text = "Extract data";
            this.BtnExtractTilesetData.UseVisualStyleBackColor = true;
            this.BtnExtractTilesetData.Click += new System.EventHandler(this.BtnExtractTilesetData_Click);
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
            // ChkObjectTag
            // 
            this.ChkObjectTag.AutoSize = true;
            this.ChkObjectTag.Location = new System.Drawing.Point(86, 49);
            this.ChkObjectTag.Name = "ChkObjectTag";
            this.ChkObjectTag.Size = new System.Drawing.Size(45, 17);
            this.ChkObjectTag.TabIndex = 4;
            this.ChkObjectTag.Text = "Tag";
            this.ChkObjectTag.UseVisualStyleBackColor = true;
            // 
            // ChkObject1stTileIndex
            // 
            this.ChkObject1stTileIndex.AutoSize = true;
            this.ChkObject1stTileIndex.Location = new System.Drawing.Point(86, 72);
            this.ChkObject1stTileIndex.Name = "ChkObject1stTileIndex";
            this.ChkObject1stTileIndex.Size = new System.Drawing.Size(84, 17);
            this.ChkObject1stTileIndex.TabIndex = 5;
            this.ChkObject1stTileIndex.Text = "1st tile index";
            this.ChkObject1stTileIndex.UseVisualStyleBackColor = true;
            // 
            // ChkObject1stTileForeColor
            // 
            this.ChkObject1stTileForeColor.AutoSize = true;
            this.ChkObject1stTileForeColor.Location = new System.Drawing.Point(86, 95);
            this.ChkObject1stTileForeColor.Name = "ChkObject1stTileForeColor";
            this.ChkObject1stTileForeColor.Size = new System.Drawing.Size(100, 17);
            this.ChkObject1stTileForeColor.TabIndex = 6;
            this.ChkObject1stTileForeColor.Text = "1st tile forecolor";
            this.ChkObject1stTileForeColor.UseVisualStyleBackColor = true;
            // 
            // ChkObject1stTileBackColor
            // 
            this.ChkObject1stTileBackColor.AutoSize = true;
            this.ChkObject1stTileBackColor.Location = new System.Drawing.Point(86, 118);
            this.ChkObject1stTileBackColor.Name = "ChkObject1stTileBackColor";
            this.ChkObject1stTileBackColor.Size = new System.Drawing.Size(106, 17);
            this.ChkObject1stTileBackColor.TabIndex = 7;
            this.ChkObject1stTileBackColor.Text = "1st tile backcolor";
            this.ChkObject1stTileBackColor.UseVisualStyleBackColor = true;
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
            // TxtObjectEmptyCell
            // 
            this.TxtObjectEmptyCell.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtObjectEmptyCell.Location = new System.Drawing.Point(285, 70);
            this.TxtObjectEmptyCell.Name = "TxtObjectEmptyCell";
            this.TxtObjectEmptyCell.Size = new System.Drawing.Size(52, 20);
            this.TxtObjectEmptyCell.TabIndex = 9;
            this.TxtObjectEmptyCell.Text = "-1";
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
            // DataExtractorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 518);
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
            this.tabPage3.ResumeLayout(false);
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
        private System.Windows.Forms.CheckBox ChkObjectTag;
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
    }
}