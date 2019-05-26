using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Graphics;
using Char = TileGameLib.Graphics.Char;

namespace TileGameMaker.GUI
{
    public class Display : PictureBox
    {
        public GraphicsAdapter Graphics { get; private set; }
        public Bitmap Grid { get; private set; }
        public Bitmap Overlay { set; get; }
        public bool ShowGrid { set; get; }
        public bool ShowOverlay { set; get; }

        private int Zoom;

        public Display(Control parent, int width, int height, int zoom)
        {
            Parent = parent;
            ShowGrid = false;
            ShowOverlay = true;
            Graphics = new GraphicsAdapter(width, height);
            Image = Graphics.Bitmap;
            BorderStyle = BorderStyle.Fixed3D;
            SetZoom(zoom);
            Graphics.Clear();
        }

        public void SetZoom(int zoom)
        {
            Zoom = zoom;
            Size = new Size(Zoom * Graphics.Width, Zoom * Graphics.Height);
            Grid = new Bitmap(Width, Height);
            MakeGrid();
        }

        public Bitmap CreateOverlay()
        {
            return new Bitmap(Width, Height);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.SmoothingMode = SmoothingMode.None;
            g.PixelOffsetMode = PixelOffsetMode.None;
            g.CompositingQuality = CompositingQuality.HighSpeed;
            g.CompositingMode = CompositingMode.SourceCopy;

            g.DrawImage(Graphics.Bitmap, 0, 0, Zoom * Graphics.Width, Zoom * Graphics.Height);

            if (ShowGrid && Grid != null)
            {
                g.CompositingMode = CompositingMode.SourceOver;
                g.DrawImage(Grid, 0, 0);
            }

            if (ShowOverlay && Overlay != null)
            {
                g.CompositingMode = CompositingMode.SourceOver;
                g.DrawImage(Overlay, 0, 0);
            }
        }

        private void MakeGrid()
        {
            Graphics g = System.Drawing.Graphics.FromImage(Grid);
            Pen pen = new Pen(Color.FromArgb(80, 0, 0, 0));

            for (int y = -1; y < Height; y += Zoom * Char.RowCount)
                g.DrawLine(pen, 0, y, Width, y);
            for (int x = -1; x < Width; x += Zoom * Char.RowLength)
                g.DrawLine(pen, x, 0, x, Height);

            pen.Dispose();
            g.Dispose();
        }

        public Point SnapMousePosToGrid(Point point)
        {
            return new Point
            {
                X = point.X / (Zoom * Char.RowLength),
                Y = point.Y / (Zoom * Char.RowCount)
            };
        }
    }
}
