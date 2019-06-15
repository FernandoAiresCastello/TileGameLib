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
    public class ColorPickerDisplay : TiledDisplay
    {
        public int ForeColorIx { set; get; }
        public int BackColorIx { set; get; }

        private readonly int SwatchTileIx = 0xdb;

        public ColorPickerDisplay(Control parent, int cols, int rows, int zoom)
            : base(parent, cols, rows, zoom)
        {
            ForeColorIx = 0;
            BackColorIx = Graphics.Palette.Size - 1;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int x = 0;
            int y = 0;

            for (int i = 0; i < Graphics.Palette.Size; i++)
            {
                Graphics.PutTile(x, y, SwatchTileIx, i, 0);
                x++;
                if (x >= Graphics.Cols)
                {
                    x = 0;
                    y++;
                }
            }

            base.OnPaint(e);
        }

        public int GetColorIndexAtMousePos(Point mousePos)
        {
            Point p = GetMouseToCellPos(mousePos);
            Tile tile = Graphics.GetTile(p.X, p.Y);
            return tile.ForeColorIx;
        }

        public int GetColor(int index)
        {
            return Graphics.Palette.Colors[index];
        }

        public void SetColor(int index, int color)
        {
            Graphics.Palette.Colors[index] = color;
        }

        public void SetColor(int index, Color color)
        {
            Color opaqueColor = Color.FromArgb(255, color);
            SetColor(index, opaqueColor.ToArgb());
        }

        public Color GetForeColor()
        {
            return Color.FromArgb(Graphics.Palette.Colors[ForeColorIx]);
        }

        public Color GetBackColor()
        {
            return Color.FromArgb(Graphics.Palette.Colors[BackColorIx]);
        }

        internal void Clear()
        {
            Graphics.Palette.Clear();
            ForeColorIx = 0;
            BackColorIx = Graphics.Palette.Size - 1;
            Refresh();
        }
    }
}
