using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.Graphics
{
    public class FastBitmap : IDisposable
    {
        public Bitmap Bitmap { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }
        public int[] Pixels { get; private set; }

        protected GCHandle BitsHandle { get; private set; }
        private bool Disposed;

        public FastBitmap(int width, int height)
        {
            Width = width;
            Height = height;
            Pixels = new int[width * height];
            BitsHandle = GCHandle.Alloc(Pixels, GCHandleType.Pinned);
            Bitmap = new Bitmap(width, height, width * 4, 
                PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
        }

        public void Dispose()
        {
            if (Disposed)
                return;

            Disposed = true;
            Bitmap.Dispose();
            BitsHandle.Free();
        }
    }
}
