using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Graphics;

namespace TileGameLib.Components
{
    public class TiledDisplay : PictureBox
    {
        public TileGraphicsDriver Graphics { get; set; }
        public Bitmap CustomOverlay { set; get; }
        public bool ShowGrid { set; get; }
        public bool ShowCustomOverlay { set; get; }
        public int Zoom { get; protected set; }
        public bool StretchImage { set; get; }
        public Color TileHighlightColor { set; get; }
        public int TileHighlightColorOpacity { set; get; }
        public List<Point> SelectedTiles { get; private set; } = new List<Point>();

        public int Cols => Graphics.Cols;
        public int Rows => Graphics.Rows;
        public int TileCount => Cols * Rows;

        protected Bitmap Grid;
        protected Color GridColor;
        protected int MinZoom = 1;
        protected int MaxZoom = 10;

        public TiledDisplay(Control parent, int cols, int rows, int zoom)
        {
            Parent = parent;
            DoubleBuffered = true;
            Graphics = new TileGraphicsDriver(cols, rows);
            Image = Graphics.Bitmap;
            ShowGrid = false;
            ShowCustomOverlay = false;
            StretchImage = false;
            GridColor = Color.FromArgb(50, 0, 0, 0);
            TileHighlightColor = SystemColors.Highlight;
            TileHighlightColorOpacity = 128;
            SetZoom(zoom);
        }

        public TiledDisplay(Control parent, int cols, int rows, int zoom, Tile defaultTile)
            : this(parent, cols, rows, zoom)
        {
            Graphics.Fill(defaultTile);
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
            Graphics = new TileGraphicsDriver(cols, rows, Graphics.Tileset, Graphics.Palette);
            UpdateSize();
        }

        public void ResizeGraphicsByTileCount(int tileCount, int tilesPerRow)
        {
            int cols = tilesPerRow;
            int rows = 0;

            for (int i = 0; i < tileCount; i++)
            {
                if (i % tilesPerRow == 0)
                    rows++;
            }

            ResizeGraphics(cols, rows);
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

        public void SetGridColor(Color color)
        {
            GridColor = color;
            MakeGrid();
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

        public Bitmap CreateCustomOverlay()
        {
            CustomOverlay = new Bitmap(Graphics.Width, Graphics.Height);
            return CustomOverlay;
        }

        public System.Drawing.Graphics GetCustomOverlayGraphics()
        {
            return System.Drawing.Graphics.FromImage(CustomOverlay);
        }
        
        public bool IsTileSelected(Point point)
        {
            foreach (Point currentPoint in SelectedTiles)
            {
                if (currentPoint.Equals(point))
                    return true;
            }

            return false;
        }

        public void SelectTile(Point point)
        {
            if (!IsTileSelected(point))
                SelectedTiles.Add(point);
        }

        public void DeselectTile(Point point)
        {
            for (int index = 0; index < SelectedTiles.Count; index++)
            {
                Point currentPoint = SelectedTiles[index];

                if (currentPoint.Equals(point))
                {
                    SelectedTiles.RemoveAt(index);
                    break;
                }
            }
        }

        public void SelectTiles(List<Point> points, bool additive = false)
        {
            if (additive)
            {
                SelectedTiles.RemoveAll(point => points.Contains(point));
            }
            else
            {
                DeselectAllTiles();
            }

            SelectedTiles.AddRange(points);
        }

        public void DeselectTiles(List<Point> points)
        {
            foreach (Point point in points)
                DeselectTile(point);
        }

        public void DeselectAllTiles()
        {
            SelectedTiles.Clear();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            PaintTiles(e.Graphics);
            PaintOverlays(e.Graphics);
        }

        private void PaintTiles(System.Drawing.Graphics g)
        {
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.SmoothingMode = SmoothingMode.None;
            g.PixelOffsetMode = PixelOffsetMode.Half;
            g.CompositingQuality = CompositingQuality.HighSpeed;
            g.CompositingMode = CompositingMode.SourceCopy;

            g.DrawImage(Graphics.Bitmap, 0, 0,
                StretchImage ? ClientRectangle.Width : Zoom * Graphics.Width,
                StretchImage ? ClientRectangle.Height : Zoom * Graphics.Height);
        }

        private void PaintOverlays(System.Drawing.Graphics g)
        {
            g.InterpolationMode = InterpolationMode.Default;
            g.SmoothingMode = SmoothingMode.Default;
            g.PixelOffsetMode = PixelOffsetMode.Default;
            g.CompositingQuality = CompositingQuality.Default;
            g.CompositingMode = CompositingMode.SourceOver;

            if (SelectedTiles.Count > 0)
                PaintTileHighlights(g);
            if (ShowGrid && Grid != null)
                g.DrawImage(Grid, 0, 0, ClientRectangle.Width, ClientRectangle.Height);
            if (ShowCustomOverlay && CustomOverlay != null)
                g.DrawImage(CustomOverlay, 0, 0, ClientRectangle.Width, ClientRectangle.Height);
        }

        private void PaintTileHighlights(System.Drawing.Graphics g)
        {
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(TileHighlightColorOpacity, TileHighlightColor)))
            {
                foreach (Point point in SelectedTiles)
                    PaintTileHighlight(g, brush, point);
            }
        }

        private void PaintTileHighlight(System.Drawing.Graphics g, Brush brush, Point point)
        {
            int scaledWidth = Zoom * TilePixels.RowLength;
            int scaledHeight = Zoom * TilePixels.RowCount;

            Rectangle rect = new Rectangle
            {
                X = point.X * scaledWidth,
                Y = point.Y * scaledHeight,
                Width = scaledWidth,
                Height = scaledHeight
            };

            g.FillRectangle(brush, rect);
        }

        protected void MakeGrid()
        {
            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(Grid))
            {
                g.Clear(Color.FromArgb(0));

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
