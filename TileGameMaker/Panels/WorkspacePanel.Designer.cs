namespace TileGameMaker.Panels
{
    partial class WorkspacePanel
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.WorkspaceGrid = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.TxtPath = new System.Windows.Forms.TextBox();
            this.BtnOpenWorkspace = new System.Windows.Forms.Button();
            this.filename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastmodified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WorkspaceGrid)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.WorkspaceGrid, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(311, 494);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // WorkspaceGrid
            // 
            this.WorkspaceGrid.AllowUserToAddRows = false;
            this.WorkspaceGrid.AllowUserToDeleteRows = false;
            this.WorkspaceGrid.AllowUserToResizeRows = false;
            this.WorkspaceGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.WorkspaceGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WorkspaceGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.filename,
            this.size,
            this.lastmodified});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.WorkspaceGrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.WorkspaceGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkspaceGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.WorkspaceGrid.Location = new System.Drawing.Point(3, 37);
            this.WorkspaceGrid.MultiSelect = false;
            this.WorkspaceGrid.Name = "WorkspaceGrid";
            this.WorkspaceGrid.ReadOnly = true;
            this.WorkspaceGrid.RowHeadersVisible = false;
            this.WorkspaceGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.WorkspaceGrid.Size = new System.Drawing.Size(305, 454);
            this.WorkspaceGrid.TabIndex = 0;
            this.WorkspaceGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.WorkspaceGrid_CellDoubleClick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.TxtPath, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnOpenWorkspace, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(305, 28);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // TxtPath
            // 
            this.TxtPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtPath.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPath.Location = new System.Drawing.Point(4, 4);
            this.TxtPath.Margin = new System.Windows.Forms.Padding(4);
            this.TxtPath.Name = "TxtPath";
            this.TxtPath.ReadOnly = true;
            this.TxtPath.Size = new System.Drawing.Size(244, 20);
            this.TxtPath.TabIndex = 0;
            // 
            // BtnOpenWorkspace
            // 
            this.BtnOpenWorkspace.Image = global::TileGameMaker.Properties.Resources.folder;
            this.BtnOpenWorkspace.Location = new System.Drawing.Point(252, 0);
            this.BtnOpenWorkspace.Margin = new System.Windows.Forms.Padding(0);
            this.BtnOpenWorkspace.Name = "BtnOpenWorkspace";
            this.BtnOpenWorkspace.Size = new System.Drawing.Size(53, 28);
            this.BtnOpenWorkspace.TabIndex = 1;
            this.BtnOpenWorkspace.UseVisualStyleBackColor = true;
            this.BtnOpenWorkspace.Click += new System.EventHandler(this.BtnOpenWorkspace_Click);
            // 
            // filename
            // 
            this.filename.FillWeight = 143.0624F;
            this.filename.HeaderText = "File";
            this.filename.Name = "filename";
            this.filename.ReadOnly = true;
            // 
            // size
            // 
            this.size.FillWeight = 53.29949F;
            this.size.HeaderText = "KB";
            this.size.Name = "size";
            this.size.ReadOnly = true;
            // 
            // lastmodified
            // 
            this.lastmodified.FillWeight = 103.6381F;
            this.lastmodified.HeaderText = "Last modified";
            this.lastmodified.Name = "lastmodified";
            this.lastmodified.ReadOnly = true;
            // 
            // WorkspacePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "WorkspacePanel";
            this.Size = new System.Drawing.Size(311, 494);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WorkspaceGrid)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView WorkspaceGrid;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox TxtPath;
        private System.Windows.Forms.Button BtnOpenWorkspace;
        private System.Windows.Forms.DataGridViewTextBoxColumn filename;
        private System.Windows.Forms.DataGridViewTextBoxColumn size;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastmodified;
    }
}
