using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.Graphics
{
    public class OverlayText
    {
        public string Text { set; get; }
        public Point Point { set; get; }
        public Color Color { set; get; }
        public Font Font { set; get; }

        public OverlayText()
        {
        }

        public OverlayText(string text, Point point, Color color, Font font)
        {
            Point = point;
            Text = text;
            Color = color;
            Font = font;
        }
    }
}
