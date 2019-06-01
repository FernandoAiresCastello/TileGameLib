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

namespace TileGameMaker.Component
{
    public partial class MapWindow : Form
    {
        private Display Disp;
        private GraphicsAdapter Gr;
        private ObjectMap Map;
        private MapRenderer MapRenderer;

        public MapWindow()
        {
            InitializeComponent();
            StatusLabel.Text = "";

            Map = new ObjectMap(30, 20);
            Gr = new GraphicsAdapter(30, 20);
            Disp = new Display(MapPanel, Gr, 3);
            MapRenderer = new MapRenderer(Map, Disp, 256);

            GameObject o = new GameObject(new ObjectChar('|', 0, 63));
            o.Animation.AddFrame(new ObjectChar('-', 0, 63));
            o.Animation.AddFrame(new ObjectChar('+', 63, 0));
            for (int y = 0; y < Map.Height; y++)
                for (int x = 0; x < Map.Width; x++)
                    Map.SetObject(o, 0, x, y);

            Text = Map.Name;

            Disp.ShowGrid = true;
            Disp.MouseMove += Display_MouseMove;
            Disp.MouseDown += Disp_MouseDown;
            Disp.MouseMove += Disp_MouseMove;
            Disp.MouseLeave += Disp_MouseLeave;
        }

        private void Disp_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Disp_MouseDown(sender, e);
        }

        private void Disp_MouseDown(object sender, MouseEventArgs e)
        {
            Point point = Disp.GetMouseToCellPos(e.Location);
            Disp.Refresh();
        }

        private void Display_MouseMove(object sender, MouseEventArgs e)
        {
            Point point = Disp.GetMouseToCellPos(e.Location);
            StatusLabel.Text = point.X + ", " + point.Y;
        }

        private void Disp_MouseLeave(object sender, EventArgs e)
        {
            StatusLabel.Text = "";
        }
    }
}
