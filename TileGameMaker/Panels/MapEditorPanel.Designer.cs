namespace TileGameMaker.Panels
{
    partial class MapEditorPanel
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.HoverLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MapPanel = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.CbLayer = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnNew = new System.Windows.Forms.ToolStripButton();
            this.BtnLoadMap = new System.Windows.Forms.ToolStripButton();
            this.BtnSaveMap = new System.Windows.Forms.ToolStripButton();
            this.BtnViewAll = new System.Windows.Forms.ToolStripButton();
            this.BtnAddLayer = new System.Windows.Forms.ToolStripButton();
            this.BtnRemoveLayer = new System.Windows.Forms.ToolStripButton();
            this.BtnClearLayer = new System.Windows.Forms.ToolStripButton();
            this.BtnSelect = new System.Windows.Forms.ToolStripButton();
            this.BtnAddText = new System.Windows.Forms.ToolStripButton();
            this.BtnZoomIn = new System.Windows.Forms.ToolStripButton();
            this.BtnZoomOut = new System.Windows.Forms.ToolStripButton();
            this.BtnGrid = new System.Windows.Forms.ToolStripButton();
            this.BtnScreenshot = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.statusStrip1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.MapPanel, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(646, 490);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel,
            this.HoverLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 470);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(646, 20);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(71, 15);
            this.StatusLabel.Text = "StatusLabel";
            // 
            // HoverLabel
            // 
            this.HoverLabel.Name = "HoverLabel";
            this.HoverLabel.Size = new System.Drawing.Size(67, 15);
            this.HoverLabel.Text = "HoverLabel";
            // 
            // MapPanel
            // 
            this.MapPanel.AutoScroll = true;
            this.MapPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MapPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapPanel.Location = new System.Drawing.Point(3, 28);
            this.MapPanel.Name = "MapPanel";
            this.MapPanel.Size = new System.Drawing.Size(640, 439);
            this.MapPanel.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnNew,
            this.BtnLoadMap,
            this.BtnSaveMap,
            this.toolStripSeparator3,
            this.CbLayer,
            this.BtnViewAll,
            this.BtnAddLayer,
            this.BtnRemoveLayer,
            this.BtnClearLayer,
            this.toolStripSeparator1,
            this.BtnSelect,
            this.BtnAddText,
            this.toolStripSeparator4,
            this.BtnZoomIn,
            this.BtnZoomOut,
            this.BtnGrid,
            this.BtnScreenshot,
            this.toolStripSeparator5});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(646, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // CbLayer
            // 
            this.CbLayer.CausesValidation = false;
            this.CbLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbLayer.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.CbLayer.Name = "CbLayer";
            this.CbLayer.Size = new System.Drawing.Size(121, 25);
            this.CbLayer.SelectedIndexChanged += new System.EventHandler(this.CbLayer_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // BtnNew
            // 
            this.BtnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnNew.Image = global::TileGameMaker.Properties.Resources.page_white;
            this.BtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(23, 22);
            this.BtnNew.Text = "toolStripButton1";
            this.BtnNew.ToolTipText = "Clear map";
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // BtnLoadMap
            // 
            this.BtnLoadMap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnLoadMap.Image = global::TileGameMaker.Properties.Resources.folder;
            this.BtnLoadMap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnLoadMap.Name = "BtnLoadMap";
            this.BtnLoadMap.Size = new System.Drawing.Size(23, 22);
            this.BtnLoadMap.Text = "toolStripButton1";
            this.BtnLoadMap.ToolTipText = "Load map";
            this.BtnLoadMap.Click += new System.EventHandler(this.BtnLoadMap_Click);
            // 
            // BtnSaveMap
            // 
            this.BtnSaveMap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnSaveMap.Image = global::TileGameMaker.Properties.Resources.diskette;
            this.BtnSaveMap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSaveMap.Name = "BtnSaveMap";
            this.BtnSaveMap.Size = new System.Drawing.Size(23, 22);
            this.BtnSaveMap.Text = "toolStripButton1";
            this.BtnSaveMap.ToolTipText = "Save map";
            this.BtnSaveMap.Click += new System.EventHandler(this.BtnSaveMap_Click);
            // 
            // BtnViewAll
            // 
            this.BtnViewAll.Checked = true;
            this.BtnViewAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BtnViewAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnViewAll.Image = global::TileGameMaker.Properties.Resources.layers;
            this.BtnViewAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnViewAll.Name = "BtnViewAll";
            this.BtnViewAll.Size = new System.Drawing.Size(23, 22);
            this.BtnViewAll.Text = "toolStripButton1";
            this.BtnViewAll.ToolTipText = "View all layers";
            this.BtnViewAll.Click += new System.EventHandler(this.BtnViewAll_Click);
            // 
            // BtnAddLayer
            // 
            this.BtnAddLayer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnAddLayer.Image = global::TileGameMaker.Properties.Resources.layer_add;
            this.BtnAddLayer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnAddLayer.Name = "BtnAddLayer";
            this.BtnAddLayer.Size = new System.Drawing.Size(23, 22);
            this.BtnAddLayer.Text = "toolStripButton1";
            this.BtnAddLayer.ToolTipText = "Add layer";
            this.BtnAddLayer.Click += new System.EventHandler(this.BtnAddLayer_Click);
            // 
            // BtnRemoveLayer
            // 
            this.BtnRemoveLayer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnRemoveLayer.Image = global::TileGameMaker.Properties.Resources.layer_delete;
            this.BtnRemoveLayer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnRemoveLayer.Name = "BtnRemoveLayer";
            this.BtnRemoveLayer.Size = new System.Drawing.Size(23, 22);
            this.BtnRemoveLayer.Text = "toolStripButton1";
            this.BtnRemoveLayer.ToolTipText = "Remove layer";
            this.BtnRemoveLayer.Click += new System.EventHandler(this.BtnRemoveLayer_Click);
            // 
            // BtnClearLayer
            // 
            this.BtnClearLayer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnClearLayer.Image = global::TileGameMaker.Properties.Resources.draw_eraser1;
            this.BtnClearLayer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnClearLayer.Name = "BtnClearLayer";
            this.BtnClearLayer.Size = new System.Drawing.Size(23, 22);
            this.BtnClearLayer.Text = "toolStripButton1";
            this.BtnClearLayer.ToolTipText = "Clear layer";
            this.BtnClearLayer.Click += new System.EventHandler(this.BtnClearLayer_Click);
            // 
            // BtnSelect
            // 
            this.BtnSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnSelect.Image = global::TileGameMaker.Properties.Resources.select;
            this.BtnSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSelect.Name = "BtnSelect";
            this.BtnSelect.Size = new System.Drawing.Size(23, 22);
            this.BtnSelect.Text = "toolStripButton1";
            this.BtnSelect.ToolTipText = "Toggle block selection mode";
            // 
            // BtnAddText
            // 
            this.BtnAddText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnAddText.Image = global::TileGameMaker.Properties.Resources.insert_text;
            this.BtnAddText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnAddText.Name = "BtnAddText";
            this.BtnAddText.Size = new System.Drawing.Size(23, 22);
            this.BtnAddText.Text = "toolStripButton1";
            this.BtnAddText.ToolTipText = "Toggle text input mode";
            this.BtnAddText.Click += new System.EventHandler(this.BtnAddText_Click);
            // 
            // BtnZoomIn
            // 
            this.BtnZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnZoomIn.Image = global::TileGameMaker.Properties.Resources.magnifier_zoom_in;
            this.BtnZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnZoomIn.Name = "BtnZoomIn";
            this.BtnZoomIn.Size = new System.Drawing.Size(23, 22);
            this.BtnZoomIn.Text = "toolStripButton1";
            this.BtnZoomIn.ToolTipText = "Zoom in";
            this.BtnZoomIn.Click += new System.EventHandler(this.BtnZoomIn_Click);
            // 
            // BtnZoomOut
            // 
            this.BtnZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnZoomOut.Image = global::TileGameMaker.Properties.Resources.magnifier_zoom_out;
            this.BtnZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnZoomOut.Name = "BtnZoomOut";
            this.BtnZoomOut.Size = new System.Drawing.Size(23, 22);
            this.BtnZoomOut.Text = "toolStripButton1";
            this.BtnZoomOut.ToolTipText = "Zoom out";
            this.BtnZoomOut.Click += new System.EventHandler(this.BtnZoomOut_Click);
            // 
            // BtnGrid
            // 
            this.BtnGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnGrid.Image = global::TileGameMaker.Properties.Resources.layouts_four_grid;
            this.BtnGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnGrid.Name = "BtnGrid";
            this.BtnGrid.Size = new System.Drawing.Size(23, 22);
            this.BtnGrid.Text = "toolStripButton1";
            this.BtnGrid.ToolTipText = "Toggle grid";
            this.BtnGrid.Click += new System.EventHandler(this.BtnGrid_Click);
            // 
            // BtnScreenshot
            // 
            this.BtnScreenshot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnScreenshot.Image = global::TileGameMaker.Properties.Resources.camera;
            this.BtnScreenshot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnScreenshot.Name = "BtnScreenshot";
            this.BtnScreenshot.Size = new System.Drawing.Size(23, 22);
            this.BtnScreenshot.Text = "toolStripButton1";
            this.BtnScreenshot.ToolTipText = "Save image";
            this.BtnScreenshot.Click += new System.EventHandler(this.BtnScreenshot_Click);
            // 
            // MapEditorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "MapEditorPanel";
            this.Size = new System.Drawing.Size(646, 490);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MapEditorControl_KeyDown);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel HoverLabel;
        private System.Windows.Forms.Panel MapPanel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BtnNew;
        private System.Windows.Forms.ToolStripButton BtnLoadMap;
        private System.Windows.Forms.ToolStripButton BtnSaveMap;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton BtnAddText;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton BtnZoomIn;
        private System.Windows.Forms.ToolStripButton BtnZoomOut;
        private System.Windows.Forms.ToolStripButton BtnGrid;
        private System.Windows.Forms.ToolStripButton BtnScreenshot;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton BtnSelect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox CbLayer;
        private System.Windows.Forms.ToolStripButton BtnAddLayer;
        private System.Windows.Forms.ToolStripButton BtnRemoveLayer;
        private System.Windows.Forms.ToolStripButton BtnViewAll;
        private System.Windows.Forms.ToolStripButton BtnClearLayer;
    }
}
