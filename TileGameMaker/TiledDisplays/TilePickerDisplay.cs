using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Components;
using TileGameLib.Graphics;

namespace TileGameMaker.TiledDisplays
{
    public class TilePickerDisplay : TiledDisplay
    {
        public int TileIndex { set; get; }

        private const int TilesPerRow = 8;
        private const int TilePickerZoom = 3;

        public TilePickerDisplay(Control parent, Tileset tileset) 
            : base(parent, 1, 1, TilePickerZoom)
        {
            ResizeGraphicsByTileCount(tileset.Size, TilesPerRow);

            TileIndex = 0;
            Graphics.Tileset = tileset;
            Graphics.Palette.Set(0, SystemColors.WindowText);
            Graphics.Palette.Set(1, SystemColors.Window);
            Graphics.Palette.Set(2, SystemColors.HighlightText);
            Graphics.Palette.Set(3, SystemColors.Highlight);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawTiles(true);
            base.OnPaint(e);
        }

        public void DrawTiles(bool drawCursor)
        {
            int x = 0;
            int y = 0;

            for (int i = 0; i < TileCount; i++)
            {
                int fgc = 0;
                int bgc = 1;
                int selectedFgc = 2;
                int selectedBgc = 3;

                if (i < Graphics.Tileset.Size)
                {
                    if (i == TileIndex && drawCursor)
                        Graphics.PutTile(x, y, i, selectedFgc, selectedBgc);
                    else
                        Graphics.PutTile(x, y, i, fgc, bgc);
                }
                else
                {
                    Graphics.PutTile(x, y, 0, bgc, bgc);
                }

                x++;

                if (x >= Graphics.Cols)
                {
                    x = 0;
                    y++;
                }

                if (x >= Graphics.Cols || y >= Graphics.Rows)
                    break;
            }
        }

        public void SelectTileIndex(int tileIx)
        {
            TileIndex = tileIx;
            Refresh();
        }

        public int GetTileIndexAtMousePos(Point mousePos)
        {
            Point p = GetMouseToCellPos(mousePos);
            Tile tile = Graphics.GetTile(p.X, p.Y);
            return tile.Index;
        }

        public void Clear()
        {
            Graphics.Tileset.Clear();
            TileIndex = 0;
            Refresh();
        }

        public void ClearRange(int first, int last)
        {
            Graphics.Tileset.ClearRange(first, last);
            Refresh();
        }

        public void ResetToDefault()
        {
            Graphics.Tileset.InitDefault();
            TileIndex = 0;
            Refresh();
        }

        public void Add8Tiles()
        {
            Graphics.Tileset.AddBlank(8);
            ResizeGraphics(Cols, Rows + 1);
            Refresh();
        }
    }
}
