using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameEngine.Windows;

namespace TileGameEngine.Core.RuntimeEnvironment
{
    public partial class Environment
    {
        private GameWindow Window;

        public bool HasWindow => Window != null;
        public bool ExitIfGameWindowClosed { get; set; } = false;

        public void CreateWindow(int cols, int rows)
        {
            if (Window == null)
            {
                Window = new GameWindow(cols, rows);
                Window.FormClosed += Window_FormClosed;
                Window.Show();
            }
        }

        private void Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            Window = null;
        }

        public void CloseWindow()
        {
            if (Window != null)
            {
                if (MapRenderer != null)
                {
                    MapRenderer.Stop();
                    MapRenderer.AutoRefresh = false;
                }

                Window.Close();
                Window = null;
            }
        }

        public void SetWindowAlwaysOnTop(bool alwaysOnTop)
        {
            Window.TopMost = alwaysOnTop;
        }

        public void SetWindowBackColor(int color)
        {
            Window.BackColor = color;
        }

        public int GetWindowBackColor()
        {
            return Window.BackColor;
        }

        public void SetWindowTileIndex(int index)
        {
            Window.SetTileIndex(index);
        }

        public int GetWindowTileIndex()
        {
            return Window.GetTileIndex();
        }

        public void SetWindowTileForeColor(int color)
        {
            Window.SetTileForeColor(color);
        }

        public int GetWindowTileForeColor()
        {
            return Window.GetTileForeColor();
        }

        public void SetWindowTileBackColor(int color)
        {
            Window.SetTileBackColor(color);
        }

        public int GetWindowTileBackColor()
        {
            return Window.GetTileBackColor();
        }

        public void SetWindowCursorX(int x)
        {
            Window.TileCursor = new Point(x, Window.TileCursor.Y);
        }

        public int GetWindowCursorY()
        {
            return Window.TileCursor.Y;
        }

        public void SetWindowCursorY(int y)
        {
            Window.TileCursor = new Point(Window.TileCursor.X, y);
        }

        public int GetWindowCursorX()
        {
            return Window.TileCursor.X;
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
            Window.Clear();
        }

        public void ClearMapViewport()
        {
            Window.ClearRect(MapRenderer.Viewport);
        }

        public void Print(string text)
        {
            Window.Print(text);
        }

        public void RefreshWindow()
        {
            Window.Refresh();
        }
    }
}
