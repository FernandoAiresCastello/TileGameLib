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
using TileGameLib.Graphics;
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

        public MapWindow(MapEditor editor, ObjectMap map)
        {
            InitializeComponent();
            InfoPanel.Hide();
            MapEditor = editor;
            Map = map;
            Disp = new Display(MapPanel, map.Width, map.Height, 3);
            Disp.BorderStyle = BorderStyle.None;
            MapRenderer = new MapRenderer(Map, Disp, 256);
            MapRenderer.AnimationEnabled = false;
            Disp.ShowGrid = true;
            Disp.MouseMove += Display_MouseMove;
            Disp.MouseDown += Disp_MouseDown;
            Disp.MouseMove += Disp_MouseMove;
            Disp.MouseLeave += Disp_MouseLeave;
            Text = Map.Name;
            HoverLabel.Text = "";
            UpdateStatusLabel();
            FillBlankMap();
            ClipboardObject = new GameObject(new Tile(0, 0, 63));
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

        private void FillBlankMap()
        {
            Map.Fill(new GameObject(new Tile(0, 0, 63)));
            RenderMap();
        }

        private void FillTestMap()
        {
            GameObject o = new GameObject(new Tile('|', 0, 63));
            o.Animation.AddFrame(new Tile('-', 0, 63));
            o.Animation.AddFrame(new Tile('+', 63, 0));
            for (int y = 0; y < Map.Height; y++)
                for (int x = 0; x < Map.Width; x++)
                    Map.SetObject(o, 0, x, y);

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

            if (o != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    PutCurrentObject(o);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    ContextMenuCell = point;
                    TxtContextMenuCell.Text = point.X + ", " + point.Y;
                    ContextMenu.Show(MousePosition, ToolStripDropDownDirection.Default);
                }
            }
        }

        private void PutCurrentObject(GameObject o)
        {
            o.Animation.Clear();
            o.Animation.GetFrame(0).SetEqual(MapEditor.GetSelectedTile());
            RenderMap();
        }

        private void ShowObjectProperties(GameObject o, Point pos)
        {
            GameObject objCopy = o.Copy();
            MapEditor.PropertyWindow.Object = objCopy;
            MapEditor.PropertyWindow.Position = pos;

            if (MapEditor.PropertyWindow.ShowDialog(this) == DialogResult.OK)
                Map.SetObject(objCopy, 0, pos.X, pos.Y);
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

        private void BtnNew_Click(object sender, EventArgs e)
        {
            Map.Fill(new GameObject(new Tile(0, 0, Disp.Graphics.Palette.Size - 1)));
            RenderMap();
        }

        private void BtnScreenshot_Click(object sender, EventArgs e)
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
            Disp.ShowGrid = !Disp.ShowGrid;
            Refresh();
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
            Disp.ZoomIn();
            UpdateStatusLabel();
        }

        private void BtnZoomOut_Click(object sender, EventArgs e)
        {
            Disp.ZoomOut();
            UpdateStatusLabel();
        }

        private void BtnInfo_Click(object sender, EventArgs e)
        {
            if (InfoPanel.Visible)
                InfoPanel.Hide();
            else
                InfoPanel.Show();
        }

        private void CtxBtnSetProperties_Click(object sender, EventArgs e)
        {
            GameObject o = Map.GetObject(0, ContextMenuCell.X, ContextMenuCell.Y);
            if (o != null)
                ShowObjectProperties(o, ContextMenuCell);
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
            ContextMenu.Close();
        }

        private void CtxBtnCopy_Click(object sender, EventArgs e)
        {
            GameObject o = Map.GetObject(0, ContextMenuCell.X, ContextMenuCell.Y);
            if (o != null)
                ClipboardObject.SetEqual(o);
        }

        private void CtxBtnPaste_Click(object sender, EventArgs e)
        {
            GameObject o = Map.GetObject(0, ContextMenuCell.X, ContextMenuCell.Y);
            if (o != null)
            {
                o.SetEqual(ClipboardObject);
                Refresh();
            }
        }
    }
}
