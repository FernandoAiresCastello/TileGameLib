using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Components;
using TileGameLib.Graphics;
using TileGameMaker.Util;

namespace TileGameMaker.TiledDisplays
{
    public class ColorPickerDisplay : TiledDisplay
    {
        public int ForeColorIx { set; get; }
        public int BackColorIx { set; get; }

        private readonly int SwatchTileIx = Config.ReadInt("ColorPickerSwatchTile");
        private readonly int SelectedForeColorSwatchTile = Config.ReadInt("ColorPickerSelectedForeColorSwatchTile");
        private readonly int SelectedBackColorSwatchTile = Config.ReadInt("ColorPickerSelectedBackColorSwatchTile");
        private readonly int SelectedBothColorsEqualSwatchTile = Config.ReadInt("ColorPickerSelectedBothColorsEqualSwatchTile");

        public ColorPickerDisplay(Control parent, int cols, int rows, int zoom)
            : base(parent, cols, rows, zoom)
        {
            ForeColorIx = Config.ReadInt("DefaultTileForeColor");
            BackColorIx = Config.ReadInt("DefaultTileBackColor");
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int x = 0;
            int y = 0;

            int black = Graphics.Palette.Black;
            int white = Graphics.Palette.White;

            for (int i = 0; i < Graphics.Palette.Size; i++)
            {
                if (i < Graphics.Palette.Size)
                {
                    int selectionIndicatorColor = Graphics.Palette.GetBrightness(i) > 0.5 ? black : white;

                    if (i == ForeColorIx && i == BackColorIx)
                        Graphics.PutTile(x, y, SelectedBothColorsEqualSwatchTile, selectionIndicatorColor, i);
                    else if (i == ForeColorIx)
                        Graphics.PutTile(x, y, SelectedForeColorSwatchTile, selectionIndicatorColor, i);
                    else if (i == BackColorIx)
                        Graphics.PutTile(x, y, SelectedBackColorSwatchTile, selectionIndicatorColor, i);
                    else
                        Graphics.PutTile(x, y, SwatchTileIx, i, i);

                    x++;

                    if (x >= Graphics.Cols)
                    {
                        x = 0;
                        y++;
                    }
                }
                else
                {
                    Graphics.PutTile(x, y, 0, Graphics.Palette.White, Graphics.Palette.White);
                }
            }

            base.OnPaint(e);
        }

        public int GetForeColorIndexAtMousePos(Point mousePos)
        {
            Point p = GetMouseToCellPos(mousePos);
            Tile tile = Graphics.GetTile(p.X, p.Y);
            return tile.ForeColor;
        }

        public int GetBackColorIndexAtMousePos(Point mousePos)
        {
            Point p = GetMouseToCellPos(mousePos);
            Tile tile = Graphics.GetTile(p.X, p.Y);
            return tile.BackColor;
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

        public void Clear()
        {
            Graphics.Palette.Clear();
            ForeColorIx = Config.ReadInt("DefaultTileForeColor");
            BackColorIx = Config.ReadInt("DefaultTileBackColor");
            Refresh();
        }

        public void ResetToDefault()
        {
            Graphics.Palette.InitDefault();
            ForeColorIx = Config.ReadInt("DefaultTileForeColor");
            BackColorIx = Config.ReadInt("DefaultTileBackColor");
            Refresh();
        }
    }
}
