using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameMaker.Modules;
using TileGameLib.GameElements;
using TileGameLib.File;
using TileGameLib.Graphics;
using TileGameLib.Util;
using TileGameMaker.Windows;
using TileGameLib.Components;
using TileGameMaker.Util;
using System.Diagnostics;

namespace TileGameMaker.Panels
{
    public partial class MapEditorPanel : BasePanel
    {
        public TiledDisplay Display { get; private set; }

        private ObjectMap Map;
        private MapEditor MapEditor;
        private MapRenderer MapRenderer;
        private int Layer;
        private TileBlockSelection Selection;

        private enum EditMode { Template, Delete, Data, TextInput, Selection }
        private EditMode Mode;

        private static readonly int DefaultZoom = Config.ReadInt("DefaultMapEditorZoom");
        private static readonly int MaxLayers = Config.ReadInt("MapEditorMaxLayers");
        private static readonly string MapFileExt = Config.ReadString("MapFileExt");

        private static readonly string MapFileFilter = $"TileGameMaker map file (*.{MapFileExt})|*.{MapFileExt}";
        private static readonly string MessageCellEmpty = "This cell is empty";

        public MapEditorPanel()
        {
            InitializeComponent();
        }

        public MapEditorPanel(MapEditor editor)
        {
            InitializeComponent();
            MapEditor = editor;
            Map = editor.Map;
            Display = new TiledDisplay(MapPanel, Map.Width, Map.Height, DefaultZoom);
            Display.ShowGrid = true;
            Display.SetGridColor(Color.FromArgb(Config.ReadInt("MapEditorGridColor")));
            MapRenderer = new MapRenderer(Map, Display);
            HoverLabel.Text = "";
            Layer = 0;
            Selection = new TileBlockSelection();

            Display.MouseMove += Disp_MouseMove;
            Display.MouseDown += Disp_MouseDown;
            Display.MouseUp += Disp_MouseUp;
            Display.MouseLeave += Disp_MouseLeave;

            SetMode(EditMode.Template, BtnPutTemplate);
            ClearMap();
            RenderMap();
            Refresh();
            UpdateLayerComboBox();
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
            StatusLabel.Text =
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

        private void Disp_MouseUp(object sender, MouseEventArgs e)
        {
            OnDisplayMouseUp(e);
        }

        private void OnDisplayMouseDown(MouseEventArgs e)
        {
            Point point = Display.GetMouseToCellPos(e.Location);
            if (IsOutOfBounds(point))
                return;

            Focus();

            ObjectCell cell = Map.GetCell(new ObjectPosition(Layer, point.X, point.Y));

            if (Mode == EditMode.Template)
            {
                if (e.Button == MouseButtons.Left)
                {
                    PutCurrentObject(cell);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    CopyObjectToTemplate(cell);
                }
            }
            else if (Mode == EditMode.Data)
            {
                if (e.Button == MouseButtons.Left)
                {
                    InputData(point.X, point.Y);
                }
            }
            else if (Mode == EditMode.TextInput)
            {
                if (e.Button == MouseButtons.Left)
                {
                    InputText(point.X, point.Y);
                }
            }
            else if (Mode == EditMode.Delete)
            {
                if (e.Button == MouseButtons.Left)
                {
                    DeleteObject(cell);
                }
            }
            else if (Mode == EditMode.Selection)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Selection.EndPoint = null;
                    Selection.StartPoint = point;
                }
                else if (e.Button == MouseButtons.Right)
                {
                    Selection.EndPoint = point;
                }

                Debug.WriteLine(Selection);
            }
        }

        private void OnDisplayMouseUp(MouseEventArgs e)
        {
            // Nothing here yet
        }

        private void OnDisplayMouseMove(MouseEventArgs e)
        {
            Point point = Display.GetMouseToCellPos(e.Location);
            if (IsOutOfBounds(point))
                return;

            HoverLabel.Text = $"Layer: {Layer} X: {point.X} Y: {point.Y} ";

            GameObject o = Map.GetObjectRef(new ObjectPosition(Layer, point.X, point.Y));
            if (o != null)
                HoverLabel.Text += o.ToString();
        }

