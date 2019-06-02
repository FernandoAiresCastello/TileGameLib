using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Util;

namespace TileGameLib.Graphics
{
    public class GraphicsAdapter
    {
        public Bitmap Bitmap { get { return FastBitmap.Bitmap; } }
        public int PixelCount { get { return FastBitmap.Pixels.Length; } }
        public int Width { get { return FastBitmap.Width; } }
        public int Height { get { return FastBitmap.Height; } }
        public int Cols { get { return FastBitmap.Width / TilePixels.RowLength; } }
        public int Rows { get { return FastBitmap.Height / TilePixels.RowCount; } }
        public Tileset Tileset { set; get; }
        public Palette Palette { set; get; }
        public TileBuffer TileBuffer { get; private set; }

        private readonly FastBitmap FastBitmap;

        public GraphicsAdapter(int cols, int rows)
        {
            Tileset = new Tileset();
            Palette = new Palette();
            TileBuffer = new TileBuffer(cols, rows);

            int width = cols * TilePixels.RowLength + 1;
            int height = rows * TilePixels.RowCount + 1;

            FastBitmap = new FastBitmap(width, height);
        }

        public ref Tile GetTile(int col, int row)
        {
            return ref TileBuffer.Tiles[col, row];
        }

        public Tile CopyTile(int col, int row)
        {
            return TileBuffer.Tiles[col, row].Copy();
        }

        public void DrawString(int x, int y, string str, int palIndex1, int palIndex0)
        {
            foreach (char ch in str)
                DrawTile(x++, y, ch, palIndex1, palIndex0);
        }

        public void DrawTile(int col, int row, int charIndex, int palIndex1, int palIndex0)
        {
            if (col >= 0 && row >= 0 && col < TileBuffer.Cols && row < TileBuffer.Rows)
            {
                TileBuffer.Tiles[col, row].Set(charIndex, palIndex1, palIndex0);
                SetTilePixels(col, row, Palette[palIndex1], Palette[palIndex0], Tileset[charIndex].PixelRows);
            }
            else
            {
                Alert.Error(
                    "Invalid tile buffer index on DrawTile\n" +
                    "Col: " + col + " Row: " + row + "\n" +
                    "Tile buffer size: " + TileBuffer.Cols + "x" + TileBuffer.Rows
                );
            }
        }

        private void SetTilePixels(int col, int row, int color1, int color0, byte[] rows)
        {
            col *= TilePixels.RowLength;
            row *= TilePixels.RowCount;

            int prevCol = col;
            int i = 0;

            for (int rowIx = 0; rowIx < rows.Length; rowIx++)
            {
                ref byte pixelRow = ref rows[rowIx];

                for (int bit = TilePixels.RowLength - 1; bit >= 0; bit--)
                {
                    int pixelIndex = row * FastBitmap.Width + col;
                    if (pixelIndex < 0 || pixelIndex >= FastBitmap.Pixels.Length)
                        return;

                    FastBitmap.Pixels[pixelIndex] = 
                        (pixelRow & (1 << bit)) != 0 ? color1 : color0;

                    if (++i < TilePixels.RowLength)
                    {
                        col++;
                    }
                    else
                    {
                        i = 0;
                        col = prevCol;
                        row++;
                    }
                }
            }
        }
    }
}
