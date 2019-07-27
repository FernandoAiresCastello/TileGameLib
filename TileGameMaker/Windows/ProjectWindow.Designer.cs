namespace TileGameMaker.Windows
{
    partial class ProjectWindow
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
            this.TxtWorkspace = new System.Windows.Forms.TextBox();
            this.TxtProject = new System.Windows.Forms.TextBox();
            this.ProjectsListBox = new System.Windows.Forms.ListBox();
            this.ButtonLayout = new System.Windows.Forms.TableLayoutPanel();
            this.BtnOk = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnLoad = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.ButtonLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.TxtWorkspace, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TxtProject, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ProjectsListBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ButtonLayout, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(303, 441);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // TxtWorkspace
            // 
            this.TxtWorkspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtWorkspace.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtWorkspace.Location = new System.Drawing.Point(8, 8);
            this.TxtWorkspace.Name = "TxtWorkspace";
            this.TxtWorkspace.ReadOnly = true;
            this.TxtWorkspace.Size = new System.Drawing.Size(287, 23);
            this.TxtWorkspace.TabIndex = 5;
            this.TxtWorkspace.TabStop = false;
            // 
            // TxtProject
            // 
            this.TxtProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtProject.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProject.Location = new System.Drawing.Point(8, 358);
            this.TxtProject.Name = "TxtProject";
            this.TxtProject.Size = new System.Drawing.Size(287, 23);
            this.TxtProject.TabIndex = 0;
            this.TxtProject.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtProject_KeyDown);
            // 
            // ProjectsListBox
            // 
            this.ProjectsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectsListBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectsListBox.FormattingEnabled = true;
            this.ProjectsListBox.ItemHeight = 15;
            this.ProjectsListBox.Location = new System.Drawing.Point(10, 34);
            this.ProjectsListBox.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.ProjectsListBox.Name = "ProjectsListBox";
            this.ProjectsListBox.ScrollAlwaysVisible = true;
            this.ProjectsListBox.Size = new System.Drawing.Size(283, 321);
            this.ProjectsListBox.TabIndex = 1;
            this.ProjectsListBox.TabStop = false;
            this.ProjectsListBox.SelectedValueChanged += new System.EventHandler(this.ProjectsListBox_SelectedValueChanged);
            this.ProjectsListBox.DoubleClick += new System.EventHandler(this.ProjectsListBox_DoubleClick);
            this.ProjectsListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProjectsListBox_KeyDown);
            // 
            // ButtonLayout
            // 
            this.ButtonLayout.ColumnCount = 5;
            this.ButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.ButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.ButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.ButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.ButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.ButtonLayout.Controls.Add(this.BtnOk, 0, 0);
            this.ButtonLayout.Controls.Add(this.BtnDelete, 3, 0);
            this.ButtonLayout.Controls.Add(this.BtnLoad, 1, 0);
            this.ButtonLayout.Controls.Add(this.BtnCancel, 4, 0);
            this.ButtonLayout.Controls.Add(this.BtnSave, 2, 0);
            this.ButtonLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonLayout.Location = new System.Drawing.Point(8, 387);
            this.ButtonLayout.Name = "ButtonLayout";
            this.ButtonLayout.RowCount = 1;
            this.ButtonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ButtonLayout.Size = new System.Drawing.Size(287, 46);
            this.ButtonLayout.TabIndex = 2;
            // 
            // BtnOk
            // 
            this.BtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnOk.Image = global::TileGameMaker.Properties.Resources.tick;
            this.BtnOk.Location = new System.Drawing.Point(3, 3);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(51, 40);
            this.BtnOk.TabIndex = 1;
            this.BtnOk.UseVisualStyleBackColor = true;
            // 
            // BtnDelete
            // 
            this.BtnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnDelete.Image = global::TileGameMaker.Properties.Resources.delete;
            this.BtnDelete.Location = new System.Drawing.Point(174, 3);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(51, 40);
            this.BtnDelete.TabIndex = 4;
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnLoad
            // 
            this.BtnLoad.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnLoad.Image = global::TileGameMaker.Properties.Resources.folder;
            this.BtnLoad.Location = new System.Drawing.Point(60, 3);
            this.BtnLoad.Name = "BtnLoad";
            this.BtnLoad.Size = new System.Drawing.Size(51, 40);
            this.BtnLoad.TabIndex = 2;
            this.BtnLoad.UseVisualStyleBackColor = true;
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnCancel.Image = global::TileGameMaker.Properties.Resources.cross;
            this.BtnCancel.Location = new System.Drawing.Point(231, 3);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(53, 40);
            this.BtnCancel.TabIndex = 5;
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnSave
            // 
            this.BtnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnSave.Image = global::TileGameMaker.Properties.Resources.diskette1;
            this.BtnSave.Location = new System.Drawing.Point(117, 3);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(51, 40);
            this.BtnSave.TabIndex = 3;
            this.BtnSave.UseVisualStyleBackColor = true;
            // 
            // ProjectWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 441);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProjectWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Workspace";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ButtonLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox TxtWorkspace;
        private System.Windows.Forms.TextBox TxtProject;
        private System.Windows.Forms.ListBox ProjectsListBox;
        private System.Windows.Forms.TableLayoutPanel ButtonLayout;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnLoad;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnSave;
    }
}