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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapEditorPanel));
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.LbMapInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.LbEditModeInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.MapPanel = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BtnNew = new System.Windows.Forms.ToolStripButton();
            this.BtnLoad = new System.Windows.Forms.ToolStripButton();
            this.BtnSave = new System.Windows.Forms.ToolStripButton();
            this.BtnSaveAs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.CbLayer = new System.Windows.Forms.ToolStripComboBox();
            this.BtnViewAll = new System.Windows.Forms.ToolStripButton();
            this.BtnAddLayer = new System.Windows.Forms.ToolStripButton();
            this.BtnRemoveLayer = new System.Windows.Forms.ToolStripButton();
            this.BtnRenderInvisibleObjects = new System.Windows.Forms.ToolStripButton();
            this.BtnClearLayer = new System.Windows.Forms.ToolStripButton();
            this.BtnSetBackColor = new System.Windows.Forms.ToolStripButton();
            this.BtnSetOutOfBoundsObject = new System.Windows.Forms.ToolStripButton();
            this.BtnSetExtra = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnPutTemplate = new System.Windows.Forms.ToolStripButton();
            this.BtnDelete = new System.Windows.Forms.ToolStripButton();
            this.BtnAddText = new System.Windows.Forms.ToolStripButton();
            this.BtnReplaceObjects = new System.Windows.Forms.ToolStripButton();
            this.BtnEditObject = new System.Windows.Forms.ToolStripButton();
            this.BtnFind = new System.Windows.Forms.ToolStripButton();
            this.BtnRunScript = new System.Windows.Forms.ToolStripButton();
            this.BtnSelect = new System.Windows.Forms.ToolStripButton();
            this.BtnSelectionActions = new System.Windows.Forms.ToolStripDropDownButton();
            this.MiCancelSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.MiCopyObjects = new System.Windows.Forms.ToolStripMenuItem();
            this.MiCutObjects = new System.Windows.Forms.ToolStripMenuItem();
            this.MiPasteObjects = new System.Windows.Forms.ToolStripMenuItem();
            this.MiDeleteObjects = new System.Windows.Forms.ToolStripMenuItem();
            this.MiFillWithTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.MiOverrideColors = new System.Windows.Forms.ToolStripMenuItem();
            this.MiReplaceWithTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MiSetSelectionColor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnZoomIn = new System.Windows.Forms.ToolStripButton();
            this.BtnZoomOut = new System.Windows.Forms.ToolStripButton();
            this.BtnGrid = new System.Windows.Forms.ToolStripButton();
            this.BtnScreenshot = new System.Windows.Forms.ToolStripButton();
            this.BtnWorkspace = new System.Windows.Forms.ToolStripButton();
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(875, 490);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LbMapInfo,
            this.LbEditModeInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 470);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(875, 20);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // LbMapInfo
            // 
            this.LbMapInfo.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.LbMapInfo.Name = "LbMapInfo";
            this.LbMapInfo.Size = new System.Drawing.Size(69, 15);
            this.LbMapInfo.Text = "LbMapInfo";
            // 
            // LbEditModeInfo
            // 
            this.LbEditModeInfo.Name = "LbEditModeInfo";
            this.LbEditModeInfo.Size = new System.Drawing.Size(92, 15);
            this.LbEditModeInfo.Text = "LbEditModeInfo";
            // 
            // MapPanel
            // 
            this.MapPanel.AutoScroll = true;
            this.MapPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MapPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapPanel.Location = new System.Drawing.Point(3, 33);
            this.MapPanel.Name = "MapPanel";
            this.MapPanel.Size = new System.Drawing.Size(869, 434);
            this.MapPanel.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnNew,
            this.BtnLoad,
            this.BtnWorkspace,
            this.BtnSave,
            this.BtnSaveAs,
            this.toolStripSeparator3,
            this.CbLayer,
            this.BtnViewAll,
            this.BtnAddLayer,
            this.BtnRemoveLayer,
            this.BtnRenderInvisibleObjects,
            this.BtnClearLayer,
            this.BtnSetBackColor,
            this.BtnSetOutOfBoundsObject,
            this.BtnSetExtra,
            this.toolStripSeparator1,
            this.BtnPutTemplate,
            this.BtnDelete,
            this.BtnAddText,
            this.BtnReplaceObjects,
            this.BtnEditObject,
            this.BtnFind,
            this.BtnRunScript,
            this.BtnSelect,
            this.BtnSelectionActions,
            this.toolStripSeparator4,
            this.BtnZoomIn,
            this.BtnZoomOut,
            this.BtnGrid,
            this.BtnScreenshot});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(8, 5, 0, 2);
            this.toolStrip1.Size = new System.Drawing.Size(875, 30);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BtnNew
            // 
            this.BtnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnNew.Image = global::TileGameMaker.Properties.Resources.page_white;
            this.BtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(23, 20);
            this.BtnNew.Text = "toolStripButton1";
            this.BtnNew.ToolTipText = "Create new map (Ctrl+N)";
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // BtnLoad
            // 
            this.BtnLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnLoad.Image = global::TileGameMaker.Properties.Resources.folder;
            this.BtnLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnLoad.Name = "BtnLoad";
            this.BtnLoad.Size = new System.Drawing.Size(23, 20);
            this.BtnLoad.Text = "toolStripButton1";
            this.BtnLoad.ToolTipText = "Open map file (Ctrl+O)";
            this.BtnLoad.Click += new System.EventHandler(this.BtnLoadRawBytes_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnSave.Image = global::TileGameMaker.Properties.Resources.diskette;
            this.BtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(23, 20);
            this.BtnSave.Text = "toolStripButton1";
            this.BtnSave.ToolTipText = "Save map file (Ctrl+S)";
            this.BtnSave.Click += new System.EventHandler(this.BtnSaveRawBytes_Click);
            // 
            // BtnSaveAs
            // 
            this.BtnSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnSaveAs.Image = global::TileGameMaker.Properties.Resources.file_save_as;
            this.BtnSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSaveAs.Name = "BtnSaveAs";
            this.BtnSaveAs.Size = new System.Drawing.Size(23, 20);
            this.BtnSaveAs.Text = "toolStripButton1";
            this.BtnSaveAs.ToolTipText = "Save map file as";
            this.BtnSaveAs.Click += new System.EventHandler(this.BtnSaveMapAs_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Margin = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
            // 
            // CbLayer
            // 
            this.CbLayer.CausesValidation = false;
            this.CbLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbLayer.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.CbLayer.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.CbLayer.Name = "CbLayer";
            this.CbLayer.Size = new System.Drawing.Size(75, 23);
            this.CbLayer.SelectedIndexChanged += new System.EventHandler(this.CbLayer_SelectedIndexChanged);
            // 
            // BtnViewAll
            // 
            this.BtnViewAll.Checked = true;
            this.BtnViewAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BtnViewAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnViewAll.Image = global::TileGameMaker.Properties.Resources.layers;
            this.BtnViewAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnViewAll.Name = "BtnViewAll";
            this.BtnViewAll.Size = new System.Drawing.Size(23, 20);
            this.BtnViewAll.Text = "toolStripButton1";
            this.BtnViewAll.ToolTipText = "View all layers (Ctrl+L)";
            this.BtnViewAll.Click += new System.EventHandler(this.BtnViewAll_Click);
            // 
            // BtnAddLayer
            // 
            this.BtnAddLayer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnAddLayer.Image = global::TileGameMaker.Properties.Resources.layer_add;
            this.BtnAddLayer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnAddLayer.Name = "BtnAddLayer";
            this.BtnAddLayer.Size = new System.Drawing.Size(23, 20);
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
            this.BtnRemoveLayer.Size = new System.Drawing.Size(23, 20);
            this.BtnRemoveLayer.Text = "toolStripButton1";
            this.BtnRemoveLayer.ToolTipText = "Remove layer";
            this.BtnRemoveLayer.Click += new System.EventHandler(this.BtnRemoveLayer_Click);
            // 
            // BtnRenderInvisibleObjects
            // 
            this.BtnRenderInvisibleObjects.CheckOnClick = true;
            this.BtnRenderInvisibleObjects.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnRenderInvisibleObjects.Image = global::TileGameMaker.Properties.Resources.eye;
            this.BtnRenderInvisibleObjects.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnRenderInvisibleObjects.Name = "BtnRenderInvisibleObjects";
            this.BtnRenderInvisibleObjects.Size = new System.Drawing.Size(23, 20);
            this.BtnRenderInvisibleObjects.Text = "toolStripButton1";
            this.BtnRenderInvisibleObjects.ToolTipText = "Render invisible objects";
            this.BtnRenderInvisibleObjects.Click += new System.EventHandler(this.BtnRenderInvisibleObjects_Click);
            // 
            // BtnClearLayer
            // 
            this.BtnClearLayer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnClearLayer.Image = global::TileGameMaker.Properties.Resources.broom;
            this.BtnClearLayer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnClearLayer.Name = "BtnClearLayer";
            this.BtnClearLayer.Size = new System.Drawing.Size(23, 20);
            this.BtnClearLayer.Text = "toolStripButton1";
            this.BtnClearLayer.ToolTipText = "Clear layer";
            this.BtnClearLayer.Click += new System.EventHandler(this.BtnClearLayer_Click);
            // 
            // BtnSetBackColor
            // 
            this.BtnSetBackColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnSetBackColor.Image = global::TileGameMaker.Properties.Resources.color_management;
            this.BtnSetBackColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSetBackColor.Name = "BtnSetBackColor";
            this.BtnSetBackColor.Size = new System.Drawing.Size(23, 20);
            this.BtnSetBackColor.Text = "toolStripButton1";
            this.BtnSetBackColor.ToolTipText = "Set map background color";
            this.BtnSetBackColor.Click += new System.EventHandler(this.BtnSetBackColor_Click);
            // 
            // BtnSetOutOfBoundsObject
            // 
            this.BtnSetOutOfBoundsObject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnSetOutOfBoundsObject.Image = global::TileGameMaker.Properties.Resources.select_by_difference;
            this.BtnSetOutOfBoundsObject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSetOutOfBoundsObject.Name = "BtnSetOutOfBoundsObject";
            this.BtnSetOutOfBoundsObject.Size = new System.Drawing.Size(23, 20);
            this.BtnSetOutOfBoundsObject.Text = "BtnSetOutOfBoundsObject";
            this.BtnSetOutOfBoundsObject.ToolTipText = "Set out of bounds object";
            this.BtnSetOutOfBoundsObject.Click += new System.EventHandler(this.BtnSetOutOfBoundsObject_Click);
            // 
            // BtnSetExtra
            // 
            this.BtnSetExtra.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnSetExtra.Image = global::TileGameMaker.Properties.Resources.evernote;
            this.BtnSetExtra.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSetExtra.Name = "BtnSetExtra";
            this.BtnSetExtra.Size = new System.Drawing.Size(23, 20);
            this.BtnSetExtra.Text = "toolStripButton1";
            this.BtnSetExtra.ToolTipText = "Set extra";
            this.BtnSetExtra.Click += new System.EventHandler(this.BtnSetExtra_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // BtnPutTemplate
            // 
            this.BtnPutTemplate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnPutTemplate.Image = global::TileGameMaker.Properties.Resources.pencil;
            this.BtnPutTemplate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnPutTemplate.Name = "BtnPutTemplate";
            this.BtnPutTemplate.Size = new System.Drawing.Size(23, 20);
            this.BtnPutTemplate.Text = "toolStripButton1";
            this.BtnPutTemplate.ToolTipText = "Draw template (CTRL+1)";
            this.BtnPutTemplate.Click += new System.EventHandler(this.BtnPutTemplate_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnDelete.Image = global::TileGameMaker.Properties.Resources.draw_eraser;
            this.BtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(23, 20);
            this.BtnDelete.Text = "toolStripButton1";
            this.BtnDelete.ToolTipText = "Delete (CTRL+2)";
            this.BtnDelete.Click += new System.EventHandler(this.BtnDeleteMode_Click);
            // 
            // BtnAddText
            // 
            this.BtnAddText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnAddText.Image = global::TileGameMaker.Properties.Resources.insert_text;
            this.BtnAddText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnAddText.Name = "BtnAddText";
            this.BtnAddText.Size = new System.Drawing.Size(23, 20);
            this.BtnAddText.Text = "toolStripButton1";
            this.BtnAddText.ToolTipText = "Draw text (CTRL+4)";
            this.BtnAddText.Click += new System.EventHandler(this.BtnAddText_Click);
            // 
            // BtnReplaceObjects
            // 
            this.BtnReplaceObjects.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnReplaceObjects.Image = global::TileGameMaker.Properties.Resources.magic_wand;
            this.BtnReplaceObjects.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnReplaceObjects.Name = "BtnReplaceObjects";
            this.BtnReplaceObjects.Size = new System.Drawing.Size(23, 20);
            this.BtnReplaceObjects.Text = "toolStripButton1";
            this.BtnReplaceObjects.ToolTipText = "Replace objects (CTRL+5)";
            this.BtnReplaceObjects.Click += new System.EventHandler(this.BtnReplaceObjects_Click);
            // 
            // BtnEditObject
            // 
            this.BtnEditObject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnEditObject.Image = global::TileGameMaker.Properties.Resources.brick_edit;
            this.BtnEditObject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnEditObject.Name = "BtnEditObject";
            this.BtnEditObject.Size = new System.Drawing.Size(23, 20);
            this.BtnEditObject.Text = "toolStripButton1";
            this.BtnEditObject.ToolTipText = "Edit object";
            this.BtnEditObject.Click += new System.EventHandler(this.BtnEditObject_Click);
            // 
            // BtnFind
            // 
            this.BtnFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnFind.Image = global::TileGameMaker.Properties.Resources.find;
            this.BtnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnFind.Name = "BtnFind";
            this.BtnFind.Size = new System.Drawing.Size(23, 20);
            this.BtnFind.Text = "toolStripButton1";
            this.BtnFind.ToolTipText = "Find objects (CTRL+F)";
            this.BtnFind.Click += new System.EventHandler(this.BtnFind_Click);
            // 
            // BtnRunScript
            // 
            this.BtnRunScript.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnRunScript.Image = global::TileGameMaker.Properties.Resources.script_lightning;
            this.BtnRunScript.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnRunScript.Name = "BtnRunScript";
            this.BtnRunScript.Size = new System.Drawing.Size(23, 20);
            this.BtnRunScript.Text = "toolStripButton1";
            this.BtnRunScript.ToolTipText = "Run editor script";
            this.BtnRunScript.Click += new System.EventHandler(this.BtnRunScript_Click);
            // 
            // BtnSelect
            // 
            this.BtnSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnSelect.Image = global::TileGameMaker.Properties.Resources.select;
            this.BtnSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSelect.Name = "BtnSelect";
            this.BtnSelect.Size = new System.Drawing.Size(23, 20);
            this.BtnSelect.Text = "toolStripButton1";
            this.BtnSelect.ToolTipText = "Selection mode (CTRL+6)";
            this.BtnSelect.Click += new System.EventHandler(this.BtnSelect_Click);
            // 
            // BtnSelectionActions
            // 
            this.BtnSelectionActions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiCancelSelection,
            this.toolStripSeparator6,
            this.MiCopyObjects,
            this.MiCutObjects,
            this.MiPasteObjects,
            this.MiDeleteObjects,
            this.MiFillWithTemplate,
            this.MiOverrideColors,
            this.MiReplaceWithTemplate,
            this.toolStripSeparator2,
            this.MiSetSelectionColor});
            this.BtnSelectionActions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSelectionActions.Margin = new System.Windows.Forms.Padding(3, 1, 0, 2);
            this.BtnSelectionActions.Name = "BtnSelectionActions";
            this.BtnSelectionActions.Size = new System.Drawing.Size(68, 20);
            this.BtnSelectionActions.Text = "Selection";
            this.BtnSelectionActions.ToolTipText = "Selection";
            // 
            // MiCancelSelection
            // 
            this.MiCancelSelection.Name = "MiCancelSelection";
            this.MiCancelSelection.Size = new System.Drawing.Size(237, 22);
            this.MiCancelSelection.Text = "Cancel";
            this.MiCancelSelection.Click += new System.EventHandler(this.MiCancelSelection_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(234, 6);
            // 
            // MiCopyObjects
            // 
            this.MiCopyObjects.Name = "MiCopyObjects";
            this.MiCopyObjects.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.MiCopyObjects.Size = new System.Drawing.Size(237, 22);
            this.MiCopyObjects.Text = "Copy objects";
            this.MiCopyObjects.Click += new System.EventHandler(this.MiCopyObjects_Click);
            // 
            // MiCutObjects
            // 
            this.MiCutObjects.Name = "MiCutObjects";
            this.MiCutObjects.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.MiCutObjects.Size = new System.Drawing.Size(237, 22);
            this.MiCutObjects.Text = "Cut objects";
            this.MiCutObjects.Click += new System.EventHandler(this.MiCutObjects_Click);
            // 
            // MiPasteObjects
            // 
            this.MiPasteObjects.Name = "MiPasteObjects";
            this.MiPasteObjects.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.MiPasteObjects.Size = new System.Drawing.Size(237, 22);
            this.MiPasteObjects.Text = "Paste objects";
            this.MiPasteObjects.Click += new System.EventHandler(this.MiPasteObjects_Click);
            // 
            // MiDeleteObjects
            // 
            this.MiDeleteObjects.Name = "MiDeleteObjects";
            this.MiDeleteObjects.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.MiDeleteObjects.Size = new System.Drawing.Size(237, 22);
            this.MiDeleteObjects.Text = "Delete objects";
            this.MiDeleteObjects.Click += new System.EventHandler(this.MiDeleteObjects_Click);
            // 
            // MiFillWithTemplate
            // 
            this.MiFillWithTemplate.Name = "MiFillWithTemplate";
            this.MiFillWithTemplate.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.F)));
            this.MiFillWithTemplate.Size = new System.Drawing.Size(237, 22);
            this.MiFillWithTemplate.Text = "Fill with template";
            this.MiFillWithTemplate.Click += new System.EventHandler(this.MiFillWithTemplate_Click);
            // 
            // MiOverrideColors
            // 
            this.MiOverrideColors.Name = "MiOverrideColors";
            this.MiOverrideColors.Size = new System.Drawing.Size(237, 22);
            this.MiOverrideColors.Text = "Override colors";
            this.MiOverrideColors.Click += new System.EventHandler(this.MiOverrideColors_Click);
            // 
            // MiReplaceWithTemplate
            // 
            this.MiReplaceWithTemplate.Name = "MiReplaceWithTemplate";
            this.MiReplaceWithTemplate.Size = new System.Drawing.Size(237, 22);
            this.MiReplaceWithTemplate.Text = "Replace with template";
            this.MiReplaceWithTemplate.Click += new System.EventHandler(this.MiReplaceWithTemplate_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(234, 6);
            // 
            // MiSetSelectionColor
            // 
            this.MiSetSelectionColor.Name = "MiSetSelectionColor";
            this.MiSetSelectionColor.Size = new System.Drawing.Size(237, 22);
            this.MiSetSelectionColor.Text = "Set selection color";
            this.MiSetSelectionColor.Click += new System.EventHandler(this.MiSetSelectionColor_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
            // 
            // BtnZoomIn
            // 
            this.BtnZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnZoomIn.Image = global::TileGameMaker.Properties.Resources.magnifier_zoom_in;
            this.BtnZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnZoomIn.Name = "BtnZoomIn";
            this.BtnZoomIn.Size = new System.Drawing.Size(23, 20);
            this.BtnZoomIn.Text = "toolStripButton1";
            this.BtnZoomIn.ToolTipText = "Zoom in (PgUp)";
            this.BtnZoomIn.Click += new System.EventHandler(this.BtnZoomIn_Click);
            // 
            // BtnZoomOut
            // 
            this.BtnZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnZoomOut.Image = global::TileGameMaker.Properties.Resources.magnifier_zoom_out;
            this.BtnZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnZoomOut.Name = "BtnZoomOut";
            this.BtnZoomOut.Size = new System.Drawing.Size(23, 20);
            this.BtnZoomOut.Text = "toolStripButton1";
            this.BtnZoomOut.ToolTipText = "Zoom out (PgDn)";
            this.BtnZoomOut.Click += new System.EventHandler(this.BtnZoomOut_Click);
            // 
            // BtnGrid
            // 
            this.BtnGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnGrid.Image = global::TileGameMaker.Properties.Resources.layouts_four_grid;
            this.BtnGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnGrid.Name = "BtnGrid";
            this.BtnGrid.Size = new System.Drawing.Size(23, 20);
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
            this.BtnScreenshot.Size = new System.Drawing.Size(23, 20);
            this.BtnScreenshot.Text = "toolStripButton1";
            this.BtnScreenshot.ToolTipText = "Save image";
            this.BtnScreenshot.Click += new System.EventHandler(this.BtnScreenshot_Click);
            // 
            // BtnWorkspace
            // 
            this.BtnWorkspace.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnWorkspace.Image = ((System.Drawing.Image)(resources.GetObject("BtnWorkspace.Image")));
            this.BtnWorkspace.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnWorkspace.Name = "BtnWorkspace";
            this.BtnWorkspace.Size = new System.Drawing.Size(23, 20);
            this.BtnWorkspace.Text = "BtnWorkspace";
            this.BtnWorkspace.ToolTipText = "Open workspace (Ctrl+W)";
            this.BtnWorkspace.Click += new System.EventHandler(this.BtnWorkspace_Click);
            // 
            // MapEditorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "MapEditorPanel";
            this.Size = new System.Drawing.Size(875, 490);
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
        private System.Windows.Forms.ToolStripStatusLabel LbMapInfo;
        private System.Windows.Forms.ToolStripStatusLabel LbEditModeInfo;
        private System.Windows.Forms.Panel MapPanel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BtnNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton BtnAddText;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton BtnZoomIn;
        private System.Windows.Forms.ToolStripButton BtnZoomOut;
        private System.Windows.Forms.ToolStripButton BtnGrid;
        private System.Windows.Forms.ToolStripButton BtnScreenshot;
        private System.Windows.Forms.ToolStripButton BtnSelect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox CbLayer;
        private System.Windows.Forms.ToolStripButton BtnAddLayer;
        private System.Windows.Forms.ToolStripButton BtnRemoveLayer;
        private System.Windows.Forms.ToolStripButton BtnViewAll;
        private System.Windows.Forms.ToolStripButton BtnClearLayer;
        private System.Windows.Forms.ToolStripButton BtnPutTemplate;
        private System.Windows.Forms.ToolStripButton BtnSetBackColor;
        private System.Windows.Forms.ToolStripButton BtnDelete;
        private System.Windows.Forms.ToolStripDropDownButton BtnSelectionActions;
        private System.Windows.Forms.ToolStripMenuItem MiCutObjects;
        private System.Windows.Forms.ToolStripMenuItem MiCancelSelection;
        private System.Windows.Forms.ToolStripMenuItem MiCopyObjects;
        private System.Windows.Forms.ToolStripMenuItem MiFillWithTemplate;
        private System.Windows.Forms.ToolStripMenuItem MiDeleteObjects;
        private System.Windows.Forms.ToolStripMenuItem MiPasteObjects;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MiSetSelectionColor;
        private System.Windows.Forms.ToolStripButton BtnReplaceObjects;
        private System.Windows.Forms.ToolStripButton BtnRenderInvisibleObjects;
        private System.Windows.Forms.ToolStripMenuItem MiReplaceWithTemplate;
        private System.Windows.Forms.ToolStripMenuItem MiOverrideColors;
        private System.Windows.Forms.ToolStripButton BtnFind;
        private System.Windows.Forms.ToolStripButton BtnRunScript;
        private System.Windows.Forms.ToolStripButton BtnEditObject;
        private System.Windows.Forms.ToolStripButton BtnSetOutOfBoundsObject;
        private System.Windows.Forms.ToolStripButton BtnSetExtra;
        private System.Windows.Forms.ToolStripButton BtnLoad;
        private System.Windows.Forms.ToolStripButton BtnSave;
        private System.Windows.Forms.ToolStripButton BtnSaveAs;
        private System.Windows.Forms.ToolStripButton BtnWorkspace;
    }
}
