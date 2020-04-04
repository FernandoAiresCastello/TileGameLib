using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameMaker.MapEditorElements;
using TileGameLib.GameElements;
using TileGameLib.File;
using TileGameLib.Graphics;
using TileGameLib.Util;
using TileGameMaker.Windows;
using TileGameLib.Components;
using TileGameMaker.Util;
using System.Diagnostics;
using System.IO;

namespace TileGameMaker.Panels
{
    public partial class MapEditorPanel : BasePanel
    {
        public TiledDisplay Display { get; private set; }

        private ObjectMap Map;
        private MapEditor Editor;
        private MapRenderer MapRenderer;
        private int Layer;
        private ObjectBlockSelection Selection;
        private ToolTip Tooltip;
        private Point CurrentTooltipPoint;
        private bool TooltipEnabled;
        private ObjectBlockClipboard ClipboardObjects;

        private enum EditMode { Draw, Delete, TextInput, Selection, Replace }
        private EditMode Mode;

        private static readonly int DefaultZoom = Config.ReadInt("DefaultMapEditorZoom");
        private static readonly int MaxLayers = Config.ReadInt("MapEditorMaxLayers");

        private static readonly string MapFileExt = FileExtensions.MapRaw;
        private static readonly string MapFileFilter = $"TileGameMaker map file (*.{MapFileExt})|*.{MapFileExt}";

        public MapEditorPanel()
        {
            InitializeComponent();
        }

        public MapEditorPanel(MapEditor editor)
        {
            InitializeComponent();
            Editor = editor;
            Map = editor.Map;
            Display = new TiledDisplay(MapPanel, Map.Width, Map.Height, DefaultZoom);
            Display.ShowGrid = true;
            Display.SetGridColor(Color.FromArgb(Config.ReadInt("MapEditorGridColor")));
            MapRenderer = new MapRenderer(Map, Display);
            MapRenderer.RenderInvisibleObjects = true;
            BtnRenderInvisibleObjects.Checked = MapRenderer.RenderInvisibleObjects;
            LbEditModeInfo.Text = "";
            Layer = 0;
            Selection = new ObjectBlockSelection();

            Tooltip = new ToolTip();
            Tooltip.IsBalloon = true;
            TooltipEnabled = false;

            Display.MouseMove += Disp_MouseMove;
            Display.MouseDown += Disp_MouseDown;
            Display.MouseLeave += Disp_MouseLeave;

            SetMode(EditMode.Draw);
            ClearMap();
            RenderMap();
            Refresh();
            UpdateLayerComboBox();
            UpdateRecentFileList();
        }

        public void ResizeMapView(int width, int height)
        {
            Display.ResizeGraphics(width, height);
            MapRenderer.Viewport = new Rectangle(0, 0, width, height);
        }

        public void UpdateLayerComboBox()
        {
            CbLayer.Items.Clear();
            for (int i = 0; i < Map.Layers.Count; i++)
                CbLayer.Items.Add("Layer " + i);

            if (CbLayer.SelectedIndex < 0)
                CbLayer.SelectedIndex = 0;
        }

        private void UpdateStatusLabel()
        {
            LbMapInfo.Text =
                string.Format("Size: {0}x{1} Image size: {2}x{3} Layers: {4} Zoom: {5}",
                    Map.Width, Map.Height, Map.ImageWidth, Map.ImageHeight, 
                    Map.Layers.Count, Display.Zoom);
        }

        private void ClearMap()
        {
            Map.Clear();
        }

