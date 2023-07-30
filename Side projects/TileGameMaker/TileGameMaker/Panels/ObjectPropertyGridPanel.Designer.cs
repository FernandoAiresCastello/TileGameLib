namespace TileGameMaker.Panels
{
    partial class ObjectPropertyGridPanel
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObjectPropertyGridPanel));
            this.Grid = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BtnAdd = new System.Windows.Forms.ToolStripButton();
            this.BtnDeleteSelectedProperty = new System.Windows.Forms.ToolStripButton();
            this.BtnGenerateId = new System.Windows.Forms.ToolStripButton();
            this.BtnDeleteAllProperties = new System.Windows.Forms.ToolStripButton();
            this.BtnOpenTextEditor = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Grid
            // 
            this.Grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.ColumnHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grid.DefaultCellStyle = dataGridViewCellStyle3;
            this.Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid.Location = new System.Drawing.Point(0, 25);
            this.Grid.Margin = new System.Windows.Forms.Padding(0);
            this.Grid.Name = "Grid";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.Grid.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.Grid.Size = new System.Drawing.Size(232, 277);
            this.Grid.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.Grid, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(232, 302);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnAdd,
            this.BtnDeleteSelectedProperty,
            this.BtnGenerateId,
            this.BtnDeleteAllProperties,
            this.BtnOpenTextEditor});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.toolStrip1.Size = new System.Drawing.Size(232, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BtnAdd
            // 
            this.BtnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnAdd.Image = global::TileGameMaker.Properties.Resources.add;
            this.BtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(23, 22);
            this.BtnAdd.Text = "Add property";
            this.BtnAdd.ToolTipText = "Add property";
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnDeleteSelectedProperty
            // 
            this.BtnDeleteSelectedProperty.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnDeleteSelectedProperty.Image = global::TileGameMaker.Properties.Resources.delete;
            this.BtnDeleteSelectedProperty.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnDeleteSelectedProperty.Name = "BtnDeleteSelectedProperty";
            this.BtnDeleteSelectedProperty.Size = new System.Drawing.Size(23, 22);
            this.BtnDeleteSelectedProperty.Text = "toolStripButton1";
            this.BtnDeleteSelectedProperty.ToolTipText = "Delete selected property";
            this.BtnDeleteSelectedProperty.Click += new System.EventHandler(this.BtnDeleteSelectedProperty_Click);
            // 
            // BtnGenerateId
            // 
            this.BtnGenerateId.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnGenerateId.Image = global::TileGameMaker.Properties.Resources.tag_blue_add;
            this.BtnGenerateId.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnGenerateId.Name = "BtnGenerateId";
            this.BtnGenerateId.Size = new System.Drawing.Size(23, 22);
            this.BtnGenerateId.Text = "toolStripButton1";
            this.BtnGenerateId.ToolTipText = "Generate ID";
            this.BtnGenerateId.Click += new System.EventHandler(this.BtnGenerateId_Click);
            // 
            // BtnDeleteAllProperties
            // 
            this.BtnDeleteAllProperties.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnDeleteAllProperties.Image = global::TileGameMaker.Properties.Resources.broom;
            this.BtnDeleteAllProperties.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnDeleteAllProperties.Name = "BtnDeleteAllProperties";
            this.BtnDeleteAllProperties.Size = new System.Drawing.Size(23, 22);
            this.BtnDeleteAllProperties.Text = "toolStripButton1";
            this.BtnDeleteAllProperties.ToolTipText = "Delete all properties";
            this.BtnDeleteAllProperties.Click += new System.EventHandler(this.BtnDeleteAllProperties_Click);
            // 
            // BtnOpenTextEditor
            // 
            this.BtnOpenTextEditor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnOpenTextEditor.Image = ((System.Drawing.Image)(resources.GetObject("BtnOpenTextEditor.Image")));
            this.BtnOpenTextEditor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnOpenTextEditor.Name = "BtnOpenTextEditor";
            this.BtnOpenTextEditor.Size = new System.Drawing.Size(23, 22);
            this.BtnOpenTextEditor.Text = "Edit in text editor";
            this.BtnOpenTextEditor.Click += new System.EventHandler(this.BtnOpenTextEditor_Click);
            // 
            // ObjectPropertyGridPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ObjectPropertyGridPanel";
            this.Size = new System.Drawing.Size(232, 302);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BtnDeleteSelectedProperty;
        private System.Windows.Forms.ToolStripButton BtnDeleteAllProperties;
        private System.Windows.Forms.ToolStripButton BtnOpenTextEditor;
        private System.Windows.Forms.ToolStripButton BtnAdd;
        private System.Windows.Forms.ToolStripButton BtnGenerateId;
    }
}
