using System;
using System.Drawing;
using System.Windows.Forms;

namespace TGLTilePaint
{
    public partial class TileEditPanel : UserControl
    {
        public TileModel Tile;
        public int LeftColorIx;
        public int RightColorIx;
        public bool ShowPixelCodes;
        public bool ShowMainGrid;
        public bool ShowSubGrid;

        public Color Color0;
        public Color Color1;
        public Color Color2;
        public Color Color3;

        private readonly Color TGLColor0 = Color.FromArgb(255, 255, 255, 255);
        private readonly Color TGLColor1 = Color.FromArgb(255, 0, 0, 0);
        private readonly Color TGLColor2 = Color.FromArgb(255, 127, 127, 127);
        private readonly Color TGLColor3 = Color.FromArgb(255, 195, 195, 195);

        private MainWindow Wnd;
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

        public TileEditPanel(MainWindow wnd)
        {
            InitializeComponent();

            Wnd = wnd;
            Mode = EditMode.Single;

            Color0 = TGLColor0;
            Color1 = TGLColor1;
            Color2 = TGLColor2;
            Color3 = TGLColor3;

            GridColor = Color.FromArgb(20, 0, 0, 0);
            GridColorMid = Color.FromArgb(80, 0, 0, 0);
            GridTextColor = Color.FromArgb(128, 0, 0, 0);

            Tile = new TileModel();
            LeftColorIx = 1;
            RightColorIx = 0;
            ShowPixelCodes = true;
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
            Color0 = TGLColor0;
            Color1 = TGLColor1;
            Color2 = TGLColor2;
            Color3 = TGLColor3;
        }

        public void PermutateColors()
        {
            Color color0 = Color.FromArgb(Color0.R, Color0.G, Color0.B);
            Color color1 = Color.FromArgb(Color1.R, Color1.G, Color1.B);
            Color color2 = Color.FromArgb(Color2.R, Color2.G, Color2.B);
            Color color3 = Color.FromArgb(Color3.R, Color3.G, Color3.B);

            Color0 = Color.FromArgb(color1.R, color1.G, color1.B);
            Color1 = Color.FromArgb(color2.R, color2.G, color2.B);
            Color2 = Color.FromArgb(color3.R, color3.G, color3.B);
            Color3 = Color.FromArgb(color0.R, color0.G, color0.B);
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
                Tile.SetPixel(px, py, LeftColorIx);
            else if (e.Button == MouseButtons.Right)
                Tile.SetPixel(px, py, RightColorIx);
            else if (e.Button == MouseButtons.Middle)
                Tile.ShiftPixelColorIndex(px, py);

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
                    int pixel = Tile.GetPixel(x, y);
                    if (pixel == 0) brush.Color = Color0;
                    else if (pixel == 1) brush.Color = Color1;
                    else if (pixel == 2) brush.Color = Color2;
                    else if (pixel == 3) brush.Color = Color3;

                    int px = x * cellWidth;
                    int py = y * cellHeight;
                    g.FillRectangle(brush, px, py, cellWidth, cellHeight);

                    if (ShowPixelCodes)
                    {
                        if (Is16x16())
                            g.DrawString(pixel.ToString(), DefaultFont, textBrush, px + 10, py + 8);
                        else if (Is8x8())
                            g.DrawString(pixel.ToString(), DefaultFont, textBrush, px + 24, py + 20);
                    }
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
            Tile.Fill(LeftColorIx);
            Refresh();
        }

        public void FillPixelsColorRight()
        {
            Tile.Fill(RightColorIx);
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
                    int colorIndex = -1;

                    Color color = bitmap.GetPixel(x, y);
                    if (color == TGLColor0) colorIndex = 0;
                    else if (color == TGLColor1) colorIndex = 1;
                    else if (color == TGLColor2) colorIndex = 2;
                    else if (color == TGLColor3) colorIndex = 3;

                    Tile.SetPixel(x, y, colorIndex);
                }
            }
            Refresh();
        }

        public Bitmap GetBitmapImageTGL()
        {
            Bitmap bitmap = new Bitmap(TileSize, TileSize);

            for (int y = 0; y < TileSize; y++)
            {
                for (int x = 0; x < TileSize; x++)
                {
                    Color color = Color.FromArgb(0, 0, 0, 0);

                    int colorIndex = Tile.GetPixel(x, y);
                    if (colorIndex == 0) color = TGLColor0;
                    else if (colorIndex == 1) color = TGLColor1;
                    else if (colorIndex == 2) color = TGLColor2;
                    else if (colorIndex == 3) color = TGLColor3;

                    bitmap.SetPixel(x, y, color);
                }
            }
            return bitmap;
        }

        public Bitmap GetBitmapImageRGB()
        {
            Bitmap bitmap = new Bitmap(TileSize, TileSize);

            for (int y = 0; y < TileSize; y++)
            {
                for (int x = 0; x < TileSize; x++)
                {
                    Color color = Color.FromArgb(0, 0, 0, 0);

                    int colorIndex = Tile.GetPixel(x, y);
                    if (colorIndex == 0) color = Color0;
                    else if (colorIndex == 1) color = Color1;
                    else if (colorIndex == 2) color = Color2;
                    else if (colorIndex == 3) color = Color3;

                    bitmap.SetPixel(x, y, color);
                }
            }
            return bitmap;
        }
    }
}
