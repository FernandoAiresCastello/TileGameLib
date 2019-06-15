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
using TileGameLib.Core;
using TileGameLib.File;
using TileGameLib.Graphics;
using TileGameLib.Util;
using TileGameMaker.Windows;
using TileGameLib.Components;

namespace TileGameMaker.Panels
{
    public partial class MapEditorPanel : BasePanel
    {
        public TiledDisplay Display { get; private set; }

        private readonly int DefaultZoom = 3;
        private readonly int DefaultAnimationInterval = 256;

        private ObjectMap Map;
        private MapEditor MapEditor;
        private MapRenderer MapRenderer;
        private MapArchive Archive;
        private int Layer;

        private enum EditMode { Template, TextInput }
        private EditMode Mode = EditMode.Template;

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
            MapRenderer = new MapRenderer(Map, Display, DefaultAnimationInterval);
            Archive = new MapArchive(MapEditor.ArchiveFile);
            HoverLabel.Text = "";
            Layer = 0;

            Display.MouseMove += Disp_MouseMove;
            Display.MouseDown += Disp_MouseDown;
            Display.MouseLeave += Disp_MouseLeave;

            ClearMap();
            Refresh();
        }

        public void ResizeMapView(int width, int height)
        {
            Display.ResizeGraphics(width, height);
        }

        private void UpdateStatusLabel()
        {
            StatusLabel.Text =
                string.Format("Size: {0}x{1} Layer: {2}/{3} Zoom: {4}",
                    Map.Width, Map.Height, Layer, Map.Layers.Count, Display.Zoom);
        }

        private void ClearMap()
        {
            Map.Clear();
            RenderMap();
        }

        private void Disp_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.None)
                OnDisplayMouseMove(e);
            else if (e.Button == MouseButtons.Left)
                OnDisplayMouseClick(e);
        }

        private void Disp_MouseDown(object sender, MouseEventArgs e)
        {
            OnDisplayMouseClick(e);
        }

        private void OnDisplayMouseMove(MouseEventArgs e)
        {
            Point point = Display.GetMouseToCellPos(e.Location);
            if (IsOutOfBounds(point))
                return;

            GameObject o = Map.GetObject(Layer, point.X, point.Y);

            if (o != null)
                HoverLabel.Text = "X: " + point.X + " Y: " + point.Y + " - " + o;
            else
                HoverLabel.Text = "";
        }

        private void OnDisplayMouseClick(MouseEventArgs e)
        {
            Point point = Display.GetMouseToCellPos(e.Location);
            if (IsOutOfBounds(point))
                return;

            Focus();

            GameObject o = Map.GetObject(Layer, point.X, point.Y);

            if (Mode == EditMode.Template)
            {
                if (e.Button == MouseButtons.Left)
                {
                    PutCurrentObject(o);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    CopyObjectToTemplate(o);
                }
            }
            else if (Mode == EditMode.TextInput && e.Button == MouseButtons.Left)
            {
                InputText(point.X, point.Y);
            }
        }

        private void PutCurrentObject(GameObject o)
        {
            o.SetEqual(MapEditor.SelectedObject);
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

        private void CopyObjectToTemplate(GameObject o)
        {
            MapEditor.SelectedObject = o;
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ConfirmClearMap();
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
                DefaultExt = "png"
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
            ToggleTextMode();
        }

        private void ToggleTextMode()
        {
            if (Mode == EditMode.Template)
                Mode = EditMode.TextInput;
            else if (Mode == EditMode.TextInput)
                Mode = EditMode.Template;

            BtnAddText.Checked = Mode == EditMode.TextInput;
        }

        private void InputText(int x, int y)
        {
            TextInputWindow win = new TextInputWindow();
            if (win.ShowDialog(this) == DialogResult.Cancel)
                return;

            string[] lines = win.String.Replace("\r", "").Split('\n');

            foreach (string line in lines)
            {
                int px = x;
                foreach (char ch in line)
                {
                    Tile tile = MapEditor.SelectedTile;
                    tile.TileIx = ch;
                    GameObject o = new GameObject(win.Type, win.Param, "", tile);
                    Map.SetObject(o, Layer, x++, y);
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

        private void SaveMap()
        {
            ArchiveWindow mgr = new ArchiveWindow(MapEditor.ArchiveFile);

            if (mgr.ShowDialog(this, ArchiveWindow.Mode.Save) == DialogResult.OK)
            {
                string entry = mgr.SelectedEntry;
                if (mgr.Contains(entry) && !Alert.Confirm($"File \"{entry}\" already exists. Overwrite?"))
                    return;

                Map.Name = MapEditor.MapPropertyControl.MapName;
                Archive.Save(Map, mgr.SelectedEntry);
                MapEditor.UpdateMapProperties(mgr.SelectedEntry);
                Refresh();
                Alert.Info("File saved successfully!");
            }
        }

        private void LoadMap()
        {
            ArchiveWindow mgr = new ArchiveWindow(MapEditor.ArchiveFile);

            if (mgr.ShowDialog(this, ArchiveWindow.Mode.Load) == DialogResult.OK)
            {
                string entry = mgr.SelectedEntry;

                if (!mgr.Contains(entry))
                {
                    Alert.Warning($"File \"{entry}\" not found");
                    return;
                }

                Archive.Load(ref Map, mgr.SelectedEntry);
                MapEditor.UpdateMapProperties(mgr.SelectedEntry);
                MapEditor.Resize(Map.Width, Map.Height);
                MapEditor.SelectedObject = new GameObject();
                Alert.Info("File loaded successfully!");
            }
        }

        private void ConfirmClearMap()
        {
            if (Alert.Confirm("Clear map?"))
                ClearMap();
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
                        ConfirmClearMap();
                        break;
                    case Keys.G:
                        ToggleGrid();
                        break;
                    case Keys.T:
                        ToggleTextMode();
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
    }
}
