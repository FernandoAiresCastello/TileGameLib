using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Core;
using TileGameLib.Graphics;
using TileGameMaker.Component;

namespace TileGameMaker.Forms
{
    public partial class TestWindow : Form
    {
        private Display Disp;
        private GraphicsAdapter Gr;
        private Charset Chars;
        private Palette Pal;
        private ObjectMap Map;
        private MapRenderer MapRenderer;

        public TestWindow()
        {
            InitializeComponent();

            Chars = new Charset();
            Pal = new Palette();
            Map = new ObjectMap(30, 25);
            Gr = new GraphicsAdapter(256, 192);
            Disp = new Display(this, Gr, 3);
            MapRenderer = new MapRenderer(Map, Disp, 256);

            GameObject o = new GameObject(new ObjectChar('|', 3, 6));
            o.Animation.AddFrame(new ObjectChar('-', 3, 6));
            o.Animation.AddFrame(new ObjectChar('+', 3, 6));
            for (int y = 0; y < Map.Height; y++)
                for (int x = 0; x < Map.Width; x++)
                    Map.SetObject(o, 0, x, y);

            Disp.ShowGrid = true;
            Disp.MouseMove += Display_MouseMove;
            Disp.MouseDown += Disp_MouseDown;
            Disp.MouseMove += Disp_MouseMove;
        }

        private void DrawCharset()
        {
            Gr.Clear(Pal, 1);

            int x = 0, y = 0;
            for (int i = 0; i < Chars.Size; i++)
            {
                Gr.DrawChar(Chars, Pal, x, y, i, 0, 1);
                if (++x >= 16)
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
            Point point = Disp.GetGridPoint(e.Location);
            Disp.Graphics.DrawChar(Chars, Pal, point.X, point.Y, '@', 0, 1);
            Disp.Refresh();
        }

        private void Display_MouseMove(object sender, MouseEventArgs e)
        {
            Point point = Disp.GetGridPoint(e.Location);
            Text = point.X + ", " + point.Y;
        }
    }
}
