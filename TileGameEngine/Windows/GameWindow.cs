using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Components;
using TileGameLib.Graphics;

namespace TileGameEngine.Windows
{
    public class GameWindow : DisplayWindow
    {
        public new int BackColor { set; get; } = 0;
        public Point TileCursor { set; get; } = new Point(0, 0);

        public GameWindow(int cols, int rows) : base(cols, rows)
        {
            Icon = TileGameEngineApplication.ApplicationIcon;
        }

        public void Clear()
        {
            Graphics.Clear(BackColor);
        }

        public void ClearRect(Rectangle rect)
        {
            Graphics.ClearRect(BackColor, rect.X, rect.Y, rect.Width, rect.Height);
        }

        public void Print(string text)
        {
            Graphics.PutString(TileCursor.X, TileCursor.Y, text, GetTileForeColor(), GetTileBackColor());
        }

        public ref Tile GetTileRefAtCursor()
        {
            return ref Graphics.TileBuffer.Get(TileCursor.X, TileCursor.Y);
        }

        public void SetTileForeColor(int color)
        {
            GetTileRefAtCursor().ForeColorIx = color;
        }

        public void SetTileBackColor(int color)
        {
            GetTileRefAtCursor().BackColorIx = color;
        }

        public void SetTileIndex(int index)
        {
            GetTileRefAtCursor().TileIx = index;
        }

        public int GetTileForeColor()
        {
            return GetTileRefAtCursor().ForeColorIx;
        }

        public int GetTileBackColor()
        {
            return GetTileRefAtCursor().BackColorIx;
        }

        public int GetTileIndex()
        {
            return GetTileRefAtCursor().TileIx;
        }

        internal void FillTiles(int ix, int fg, int bg)
        {
            Graphics.Fill(ix, fg, bg);
        }
    }
}
