using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Graphics;

namespace TileGameLib.Component
{
    public class TiledDisplay : PictureBox
    {
        public GraphicsAdapter Graphics { get; set; }
        public Bitmap Overlay { set; get; }
        public bool ShowGrid { set; get; }
        public bool ShowOverlay { set; get; }
        public Color GridColor { set; get; }
        public int Zoom { get; protected set; }

        protected Bitmap Grid;
        protected int MinZoom = 1;
        protected int MaxZoom = 10;

        public TiledDisplay(Control parent, int cols, int rows, int zoom)
        {
            Parent = parent;
            DoubleBuffered = true;
            Graphics = new GraphicsAdapter(cols, rows);
            Image = Graphics.Bitmap;
            ShowGrid = true;
            ShowOverlay = true;
            GridColor = Color.FromArgb(50, 0, 0, 0);
            ShowBorder(false);
            SetZoom(zoom);
        }

        protected void ShowBorder(bool show)
        {
            BorderStyle = show ? BorderStyle.Fixed3D : BorderStyle.None;
        }

        public Point GetMouseToCellPos(Point point)
        {
            return new Point
            {
                X = point.X / (Zoom * TilePixels.RowLength),
                Y = point.Y / (Zoom * TilePixels.RowCount)
            };
        }

        public int GetMouseToCellIndex(Point point)
        {
            Point p = GetMouseToCellPos(point);
            return (p.Y * Graphics.Cols) + p.X;
        }

        public void ResizeGraphics(int cols, int rows)
        {
            Graphics = new GraphicsAdapter(cols, rows, Graphics.Tileset, Graphics.Palette);
            UpdateSize();
        }

        public void SetZoom(int zoom)
        {
            if (zoom < MinZoom)
                zoom = MinZoom;
            else if (zoom > MaxZoom)
                zoom = MaxZoom;

            Zoom = zoom;
            UpdateSize();
        }

        private void UpdateSize()
        {
            Size = new Size(Zoom * Graphics.Width, Zoom * Graphics.Height);
            Grid = new Bitmap(Width, Height);
            MakeGrid();
            Refresh();
        }

        public void ZoomIn()
        {
            SetZoom(Zoom + 1);
        }

        public void ZoomOut()
        {
            SetZoom(Zoom - 1);
        }

        public Bitmap CreateOverlay()
        {
            Overlay = new Bitmap(Width, Height);
            return Overlay;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            System.Drawing.Graphics g = e.Graphics;
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.SmoothingMode = SmoothingMode.None;
            g.PixelOffsetMode = PixelOffsetMode.Half;
            g.CompositingQuality = CompositingQuality.HighSpeed;
            g.CompositingMode = CompositingMode.SourceCopy;

            g.DrawImage(Graphics.Bitmap, 0, 0, Zoom * Graphics.Width, Zoom * Graphics.Height);

            g.CompositingMode = CompositingMode.SourceOver;
            if (ShowGrid && Grid != null)
                g.DrawImage(Grid, 0, 0);
            if (ShowOverlay && Overlay != null)
                g.DrawImage(Overlay, 0, 0);
        }

        protected void MakeGrid()
        {
            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(Grid))
            {
                using (Pen pen = new Pen(GridColor))
                {
                    for (int y = -1; y < Height; y += Zoom * TilePixels.RowCount)
                        g.DrawLine(pen, 0, y, Width, y);
                    for (int x = -1; x < Width; x += Zoom * TilePixels.RowLength)
                        g.DrawLine(pen, x, 0, x, Height);
                }
            }
        }
    }
}
