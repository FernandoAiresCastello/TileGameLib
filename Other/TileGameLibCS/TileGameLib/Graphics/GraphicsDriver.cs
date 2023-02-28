using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Exceptions;

namespace TileGameLib.Graphics
{
    public class GraphicsDriver
    {
        public Bitmap Bitmap => FastBitmap.Bitmap;
        public int PixelCount => FastBitmap.Pixels.Length;
        public int Width => FastBitmap.Width;
        public int Height => FastBitmap.Height;
        public int Cols => FastBitmap.Width / TilePixels.RowLength;
        public int Rows => FastBitmap.Height / TilePixels.RowCount;

        protected readonly FastBitmap FastBitmap;

        public GraphicsDriver(int width, int height)
        {
            FastBitmap = new FastBitmap(width, height);
        }

        public void Clear(int rgb)
        {
            for (int i = 0; i < PixelCount; i++)
                FastBitmap.Pixels[i] = rgb;
        }

        public void Clear(Color color)
        {
            Clear(color.ToArgb());
        }

        public void SaveImage(string file, ImageFormat format)
        {
            Bitmap.Save(file, format);
        }

        public void SetPixel(int x, int y, int rgb)
        {
            SetPixel(y * Width + x, rgb);
        }

        public void SetPixel(int pixelIndex, int rgb)
        {
            if (pixelIndex < 0 || pixelIndex >= PixelCount)
                return;

            FastBitmap.Pixels[pixelIndex] = rgb;
        }

        public void SetPixel(int x, int y, Color color)
        {
            SetPixel(y * Width + x, color);
        }

        public void SetPixel(int pixelIndex, Color color)
        {
            SetPixel(pixelIndex, color.ToArgb());
        }

        public int GetPixel(int x, int y)
        {
            return GetPixel(y * Width + x);
        }

        public int GetPixel(int pixelIndex)
        {
            if (pixelIndex < 0 || pixelIndex >= PixelCount)
                throw new TGLException($"Pixel index out of bounds. Index: {pixelIndex} Pixels: {PixelCount}");

            return FastBitmap.Pixels[pixelIndex];
        }
    }
}
