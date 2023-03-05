using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGLTilePaint
{
    public class TileModel
    {
        private static readonly int Width = 16;
        private static readonly int Height = 16;
        private static readonly int HalfWidth = Width / 2;
        private static readonly int HalfHeight = Height / 2;

        private Color[,] Pixels;

        public TileModel()
        {
            Pixels = new Color[Height, Width];
            New();
        }

        public void New()
        {
            Fill(Color.White);
        }

        public void Fill(Color color)
        {
            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                    SetPixel(x, y, color);
        }

        public void SetPixel(int x, int y, Color color)
        {
            if (x >= 0 && y >= 0 && x < Width && y < Height)
                Pixels[y, x] = color;
        }

        public Color GetPixel(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < Width && y < Height)
                return Pixels[y, x];

            return Color.FromArgb(0, 0, 0, 0);
        }

        public List<Color> GetColorPalette(bool single)
        {
            HashSet<int> argbs = new HashSet<int>();

            if (single)
            {
                for (int y = 0; y < HalfHeight; y++)
                    for (int x = 0; x < HalfWidth; x++)
                        argbs.Add(GetPixel(x, y).ToArgb());
            }
            else
            {
                for (int y = 0; y < Height; y++)
                    for (int x = 0; x < Width; x++)
                        argbs.Add(GetPixel(x, y).ToArgb());
            }

            List<Color> colors = new List<Color>();
            foreach (int argb in argbs)
                colors.Add(Color.FromArgb(255, Color.FromArgb(argb)));

            return colors;
        }
    }
}
