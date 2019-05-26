using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.Graphics
{
    public class GraphicsAdapter
    {
        public Bitmap Bitmap { get { return Buffer.Bitmap; } }
        public int PixelCount { get { return Buffer.Pixels.Length; } }
        public int Width { get { return Buffer.Width; } }
        public int Height { get { return Buffer.Height; } }
        public int Cols { get { return Buffer.Width / Char.RowLength; } }
        public int Rows { get { return Buffer.Height / Char.RowCount; } }

        private readonly FastBitmap Buffer;

        public GraphicsAdapter(int width, int height)
        {
            Buffer = new FastBitmap(width, height);
        }

        public void SetPixel(int index, int color)
        {
            Buffer.Pixels[index] = color;
        }

        public void SetPixel(int x, int y, int color)
        {
            Buffer.Pixels[y * Buffer.Width + x] = color;
        }

        public int GetPixel(int index)
        {
            return Buffer.Pixels[index];
        }

        public int GetPixel(int x, int y)
        {
            return Buffer.Pixels[y * Buffer.Width + x];
        }

        public void Clear()
        {
            for (int i = 0; i < Buffer.Pixels.Length; i++)
                Buffer.Pixels[i] = 0;
        }

        public void Clear(Palette pal, int palIndex)
        {
            for (int i = 0; i < Buffer.Pixels.Length; i++)
                Buffer.Pixels[i] = pal[palIndex];
        }

        public void DrawString(Charset chars, Palette pal, int x, int y, string str, int palIndex1, int palIndex0)
        {
            foreach (char ch in str)
                DrawChar(chars, pal, x++, y, ch, palIndex1, palIndex0);
        }

        public void DrawChar(Charset chars, Palette pal, int x, int y, int charIndex, int palIndex1, int palIndex0)
        {
            SetPixels8x8(true, x, y, pal[palIndex1], pal[palIndex0], chars[charIndex].PixelRows);
        }

        private void SetPixels8x8(bool tileXY, int x, int y, int color1, int color0,
            byte row1, byte row2, byte row3, byte row4,
            byte row5, byte row6, byte row7, byte row8)
        {
            SetPixels8x8(tileXY, x, y, color0, color1,
                new[] { row1, row2, row3, row4, row5, row6, row7, row8 });
        }

        private void SetPixels8x8(bool tileXY, int x, int y, int color1, int color0, byte[] rows)
        {
            if (tileXY)
            {
                x *= Char.RowLength;
                y *= Char.RowCount;
            }

            int px = x;
            int i = 0;

            for (int rowIx = 0; rowIx < rows.Length; rowIx++)
            {
                ref byte row = ref rows[rowIx];

                for (int bit = Char.RowLength - 1; bit >= 0; bit--)
                {
                    int pixelIndex = y * Buffer.Width + x;
                    if (pixelIndex < 0 || pixelIndex >= Buffer.Pixels.Length)
                        return;

                    Buffer.Pixels[pixelIndex] = 
                        (row & (1 << bit)) != 0 ? color1 : color0;

                    if (++i < Char.RowLength)
                    {
                        x++;
                    }
                    else
                    {
                        i = 0;
                        x = px;
                        y++;
                    }
                }
            }
        }
    }
}
