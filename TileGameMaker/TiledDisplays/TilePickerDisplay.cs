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

        public TilePickerDisplay(Control parent, int zoom) 
            : this(parent, 1, 1, zoom)
        {
        }

        public TilePickerDisplay(Control parent, int cols, int rows, int zoom)
            : base(parent, cols, rows, zoom)
        {
            TileIndex = 0;
            Graphics.Palette.Set(0, SystemColors.WindowText);
            Graphics.Palette.Set(1, SystemColors.Window);
            Graphics.Palette.Set(2, SystemColors.HighlightText);
            Graphics.Palette.Set(3, SystemColors.Highlight);
        }

        protected override void OnPaint(PaintEventArgs e)
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
                    if (i == TileIndex)
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

            base.OnPaint(e);
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
            return tile.TileIx;
        }

        public void Clear()
        {
            Graphics.Tileset.Clear();
            TileIndex = 0;
            Refresh();
        }

        public void ResetToDefault()
        {
            Graphics.Tileset.InitDefault();
            TileIndex = 0;
            Refresh();
        }
    }
}
