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
    public partial class BinaryWindow : Form
    {
        public Color TileForeColor = Color.FromArgb(0, 0, 0);
        public Color TileBackColor = Color.FromArgb(255, 255, 255);

        private TileEditPanel PnlTileEdit;
        private MosaicPanel PnlMosaic;

        public BinaryWindow()
        {
            InitializeComponent();
            PnlTileEdit = new TileEditPanel(this);
            PnlTileEdit.Parent = PnlTileEditContainer;
            PnlTileEdit.Dock = DockStyle.Fill;
            UpdateBinaryString();

            PnlMosaic = new MosaicPanel();
            PnlMosaic.Parent = PnlMosaicContainer;
            PnlMosaic.Dock = DockStyle.Fill;
            PnlMosaic.TileImage = PnlTileEdit.GetBitmapRGB();

            //Size = new Size(418, 570);
            ResizeEnd += BinaryWindow_ResizeEnd;
        }

        private void BinaryWindow_ResizeEnd(object sender, EventArgs e)
        {
            Text = "Size = " + Width + ", " + Height;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            PnlTileEdit.FillPixelsColor(TileBackColor);
            UpdateMosaicAndBinaryString();
        }

        public void UpdateMosaicAndBinaryString()
        {
            UpdateBinaryString();
            UpdateMosaic();
        }

        private void UpdateMosaic()
        {
            PnlMosaic.TileImage = PnlTileEdit.GetBitmapRGB();
            PnlMosaic.Refresh();
        }

        private void UpdateBinaryString()
        {
            Bitmap bmp = PnlTileEdit.GetBitmapRGB();
            StringBuilder binary = new StringBuilder();
            
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color pixel = bmp.GetPixel(x, y);

                    if (pixel == TileForeColor)
                        binary.Append('1');
                    else if (pixel == TileBackColor)
                        binary.Append('0');
                    else
                        binary.Append('?');
                }
            }

            TxtBinary.Text = binary.ToString();
        }

        private void BtnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(TxtBinary.Text);
        }

        private void BtnPaste_Click(object sender, EventArgs e)
        {
            string text = Clipboard.GetText();
            
            if (text.Length != 64)
            {
                MessageBox.Show("Invalid tile data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int x = 0;
            int y = 0;

            foreach (char ch in text)
            {
                Color color;
                if (ch == '0')
                    color = TileBackColor;
                else if (ch == '1')
                    color = TileForeColor;
                else
                {
                    MessageBox.Show("Invalid tile data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                PnlTileEdit.Tile.SetPixel(x, y, color);
                x++;
                if (x >= 8)
                {
                    x = 0;
                    y++;
                }
            }
            
            PnlTileEdit.Refresh();
            UpdateMosaic();
            TxtBinary.Text = text;
        }
    }
}