        private void Disp_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.None)
                OnDisplayMouseMove(e);
            else if (e.Button == MouseButtons.Left)
                OnDisplayMouseDown(e);
        }

        private void Disp_MouseDown(object sender, MouseEventArgs e)
        {
            OnDisplayMouseDown(e);
        }

        private void OnDisplayMouseDown(MouseEventArgs e)
        {
            Point point = Display.GetMouseToCellPos(e.Location);
            if (IsOutOfBounds(point))
                return;

            Focus();

            ObjectCell cell = Map.GetCell(new ObjectPosition(Layer, point));

            if (Mode == EditMode.Draw)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (ModifierKeys == Keys.Control)
                        DeleteObject(cell);
                    else
                        PutCurrentObject(cell);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    CopyObjectToTemplate(cell);
                }
            }
            else if (Mode == EditMode.TextInput)
            {
                if (e.Button == MouseButtons.Left)
                {
                    InputText(point.X, point.Y);
                }
                else
                {
                    SetMode(EditMode.Draw);
                }
            }
            else if (Mode == EditMode.Delete)
            {
                if (e.Button == MouseButtons.Left)
                {
                    DeleteObject(cell);
                }
                else
                {
                    SetMode(EditMode.Draw);
                }
            }
            else if (Mode == EditMode.Replace)
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReplaceObjectsWithTemplate(cell.Object);
                }
                else
                {
                    SetMode(EditMode.Draw);
                }
            }
            else if (Mode == EditMode.Selection)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (Selection.StartPoint.HasValue)
                        EndSelection(point);
                    else
                        StartSelection(point);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    CancelSelection();
                }
            }
        }

        private void StartSelection(Point point)
        {
            SetSelectionModeInstructionLabel();
            Selection.EndPoint = null;
            Selection.StartPoint = point;
            ClearTileSelection();
            Display.SelectTile(point);
        }

        private void EndSelection(Point point)
        {
            SetSelectionModeInstructionLabel();

            if (point.X < Selection.StartPoint.Value.X || point.Y < Selection.StartPoint.Value.Y)
            {
                EndSelection(Selection.StartPoint.Value);
                StartSelection(point);
            }
            else
            {
                point.Offset(1, 1);
                Selection.EndPoint = point;
            }
            
            ApplyTileSelection();
        }

        private void CancelSelection()
        {
            Selection.StartPoint = null;
            Selection.EndPoint = null;
            ClearTileSelection();
        }

        private void ClearTileSelection()
        {
            Display.DeselectAllTiles();
        }

        private void ApplyTileSelection()
        {
            Display.DeselectAllTiles();

            List<Point> selectedTiles = Selection.Points;
            if (selectedTiles.Count > 0)
                Display.SelectTiles(selectedTiles);

            Display.Refresh();
        }

        private void SetSelectionModeInstructionLabel()
        {
            LbEditModeInfo.Text = "Selection mode: Left-click to set top-left and bottom-right tile; Right-click to cancel";
        }

        private void SetReplaceModeInstructionLabel()
        {
            LbEditModeInfo.Text = "Replace objects mode: Left-click to replace with template all objects equal to clicked object";
        }

        private void OnDisplayMouseMove(MouseEventArgs e)
        {
            Point point = Display.GetMouseToCellPos(e.Location);
            if (IsOutOfBounds(point))
                return;

            ObjectPosition position = new ObjectPosition(Layer, point);

            if (Mode == EditMode.Selection)
                SetSelectionModeInstructionLabel();
            else if (Mode == EditMode.Replace)
                SetReplaceModeInstructionLabel();
            else
                LbEditModeInfo.Text = position.ToString();

            GameObject o = Map.GetObject(position);

            if (o != null)
            {
                if (Mode != EditMode.Selection && Mode != EditMode.Replace)
                {
                    LbEditModeInfo.Text += " → " + o.ToString();
                    ShowTooltip(o, position);
                }
            }
            else
            {
                HideTooltip();
            }
        }

        private void ShowTooltip(GameObject o, ObjectPosition position)
        {
            if (position.Point != CurrentTooltipPoint)
            {
                CurrentTooltipPoint = position.Point;
                Tooltip.SetToolTip(Display, TooltipEnabled ? GetTooltipText(o, position) : null);
            }
        }

        private void HideTooltip()
        {
            Tooltip.Hide(Display);
            CurrentTooltipPoint = new Point(-1, -1);
        }

        private string GetTooltipText(GameObject o, ObjectPosition position)
        {
            StringBuilder properties = new StringBuilder();
            foreach (KeyValuePair<string, string> prop in o.Properties.Entries)
                properties.Append($"    {prop.Key} = {prop.Value}\n");

            return 
                $"{position}\n" +
                $"Visible: {o.Visible}\n" +
                $"Frames: {o.Animation.Frames.Count}\n" +
                "Properties: \n" +
                "{\n" + properties + "}";
        }

        private void PutCurrentObject(ObjectCell cell)
        {
            cell.SetObjectEqual(Editor.SelectedObject);
            RenderMap();
        }

        private void DeleteObject(ObjectCell cell)
        {
            cell.DeleteObject();
            RenderMap();
        }

        private bool IsOutOfBounds(Point point)
        {
            return point.X < 0 || point.Y < 0 || point.X >= Map.Width || point.Y >= Map.Height;
        }

        private void Disp_MouseLeave(object sender, EventArgs e)
        {
            LbEditModeInfo.Text = "";
        }

        public override void Refresh()
        {
            MapRenderer.Render();
            UpdateStatusLabel();
            base.Refresh();
        }

        public void RenderMap()
        {
            MapRenderer.Render();
        }

        private void BtnZoomIn_Click(object sender, EventArgs e)
        {
            ZoomIn();
        }

        private void BtnZoomOut_Click(object sender, EventArgs e)
        {
            ZoomOut();
        }

        private void ZoomIn()
        {
            Display.ZoomIn();
            Refresh();
        }

        private void ZoomOut()
        {
            Display.ZoomOut();
            Refresh();
        }

        private void CopyObjectToTemplate(ObjectCell cell)
        {
            if (!cell.IsEmpty)
                Editor.SelectedObject = cell.Object;
            else
                Alert.Warning("Can't copy from empty cell");
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ConfirmNewMap();
        }

        private void BtnScreenshot_Click(object sender, EventArgs e)
        {
            SaveScreenshot();
        }

        private void SaveScreenshot()
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                Title = "Save map image",
                AddExtension = true,
                DefaultExt = "png",
                Filter = "PNG image files (*.png)|*.png"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
                Display.Graphics.SaveImage(dialog.FileName);
        }

        private void BtnGrid_Click(object sender, EventArgs e)
        {
            ToggleGrid();
        }

        private void ToggleGrid()
        {
            Display.ShowGrid = !Display.ShowGrid;
            Refresh();
        }

        private void BtnToggleTooltip_Click(object sender, EventArgs e)
        {
            TooltipEnabled = !TooltipEnabled;
            BtnToggleTooltip.Checked = TooltipEnabled;
        }

        private void BtnAddText_Click(object sender, EventArgs e) => SetMode(EditMode.TextInput);
        private void BtnPutTemplate_Click(object sender, EventArgs e) => SetMode(EditMode.Draw);
        private void BtnDeleteMode_Click(object sender, EventArgs e) => SetMode(EditMode.Delete);
        private void BtnReplaceObjects_Click(object sender, EventArgs e) => SetMode(EditMode.Replace);
        private void BtnSelect_Click(object sender, EventArgs e) => SetMode(EditMode.Selection);

        private void SetMode(EditMode mode)
        {
            Mode = mode;
            BtnSelectionActions.Visible = Mode == EditMode.Selection;
            ToolStripButton button = null;

            if (mode != EditMode.Selection)
                CancelSelection();

            switch (mode)
            {
                case EditMode.Draw:
                    Display.Cursor = GetCursor(Properties.Resources.pencil);
                    button = BtnPutTemplate;
                    break;
                case EditMode.Delete:
                    Display.Cursor = GetCursor(Properties.Resources.draw_eraser);
                    button = BtnDelete;
                    break;
                case EditMode.TextInput:
                    Display.Cursor = GetCursor(Properties.Resources.insert_text);
                    button = BtnAddText;
                    break;
                case EditMode.Selection:
                    Display.Cursor = GetCursor(Properties.Resources.select);
                    button = BtnSelect;
                    SetSelectionModeInstructionLabel();
                    break;
                case EditMode.Replace:
                    Display.Cursor = GetCursor(Properties.Resources.magic_wand);
                    button = BtnReplaceObjects;
                    SetReplaceModeInstructionLabel();
                    break;
            }

            if (button != null)
                CheckModeButton(button);
        }

        private Cursor GetCursor(Bitmap bitmap)
        {
            return new Cursor(bitmap.GetHicon());
        }

        private void CheckModeButton(ToolStripButton button)
        {
            BtnAddText.Checked = false;
            BtnPutTemplate.Checked = false;
            BtnSelect.Checked = false;
            BtnDelete.Checked = false;
            BtnReplaceObjects.Checked = false;

            button.Checked = true;
        }

        private void InputText(int x, int y)
        {
            TextInputWindow win = new TextInputWindow($"Enter text to insert @{x},{y}");
            win.EnableOrientationChange = true;
            if (win.ShowDialog(this) == DialogResult.Cancel)
                return;

            bool vertical = win.TextOrientation.Trim().ToLower().Equals("vertical");
            Tile tile = Editor.SelectedTile;
            ObjectPosition pos = new ObjectPosition(Layer, x, y);

            if (vertical)
                Map.SetVerticalStringOfObjects(win.Text, pos, tile.ForeColor, tile.BackColor);
            else
                Map.SetHorizontalStringOfObjects(win.Text, pos, tile.ForeColor, tile.BackColor);

            Refresh();
        }

        private void BtnSaveMapAs_Click(object sender, EventArgs e)
        {
            SaveMapAs();
        }

        public void SaveMap()
        {
            bool success = false;

            Map.Name = Editor.MapName;
            Map.MusicFile = Editor.MapMusic;
            Map.Text = Editor.ScriptPanel.Script;

            if (string.IsNullOrWhiteSpace(Editor.MapFile))
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.InitialDirectory = Editor.WorkspacePath;
                dialog.Filter = MapFileFilter;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    MapFile.SaveAsRawBytes(Map, dialog.FileName);
                    Editor.MapFile = dialog.FileName;
                    success = true;
                }
            }
            else if (Alert.Confirm($"Overwrite file {Editor.MapFile}?"))
            {
                MapFile.SaveAsRawBytes(Map, Editor.MapFile);
                success = true;
            }

            if (success)
            {
                Editor.UpdateMapProperties();
                Refresh();
                Alert.Info("File saved successfully!");
            }
        }

        public void SaveMapAs()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = Editor.WorkspacePath;
            dialog.Filter = MapFileFilter;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Map.Name = Editor.MapName;
                Map.MusicFile = Editor.MapMusic;
                Map.Text = Editor.ScriptPanel.Script;
                MapFile.SaveAsRawBytes(Map, dialog.FileName);
                Editor.MapFile = dialog.FileName;
                Editor.UpdateMapProperties();
                Alert.Info("File saved successfully!");
            }
        }

        public void LoadMap()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Editor.WorkspacePath;
            dialog.Filter = MapFileFilter;

            if (dialog.ShowDialog() == DialogResult.OK)
                LoadMap(dialog.FileName);
        }

        public void LoadMap(string file)
        {
            MapFile.LoadFromRawBytes(ref Map, file);
            Editor.MapFile = file;
            Editor.ScriptPanel.Script = Map.Text;
            Editor.UpdateMapProperties();
            Editor.ResizeMap(Map.Width, Map.Height);
            Editor.SelectedObject = Editor.BlankObject;
            Editor.RecentFiles.Add(file);
            UpdateRecentFileList();
            UpdateLayerComboBox();
            Alert.Info("File loaded successfully!");
        }

        private void UpdateRecentFileList()
        {
            BtnRecentFiles.DropDownItems.Clear();

            foreach (string file in Editor.RecentFiles.Files)
            {
                ToolStripMenuItem fileItem = new ToolStripMenuItem(file);
                fileItem.Click += BtnRecentFileItem_Click;
                BtnRecentFiles.DropDownItems.Add(fileItem);
            }

            if (BtnRecentFiles.DropDownItems.Count > 0)
            {
                BtnRecentFiles.DropDownItems.Add(new ToolStripSeparator());
                ToolStripMenuItem clearAll = new ToolStripMenuItem("Clear recent files list");
                clearAll.Click += BtnClearAllRecentItems_Click;
                BtnRecentFiles.DropDownItems.Add(clearAll);
            }
            else
            {
                BtnRecentFiles.DropDownItems.Add("(Empty)").Enabled = false;
            }
        }

        private void BtnRecentFileItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem fileItem = (ToolStripMenuItem)sender;
            LoadMap(fileItem.Text);
        }

        private void BtnClearAllRecentItems_Click(object sender, EventArgs e)
        {
            Editor.RecentFiles.Files.Clear();
            UpdateRecentFileList();
        }

        public void SaveMapToArchive(string path)
        {
            ArchiveWindow mgr = new ArchiveWindow(path);

            if (mgr.ShowDialog(this, ArchiveWindow.Mode.Save, MapFileExt) == DialogResult.OK)
            {
                string entry = mgr.SelectedEntry;
                if (mgr.Contains(entry) && !Alert.Confirm($"File \"{entry}\" already exists. Overwrite?"))
                    return;

                Map.Name = Editor.MapName;
                MapArchive arch = new MapArchive(path);
                string file = mgr.SelectedEntry + "." + MapFileExt;
                arch.Save(Map, file);
                Editor.MapFile = file;
                Editor.UpdateMapProperties();
                Refresh();
                Alert.Info("File saved successfully!");
            }
        }

        public void LoadMapFromArchive(string path)
        {
            ArchiveWindow mgr = new ArchiveWindow(path);

            if (mgr.ShowDialog(this, ArchiveWindow.Mode.Load, MapFileExt) == DialogResult.OK)
            {
                string entry = mgr.SelectedEntry;

                if (!mgr.Contains(entry))
                {
                    Alert.Warning($"File \"{entry}\" not found");
                    return;
                }

                MapArchive arch = new MapArchive(path);
                string file = mgr.SelectedEntry;
                arch.Load(Map, file);
                Editor.MapFile = file;
                Editor.UpdateMapProperties();
                Editor.ResizeMap(Map.Width, Map.Height);
                Editor.SelectedObject = Editor.BlankObject;
                UpdateLayerComboBox();
                Alert.Info("File loaded successfully!");
            }
        }

        public void CreateNewMap()
        {
            Layer = 0;

            if (Map.Layers.Count > 1)
            {
                for (int i = Map.Layers.Count - 1; i != 0; i--)
                    Map.RemoveLayer(i);
            }

            Map.Name = ObjectMap.DefaultName;
            Map.BackColor = Map.Palette.White;
            Map.MusicFile = "";
            Editor.ResizeMap(Editor.DefaultMapWidth, Editor.DefaultMapHeight);
            Editor.MapFile = null;
            Editor.UpdateMapProperties();
            ClearMap();
            RenderMap();
            UpdateStatusLabel();
            UpdateLayerComboBox();
        }

        private void ConfirmNewMap()
        {
            if (Alert.Confirm("Create new map?"))
                CreateNewMap();
        }

        private void CbLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            Layer = CbLayer.SelectedIndex;
            UpdateStatusLabel();
            MapRenderer.SetSingleLayerToRender(Layer);
            Refresh();
        }

        private void BtnAddLayer_Click(object sender, EventArgs e)
        {
            if (Map.Layers.Count < MaxLayers)
            {
                Map.AddLayer();
                Refresh();
                UpdateLayerComboBox();
                UpdateStatusLabel();
                Editor.UpdateMapProperties();
                CbLayer.SelectedIndex = CbLayer.SelectedIndex + 1;
            }
            else
            {
                Alert.Warning("Maximum number of layers is " + MaxLayers);
            }
        }

        private void BtnRemoveLayer_Click(object sender, EventArgs e)
        {
            if (CbLayer.SelectedIndex > 0)
            {
                if (Alert.Confirm("Delete layer " + CbLayer.SelectedIndex + "?"))
                {
                    Map.RemoveLayer(CbLayer.SelectedIndex);
                    MapRenderer.SetSingleLayerToRender(CbLayer.SelectedIndex - 1);
                    Refresh();
                    UpdateLayerComboBox();
                    UpdateStatusLabel();
                    Editor.UpdateMapProperties();
                }
            }
            else
            {
                Alert.Warning("Cannot remove layer 0");
            }
        }

        private void BtnViewAll_Click(object sender, EventArgs e)
        {
            ToggleViewAllLayers();
        }

        private void ToggleViewAllLayers()
        {
            BtnViewAll.Checked = !BtnViewAll.Checked;
            MapRenderer.SetRenderSingleLayer(!BtnViewAll.Checked, Layer);
            Refresh();
        }

        private void BtnClearLayer_Click(object sender, EventArgs e)
        {
            if (Alert.Confirm("Clear layer " + Layer + "?"))
            {
                Map.Clear(Layer);
                Refresh();
            }
        }

        private void BtnSetBackColor_Click(object sender, EventArgs e)
        {
            ColorPickerWindow win = new ColorPickerWindow(Editor, "Select map background");
            if (win.ShowDialog(this) == DialogResult.OK)
                Map.BackColor = win.SelectedColor;
        }

        private void MiCancelSelection_Click(object sender, EventArgs e)
        {
            CancelSelection();
        }

        private void MiSetSelectionColor_Click(object sender, EventArgs e)
        {
            ColorDialog win = new ColorDialog();

            if (win.ShowDialog(this) == DialogResult.OK)
            {
                Display.TileHighlightColor = win.Color;
                Display.Refresh();
            }
        }

        private void ReplaceObjectsWithTemplate(GameObject o)
        {
            if (o == null)
            {
                if (Alert.Confirm($"The clicked cell is empty. This will put the template object in all empty cells in the current layer (layer {Layer}). Are you sure?"))
                {
                    Map.FillEmptyCells(Editor.SelectedObject, Layer);
                    Display.Refresh();
                }
            }
            else if (Alert.Confirm("This will replace with the template all objects in all layers that are equal to the clicked object. Are you sure?"))
            {
                Map.ReplaceObjects(o, Editor.SelectedObject);
                Display.Refresh();
            }
        }

        private void BtnRenderInvisibleObjects_Click(object sender, EventArgs e)
        {
            MapRenderer.RenderInvisibleObjects = BtnRenderInvisibleObjects.Checked;
            Display.Refresh();
        }

        private void MiDeleteObjects_Click(object sender, EventArgs e)
        {
            DeleteSelectedObjects();
        }

        private void DeleteSelectedObjects()
        {
            List<ObjectCell> selectedCells = Map.GetCells(Selection.GetSelectedPositions(Layer));
            foreach (ObjectCell cell in selectedCells)
                cell.DeleteObject();

            Display.Refresh();
        }

        private void MiFillWithTemplate_Click(object sender, EventArgs e)
        {
            List<ObjectCell> selectedCells = Map.GetCells(Selection.GetSelectedPositions(Layer));
            foreach (ObjectCell cell in selectedCells)
                cell.SetObjectEqual(Editor.SelectedObject);

            Display.Refresh();
        }

        private void MiCopyObjects_Click(object sender, EventArgs e)
        {
            CopySelectedObjectsToClipboard();
        }

        private void MiCutObjects_Click(object sender, EventArgs e)
        {
            CutSelectedObjectsToClipboard();
        }

        private void MiPasteObjects_Click(object sender, EventArgs e)
        {
            PasteObjectsFromClipboard();
        }

        private void CutSelectedObjectsToClipboard()
        {
            CopySelectedObjectsToClipboard(false);
            DeleteSelectedObjects();
            CancelSelection();
        }

        private void CopySelectedObjectsToClipboard(bool cancelSelectionAfterCopy = true)
        {
            if (!Selection.Block.HasValue)
            {
                Alert.Warning("Can't copy from empty selection");
                return;
            }

            ClipboardObjects = new ObjectBlockClipboard(Selection.Block.Value);

            for (int y = 0; y < ClipboardObjects.Block.Height; y++)
            {
                for (int x = 0; x < ClipboardObjects.Block.Width; x++)
                {
                    GameObject o = Map.GetObject(new ObjectPosition(Layer, Selection.Block.Value.X + x, Selection.Block.Value.Y + y));
                    ClipboardObjects.SetObject(o?.Copy(), x, y);
                }
            }

            if (cancelSelectionAfterCopy)
                CancelSelection();

            Display.Refresh();
        }

        private void PasteObjectsFromClipboard()
        {
            if (ClipboardObjects == null)
            {
                Alert.Warning("Clipboard is empty");
                return;
            }
            if (Selection.StartPoint == null)
            {
                Alert.Warning("Can't paste to empty selection");
                return;
            }

            for (int y = 0; y < ClipboardObjects.Block.Height; y++)
            {
                for (int x = 0; x < ClipboardObjects.Block.Width; x++)
                {
                    GameObject o = ClipboardObjects.Objects[x, y];
                    ObjectPosition pastePosition = new ObjectPosition(Layer, Selection.Block.Value.X + x, Selection.Block.Value.Y + y);

                    if (pastePosition.X < Map.Width && pastePosition.Y < Map.Height)
                    {
                        if (o != null)
                            Map.SetObject(o.Copy(), pastePosition);
                        else
                            Map.DeleteObject(pastePosition);
                    }
                }
            }

            CancelSelection();
            Display.Refresh();
        }

        public void HandleKeyEvent(object sender, KeyEventArgs e)
        {
            MapEditorControl_KeyDown(sender, e);
        }

        private void MapEditorControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.O:
                        LoadMap();
                        break;
                    case Keys.S:
                        SaveMap();
                        break;
                    case Keys.N:
                        ConfirmNewMap();
                        break;
                    case Keys.D1:
                        SetMode(EditMode.Draw);
                        break;
                    case Keys.D2:
                        SetMode(EditMode.Delete);
                        break;
                    case Keys.D3:
                        SetMode(EditMode.TextInput);
                        break;
                    case Keys.D4:
                        SetMode(EditMode.Replace);
                        break;
                    case Keys.D5:
                        SetMode(EditMode.Selection);
                        break;
                }
            }
            else
            {
                switch (e.KeyCode)
                {
                    case Keys.PageUp:
                        ZoomIn();
                        break;
                    case Keys.PageDown:
                        ZoomOut();
                        break;
                    case Keys.Escape:
                        CancelSelection();
                        break;
                }
            }
        }

        private void BtnSaveRawBytes_Click(object sender, EventArgs e)
        {
            SaveMap();
        }

        private void BtnLoadRawBytes_Click(object sender, EventArgs e)
        {
            LoadMap();
        }

        private void MiReplaceWithTemplate_Click(object sender, EventArgs e)
        {
            Alert.Warning("Feature not yet implemented");
        }

        private void MiOverrideColors_Click(object sender, EventArgs e)
        {
            List<ObjectCell> selectedCells = Map.GetCells(Selection.GetSelectedPositions(Layer));

            foreach (ObjectCell cell in selectedCells)
            {
                foreach (Tile tile in cell.Object.Animation.Frames)
                {
                    tile.ForeColor = Editor.ColorPickerControl.SelectedForeColor;
                    tile.BackColor = Editor.ColorPickerControl.SelectedBackColor;
                }
            }

            Display.Refresh();
        }

        private void BtnExportJson_Click(object sender, EventArgs e)
        {
            Export(MapExportFormat.Json);
        }

        public void Export(MapExportFormat format)
        {
            string fileExt = MapExportFileExtension.Get(format);

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = Editor.WorkspacePath;
            dialog.Filter = $"TileGameMaker map JSON file (*.{fileExt})|*.{fileExt}";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                MapFile.Export(format, Map, dialog.FileName);
                Alert.Info("Map exported successfully!");
            }
        }
    }
}
