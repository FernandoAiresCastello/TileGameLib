namespace TileGameMaker.Windows
{
    partial class SearchWindow
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
            this.BtnTileIndex = new System.Windows.Forms.Button();
            this.TxtTileIndex = new System.Windows.Forms.TextBox();
            this.TxtTileForeColor = new System.Windows.Forms.TextBox();
            this.BtnTileForeColor = new System.Windows.Forms.Button();
            this.TxtTileBackColor = new System.Windows.Forms.TextBox();
            this.BtnTileBackColor = new System.Windows.Forms.Button();
            this.BtnClearTileIndex = new System.Windows.Forms.Button();
            this.BtnClearTileForeColor = new System.Windows.Forms.Button();
            this.BtnClearTileBackColor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtProperties = new System.Windows.Forms.TextBox();
            this.BtnSelect = new System.Windows.Forms.Button();
            this.ChkVisible = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnDeselectAll = new System.Windows.Forms.Button();
            this.BtnOverrideColors = new System.Windows.Forms.Button();
            this.BtnReplace = new System.Windows.Forms.Button();
            this.BtnOverrideTileIndex = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtnTileIndex
            // 
            this.BtnTileIndex.Location = new System.Drawing.Point(12, 12);
            this.BtnTileIndex.Name = "BtnTileIndex";
            this.BtnTileIndex.Size = new System.Drawing.Size(91, 23);
            this.BtnTileIndex.TabIndex = 0;
            this.BtnTileIndex.Text = "Tile index";
            this.BtnTileIndex.UseVisualStyleBackColor = true;
            this.BtnTileIndex.Click += new System.EventHandler(this.BtnTileIndex_Click);
            // 
            // TxtTileIndex
            // 
            this.TxtTileIndex.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTileIndex.Location = new System.Drawing.Point(109, 14);
            this.TxtTileIndex.Name = "TxtTileIndex";
            this.TxtTileIndex.ReadOnly = true;
            this.TxtTileIndex.Size = new System.Drawing.Size(63, 20);
            this.TxtTileIndex.TabIndex = 1;
            this.TxtTileIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtTileForeColor
            // 
            this.TxtTileForeColor.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTileForeColor.Location = new System.Drawing.Point(109, 43);
            this.TxtTileForeColor.Name = "TxtTileForeColor";
            this.TxtTileForeColor.ReadOnly = true;
            this.TxtTileForeColor.Size = new System.Drawing.Size(63, 20);
            this.TxtTileForeColor.TabIndex = 3;
            this.TxtTileForeColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BtnTileForeColor
            // 
            this.BtnTileForeColor.Location = new System.Drawing.Point(12, 41);
            this.BtnTileForeColor.Name = "BtnTileForeColor";
            this.BtnTileForeColor.Size = new System.Drawing.Size(91, 23);
            this.BtnTileForeColor.TabIndex = 2;
            this.BtnTileForeColor.Text = "Tile forecolor";
            this.BtnTileForeColor.UseVisualStyleBackColor = true;
            this.BtnTileForeColor.Click += new System.EventHandler(this.BtnTileForeColor_Click);
            // 
            // TxtTileBackColor
            // 
            this.TxtTileBackColor.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTileBackColor.Location = new System.Drawing.Point(109, 72);
            this.TxtTileBackColor.Name = "TxtTileBackColor";
            this.TxtTileBackColor.ReadOnly = true;
            this.TxtTileBackColor.Size = new System.Drawing.Size(63, 20);
            this.TxtTileBackColor.TabIndex = 5;
            this.TxtTileBackColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BtnTileBackColor
            // 
            this.BtnTileBackColor.Location = new System.Drawing.Point(12, 70);
            this.BtnTileBackColor.Name = "BtnTileBackColor";
            this.BtnTileBackColor.Size = new System.Drawing.Size(91, 23);
            this.BtnTileBackColor.TabIndex = 4;
            this.BtnTileBackColor.Text = "Tile backcolor";
            this.BtnTileBackColor.UseVisualStyleBackColor = true;
            this.BtnTileBackColor.Click += new System.EventHandler(this.BtnTileBackColor_Click);
            // 
            // BtnClearTileIndex
            // 
            this.BtnClearTileIndex.Location = new System.Drawing.Point(178, 12);
            this.BtnClearTileIndex.Name = "BtnClearTileIndex";
            this.BtnClearTileIndex.Size = new System.Drawing.Size(47, 23);
            this.BtnClearTileIndex.TabIndex = 6;
            this.BtnClearTileIndex.Text = "Clear";
            this.BtnClearTileIndex.UseVisualStyleBackColor = true;
            this.BtnClearTileIndex.Click += new System.EventHandler(this.BtnClearTileIndex_Click);
            // 
            // BtnClearTileForeColor
            // 
            this.BtnClearTileForeColor.Location = new System.Drawing.Point(178, 42);
            this.BtnClearTileForeColor.Name = "BtnClearTileForeColor";
            this.BtnClearTileForeColor.Size = new System.Drawing.Size(47, 23);
            this.BtnClearTileForeColor.TabIndex = 7;
            this.BtnClearTileForeColor.Text = "Clear";
            this.BtnClearTileForeColor.UseVisualStyleBackColor = true;
            this.BtnClearTileForeColor.Click += new System.EventHandler(this.BtnClearTileForeColor_Click);
            // 
            // BtnClearTileBackColor
            // 
            this.BtnClearTileBackColor.Location = new System.Drawing.Point(178, 70);
            this.BtnClearTileBackColor.Name = "BtnClearTileBackColor";
            this.BtnClearTileBackColor.Size = new System.Drawing.Size(47, 23);
            this.BtnClearTileBackColor.TabIndex = 8;
            this.BtnClearTileBackColor.Text = "Clear";
            this.BtnClearTileBackColor.UseVisualStyleBackColor = true;
            this.BtnClearTileBackColor.Click += new System.EventHandler(this.BtnClearTileBackColor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Properties: (property1=value; property2=value; ...)";
            // 
            // TxtProperties
            // 
            this.TxtProperties.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProperties.Location = new System.Drawing.Point(15, 168);
            this.TxtProperties.Multiline = true;
            this.TxtProperties.Name = "TxtProperties";
            this.TxtProperties.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtProperties.Size = new System.Drawing.Size(257, 185);
            this.TxtProperties.TabIndex = 10;
            this.TxtProperties.WordWrap = false;
            // 
            // BtnSelect
            // 
            this.BtnSelect.Location = new System.Drawing.Point(296, 321);
            this.BtnSelect.Name = "BtnSelect";
            this.BtnSelect.Size = new System.Drawing.Size(162, 32);
            this.BtnSelect.TabIndex = 11;
            this.BtnSelect.Text = "Find and select";
            this.BtnSelect.UseVisualStyleBackColor = true;
            this.BtnSelect.Click += new System.EventHandler(this.BtnSelect_Click);
            // 
            // ChkVisible
            // 
            this.ChkVisible.AutoSize = true;
            this.ChkVisible.Checked = true;
            this.ChkVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkVisible.Location = new System.Drawing.Point(15, 110);
            this.ChkVisible.Name = "ChkVisible";
            this.ChkVisible.Size = new System.Drawing.Size(56, 17);
            this.ChkVisible.TabIndex = 12;
            this.ChkVisible.Text = "Visible";
            this.ChkVisible.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(293, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Selection actions:";
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(296, 69);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(162, 32);
            this.BtnDelete.TabIndex = 14;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnDeselectAll
            // 
            this.BtnDeselectAll.Location = new System.Drawing.Point(296, 36);
            this.BtnDeselectAll.Name = "BtnDeselectAll";
            this.BtnDeselectAll.Size = new System.Drawing.Size(162, 32);
            this.BtnDeselectAll.TabIndex = 15;
            this.BtnDeselectAll.Text = "Deselect all";
            this.BtnDeselectAll.UseVisualStyleBackColor = true;
            this.BtnDeselectAll.Click += new System.EventHandler(this.BtnDeselectAll_Click);
            // 
            // BtnOverrideColors
            // 
            this.BtnOverrideColors.Location = new System.Drawing.Point(296, 102);
            this.BtnOverrideColors.Name = "BtnOverrideColors";
            this.BtnOverrideColors.Size = new System.Drawing.Size(162, 32);
            this.BtnOverrideColors.TabIndex = 16;
            this.BtnOverrideColors.Text = "Override colors";
            this.BtnOverrideColors.UseVisualStyleBackColor = true;
            this.BtnOverrideColors.Click += new System.EventHandler(this.BtnOverrideColors_Click);
            // 
            // BtnReplace
            // 
            this.BtnReplace.Location = new System.Drawing.Point(296, 168);
            this.BtnReplace.Name = "BtnReplace";
            this.BtnReplace.Size = new System.Drawing.Size(162, 32);
            this.BtnReplace.TabIndex = 17;
            this.BtnReplace.Text = "Replace";
            this.BtnReplace.UseVisualStyleBackColor = true;
            this.BtnReplace.Click += new System.EventHandler(this.BtnReplace_Click);
            // 
            // BtnOverrideTileIndex
            // 
            this.BtnOverrideTileIndex.Location = new System.Drawing.Point(296, 135);
            this.BtnOverrideTileIndex.Name = "BtnOverrideTileIndex";
            this.BtnOverrideTileIndex.Size = new System.Drawing.Size(162, 32);
            this.BtnOverrideTileIndex.TabIndex = 18;
            this.BtnOverrideTileIndex.Text = "Override tile index";
            this.BtnOverrideTileIndex.UseVisualStyleBackColor = true;
            this.BtnOverrideTileIndex.Click += new System.EventHandler(this.BtnOverrideTileIndex_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(293, 273);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Find by ID only:";
            // 
            // TxtId
            // 
            this.TxtId.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtId.Location = new System.Drawing.Point(296, 295);
            this.TxtId.MaxLength = 10;
            this.TxtId.Name = "TxtId";
            this.TxtId.Size = new System.Drawing.Size(162, 20);
            this.TxtId.TabIndex = 21;
            this.TxtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SearchWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 365);
            this.Controls.Add(this.TxtId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnOverrideTileIndex);
            this.Controls.Add(this.BtnReplace);
            this.Controls.Add(this.BtnOverrideColors);
            this.Controls.Add(this.BtnDeselectAll);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ChkVisible);
            this.Controls.Add(this.BtnSelect);
            this.Controls.Add(this.TxtProperties);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnClearTileBackColor);
            this.Controls.Add(this.BtnClearTileForeColor);
            this.Controls.Add(this.BtnClearTileIndex);
            this.Controls.Add(this.TxtTileBackColor);
            this.Controls.Add(this.BtnTileBackColor);
            this.Controls.Add(this.TxtTileForeColor);
            this.Controls.Add(this.BtnTileForeColor);
            this.Controls.Add(this.TxtTileIndex);
            this.Controls.Add(this.BtnTileIndex);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SearchWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find objects";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnTileIndex;
        private System.Windows.Forms.TextBox TxtTileIndex;
        private System.Windows.Forms.TextBox TxtTileForeColor;
        private System.Windows.Forms.Button BtnTileForeColor;
        private System.Windows.Forms.TextBox TxtTileBackColor;
        private System.Windows.Forms.Button BtnTileBackColor;
        private System.Windows.Forms.Button BtnClearTileIndex;
        private System.Windows.Forms.Button BtnClearTileForeColor;
        private System.Windows.Forms.Button BtnClearTileBackColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtProperties;
        private System.Windows.Forms.Button BtnSelect;
        private System.Windows.Forms.CheckBox ChkVisible;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnDeselectAll;
        private System.Windows.Forms.Button BtnOverrideColors;
        private System.Windows.Forms.Button BtnReplace;
        private System.Windows.Forms.Button BtnOverrideTileIndex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtId;
    }
}