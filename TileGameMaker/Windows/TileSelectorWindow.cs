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
using TileGameMaker.MapEditorElements;
using TileGameMaker.TiledDisplays;

namespace TileGameMaker.Windows
{
    public partial class TileSelectorWindow : BaseWindow
    {
        public Tile Tile => new Tile(
            TilesetDisplay.TileIndex, 
            PaletteDisplay.SelectedForeColor, 
            PaletteDisplay.SelectedBackColor);

        private MapEditor Editor;
        private TilePickerDisplay TilesetDisplay;
        private ColorPickerDisplay PaletteDisplay;

        private TileSelectorWindow()
        {
        }

        public TileSelectorWindow(MapEditor editor, Tile initialTile)
        {
            InitializeComponent();
            Editor = editor;
            KeyPreview = true;

            TilesetDisplay = new TilePickerDisplay(TilesetPanel, editor.Tileset, 8);
            TilesetDisplay.ShowGrid = true;

            PaletteDisplay = new ColorPickerDisplay(PalettePanel, 8, 8, 3);
            PaletteDisplay.ResizeGraphicsByTileCount(PaletteDisplay.Graphics.Palette.Size, 8);
            PaletteDisplay.ShowGrid = true;

            TilesetDisplay.MouseDown += TileDisplay_MouseDown;
            TilesetDisplay.MouseDoubleClick += TilesetDisplay_MouseDoubleClick;
            PaletteDisplay.MouseDown += PaletteDisplay_MouseDown;
            PaletteDisplay.MouseDoubleClick += PaletteDisplay_MouseDoubleClick;

            KeyDown += TileSelectorWindow_KeyDown;

            if (initialTile != null)
            {
                TilesetDisplay.TileIndex = initialTile.Index;
                PaletteDisplay.SelectedForeColor = initialTile.ForeColor;
                PaletteDisplay.SelectedBackColor = initialTile.BackColor;
            }
        }

        private void PaletteDisplay_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void TilesetDisplay_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void TileSelectorWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
                DialogResult = DialogResult.OK;
        }

        private void PaletteDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            int color = PaletteDisplay.GetMouseToCellIndex(e.Location);

            if (e.Button == MouseButtons.Left)
                PaletteDisplay.SelectedForeColor = color;
            else if (e.Button == MouseButtons.Right)
                PaletteDisplay.SelectedBackColor = color;

            Refresh();
        }

        private void TileDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            int index = TilesetDisplay.GetMouseToCellIndex(e.Location);
            TilesetDisplay.TileIndex = index;
            Refresh();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
