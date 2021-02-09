using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Components;
using TileGameLib.GameElements;
using TileGameLib.Util;
using TileGameMaker.MapEditorElements;
using TileGameMaker.Panels;

namespace TileGameMaker.Windows
{
    public partial class SearchWindow : Form
    {
        private MapEditor MapEditor;
        private MapEditorPanel MapEditorPanel;
        private TiledDisplay Display;
        private List<ObjectPosition> SelectedObjects = new List<ObjectPosition>();

        public SearchWindow(MapEditor editor, MapEditorPanel editorPanel, TiledDisplay display)
        {
            MapEditor = editor;
            MapEditorPanel = editorPanel;
            Display = display;
            InitializeComponent();
            KeyPreview = true;
            KeyDown += SearchWindow_KeyDown;
        }

        private void SearchWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                Close();
            }
        }

        private void BtnTileIndex_Click(object sender, EventArgs e)
        {
            Form window = new Form();
            window.Text = "Tileset";
            window.Size = new Size(619, 626);
            window.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            window.StartPosition = FormStartPosition.CenterScreen;

            Panel panel = new Panel();
            panel.Dock = DockStyle.Fill;
            panel.Parent = window;

            TilePickerPanel poppedOutPicker = new TilePickerPanel(MapEditor, 24);
            poppedOutPicker.PopOutAllowed = false;
            poppedOutPicker.CloseOnTileSelected = true;
            poppedOutPicker.Dock = DockStyle.Fill;
            poppedOutPicker.Parent = panel;
            poppedOutPicker.HideToolStrip = true;

            window.ShowDialog(this);

            TxtTileIndex.Text = poppedOutPicker.SelectedTile.ToString();
        }

        private void BtnTileForeColor_Click(object sender, EventArgs e)
        {
            ColorPickerWindow window = new ColorPickerWindow(MapEditor, "Select a color");
            window.ShowDialog(this);
            TxtTileForeColor.Text = window.SelectedColor.ToString();
        }

        private void BtnTileBackColor_Click(object sender, EventArgs e)
        {
            ColorPickerWindow window = new ColorPickerWindow(MapEditor, "Select a color");
            window.ShowDialog(this);
            TxtTileBackColor.Text = window.SelectedColor.ToString();
        }

        private void BtnClearTileIndex_Click(object sender, EventArgs e)
        {
            TxtTileIndex.Text = "";
        }

        private void BtnClearTileForeColor_Click(object sender, EventArgs e)
        {
            TxtTileForeColor.Text = "";
        }

        private void BtnClearTileBackColor_Click(object sender, EventArgs e)
        {
            TxtTileBackColor.Text = "";
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            SelectObjects();
        }

        private void SelectObjects()
        {
            bool compareTileIndex = true;
            bool compareTileForeColor = true;
            bool compareTileBackColor = true;
            bool compareProperties = true;

            GameObject o = new GameObject();
            o.Visible = ChkVisible.Checked;

            if (!string.IsNullOrWhiteSpace(TxtTileIndex.Text))
                o.Tile.Index = int.Parse(TxtTileIndex.Text);
            else
                compareTileIndex = false;

            if (!string.IsNullOrWhiteSpace(TxtTileForeColor.Text))
                o.Tile.ForeColor = int.Parse(TxtTileForeColor.Text);
            else
                compareTileForeColor = false;

            if (!string.IsNullOrWhiteSpace(TxtTileBackColor.Text))
                o.Tile.BackColor = int.Parse(TxtTileBackColor.Text);
            else
                compareTileBackColor = false;

            if (!string.IsNullOrWhiteSpace(TxtProperties.Text))
            {
                string[] props = TxtProperties.Text.Trim().Split(';');

                foreach (string prop in props)
                {
                    string[] propValue = prop.Trim().Split('=');
                    o.Properties.Set(propValue[0].Trim(), propValue[1].Trim());
                }
            }
            else
                compareProperties = false;

            List<Point> pos = new List<Point>();
            List<PositionedObject> objects = MapEditor.Map.FindObjectsPartiallyEqual(
                o, compareTileIndex, compareTileForeColor, compareTileBackColor, compareProperties);

            foreach (PositionedObject po in objects)
            {
                pos.Add(po.Position.Point);
                SelectedObjects.Add(po.Position);
            }

            Display.SelectTiles(pos, true);
            Display.Refresh();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            foreach (ObjectPosition pos in SelectedObjects)
            {
                MapEditor.Map.DeleteObject(pos);
            }

            Display.Refresh();
        }

        private void BtnDeselectAll_Click(object sender, EventArgs e)
        {
            SelectedObjects.Clear();
            Display.DeselectAllTiles();
        }

        private void BtnOverrideColors_Click(object sender, EventArgs e)
        {
            MapEditorPanel.OverrideObjectColors(SelectedObjects);
        }

        private void BtnReplace_Click(object sender, EventArgs e)
        {
            MapEditorPanel.ReplaceObjectsWithTemplate(SelectedObjects);
        }

        private void BtnOverrideTileIndex_Click(object sender, EventArgs e)
        {
            MapEditorPanel.OverrideObjectTileIndex(SelectedObjects);
        }
    }
}
