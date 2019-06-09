using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Core;
using TileGameLib.File;
using TileGameLib.Graphics;
using TileGameLib.Util;
using TileGameMaker.Component;
using TileGameMaker.Modules;

namespace TileGameMaker.Component
{
    public partial class MapWindow : BaseWindow
    {
        private MapEditor MapEditor;
        private Display Disp;
        private ObjectMap Map;
        private MapRenderer MapRenderer;
        private Point ContextMenuCell;
        private GameObject ClipboardObject;

        private enum EditMode { Template, TextInput }
        private EditMode Mode = EditMode.Template;

        public MapWindow(MapEditor editor, ObjectMap map)
        {
            InitializeComponent();
            InfoPanel.Hide();
            MapEditor = editor;
            Map = map;
            Disp = new Display(MapPanel, map.Width, map.Height, 3);
            Disp.BorderStyle = BorderStyle.None;
            MapRenderer = new MapRenderer(Map, Disp, 256);
            Disp.ShowGrid = true;
            Disp.MouseMove += Display_MouseMove;
            Disp.MouseDown += Disp_MouseDown;
            Disp.MouseMove += Disp_MouseMove;
            Disp.MouseLeave += Disp_MouseLeave;
            Text = Map.Name;
            HoverLabel.Text = "";
            UpdateStatusLabel();
            ClipboardObject = new GameObject(new Tile(0, 0, 63));
            ClearMap();
        }

        public void SetMap(ObjectMap map)
        {
            Map = map;
            MapRenderer.Map = map;
            Disp.ResizeGraphics(map.Width, map.Height);
        }

        private void UpdateStatusLabel()
        {
            StatusLabel.Text =
                "Size: " + Map.Width + " x " + Map.Height + " " +
                "Zoom: " + Disp.GetZoom();
        }

        private void ClearMap()
        {
            Map.Fill(new GameObject(new Tile(0, 0, Disp.Graphics.Palette.Size - 1)));
            RenderMap();
        }

        private void Disp_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Disp_MouseDown(sender, e);
        }

        private void Disp_MouseDown(object sender, MouseEventArgs e)
        {
            Point point = Disp.GetMouseToCellPos(e.Location);
            GameObject o = Map.GetObject(0, point.X, point.Y);
            if (o == null)
                return;

            if (Mode == EditMode.Template)
            {
                if (e.Button == MouseButtons.Left)
                {
                    PutCurrentObject(o);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    ContextMenuCell = point;
                    TxtContextMenuCell.Text = point.X + ", " + point.Y;
                    CopyObjectToTemplate(o);
                }
            }
            else if (Mode == EditMode.TextInput)
            {
                if (e.Button == MouseButtons.Left)
                    InputText(point.X, point.Y);
            }
        }

        private void PutCurrentObject(GameObject o)
        {
            o.SetEqual(MapEditor.GetSelectedObject());
            RenderMap();
        }
        private void Display_MouseMove(object sender, MouseEventArgs e)
        {
            Point point = Disp.GetMouseToCellPos(e.Location);
            GameObject o = Map.GetObject(0, point.X, point.Y);

            if (o != null)
                HoverLabel.Text = "X: " + point.X + " Y: " + point.Y + " - " + o;
            else
                HoverLabel.Text = "";
        }

        private void Disp_MouseLeave(object sender, EventArgs e)
        {
            HoverLabel.Text = "";
        }

        public override void Refresh()
        {
            MapRenderer.Render();
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
            Disp.ZoomIn();
            UpdateStatusLabel();
        }

        private void ZoomOut()
        {
            Disp.ZoomOut();
            UpdateStatusLabel();
        }

        private void BtnInfo_Click(object sender, EventArgs e)
        {
            ToggleInfo();
        }

        private void ToggleInfo()
        {
            if (InfoPanel.Visible)
                InfoPanel.Hide();
            else
                InfoPanel.Show();
        }

        private void CtxBtnDelete_Click(object sender, EventArgs e)
        {
            GameObject o = Map.GetObject(0, ContextMenuCell.X, ContextMenuCell.Y);
            if (o != null)
            {
                o.SetEqual(new GameObject(new Tile(0, 0, 63)));
                Refresh();
            }
        }

        private void CtxBtnCancel_Click(object sender, EventArgs e)
        {
            CtxMenu.Close();
        }

        private void CtxBtnCopy_Click(object sender, EventArgs e)
        {
            GameObject o = Map.GetObject(0, ContextMenuCell.X, ContextMenuCell.Y);

            if (o != null)
                CopyObjectToTemplate(o);
        }

        private void CtxBtnPaste_Click(object sender, EventArgs e)
        {
            GameObject o = Map.GetObject(0, ContextMenuCell.X, ContextMenuCell.Y);

            if (o != null)
            {
                o.SetEqual(MapEditor.TemplateWindow.Object);
                Refresh();
            }
        }

        private void CopyObjectToTemplate(GameObject o)
        {
            MapEditor.TemplateWindow.Object.SetEqual(o);
            MapEditor.TemplateWindow.UpdateAnimation(o.Animation);
            MapEditor.TemplateWindow.Refresh();
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
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save map image";
            dialog.AddExtension = true;
            dialog.DefaultExt = "png";

            if (dialog.ShowDialog() == DialogResult.OK)
                Disp.Graphics.SaveScreenshot(dialog.FileName);
        }

        private void BtnGrid_Click(object sender, EventArgs e)
        {
            ToggleGrid();
        }

        private void ToggleGrid()
        {
            Disp.ShowGrid = !Disp.ShowGrid;
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

            string[] lines = win.GetText().Replace("\r", "").Split('\n');

            foreach (string line in lines)
            {
                int px = x;
                foreach (char ch in line)
                {
                    Tile tile = MapEditor.GetSelectedTile();
                    tile.TileIx = ch;
                    GameObject o = new GameObject(tile);
                    Map.SetObject(o, 0, x++, y);
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
            ArchiveManager mgr = new ArchiveManager(MapEditor.ArchiveFile);

            if (mgr.ShowDialog(this, ArchiveManager.Mode.Save) == DialogResult.OK)
            {
                string entry = mgr.SelectedEntry;

                if (mgr.Contains(entry) && !Alert.Confirm($"File \"{entry}\" already exists. Overwrite?"))
                    return;

                ObjectMapFile file = new ObjectMapFile(Map, MapEditor.ArchiveFile, mgr.SelectedEntry);
                file.Save();
                DialogResult = DialogResult.OK;
                Alert.Info("File saved successfully!");
            }
        }

        private void LoadMap()
        {
            ArchiveManager mgr = new ArchiveManager(MapEditor.ArchiveFile);

            if (mgr.ShowDialog(this, ArchiveManager.Mode.Load) == DialogResult.OK)
            {
                string entry = mgr.SelectedEntry;

                if (!mgr.Contains(entry))
                {
                    Alert.Warning($"File \"{entry}\" not found");
                    return;
                }

                Alert.Error("Not implemented");
            }
        }

        private void ConfirmClearMap()
        {
            if (Alert.Confirm("Clear map?"))
                ClearMap();
        }

        private void MapWindow_KeyDown(object sender, KeyEventArgs e)
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
                    case Keys.I:
                        ToggleInfo();
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
