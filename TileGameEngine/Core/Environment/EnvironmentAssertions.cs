using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameEngine.Exceptions;

namespace TileGameEngine.Core
{
    public partial class Environment
    {
        private void AssertWindowIsOpen()
        {
            if (!HasWindow)
                throw new EnvironmentException("Game window is closed");
        }

        private void AssertWindowIsNotOpen()
        {
            if (HasWindow)
                throw new EnvironmentException("Game window is already open");
        }

        private void AssertTextColorIsWithinPalette()
        {
            int fgc = Window.TileForeColor;
            int bgc = Window.TileBackColor;

            if (fgc < 0 || bgc < 0 || fgc >= Window.Graphics.Palette.Size || bgc >= Window.Graphics.Palette.Size)
                throw new EnvironmentException("Color palette index out of range");
        }

        private void AssertTextCursorIsWithinBounds()
        {
            Point textCursor = Window.TileCursor;
            int x = textCursor.X;
            int y = textCursor.Y;

            if (x < 0 || y < 0 || x >= Window.Graphics.Cols || y >= Window.Graphics.Rows)
                throw new EnvironmentException("Text cursor out of bounds");
        }
    }
}
