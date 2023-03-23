using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TileGameLib
{
    /// <summary>
    /// Rectangular area on a <see cref="TileDisplay"/>.
    /// </summary>
    public class View
    {
        public static readonly string DefaultId = "default";

        public string Id => id;
        public bool IsDefault => id == DefaultId;

        public Rect Rect;
        public int scrollX = 0;
        public int scrollY = 0;
        public Rgb backColor = 0x000000;

        private readonly string id;

        public View(string id, int x1, int y1, int x2, int y2, Rgb backColor)
        {
            this.id = id;
            Set(x1, y1, x2, y2, backColor);
        }

        public static View Default(int x1, int y1, int x2, int y2, Rgb backColor)
        {
            return new View(DefaultId, x1, y1, x2, y2, backColor);
        }

        public void Set(int x1, int y1, int x2, int y2, Rgb backColor)
        {
            Rect = new Rect(x1, y1, x2, y2);
            this.backColor = backColor;
        }

        public void Scroll(int dx, int dy)
        {
            scrollX += dx;
            scrollY += dy;
        }

        public void ScrollTo(int x, int y)
        {
            scrollX = x;
            scrollY = y;
        }
    }
}
