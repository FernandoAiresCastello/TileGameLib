using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Graphics;
using TileGameMaker.Modules;

namespace TileGameMaker.Component
{
    public partial class TilePickerWindow : Form
    {
        private MapEditor MapEditor;
        private TilePicker TilePicker;
        private TileEditorWindow TileEditorWindow;

        public TilePickerWindow(MapEditor editor, Tileset tileset)
        {
            InitializeComponent();
            MapEditor = editor;
            TilePicker = new TilePicker(TilePickerPanel, 8, 64, 3);
            TilePicker.Graphics.Tileset = tileset;
            TilePicker.ShowGrid = true;
            TilePicker.MouseMove += TilePicker_MouseMove;
            TilePicker.MouseLeave += TilePicker_MouseLeave;
            TilePicker.MouseDown += TilePicker_MouseDown;
            TilePicker.MouseDoubleClick += TilePicker_MouseDoubleClick;
            TileEditorWindow = new TileEditorWindow(tileset);
            TileEditorWindow.Subscribe(this);
            TileEditorWindow.Subscribe(TilePicker);
            TileEditorWindow.Subscribe(editor.MapWindow);
            TileEditorWindow.Subscribe(editor.TemplateWindow);
            SetHoverStatus("");
            UpdateStatus();
        }

        public void SetTileIndex(int index)
        {
            TilePicker.TileIndex = index;
            UpdateStatus();
            Refresh();
        }

        public int GetTileIndex()
        {
            return TilePicker.TileIndex;
        }

        private void TilePicker_MouseDown(object sender, MouseEventArgs e)
        {
            int tileIx = TilePicker.GetTileIndexAtMousePos(e.Location);
            if (tileIx < 0 || tileIx >= TilePicker.Graphics.Tileset.Size)
                return;

            if (e.Button == MouseButtons.Left)
            {
                TilePicker.SelectTiileIndex(tileIx);
                UpdateStatus();
            }
        }

        private void TilePicker_MouseMove(object sender, MouseEventArgs e)
        {
            int tileIx = TilePicker.GetTileIndexAtMousePos(e.Location);
            if (tileIx >= 0 && tileIx < TilePicker.Graphics.Tileset.Size)
            {
                SetHoverStatus("IX: " + tileIx);
            }
            else
            {
                SetHoverStatus("");
            }
        }

        private void TilePicker_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int tileIx = TilePicker.GetTileIndexAtMousePos(e.Location);
            TileEditorWindow.SetTile(tileIx);
            TileEditorWindow.Location = new Point(Location.X, Location.Y + 50);
            TileEditorWindow.ShowDialog(this);
        }

        private void TilePicker_MouseLeave(object sender, EventArgs e)
        {
            SetHoverStatus("");
        }

        private void UpdateStatus()
        {
            StatusLabel.Text = "SEL: " + TilePicker.TileIndex;
        }

        private void SetHoverStatus(string status)
        {
            HoverLabel.Text = status;
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            TilePicker.Clear();
            UpdateStatus();
        }
    }
}
