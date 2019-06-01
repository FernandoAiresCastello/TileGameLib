using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Graphics;
using TileGameMaker.Component;

namespace TileGameMaker.Component
{
    public class CharPicker : Display
    {
        public Charset Chars { set; get; }
        public int CharIndex { set; get; }

        private readonly Palette Pal;

        public CharPicker(Control parent, GraphicsAdapter gr, int zoom)
            : base(parent, gr, zoom)
        {
            Chars = new Charset();
            Pal = new Palette();
            CharIndex = 0;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int x = 0;
            int y = 0;

            for (int i = 0; i < Chars.Size; i++)
            {
                Graphics.DrawChar(Chars, Pal, x, y, i, 0, Pal.Size - 1);
                x++;
                if (x > 15)
                {
                    x = 0;
                    y++;
                }
            }

            base.OnPaint(e);
        }
    }
}
