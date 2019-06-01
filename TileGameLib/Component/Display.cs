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

namespace TileGameMaker.Component
{
    public class Display : PictureBox
    {
        public GraphicsAdapter Graphics { get; set; }
        public Bitmap Overlay { set; get; }
        public bool ShowGrid { set; get; }
        public bool ShowOverlay { set; get; }
        public Color GridColor { set; get; }

        protected int Zoom;
        protected Bitmap Grid;

        public Display(Control parent, GraphicsAdapter gr, int zoom)
        {
            Parent = parent;
            Graphics = gr;
            Image = gr.Bitmap;
            ShowGrid = false;
            ShowOverlay = true;
            GridColor = Color.FromArgb(50, 0, 0, 0);
            BorderStyle = BorderStyle.Fixed3D;
            Graphics.Fill(Color.White.ToArgb());
            SetZoom(zoom);
        }

        public void SetZoom(int zoom)
        {
            if (zoom < 1)
                zoom = 1;

            Zoom = zoom;
            Size = new Size(Zoom * Graphics.Width, Zoom * Graphics.Height);
            Grid = new Bitmap(Width, Height);
            MakeGrid();
        }

        public Bitmap CreateOverlay()
        {
            Overlay = new Bitmap(Width, Height);
            return Overlay;
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

        protected void MakeGrid()
        {
            Graphics g = System.Drawing.Graphics.FromImage(Grid);
            Pen pen = new Pen(GridColor);

            for (int y = -1; y < Height; y += Zoom * Char.RowCount)
                g.DrawLine(pen, 0, y, Width, y);
            for (int x = -1; x < Width; x += Zoom * Char.RowLength)
                g.DrawLine(pen, x, 0, x, Height);

            pen.Dispose();
            g.Dispose();
        }

        public Point GetMouseToCellPos(Point point)
        {
            return new Point
            {
                X = point.X / (Zoom * Char.RowLength),
                Y = point.Y / (Zoom * Char.RowCount)
            };
        }

        public int GetMouseToCellIndex(Point point)
        {
            Point p = GetMouseToCellPos(point);
            return (p.Y * Graphics.Cols) + p.X;
        }
    }
}
