using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TGLTilePaint
{
    public partial class MosaicPanel : UserControl
    {
        private TileModel Tile { set; get; }

        public MosaicPanel()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            if (Tile != null)
            {
                DrawTile(g, 0, 0);
                DrawTile(g, 1, 0);
                DrawTile(g, 0, 1);
                DrawTile(g, 1, 1);
            }
        }

        private void DrawTile(Graphics g, int col, int row)
        {
            
        }
    }
}