        private void PutCurrentObject(ObjectCell cell)
        {
            cell.SetObjectEqual(MapEditor.SelectedObject);
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
            HoverLabel.Text = "";
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
                MapEditor.SelectedObject = cell.GetObjectRef();
            else
                Alert.Warning(MessageCellEmpty);
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
                Display.Graphics.SaveAsImage(dialog.FileName);
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

        private void BtnAddText_Click(object sender, EventArgs e)
        {
            SetMode(EditMode.TextInput, sender);
        }

        private void BtnSetScript_Click(object sender, EventArgs e)
        {
            SetMode(EditMode.Data, sender);
        }

        private void BtnPutTemplate_Click(object sender, EventArgs e)
        {
            SetMode(EditMode.Template, sender);
        }

        private void BtnDeleteMode_Click(object sender, EventArgs e)
        {
            SetMode(EditMode.Delete, sender);
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            SetMode(EditMode.Selection, sender);
        }

        private void SetMode(EditMode mode, object button)
        {
            Mode = mode;

            switch (mode)
            {
                case EditMode.Template:
                case EditMode.Delete:
                    Display.Cursor = Cursors.Arrow;
                    break;
                case EditMode.TextInput:
                    Display.Cursor = Cursors.IBeam;
                    break;
                case EditMode.Data:
                    Display.Cursor = Cursors.Hand;
                    break;
                case EditMode.Selection:
                    Display.Cursor = Cursors.Cross;
                    break;
            }

            CheckModeButton(button as ToolStripButton);
        }

        private void CheckModeButton(ToolStripButton button)
        {
            BtnSetData.Checked = false;
            BtnAddText.Checked = false;
            BtnPutTemplate.Checked = false;
            BtnSelect.Checked = false;
            BtnDelete.Checked = false;

            button.Checked = true;
        }

        private void InputData(int x, int y)
        {
            GameObject o = Map.GetObjectRef(new ObjectPosition(Layer, x, y));

            if (o == null)
            {
                Alert.Warning(MessageCellEmpty);
                return;
            }

            ObjectDataInputWindow win = new ObjectDataInputWindow($"Enter object data @{x},{y}");

            if (win.ShowDialog(this, o) == DialogResult.OK)
            {
                o.Tag = win.ObjectTag;
                o.Properties = win.ObjectProperties;
            }
        }

        private void InputText(int x, int y)
        {
            TextInputWindow win = new TextInputWindow($"Enter text to insert @{x},{y}");
            if (win.ShowDialog(this) == DialogResult.Cancel)
                return;

            string[] lines = win.Text.Replace("\r", "").Split('\n');

            foreach (string line in lines)
            {
                int px = x;
                foreach (char ch in line)
                {
                    Tile tile = MapEditor.SelectedTile;
                    tile.TileIx = ch;
                    GameObject o = new GameObject(tile);
                    Map.SetObject(o, new ObjectPosition(Layer, x++, y));
                }
                y++;
                x = px;
            }

            Refresh();
        }

        private void BtnSaveMap_Click(object sender, EventArgs e)
        {
            SaveMap();
        }

        private void BtnLoadMap_Click(object sender, EventArgs e)
        {
            LoadMap();
        }

        public void SaveMap()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = MapEditor.WorkspacePath;
            dialog.Filter = MapFileFilter;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Map.Name = MapEditor.MapName;
                MapFile.Save(Map, dialog.FileName);
                MapEditor.MapFile = dialog.FileName;
                MapEditor.UpdateMapProperties();
                Refresh();
                Alert.Info("File saved successfully!");
            }
        }

        public void LoadMap()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = MapEditor.WorkspacePath;
            dialog.Filter = MapFileFilter;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                MapFile.Load(ref Map, dialog.FileName);
                MapEditor.MapFile = dialog.FileName;
                MapEditor.UpdateMapProperties();
                MapEditor.ResizeMap(Map.Width, Map.Height);
                MapEditor.SelectedObject = new GameObject();
                UpdateLayerComboBox();
                Alert.Info("File loaded successfully!");
            }
        }

        public void SaveMapToArchive(string path)
        {
            ArchiveWindow mgr = new ArchiveWindow(path);

            if (mgr.ShowDialog(this, ArchiveWindow.Mode.Save, MapFileExt) == DialogResult.OK)
            {
                string entry = mgr.SelectedEntry;
                if (mgr.Contains(entry) && !Alert.Confirm($"File \"{entry}\" already exists. Overwrite?"))
                    return;

                Map.Name = MapEditor.MapName;
                MapArchive arch = new MapArchive(path);
                string file = mgr.SelectedEntry + "." + MapFileExt;
                arch.Save(Map, file);
                MapEditor.MapFile = file;
                MapEditor.UpdateMapProperties();
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
                arch.Load(ref Map, file);
                MapEditor.MapFile = file;
                MapEditor.UpdateMapProperties();
                MapEditor.ResizeMap(Map.Width, Map.Height);
                MapEditor.SelectedObject = new GameObject();
                UpdateLayerComboBox();
                Alert.Info("File loaded successfully!");
            }
        }

        public void NewMap(string name, int width, int height)
        {
            Layer = 0;

            if (Map.Layers.Count > 1)
            {
                for (int i = Map.Layers.Count - 1; i != 0; i--)
                    Map.RemoveLayer(i);
            }
            
            Map.Name = name;
            MapEditor.ResizeMap(width, height);
            MapEditor.MapFile = null;
            MapEditor.UpdateMapProperties();
            ClearMap();
            RenderMap();
            UpdateStatusLabel();
            UpdateLayerComboBox();
        }

        private void ConfirmNewMap()
        {
            if (Alert.Confirm("Create new map?"))
                NewMap(MapEditor.DefaultMapName, MapEditor.DefaultMapWidth, MapEditor.DefaultMapHeight);
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
                    case Keys.G:
                        ToggleGrid();
                        break;
                    case Keys.T:
                        SetMode(EditMode.TextInput, BtnAddText);
                        break;
                    case Keys.P:
                        SaveScreenshot();
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
                }
            }
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
                MapEditor.UpdateMapProperties();
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
                Map.RemoveLayer(CbLayer.SelectedIndex);
                MapRenderer.SetSingleLayerToRender(CbLayer.SelectedIndex - 1);
                Refresh();
                UpdateLayerComboBox();
                UpdateStatusLabel();
                MapEditor.UpdateMapProperties();
            }
            else
            {
                Alert.Warning("Cannot remove layer 0");
            }
        }

        private void BtnViewAll_Click(object sender, EventArgs e)
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
            ColorPickerWindow win = new ColorPickerWindow(MapEditor, "Select map background");

            if (win.ShowDialog(this) == DialogResult.OK)
                Map.BackColor = win.SelectedColor;
        }
    }
}
