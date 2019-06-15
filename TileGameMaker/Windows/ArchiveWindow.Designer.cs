namespace TileGameMaker.Windows
{
    partial class ArchiveWindow
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
            this.TxtArchive = new System.Windows.Forms.TextBox();
            this.TxtEntry = new System.Windows.Forms.TextBox();
            this.EntriesListBox = new System.Windows.Forms.ListBox();
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
            this.tableLayoutPanel1.Controls.Add(this.TxtArchive, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TxtEntry, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.EntriesListBox, 0, 1);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(304, 427);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // TxtArchive
            // 
            this.TxtArchive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtArchive.Location = new System.Drawing.Point(8, 8);
            this.TxtArchive.Name = "TxtArchive";
            this.TxtArchive.ReadOnly = true;
            this.TxtArchive.Size = new System.Drawing.Size(288, 21);
            this.TxtArchive.TabIndex = 4;
            // 
            // TxtEntry
            // 
            this.TxtEntry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtEntry.Location = new System.Drawing.Point(8, 346);
            this.TxtEntry.Name = "TxtEntry";
            this.TxtEntry.Size = new System.Drawing.Size(288, 21);
            this.TxtEntry.TabIndex = 3;
            this.TxtEntry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtEntry_KeyDown);
            // 
            // EntriesListBox
            // 
            this.EntriesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EntriesListBox.FormattingEnabled = true;
            this.EntriesListBox.ItemHeight = 15;
            this.EntriesListBox.Location = new System.Drawing.Point(10, 32);
            this.EntriesListBox.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.EntriesListBox.Name = "EntriesListBox";
            this.EntriesListBox.ScrollAlwaysVisible = true;
            this.EntriesListBox.Size = new System.Drawing.Size(284, 311);
            this.EntriesListBox.TabIndex = 1;
            this.EntriesListBox.SelectedValueChanged += new System.EventHandler(this.EntriesListBox_SelectedValueChanged);
            this.EntriesListBox.DoubleClick += new System.EventHandler(this.EntriesListBox_DoubleClick);
            this.EntriesListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EntriesListBox_KeyDown);
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
            this.ButtonLayout.Location = new System.Drawing.Point(8, 373);
            this.ButtonLayout.Name = "ButtonLayout";
            this.ButtonLayout.RowCount = 1;
            this.ButtonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ButtonLayout.Size = new System.Drawing.Size(288, 46);
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
            this.BtnOk.TabIndex = 4;
            this.BtnOk.UseVisualStyleBackColor = true;
            // 
            // BtnDelete
            // 
            this.BtnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnDelete.Image = global::TileGameMaker.Properties.Resources.delete;
            this.BtnDelete.Location = new System.Drawing.Point(174, 3);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(51, 40);
            this.BtnDelete.TabIndex = 3;
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
            this.BtnCancel.Size = new System.Drawing.Size(54, 40);
            this.BtnCancel.TabIndex = 1;
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
            this.BtnSave.TabIndex = 0;
            this.BtnSave.UseVisualStyleBackColor = true;
            // 
            // ArchiveManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 427);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ArchiveManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Archive";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ButtonLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox EntriesListBox;
        private System.Windows.Forms.TableLayoutPanel ButtonLayout;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.TextBox TxtArchive;
        private System.Windows.Forms.TextBox TxtEntry;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnLoad;
        private System.Windows.Forms.Button BtnOk;
    }
}