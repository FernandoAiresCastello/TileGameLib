namespace TileGameMaker.Windows
{
    partial class TemplateObjectWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TemplatePropPanel = new System.Windows.Forms.Panel();
            this.PropertyList = new System.Windows.Forms.DataGridView();
            this.gridViewPropertyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridViewPropertyValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TemplateListPanel = new System.Windows.Forms.Panel();
            this.TemplateList = new System.Windows.Forms.DataGridView();
            this.gridViewTemplateId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BtnNewTemplate = new System.Windows.Forms.ToolStripButton();
            this.BtnEditSelected = new System.Windows.Forms.ToolStripButton();
            this.BtnDuplicateSelected = new System.Windows.Forms.ToolStripButton();
            this.BtnDeleteSelected = new System.Windows.Forms.ToolStripButton();
            this.TemplateMapPanel = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.LbStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.BtnRearrange = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.TemplatePropPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PropertyList)).BeginInit();
            this.TemplateListPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TemplateList)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.TemplatePropPanel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.TemplateListPanel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TemplateMapPanel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.statusStrip1, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 69.07021F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.92979F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(562, 618);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // TemplatePropPanel
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.TemplatePropPanel, 2);
            this.TemplatePropPanel.Controls.Add(this.PropertyList);
            this.TemplatePropPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TemplatePropPanel.Location = new System.Drawing.Point(3, 422);
            this.TemplatePropPanel.Name = "TemplatePropPanel";
            this.TemplatePropPanel.Size = new System.Drawing.Size(556, 170);
            this.TemplatePropPanel.TabIndex = 3;
            // 
            // PropertyList
            // 
            this.PropertyList.AllowUserToAddRows = false;
            this.PropertyList.AllowUserToDeleteRows = false;
            this.PropertyList.AllowUserToResizeRows = false;
            this.PropertyList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PropertyList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.PropertyList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PropertyList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridViewPropertyName,
            this.gridViewPropertyValue});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.PropertyList.DefaultCellStyle = dataGridViewCellStyle6;
            this.PropertyList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertyList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.PropertyList.Location = new System.Drawing.Point(0, 0);
            this.PropertyList.MultiSelect = false;
            this.PropertyList.Name = "PropertyList";
            this.PropertyList.ReadOnly = true;
            this.PropertyList.RowHeadersVisible = false;
            this.PropertyList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.PropertyList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PropertyList.Size = new System.Drawing.Size(556, 170);
            this.PropertyList.TabIndex = 1;
            // 
            // gridViewPropertyName
            // 
            this.gridViewPropertyName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gridViewPropertyName.FillWeight = 20F;
            this.gridViewPropertyName.HeaderText = "Property";
            this.gridViewPropertyName.Name = "gridViewPropertyName";
            this.gridViewPropertyName.ReadOnly = true;
            // 
            // gridViewPropertyValue
            // 
            this.gridViewPropertyValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gridViewPropertyValue.HeaderText = "Value";
            this.gridViewPropertyValue.Name = "gridViewPropertyValue";
            this.gridViewPropertyValue.ReadOnly = true;
            // 
            // TemplateListPanel
            // 
            this.TemplateListPanel.Controls.Add(this.TemplateList);
            this.TemplateListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TemplateListPanel.Location = new System.Drawing.Point(3, 28);
            this.TemplateListPanel.Name = "TemplateListPanel";
            this.TemplateListPanel.Size = new System.Drawing.Size(162, 388);
            this.TemplateListPanel.TabIndex = 2;
            // 
            // TemplateList
            // 
            this.TemplateList.AllowUserToAddRows = false;
            this.TemplateList.AllowUserToDeleteRows = false;
            this.TemplateList.AllowUserToResizeRows = false;
            this.TemplateList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TemplateList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.TemplateList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TemplateList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridViewTemplateId});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.TemplateList.DefaultCellStyle = dataGridViewCellStyle8;
            this.TemplateList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TemplateList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.TemplateList.Location = new System.Drawing.Point(0, 0);
            this.TemplateList.MultiSelect = false;
            this.TemplateList.Name = "TemplateList";
            this.TemplateList.ReadOnly = true;
            this.TemplateList.RowHeadersVisible = false;
            this.TemplateList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.TemplateList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TemplateList.Size = new System.Drawing.Size(162, 388);
            this.TemplateList.TabIndex = 0;
            // 
            // gridViewTemplateId
            // 
            this.gridViewTemplateId.HeaderText = "ID";
            this.gridViewTemplateId.Name = "gridViewTemplateId";
            this.gridViewTemplateId.ReadOnly = true;
            // 
            // toolStrip1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.toolStrip1, 2);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnNewTemplate,
            this.BtnEditSelected,
            this.BtnDuplicateSelected,
            this.BtnDeleteSelected,
            this.BtnRearrange});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(562, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BtnNewTemplate
            // 
            this.BtnNewTemplate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnNewTemplate.Image = global::TileGameMaker.Properties.Resources.page_white;
            this.BtnNewTemplate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnNewTemplate.Name = "BtnNewTemplate";
            this.BtnNewTemplate.Size = new System.Drawing.Size(23, 22);
            this.BtnNewTemplate.Text = "New template";
            this.BtnNewTemplate.Click += new System.EventHandler(this.BtnNewTemplate_Click);
            // 
            // BtnEditSelected
            // 
            this.BtnEditSelected.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnEditSelected.Image = global::TileGameMaker.Properties.Resources.pencil;
            this.BtnEditSelected.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnEditSelected.Name = "BtnEditSelected";
            this.BtnEditSelected.Size = new System.Drawing.Size(23, 22);
            this.BtnEditSelected.Text = "Edit selected template";
            this.BtnEditSelected.Click += new System.EventHandler(this.BtnEditSelected_Click);
            // 
            // BtnDuplicateSelected
            // 
            this.BtnDuplicateSelected.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnDuplicateSelected.Image = global::TileGameMaker.Properties.Resources.page_white_copy;
            this.BtnDuplicateSelected.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnDuplicateSelected.Name = "BtnDuplicateSelected";
            this.BtnDuplicateSelected.Size = new System.Drawing.Size(23, 22);
            this.BtnDuplicateSelected.Text = "Duplicate selected template";
            this.BtnDuplicateSelected.Click += new System.EventHandler(this.BtnDuplicateSelected_Click);
            // 
            // BtnDeleteSelected
            // 
            this.BtnDeleteSelected.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnDeleteSelected.Image = global::TileGameMaker.Properties.Resources.delete;
            this.BtnDeleteSelected.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnDeleteSelected.Name = "BtnDeleteSelected";
            this.BtnDeleteSelected.Size = new System.Drawing.Size(23, 22);
            this.BtnDeleteSelected.Text = "Delete selected template";
            this.BtnDeleteSelected.Click += new System.EventHandler(this.BtnDeleteSelected_Click);
            // 
            // TemplateMapPanel
            // 
            this.TemplateMapPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TemplateMapPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TemplateMapPanel.Location = new System.Drawing.Point(171, 28);
            this.TemplateMapPanel.Name = "TemplateMapPanel";
            this.TemplateMapPanel.Size = new System.Drawing.Size(388, 388);
            this.TemplateMapPanel.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.statusStrip1, 2);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LbStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 596);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(562, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // LbStatus
            // 
            this.LbStatus.Name = "LbStatus";
            this.LbStatus.Size = new System.Drawing.Size(454, 17);
            this.LbStatus.Text = "LMB: Select template | RMB: New template | ESC: Minimize | F2: Rename | DEL: Dele" +
    "te";
            // 
            // BtnRearrange
            // 
            this.BtnRearrange.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnRearrange.Image = global::TileGameMaker.Properties.Resources.layer_stack_arrange;
            this.BtnRearrange.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnRearrange.Name = "BtnRearrange";
            this.BtnRearrange.Size = new System.Drawing.Size(23, 22);
            this.BtnRearrange.Text = "Rearrange templates";
            this.BtnRearrange.Click += new System.EventHandler(this.BtnRearrange_Click);
            // 
            // TemplateObjectWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 618);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TemplateObjectWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Template objects";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.TemplatePropPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PropertyList)).EndInit();
            this.TemplateListPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TemplateList)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel TemplateMapPanel;
        private System.Windows.Forms.Panel TemplateListPanel;
        private System.Windows.Forms.Panel TemplatePropPanel;
        private System.Windows.Forms.DataGridView TemplateList;
        private System.Windows.Forms.DataGridView PropertyList;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel LbStatus;
        private System.Windows.Forms.ToolStripButton BtnEditSelected;
        private System.Windows.Forms.ToolStripButton BtnDeleteSelected;
        private System.Windows.Forms.ToolStripButton BtnNewTemplate;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridViewPropertyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridViewPropertyValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridViewTemplateId;
        private System.Windows.Forms.ToolStripButton BtnDuplicateSelected;
        private System.Windows.Forms.ToolStripButton BtnRearrange;
    }
}