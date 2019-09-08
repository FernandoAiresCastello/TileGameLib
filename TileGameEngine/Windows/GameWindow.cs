using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Components;

namespace TileGameEngine.Windows
{
    public class GameWindow : DisplayWindow
    {
        public new int BackColor { set; get; } = 0;
        public Point TileCursor { set; get; } = new Point(0, 0);
        public int TileForeColor { set; get; } = 0;
        public int TileBackColor { set; get; } = 0;

        public GameWindow(int cols, int rows) : base(cols, rows)
        {
        }

        public void Clear()
        {
            Graphics.Clear(BackColor);
        }

        public void ClearRect(Rectangle rect)
        {
            Graphics.ClearRect(BackColor, rect.X, rect.Y, rect.Width, rect.Height);
        }

        public void PutTile(int index)
        {
            Graphics.PutTile(TileCursor.X, TileCursor.Y, index, TileForeColor, TileBackColor);
        }

        public void Print(string text)
        {
            Graphics.PutString(TileCursor.X, TileCursor.Y, text, TileForeColor, TileBackColor);
        }
    }
}
