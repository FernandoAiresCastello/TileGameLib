using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Components;
using TileGameLib.Graphics;

namespace TileGameSamples
{
    public class GraphicsSample : DisplayWindow
    {
        private GraphicsAdapter Gr;
        private new readonly int DefaultForeColor = 255;
        private new readonly int DefaultBackColor = 2;

        private enum SampleMode { Menu, Tileset, Palette }
        private SampleMode Sample = SampleMode.Menu;

        public GraphicsSample() : base(32, 24, false, false)
        {
            Text = "Graphics Sample";
            Gr = Display.Graphics;
            Display.ShowOverlay = false;
            Display.CreateOverlay();
            DrawScanlines();
            ShowMenu();
        }

        protected override void HandleMouseEvent(MouseEventArgs e)
        {
        }

        protected override void HandleKeyEvent(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape: Close(); break;
                case Keys.F: ToggleScanlines(); break;
                case Keys.D0: ShowMenu(); break;
            }

            if (Sample == SampleMode.Menu)
            {
                switch (e.KeyCode)
                {
                    case Keys.D1: ShowTileset(); break;
                    case Keys.D2: ShowPalette(); break;
                }
            }

            Refresh();
        }

        private void ToggleScanlines()
        {
            Display.ShowOverlay = !Display.ShowOverlay;
        }

        private void DrawScanlines()
        {
            using (Graphics g = Display.GetOverlayGraphics())
            {
                using (Pen pen = new Pen(Color.FromArgb(100, 0, 0, 0)))
                {
                    for (int y = 0; y < Display.Overlay.Height; y += 2)
                        g.DrawLine(pen, 0, y, Display.Overlay.Width, y);
                }
            }
        }

        private void ClearDisplay()
        {
            Gr.Clear(DefaultBackColor);
        }

        private void ShowMenu()
        {
            Sample = SampleMode.Menu;
            ClearDisplay();

            int y = 1;

            PrintMenuItem(y++, "Graphics Sample", "");
            y++;
            PrintMenuItem(y++, "[ESC]", "Exit");
            PrintMenuItem(y++, "[ALT+ENTER]", "Toggle fullscreen");
            PrintMenuItem(y++, "[F]", "Toggle scanlines");
            PrintMenuItem(y++, "[0]", "Back to this menu");
            PrintMenuItem(y++, "[1]", "View tileset");
            PrintMenuItem(y++, "[2]", "View palette");
        }

        private void PrintMenuItem(int row, string keys, string description)
        {
            const int keysColumn = 1;
            const int descColumn = 13;

            Gr.PutString(keysColumn, row, keys, DefaultForeColor, DefaultBackColor);
            Gr.PutString(descColumn, row, description, DefaultForeColor, DefaultBackColor);
        }

        private void ShowTileset()
        {
            Sample = SampleMode.Tileset;
            ClearDisplay();

            int x = 1;
            int y = 1;

            for (int i = 0; i < Gr.Tileset.Size; i++)
            {
                Gr.PutTile(x, y, i, DefaultForeColor, DefaultBackColor);
                x++;
                if (x >= Gr.Cols - 1)
                {
                    x = 1;
                    y++;
                }
            }
        }

        private void ShowPalette()
        {
            Sample = SampleMode.Palette;
            ClearDisplay();

            int x = 0;
            int y = 0;
            const int SwatchTile = 0xdb;

            for (int i = 0; i < Gr.Palette.Size; i++)
            {
                Gr.PutTile(x + 0, y + 0, SwatchTile, i, DefaultBackColor);
                Gr.PutTile(x + 1, y + 0, SwatchTile, i, DefaultBackColor);

                x += 2;
                if (x > Gr.Cols - 2)
                {
                    x = 0;
                    y++;
                }
            }
        }
    }
}
