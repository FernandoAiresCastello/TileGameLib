namespace TileGameMaker.Panels
{
    partial class ProjectPanel
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ToolStripAndGrid = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.MapListGrid = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TxtProjectName = new System.Windows.Forms.TextBox();
            this.LblProjectName = new System.Windows.Forms.Label();
            this.BtnAdd = new System.Windows.Forms.ToolStripButton();
            this.BtnDelete = new System.Windows.Forms.ToolStripButton();
            this.BtnDuplicate = new System.Windows.Forms.ToolStripButton();
            this.map = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.ToolStripAndGrid.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapListGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.ToolStripAndGrid, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(258, 361);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // ToolStripAndGrid
            // 
            this.ToolStripAndGrid.ColumnCount = 1;
            this.ToolStripAndGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ToolStripAndGrid.Controls.Add(this.toolStrip1, 0, 1);
            this.ToolStripAndGrid.Controls.Add(this.MapListGrid, 0, 2);
            this.ToolStripAndGrid.Controls.Add(this.panel1, 0, 0);
            this.ToolStripAndGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolStripAndGrid.Location = new System.Drawing.Point(0, 0);
            this.ToolStripAndGrid.Margin = new System.Windows.Forms.Padding(0);
            this.ToolStripAndGrid.Name = "ToolStripAndGrid";
            this.ToolStripAndGrid.RowCount = 3;
            this.ToolStripAndGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ToolStripAndGrid.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ToolStripAndGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ToolStripAndGrid.Size = new System.Drawing.Size(258, 361);
            this.ToolStripAndGrid.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnAdd,
            this.BtnDelete,
            this.BtnDuplicate});
            this.toolStrip1.Location = new System.Drawing.Point(0, 30);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(8, 5, 0, 2);
            this.toolStrip1.Size = new System.Drawing.Size(258, 30);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // MapListGrid
            // 
            this.MapListGrid.AllowUserToAddRows = false;
            this.MapListGrid.AllowUserToDeleteRows = false;
            this.MapListGrid.AllowUserToResizeColumns = false;
            this.MapListGrid.AllowUserToResizeRows = false;
            this.MapListGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MapListGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.MapListGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.MapListGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.map,
            this.id});
            this.MapListGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapListGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.MapListGrid.Location = new System.Drawing.Point(3, 63);
            this.MapListGrid.MultiSelect = false;
            this.MapListGrid.Name = "MapListGrid";
            this.MapListGrid.ReadOnly = true;
            this.MapListGrid.RowHeadersVisible = false;
            this.MapListGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.MapListGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MapListGrid.Size = new System.Drawing.Size(252, 295);
            this.MapListGrid.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TxtProjectName);
            this.panel1.Controls.Add(this.LblProjectName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(252, 24);
            this.panel1.TabIndex = 2;
            // 
            // TxtProjectName
            // 
            this.TxtProjectName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtProjectName.Location = new System.Drawing.Point(52, 0);
            this.TxtProjectName.Name = "TxtProjectName";
            this.TxtProjectName.Size = new System.Drawing.Size(193, 20);
            this.TxtProjectName.TabIndex = 2;
            // 
            // LblProjectName
            // 
            this.LblProjectName.AutoSize = true;
            this.LblProjectName.Location = new System.Drawing.Point(3, 3);
            this.LblProjectName.Name = "LblProjectName";
            this.LblProjectName.Size = new System.Drawing.Size(43, 13);
            this.LblProjectName.TabIndex = 0;
            this.LblProjectName.Text = "Project:";
            // 
            // BtnAdd
            // 
            this.BtnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnAdd.Image = global::TileGameMaker.Properties.Resources.add;
            this.BtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(23, 20);
            this.BtnAdd.Text = "Add new map";
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnDelete.Image = global::TileGameMaker.Properties.Resources.delete;
            this.BtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(23, 20);
            this.BtnDelete.Text = "Delete map";
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnDuplicate
            // 
            this.BtnDuplicate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnDuplicate.Image = global::TileGameMaker.Properties.Resources.page_white_copy;
            this.BtnDuplicate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnDuplicate.Name = "BtnDuplicate";
            this.BtnDuplicate.Size = new System.Drawing.Size(23, 20);
            this.BtnDuplicate.Text = "Copy map";
            this.BtnDuplicate.Click += new System.EventHandler(this.BtnDuplicate_Click);
            // 
            // map
            // 
            this.map.HeaderText = "Name";
            this.map.Name = "map";
            this.map.ReadOnly = true;
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 41;
            // 
            // ProjectPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ProjectPanel";
            this.Size = new System.Drawing.Size(258, 361);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ToolStripAndGrid.ResumeLayout(false);
            this.ToolStripAndGrid.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapListGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel ToolStripAndGrid;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BtnAdd;
        private System.Windows.Forms.ToolStripButton BtnDelete;
        private System.Windows.Forms.ToolStripButton BtnDuplicate;
        private System.Windows.Forms.DataGridView MapListGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TxtProjectName;
        private System.Windows.Forms.Label LblProjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn map;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
    }
}
