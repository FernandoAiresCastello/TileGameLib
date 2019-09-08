using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameEngine.Windows;

namespace TileGameEngine.Core
{
    public partial class Environment
    {
        private GameWindow Window;

        public bool HasWindow => Window != null;
        public bool ExitIfGameWindowClosed { get; set; } = false;

        public void CreateWindow(int cols, int rows)
        {
            AssertWindowIsNotOpen();
            Window = new GameWindow(cols, rows);
            Window.FormClosed += Window_FormClosed;
            Window.Show();
        }

        private void Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            Window = null;
        }

        public void CloseWindow()
        {
            AssertWindowIsOpen();

            if (MapRenderer != null)
            {
                MapRenderer.Stop();
                MapRenderer.AutoRefresh = false;
            }

            Window.Close();
            Window = null;
        }

        public void SetWindowAlwaysOnTop(bool alwaysOnTop)
        {
            Window.TopMost = alwaysOnTop;
        }

        public void SetWindowBackColor(int color)
        {
            Window.BackColor = color;
        }

        public void SetWindowTileForeColor(int color)
        {
            Window.TileForeColor = color;
        }

        public void SetWindowTileBackColor(int color)
        {
            Window.TileBackColor = color;
        }

        public void SetWindowCursorX(int x)
        {
            Window.TileCursor = new Point(x, Window.TileCursor.Y);
        }

        public void SetWindowCursorY(int y)
        {
            Window.TileCursor = new Point(Window.TileCursor.X, y);
        }

        public void SetWindowPalette(int index, int rgb)
        {
            Window.Graphics.Palette.Set(index, rgb);
        }

        public void SetWindowTileset(int index, byte[] pattern)
        {
            Window.Graphics.Tileset.Set(index,
                pattern[0], pattern[1], pattern[2], pattern[3],
                pattern[4], pattern[5], pattern[6], pattern[7]);
        }

        public bool IsKeyPressed(string keyname)
        {
            return Window.IsKeyPressed(keyname);
        }

        public void ClearWindow()
        {
            AssertWindowIsOpen();
            Window.Clear();
        }

        public void ClearMapViewport()
        {
            AssertWindowIsOpen();
            Window.ClearRect(MapRenderer.Viewport);
        }

        public void PutTile(int index)
        {
            AssertWindowIsOpen();
            AssertTextColorIsWithinPalette();
            AssertTextCursorIsWithinBounds();

            Window.PutTile(index);
        }

        public void Print(string text)
        {
            AssertWindowIsOpen();
            AssertTextColorIsWithinPalette();
            AssertTextCursorIsWithinBounds();

            Window.Print(text);
        }

        public void RefreshWindow()
        {
            AssertWindowIsOpen();
            Window.Refresh();
        }
    }
}
