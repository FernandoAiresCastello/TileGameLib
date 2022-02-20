using System;
using System.Collections.Generic;
using System.Drawing;
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
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace TileGameMaker.Panels
{
    public partial class MapEditorPanel : UserControl
    {
        public TiledDisplay Display { get; private set; }

        public int ViewScrollX => MapRenderer.ScrollX;
        public int ViewScrollY => MapRenderer.ScrollY;

        private ObjectMap Map;
        private MapEditor Editor;
        private MapRenderer MapRenderer;
        private int Layer;
        private ObjectBlockSelection Selection;
        private ScriptWindow ScriptWindow;
        private ObjectBlockClipboard ClipboardObjects;
        private GameObjectPanel GameObjectPanel;
        private int ViewWidth = 32;
        private int ViewHeight = 24;

        private enum EditMode { Draw, Delete, TextInput, Selection, Replace, EditObject }
        private EditMode Mode;

        private Stack<ObjectMap> ObjectLinks = new Stack<ObjectMap>();

        private static readonly int DefaultZoom = Config.ReadInt("DefaultMapEditorZoom");
        private static readonly int MaxLayers = Config.ReadInt("MapEditorMaxLayers");

        private static readonly string MapFileExt = FileExtensions.Map;
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
            Display = new TiledDisplay(MapPanel, ViewWidth, ViewHeight, DefaultZoom);
            Display.ShowGrid = true;
            Display.SetMainGridColor(Color.FromArgb(Config.ReadInt("MapEditorGridColor")));
            MapRenderer = new MapRenderer(Map, Display, new Rectangle(0, 0, ViewWidth, ViewHeight));
            MapRenderer.RenderInvisibleObjects = true;
            BtnRenderInvisibleObjects.Checked = MapRenderer.RenderInvisibleObjects;
            LbEditModeInfo.Text = "";
            Layer = 0;
            Selection = new ObjectBlockSelection();
            ScriptWindow = new ScriptWindow(Map);
            GameObjectPanel = editor.GameObjectPanel;

            Display.MouseMove += Disp_MouseMove;
            Display.MouseDown += Disp_MouseDown;
            Display.MouseLeave += Disp_MouseLeave;

            LbViewPos.Click += LbViewPos_Click;

            SetMode(EditMode.Draw);
            RenderMap();
            Refresh();
            UpdateLayerComboBox();
            UpdateViewLabel();
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
            LbMapInfo.Text = string.Format("Size: {0}x{1}, Layers: {2}, Zoom: {3}",
                Map.Width, Map.Height, Map.Layers.Count, Display.Zoom);
        }

        private void UpdateViewLabel()
        {
            LbViewPos.Text = string.Format("View: X{0} Y{1} - X{2} Y{3}",
                MapRenderer.ScrollX, MapRenderer.ScrollY,
                MapRenderer.ScrollX + MapRenderer.Viewport.Width - 1, 
                MapRenderer.ScrollY + MapRenderer.Viewport.Height - 1);
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
            else if (e.Button == MouseButtons.Middle)
                OnDisplayMouseMoveMiddleButton(e);
        }

        private void Disp_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
                OnDisplayMouseDownMiddleButton(e);
            else
                OnDisplayMouseDown(e);
        }

        private void OnDisplayMouseDown(MouseEventArgs e)
        {
            Point point = GetMouseToScrolledCellPos(e.Location);
            if (IsOutOfBounds(point))
                return;

            Focus();

            ObjectPosition pos = new ObjectPosition(Layer, point);
            PositionedObject obj = Map.GetPositionedObject(pos);
            ObjectCell cell = Map.GetCell(pos);

            if (Mode == EditMode.Draw)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (ModifierKeys == Keys.Shift)
                        DeleteObject(cell);
                    else if (ModifierKeys == Keys.Control)
                        EditObject(obj, pos);
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
            else if (Mode == EditMode.EditObject)
            {
                if (e.Button == MouseButtons.Left)
                {
                    EditObject(obj, pos);
                }
                else
                {
                    CopyObjectToTemplate(cell);
                }
            }
        }

        private void OnDisplayMouseDownMiddleButton(MouseEventArgs e)
        {
        }

        private void OnDisplayMouseMoveMiddleButton(MouseEventArgs e)
        {
        }

        private void StartSelection(Point point)
        {
            SetSelectionModeLabel();
            Selection.EndPoint = null;
            Selection.StartPoint = point;
            ClearTileSelection();
            Display.SelectTile(GetUnscrolledCellPos(point));
        }

        private void EndSelection(Point point)
        {
            SetSelectionModeLabel();

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
            {
                for (int i = 0; i < selectedTiles.Count; i++)
                    selectedTiles[i] = GetUnscrolledCellPos(selectedTiles[i]);

                Display.SelectTiles(selectedTiles);
            }

            Display.Refresh();
        }

        private void SetSelectionModeLabel()
        {
            Rectangle? selection = Selection.Block;
            
            if (selection.HasValue)
                LbEditModeInfo.Text = $"Selection size: {selection.Value.Width}x{selection.Value.Height}";
            else
                LbEditModeInfo.Text = "Selection mode";
        }

        private void SetReplaceModeLabel()
        {
            LbEditModeInfo.Text = "Replace mode";
        }

        private Point GetMouseToScrolledCellPos(Point mousePos)
        {
            Point point = Display.GetMouseToCellPos(mousePos);
            point.X += MapRenderer.ScrollX;
            point.Y += MapRenderer.ScrollY;
            return point;
        }

        private Point GetUnscrolledCellPos(Point cellPos)
        {
            Point pos = new Point(cellPos.X, cellPos.Y);
            pos.X -= MapRenderer.ScrollX;
            pos.Y -= MapRenderer.ScrollY;
            return pos;
        }

        private void OnDisplayMouseMove(MouseEventArgs e)
        {
            Point point = GetMouseToScrolledCellPos(e.Location);

            if (IsOutOfBounds(point))
            {
                GameObjectPanel.Update(null);
                return;
            }

            ObjectPosition position = new ObjectPosition(Layer, point);

            if (Mode == EditMode.Selection)
                SetSelectionModeLabel();
            else if (Mode == EditMode.Replace)
                SetReplaceModeLabel();
            else
                LbEditModeInfo.Text = "";

            GameObjectPanel.Update(new PositionedCell(Map, position));
        }

        private void OnDisplayMouseLeave(EventArgs e)
        {
            LbEditModeInfo.Text = "";
            GameObjectPanel.ClearPointedToObjectView();
        }

        private void PutCurrentObject(ObjectCell cell)
        {
            cell.SetObjectEqual(Editor.CopyObjectFromClipboard());
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
            OnDisplayMouseLeave(e);
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
                Editor.CopyObjectToClipboard(cell.Object);
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
                DefaultExt = "bmp",
                Filter = "Bitmap image (*.bmp)|*.bmp"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Display.Graphics.SaveImage(dialog.FileName, ImageFormat.Bmp);
                Alert.Info("Screenshot successfully saved to file!");
            }
        }

        private void BtnGrid_Click(object sender, EventArgs e)
        {
            GridSetupWindow win = new GridSetupWindow(Display);

            if (win.ShowDialog(this) == DialogResult.OK)
            {
                Display.SetMainGridColor(win.MainGridColor);
                Display.SetAuxGrid(win.AuxGridColor, win.AuxGridIntervalX, win.AuxGridIntervalY);
                Refresh();
            }
        }

        private void ToggleGrid()
        {
            Display.ShowGrid = !Display.ShowGrid;
            Refresh();
        }

        private void BtnAddText_Click(object sender, EventArgs e) => SetMode(EditMode.TextInput);
        private void BtnPutTemplate_Click(object sender, EventArgs e) => SetMode(EditMode.Draw);
        private void BtnDeleteMode_Click(object sender, EventArgs e) => SetMode(EditMode.Delete);
        private void BtnReplaceObjects_Click(object sender, EventArgs e) => SetMode(EditMode.Replace);
        private void BtnSelect_Click(object sender, EventArgs e) => SetMode(EditMode.Selection);
        private void BtnEditObject_Click(object sender, EventArgs e) => SetMode(EditMode.EditObject);

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
                    SetSelectionModeLabel();
                    break;
                case EditMode.Replace:
                    Display.Cursor = GetCursor(Properties.Resources.magic_wand);
                    button = BtnReplaceObjects;
                    SetReplaceModeLabel();
                    break;
                case EditMode.EditObject:
                    Display.Cursor = GetCursor(Properties.Resources.brick_edit);
                    button = BtnEditObject;
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
            BtnEditObject.Checked = false;

            button.Checked = true;
        }

        private void InputText(int x, int y)
        {
            TextInputWindow win = new TextInputWindow($"Enter text to insert @{x},{y}");
            win.EnableOrientationChange = true;
            if (win.ShowDialog(this) == DialogResult.Cancel)
                return;

            bool vertical = win.TextOrientation.Trim().ToLower().Equals("vertical");
            Tile tile = Editor.CopyObjectFromClipboard().Tile;
            ObjectPosition pos = new ObjectPosition(Layer, x, y);

            if (vertical)
                Map.SetVerticalStringOfObjects(win.Text, pos, tile.ForeColor, tile.BackColor);
            else
                Map.SetHorizontalStringOfObjects(win.Text, pos, tile.ForeColor, tile.BackColor);

            Refresh();
        }

        public void SetMap(ObjectMap map)
        {
            Map = map;
            MapRenderer.Map = map;
            Editor.UpdateMapProperties();
            Editor.ResizeMap(Map.Width, Map.Height);
            Editor.Refresh();
            UpdateLayerComboBox();
        }

        public void DisableEditorTemporarily(int ms = 500)
        {
            Enabled = false;
            Timer timer = new Timer();
            timer.Interval = ms;
            timer.Tick += (sender, e) =>
            {
                Enabled = true;
                timer.Stop();
            };
            timer.Start();
        }

        public void CreateNewMap()
        {
            Layer = 0;

            if (Map.Layers.Count > 1)
            {
                for (int i = Map.Layers.Count - 1; i != 0; i--)
                    Map.RemoveLayer(i);
            }

            Map.GenerateId();
            Map.Name = ObjectMap.DefaultName;
            Map.BackColor = Map.Palette.White;
            Editor.ResizeMap(Project.DefaultMapWidth, Project.DefaultMapHeight);
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
                    Map.FillEmptyCells(Editor.CopyObjectFromClipboard(), Layer);
                    Display.Refresh();
                }
            }
            else if (Alert.Confirm("This will replace with the template all objects in all layers that are equal to the clicked object. Are you sure?"))
            {
                Map.ReplaceObjects(o, Editor.CopyObjectFromClipboard());
                Display.Refresh();
            }
        }

        public void ReplaceObjectsWithTemplate(List<ObjectPosition> positions)
        {
            Map.SetObjects(Editor.CopyObjectFromClipboard(), positions);
            Display.Refresh();
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
                cell.SetObjectEqual(Editor.CopyObjectFromClipboard());

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
                    case Keys.G:
                        SelectViewScrollPos();
                        break;
                    case Keys.Right:
                        if (e.Shift)
                            ScrollViewToRightEdge();
                        else
                            ScrollView(1, 0);
                        break;
                    case Keys.Left:
                        if (e.Shift)
                            ScrollViewToLeftEdge();
                        else
                            ScrollView(-1, 0);
                        break;
                    case Keys.Up:
                        if (e.Shift)
                            ScrollViewToTopEdge();
                        else
                            ScrollView(0, -1);
                        break;
                    case Keys.Down:
                        if (e.Shift)
                            ScrollViewToBottomEdge();
                        else
                            ScrollView(0, 1);
                        break;
                }
            }
            else
            {
                switch (e.KeyCode)
                {
                    case Keys.PageUp:
                        if (CbLayer.SelectedIndex < CbLayer.Items.Count - 1)
                            CbLayer.SelectedIndex++;
                        break;
                    case Keys.PageDown:
                        if (CbLayer.SelectedIndex > 0)
                            CbLayer.SelectedIndex--;
                        break;
                    case Keys.Escape:
                        CancelSelection();
                        break;
                }
            }
        }

        private void MiOverrideColors_Click(object sender, EventArgs e)
        {
            OverrideObjectColors(Selection.GetSelectedPositions(Layer));
        }

        public void OverrideObjectColors(List<ObjectPosition> positions)
        {
            List<ObjectCell> selectedCells = Map.GetCells(positions);

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

        public void OverrideObjectTileIndex(List<ObjectPosition> positions)
        {
            List<ObjectCell> selectedCells = Map.GetCells(positions);

            foreach (ObjectCell cell in selectedCells)
            {
                foreach (Tile tile in cell.Object.Animation.Frames)
                {
                    tile.Index = Editor.TilePickerControl.SelectedTile;
                }
            }

            Display.Refresh();
        }

        private void BtnRunScript_Click(object sender, EventArgs e)
        {
            OpenScriptWindow();
        }

        private void OpenScriptWindow()
        {
            ScriptWindow.Show();
        }

        private void EditObject(PositionedObject po, ObjectPosition pos)
        {
            ObjectEditWindow win = new ObjectEditWindow(Editor, po, Map, pos);
            if (win.ShowDialog(this, "Edit object") == DialogResult.OK)
                Map.SetObject(win.EditedObject, pos);
        }

        private void BtnSetOutOfBoundsObject_Click(object sender, EventArgs e)
        {
            ObjectEditWindow win = new ObjectEditWindow(Editor, Map.OutOfBoundsObject);
            if (win.ShowDialog(this, "Edit out of bounds object") == DialogResult.OK)
                Map.OutOfBoundsObject = win.EditedObject;
        }

        private void FollowObjectLink(GameObject o)
        {
            if (o == null)
            {
                Alert.Warning("The clicked cell is empty");
            }
            else
            {
                if (o.Properties.Has("link"))
                {
                    string linkedMapId = o.Properties.GetAsString("link").Trim();

                    if (!string.IsNullOrEmpty(linkedMapId))
                    {
                        ObjectMap currentMap = Editor.Map;
                        ObjectMap linkedMap = Editor.Project.FindMapById(linkedMapId);

                        if (linkedMap != null)
                        {
                            Editor.SetMap(linkedMap);
                            ObjectLinks.Push(currentMap);
                        }
                        else
                        {
                            Alert.Warning($"Linked map with ID \"{linkedMapId}\" not found in project {Editor.Project.Path}");
                        }
                    }
                    else
                    {
                        Alert.Warning("Link property is empty");
                    }
                }
                else
                {
                    Alert.Warning("No link found");
                }
            }
        }

        private void ReturnFromObjectLink()
        {
            if (ObjectLinks.Count > 0)
            {
                ObjectMap previousMap = ObjectLinks.Pop();
                Editor.SetMap(previousMap);
            }
            else
            {
                Alert.Warning("No previous link found");
            }
        }

        public void ScrollViewTo(int x, int y)
        {
            MapRenderer.ScrollToPoint(x, y);
            UpdateViewLabel();
        }

        public void ScrollView(int dx, int dy)
        {
            bool amountOk = int.TryParse(TxtScrollAmount.Text, out int amount);

            if (!amountOk)
            {
                amount = 1;
                TxtScrollAmount.Text = amount.ToString();
            }

            if (amount > 1)
            {
                amount--;

                if (dx > 0)
                    dx += amount;
                else if (dx < 0)
                    dx -= amount;
                if (dy > 0)
                    dy += amount;
                else if (dy < 0)
                    dy -= amount;
            }

            MapRenderer.ScrollByDistanceIfInsideView(dx, dy);
            UpdateViewLabel();
        }

        private void ScrollViewToRightEdge()
        {
            MapRenderer.ScrollViewToRightEdge();
            UpdateViewLabel();
        }

        private void ScrollViewToLeftEdge()
        {
            MapRenderer.ScrollViewToLeftEdge();
            UpdateViewLabel();
        }

        private void ScrollViewToTopEdge()
        {
            MapRenderer.ScrollViewToTopEdge();
            UpdateViewLabel();
        }

        private void ScrollViewToBottomEdge()
        {
            MapRenderer.ScrollViewToBottomEdge();
            UpdateViewLabel();
        }

        public void ResetViewScroll()
        {
            MapRenderer.ScrollToPoint(0, 0);
            UpdateViewLabel();
        }

        private void LbViewPos_Click(object sender, EventArgs e)
        {
            SelectViewScrollPos();
        }

        private void SelectViewScrollPos()
        {
            RangeInputWindow win = new RangeInputWindow("Enter view scroll top-left position:", "X", "Y");
            win.FromMinValue = 0;
            win.FromMaxValue = Map.Width - MapRenderer.Viewport.Width;
            win.ToMinValue = 0;
            win.ToMaxValue = Map.Height - MapRenderer.Viewport.Height;
            win.FromValue = MapRenderer.ScrollX;
            win.ToValue = MapRenderer.ScrollY;

            if (win.ShowDialog() == DialogResult.OK)
            {
                MapRenderer.ScrollToPoint(win.FromValue, win.ToValue);
                UpdateViewLabel();
            }
        }

        private void BtnScrollLeft_Click(object sender, EventArgs e)
        {
            ScrollView(-1, 0);
        }

        private void BtnScrollRight_Click(object sender, EventArgs e)
        {
            ScrollView(1, 0);
        }

        private void BtnScrollDown_Click(object sender, EventArgs e)
        {
            ScrollView(0, 1);
        }

        private void BtnScrollUp_Click(object sender, EventArgs e)
        {
            ScrollView(0, -1);
        }

        private void BtnBookmarks_Click(object sender, EventArgs e)
        {
            MapBookmarkWindow win = new MapBookmarkWindow(
                Editor.MapBookmarks, Map.Id, Editor.MapEditorControl);

            win.ShowDialog(this);
        }

        private void MiExportSelectionToImage_Click(object sender, EventArgs e)
        {
            Alert.Warning("This function is not yet implemented");
            return;

            // TODO: This is currently not working correctly

            int w = Selection.Cols * TilePixels.RowLength;
            int h = Selection.Rows * TilePixels.RowCount;
            Bitmap tile = new Bitmap(w, h);

            foreach (Point pt in Selection.Points)
            {
                int x = pt.X * TilePixels.RowLength;
                int y = pt.Y * TilePixels.RowCount;
                Bitmap image = Display.Graphics.Bitmap;
                Graphics g = Graphics.FromImage(tile);
                g.SmoothingMode = SmoothingMode.None;
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = PixelOffsetMode.None;
                g.DrawImage(image, x, y, w, h);
            }

            SaveFileDialog dialog = new SaveFileDialog
            {
                Title = "Export selection to image",
                AddExtension = true,
                DefaultExt = "bmp",
                Filter = "Bitmap image (*.bmp)|*.bmp"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tile.Save(dialog.FileName, ImageFormat.Bmp);
                Alert.Info("Selection image successfully exported to file!");
            }
        }
    }
}
