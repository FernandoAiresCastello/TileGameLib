using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Graphics;
using TileGameMaker.Component;

namespace TileGameMaker.Component
{
    public class TilePicker : Display
    {
        public int TileIndex { set; get; }

        public TilePicker(Control parent, int cols, int rows, int zoom)
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

            for (int i = 0; i < Graphics.Tileset.Size; i++)
            {
                int fgc = 0;
                int bgc = 1;
                int selectedFgc = 2;
                int selectedBgc = 3;

                if (i == TileIndex)
                    Graphics.DrawTile(x, y, i, selectedFgc, selectedBgc);
                else
                    Graphics.DrawTile(x, y, i, fgc, bgc);

                x++;
                if (x >= Graphics.Cols)
                {
                    x = 0;
                    y++;
                }
            }

            base.OnPaint(e);
        }

        internal void SelectTiileIndex(int tileIx)
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
    }
}
