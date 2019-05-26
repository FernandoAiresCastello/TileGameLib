using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Graphics;
using TileGameMaker.GUI;

namespace TileGameMaker.Forms
{
    public partial class TestWindow : Form
    {
        private Display Disp;
        Charset Chars = new Charset();
        Palette Pal = new Palette();

        public TestWindow()
        {
            InitializeComponent();
            AutoSize = true;

            Disp = new Display(this, 256, 192, 3);
            Disp.ShowGrid = true;
            Disp.MouseMove += Display_MouseMove;
            Disp.MouseDown += Disp_MouseDown;
            Disp.MouseMove += Disp_MouseMove;
            GraphicsAdapter g = Disp.Graphics;
            g.Clear(Pal, 1);

            int x = 0;
            int y = 0;
            for (int i = 0; i < Chars.Size; i++)
            {
                g.DrawChar(Chars, Pal, x, y, i, 0, 1);
                x++;
                if (x >= 16)
                {
                    x = 0;
                    y++;
                }
            }
        }

        private void Disp_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Disp_MouseDown(sender, e);
        }

        private void Disp_MouseDown(object sender, MouseEventArgs e)
        {
            Point point = Disp.SnapMousePosToGrid(e.Location);
            Disp.Graphics.DrawChar(Chars, Pal, point.X, point.Y, '@', 0, 1);
            Disp.Refresh();
        }

        private void Display_MouseMove(object sender, MouseEventArgs e)
        {
            Point point = Disp.SnapMousePosToGrid(e.Location);
            Text = point.X + ", " + point.Y;
        }
    }
}
