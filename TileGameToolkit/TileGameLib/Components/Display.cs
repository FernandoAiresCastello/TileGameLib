using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Graphics;

namespace TileGameLib.Components
{
    public class Display : PictureBox
    {
        public GraphicsDriver Graphics { get; set; }
        public bool StretchImage { set; get; }

        public int Zoom
        {
            get => CurrentZoom;

            set
            {
                if (value < MinZoom)
                    CurrentZoom = MinZoom;
                else if (value > MaxZoom)
                    CurrentZoom = MaxZoom;
                else
                    CurrentZoom = value;

                UpdateSize();
            }
        }

        protected int CurrentZoom;
        protected int MinZoom = 1;
        protected int MaxZoom = 10;

        public Display(Control parent, int width, int height, int zoom)
        {
            Parent = parent;
            DoubleBuffered = true;
            Graphics = new GraphicsDriver(width, height);
            Image = Graphics.Bitmap;
            StretchImage = false;
            Zoom = zoom;
        }

        private void UpdateSize()
        {
            Size = new Size(Zoom * Graphics.Width, Zoom * Graphics.Height);
            Refresh();
        }

        public void ZoomIn()
        {
            Zoom++;
        }

        public void ZoomOut()
        {
            Zoom--;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            System.Drawing.Graphics g = e.Graphics;
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.SmoothingMode = SmoothingMode.None;
            g.PixelOffsetMode = PixelOffsetMode.Half;
            g.CompositingQuality = CompositingQuality.HighSpeed;
            g.CompositingMode = CompositingMode.SourceCopy;

            g.DrawImage(Graphics.Bitmap, 0, 0, 
                StretchImage ? ClientRectangle.Width : Zoom * Graphics.Width,
                StretchImage ? ClientRectangle.Height : Zoom * Graphics.Height);
        }
    }
}
