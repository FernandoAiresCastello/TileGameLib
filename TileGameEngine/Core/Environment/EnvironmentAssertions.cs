using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Core
{
    public partial class Environment
    {
        private void AssertWindowIsOpen()
        {
            if (!HasWindow)
                TileGameEngineApplication.Error("SCRIPT ERROR", "Game window is closed");
        }

        private void AssertWindowIsNotOpen()
        {
            if (HasWindow)
                TileGameEngineApplication.Error("SCRIPT ERROR", "Game window is already open");
        }

        private void AssertTextColorIsWithinPalette()
        {
            int fgc = Window.TileForeColor;
            int bgc = Window.TileBackColor;

            if (fgc < 0 || bgc < 0 || fgc >= Window.Graphics.Palette.Size || bgc >= Window.Graphics.Palette.Size)
                TileGameEngineApplication.Error("SCRIPT ERROR", "Color palette index out of range");
        }

        private void AssertTextCursorIsWithinBounds()
        {
            Point textCursor = Window.TileCursor;
            int x = textCursor.X;
            int y = textCursor.Y;

            if (x < 0 || y < 0 || x >= Window.Graphics.Cols || y >= Window.Graphics.Rows)
                TileGameEngineApplication.Error("SCRIPT ERROR", "Text cursor out of bounds");
        }
    }
}
