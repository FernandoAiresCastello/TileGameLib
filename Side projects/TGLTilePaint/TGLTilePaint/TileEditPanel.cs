using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TGLTilePaint
{
    public partial class TileEditPanel : UserControl
    {
        public TileModel Tile;
        public Color CurrentColor;
        public bool ShowMainGrid;
        public bool ShowSubGrid;

        public Color Color0;
        public Color Color1;
        public Color Color2;
        public Color Color3;

        private Form Wnd;
        private Color GridColor;
        private Color GridColorMid;
        private Color GridTextColor;
        
        private enum EditMode { Single, Multiple }
        private EditMode Mode;

        private int TileSize
        {
            get
            {
                if (Mode == EditMode.Single) return 8;
                if (Mode == EditMode.Multiple) return 16;
                return 0;
            }
        }

        public TileEditPanel()
        {
            Init(null, EditMode.Multiple);
        }

        public TileEditPanel(Form wnd)
        {
            Init(wnd, EditMode.Single);
        }

        private void Init(Form wnd, EditMode mode)
        {
            Wnd = wnd;
            Mode = mode;

            InitializeComponent();
            ResetColors();

            GridColor = Color.FromArgb(20, 100, 100, 128);
            GridColorMid = Color.FromArgb(90, 100, 100, 128);
            GridTextColor = Color.FromArgb(200, 100, 100, 128);

            Tile = new TileModel();
            CurrentColor = Color.Black;
            ShowMainGrid = true;
            ShowSubGrid = true;

            DoubleBuffered = true;
            Resize += TileEditPanel_Resize;
            MouseClick += TileEditPanel_Click;
            MouseMove += TileEditPanel_MouseMove;
            MouseDown += TileEditPanel_MouseDown;
        }

        public void ResetColors()
        {
            Color0 = Color.FromArgb(255, 255, 255);
            Color1 = Color.FromArgb(220, 220, 220);
            Color2 = Color.FromArgb(127, 127, 127);
            Color3 = Color.FromArgb(0, 0, 0);
        }

        public void Mode8x8()
        {
            Mode = EditMode.Single;
            Refresh();
        }

        public void Mode16x16()
        {
            Mode = EditMode.Multiple;
            Refresh();
        }

        public bool Is8x8()
        {
            return Mode == EditMode.Single;
        }

        public bool Is16x16()
        {
            return Mode == EditMode.Multiple;
        }

        public void ToggleMode()
        {
            if (Mode == EditMode.Single)
                Mode = EditMode.Multiple;
            else if (Mode == EditMode.Multiple)
                Mode = EditMode.Single;

            Refresh();
        }

        private void TileEditPanel_Resize(object sender, EventArgs e)
        {
            Refresh();
        }

        private void TileEditPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.None && e.Button != MouseButtons.Middle)
                OnPanelClicked(e);
        }

        private void TileEditPanel_Click(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Middle)
                OnPanelClicked(e);
        }

        private void TileEditPanel_MouseDown(object sender, MouseEventArgs e)
        {
            OnPanelClicked(e);
        }

        private void OnPanelClicked(MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;
            int w = TileSize;
            int h = TileSize;
            int cellWidth = Width / w;
            int cellHeight = Height / h;
            int px = x / cellWidth;
            int py = y / cellHeight;

            if (e.Button == MouseButtons.Left)
            {
                if (Wnd is MainWindow)
                {
                    Tile.SetPixel(px, py, CurrentColor);
                }
                else if (Wnd is BinaryWindow)
                {
                    Tile.SetPixel(px, py, (Wnd as BinaryWindow).TileForeColor);
                    (Wnd as BinaryWindow).UpdateMosaicAndBinaryString();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                CurrentColor = Tile.GetPixel(px, py);

                if (Wnd is MainWindow)
                {
                    (Wnd as MainWindow).UpdateColorButtons();
                    (Wnd as MainWindow).UpdateColorHexRGBs();
                }
                else if (Wnd is BinaryWindow)
                {
                    Tile.SetPixel(px, py, (Wnd as BinaryWindow).TileBackColor);
                    (Wnd as BinaryWindow).UpdateMosaicAndBinaryString();
                }
            }

            Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.FillRectangle(Brushes.White, ClientRectangle);

            DrawPixels(g);
            DrawGrid(g);
        }

        private void DrawPixels(Graphics g)
        {
            int w = TileSize;
            int h = TileSize;
            int cellWidth = Width / w;
            int cellHeight = Height / h;

            SolidBrush brush = new SolidBrush(Color0);
            SolidBrush textBrush = new SolidBrush(GridTextColor);

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    int px = x * cellWidth;
                    int py = y * cellHeight;
                    Color color = Tile.GetPixel(x, y);
                    brush.Color = color;
                    g.FillRectangle(brush, px, py, cellWidth, cellHeight);
                }
            }

            brush.Dispose();
            textBrush.Dispose();
        }

        private void DrawGrid(Graphics g)
        {
            SolidBrush brush = new SolidBrush(GridColor);
            Pen pen = new Pen(brush);
            SolidBrush dkBrush = new SolidBrush(GridColorMid);
            Pen dkPen = new Pen(dkBrush);

            int w = TileSize;
            int h = TileSize;
            int cellWidth = Width / w;
            int cellHeight = Height / h;
            int midX = w / 2;
            int midY = h / 2;
            int lineX = 0;
            int lineY = 0;

            for (int x = 0; x < w; x++)
            {
                if (x == midX && ShowSubGrid) g.DrawLine(dkPen, lineX, lineY, lineX, Height);
                else if (ShowMainGrid) g.DrawLine(pen, lineX, lineY, lineX, Height);
                lineX += cellWidth;
            }

            lineX = 0;
            lineY = 0;

            for (int y = 0; y < h; y++)
            {
                if (y == midY && ShowSubGrid) g.DrawLine(dkPen, lineX, lineY, Width, lineY);
                else if (ShowMainGrid) g.DrawLine(pen, lineX, lineY, Width, lineY);
                lineY += cellHeight;
            }

            g.DrawLine(pen, 0, 0, Width, 0);

            pen.Dispose();
            brush.Dispose();
            dkPen.Dispose();
            dkBrush.Dispose();
        }

        public void FillPixelsColorLeft()
        {
            Tile.Fill(CurrentColor);
            Refresh();
        }

        public void FillPixelsColor(Color color)
        {
            Tile.Fill(color);
            Refresh();
        }

        public void ParseBitmapImageTGL(Bitmap bitmap)
        {
            if (bitmap.Width == 8 && bitmap.Height == 8)
                Mode8x8();
            else if (bitmap.Width == 16 && bitmap.Height == 16)
                Mode16x16();
            else
            {
                MessageBox.Show("Invalid bitmap size. Only bitmaps of size 8x8 and 16x16 are supported", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            for (int y = 0; y < TileSize; y++)
            {
                for (int x = 0; x < TileSize; x++)
                {
                    Tile.SetPixel(x, y, bitmap.GetPixel(x, y));
                }
            }
            Refresh();
        }

        public Bitmap GetBitmapRGB()
        {
            Bitmap bitmap = new Bitmap(TileSize, TileSize);

            for (int y = 0; y < TileSize; y++)
            {
                for (int x = 0; x < TileSize; x++)
                {
                    bitmap.SetPixel(x, y, Tile.GetPixel(x, y));
                }
            }
            return bitmap;
        }

        public List<Bitmap> GetBitmapsTGL()
        {
            List<Bitmap> bitmaps = new List<Bitmap>();

            if (Is8x8())
                bitmaps.Add(GetBitmapImageTGL8x8());
            else if (Is16x16())
                bitmaps.AddRange(GetBitmapImageTGL16x16());

            return bitmaps;
        }

        private Bitmap GetBitmapImageTGL8x8()
        {
            return Get8x8BitmapFrom16x16(0, 0);
        }

        private Bitmap[] GetBitmapImageTGL16x16()
        {
            Bitmap[] bitmaps = new Bitmap[5];

            bitmaps[0] = Get16x16Bitmap();
            bitmaps[1] = Get8x8BitmapFrom16x16(0, 0);
            bitmaps[2] = Get8x8BitmapFrom16x16(8, 0);
            bitmaps[3] = Get8x8BitmapFrom16x16(0, 8);
            bitmaps[4] = Get8x8BitmapFrom16x16(8, 8);

            return bitmaps;
        }

        private Bitmap Get8x8BitmapFrom16x16(int ix, int iy)
        {
            Bitmap bitmap = new Bitmap(8, 8);

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    bitmap.SetPixel(x, y, Tile.GetPixel(ix + x, iy + y));
                }
            }
            return bitmap;
        }

        private Bitmap Get16x16Bitmap()
        {
            Bitmap bitmap = new Bitmap(TileSize, TileSize);

            for (int y = 0; y < TileSize; y++)
            {
                for (int x = 0; x < TileSize; x++)
                {
                    bitmap.SetPixel(x, y, Tile.GetPixel(x, y));
                }
            }
            return bitmap;
        }

        public void ReplaceColor(Color src, Color dst)
        {
            for (int y = 0; y < TileSize; y++)
            {
                for (int x = 0; x < TileSize; x++)
                {
                    int rgb = Tile.GetPixel(x, y).ToArgb();
                    if (rgb == src.ToArgb())
                        Tile.SetPixel(x, y, dst);
                }
            }
            Refresh();
        }
    }
}
