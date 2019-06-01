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
    public class ColorPicker : Display
    {
        public Palette Pal { set; get; }
        public int ForeColorIx { set; get; }
        public int BackColorIx { set; get; }

        private readonly Charset Chars;

        public ColorPicker(Control parent, GraphicsAdapter gr, int zoom)
            : base(parent, gr, zoom)
        {
            Pal = new Palette();
            Chars = new Charset();
            ForeColorIx = 0;
            BackColorIx = Pal.Size - 1;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int x = 0;
            int y = 0;

            for (int i = 0; i < Pal.Size; i++)
            {
                Graphics.DrawChar(Chars, Pal, x, y, 0xdb, i, 0);
                x++;
                if (x > 7)
                {
                    x = 0;
                    y++;
                }
            }

            base.OnPaint(e);
        }

        public int GetColor(int index)
        {
            return Pal.Colors[index];
        }

        public void SetColor(int index, int color)
        {
            Pal.Colors[index] = color;
        }

        public void SetColor(int index, Color color)
        {
            Color opaqueColor = Color.FromArgb(255, color);
            SetColor(index, opaqueColor.ToArgb());
        }

        public Color GetForeColor()
        {
            return Color.FromArgb(Pal.Colors[ForeColorIx]);
        }

        public Color GetBackColor()
        {
            return Color.FromArgb(Pal.Colors[BackColorIx]);
        }
    }
}
