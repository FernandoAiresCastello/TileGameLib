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
using TileGameMaker.TiledDisplays;
using TileGameMaker.Util;

namespace TileGameMaker.Windows
{
    public partial class TileEditor16x16Window : BaseWindow
    {
        private int TileIndexTL = 0;
        private int TileIndexTR = 0;
        private int TileIndexBL = 0;
        private int TileIndexBR = 0;

        private TilePixels OriginalPixelsTL;
        private TilePixels OriginalPixelsTR;
        private TilePixels OriginalPixelsBL;
        private TilePixels OriginalPixelsBR;

        private readonly TileEditor16x16Display TileEditor;
        private readonly Tileset Tileset;

        private readonly int PixelOn = Config.ReadInt("TileEditorPixelOnValue");
        private readonly int PixelOff = Config.ReadInt("TileEditorPixelOffValue");

        public TileEditor16x16Window(Tileset tileset)
        {
            InitializeComponent();
            Tileset = tileset;

            TileEditor = new TileEditor16x16Display(TilePanel, Config.ReadInt("TileEditorZoom"));

            TileEditor.ShowGrid = true;
            TileEditor.MouseMove += TileEditor_MouseMove;
            TileEditor.MouseDown += TileEditor_MouseDown;
        }

        public void SetTiles(int indexTL, int indexTR, int indexBL, int indexBR)
        {
            TileIndexTL = indexTL;
            TileIndexBL = indexBL;
            TileIndexTR = indexTR;
            TileIndexBR = indexBR;

            TileEditor.SetTiles(Tileset, indexTL, indexTR, indexBL, indexBR);

            OriginalPixelsTL = new TilePixels(Tileset.Get(indexTL));
            OriginalPixelsTR = new TilePixels(Tileset.Get(indexTR));
            OriginalPixelsBL = new TilePixels(Tileset.Get(indexBL));
            OriginalPixelsBR = new TilePixels(Tileset.Get(indexBR));
        }

        private void TileEditor_MouseDown(object sender, MouseEventArgs e)
        {
            Point p = TileEditor.GetMouseToCellPos(e.Location);

            if (e.Button == MouseButtons.Left)
            {
                TileEditor.SetTilePixel(p.X, p.Y, PixelOn);
            }
            else if (e.Button == MouseButtons.Right)
            {
                TileEditor.SetTilePixel(p.X, p.Y, PixelOff);
            }

            OnTileChanged();
        }

        private void TileEditor_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                TileEditor_MouseDown(sender, e);
            }
        }

        private void OnTileChanged()
        {
            RefreshSubscribed();
        }

        private void Undo()
        {
            TileEditor.SetTilePixels(OriginalPixelsTL, OriginalPixelsTR, OriginalPixelsBL, OriginalPixelsBR);
            OnTileChanged();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Undo();
            Close();
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            TileEditor.ClearTiles();
            OnTileChanged();
        }

        private void BtnInvert_Click(object sender, EventArgs e)
        {
            TileEditor.InvertTiles();
            OnTileChanged();
        }
    }
}
