using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TGLTilePaint
{
    public partial class MosaicPanel : UserControl
    {
        public Bitmap TileImage { set; get; }
        private readonly int TileSize = 32;

        public MosaicPanel()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.SmoothingMode = SmoothingMode.HighSpeed;
            g.PixelOffsetMode = PixelOffsetMode.Half;

            base.OnPaint(e);

            g.DrawImage(TileImage, 60, 0, TileSize, TileSize);

            for (int y = 2; y < 7; y++)
                for (int x = 0; x < 5; x++)
                    g.DrawImage(TileImage, x * TileSize, y * TileSize, TileSize, TileSize);
        }
    }
}
