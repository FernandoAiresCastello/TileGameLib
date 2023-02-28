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

        private int[,] Pixels;

        public TileModel()
        {
            Pixels = new int[Height, Width];
            Fill(0);
        }

        public override string ToString()
        {
            return ToStringSingle16x16();
        }

        public string ToStringSingle16x16()
        {
            StringBuilder sb = new StringBuilder();
            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                    sb.Append(GetPixel(x, y));

            return sb.ToString();
        }

        public string ToStringSingle8x8()
        {
            StringBuilder sb = new StringBuilder();
            for (int y = 0; y <= 7; y++)
                for (int x = 0; x <= 7; x++)
                    sb.Append(GetPixel(x, y));

            return sb.ToString();
        }

        public string ToStringComposite()
        {
            StringBuilder topLeft = new StringBuilder();
            for (int y = 0; y <= 7; y++)
                for (int x = 0; x <= 7; x++)
                    topLeft.Append(GetPixel(x, y));
            StringBuilder topRight = new StringBuilder();
            for (int y = 0; y <= 7; y++)
                for (int x = 8; x <= 15; x++)
                    topRight.Append(GetPixel(x, y));
            StringBuilder btmLeft = new StringBuilder();
            for (int y = 8; y <= 15; y++)
                for (int x = 0; x <= 7; x++)
                    btmLeft.Append(GetPixel(x, y));
            StringBuilder btmRight = new StringBuilder();
            for (int y = 8; y <= 15; y++)
                for (int x = 8; x <= 15; x++)
                    btmRight.Append(GetPixel(x, y));

            return
                topLeft + Environment.NewLine +
                topRight + Environment.NewLine +
                btmLeft + Environment.NewLine +
                btmRight + Environment.NewLine;
        }

        public bool Parse(string str)
        {
            if (str.Length != 64) return false;

            int i = 0;
            Fill(0);

            for (int y = 0; y <= 7; y++)
            {
                for (int x = 0; x <= 7; x++)
                {
                    int ixColor = 0;
                    if (str[i] == '0') ixColor = 0;
                    else if (str[i] == '1') ixColor = 1;
                    else if (str[i] == '2') ixColor = 2;
                    else if (str[i] == '3') ixColor = 3;
                    
                    SetPixel(x, y, ixColor);
                    i++;
                }
            }

            return true;
        }

        public void Fill(int ixColor)
        {
            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                    SetPixel(x, y, ixColor);
        }

        public void SetPixel(int x, int y, int ixColor)
        {
            if (x >= 0 && y >= 0 && x < Width && y < Height)
                Pixels[y, x] = ixColor;
        }

        public void ShiftPixelColorIndex(int x, int y)
        {
            int index = Pixels[y, x];
            index++;
            if (index > 3)
                index = 0;

            Pixels[y, x] = index;
        }

        public int GetPixel(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < Width && y < Height)
                return Pixels[y, x];

            return -1;
        }

        public void SetPixels(string pixels)
        {
            int x = 0;
            int y = 0;

            foreach (char pix in pixels)
            {
                if (pix == '0') SetPixel(x, y, 0);
                else if (pix == '1') SetPixel(x, y, 1);
                else if (pix == '2') SetPixel(x, y, 2);
                else if (pix == '3') SetPixel(x, y, 3);

                x++;
                if (x >= Width)
                {
                    y++;
                    x = 0;
                }
            }
        }
    }
}
