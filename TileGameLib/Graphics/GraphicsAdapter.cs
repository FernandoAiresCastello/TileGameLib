﻿using System;
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
        public Bitmap Bitmap => FastBitmap.Bitmap;
        public int PixelCount => FastBitmap.Pixels.Length;
        public int Width => FastBitmap.Width; 
        public int Height => FastBitmap.Height;
        public int Cols => FastBitmap.Width / TilePixels.RowLength;
        public int Rows => FastBitmap.Height / TilePixels.RowCount;
        public Tileset Tileset { set; get; }
        public Palette Palette { set; get; }
        public TileBuffer TileBuffer { get; private set; }

        private readonly FastBitmap FastBitmap;

        public GraphicsAdapter(int cols, int rows)
            : this(cols, rows, new Tileset(), new Palette())
        {
        }

        public GraphicsAdapter(int cols, int rows, Tileset tileset, Palette palette)
        {
            Tileset = tileset;
            Palette = palette;
            TileBuffer = new TileBuffer(cols, rows);

            int width = cols * TilePixels.RowLength;
            int height = rows * TilePixels.RowCount;

            FastBitmap = new FastBitmap(width, height);
        }

        public void SaveAsImage(string file)
        {
            Bitmap.Save(file);
        }

        public ref Tile GetTile(int col, int row)
        {
            return ref TileBuffer.Tiles[col, row];
        }

        public Tile CopyTile(int col, int row)
        {
            return TileBuffer.Tiles[col, row].Copy();
        }

        public void Clear(int palIndex0)
        {
            Fill(Tile.Null.TileIx, Tile.Null.ForeColorIx, palIndex0);
        }

        public void Fill(Tile tile)
        {
            Fill(tile.TileIx, tile.ForeColorIx, tile.BackColorIx);
        }

        public void Fill(int charIndex, int palIndex1, int palIndex0)
        {
            for (int y = 0; y < Rows; y++)
                for (int x = 0; x < Cols; x++)
                    PutTile(x, y, charIndex, palIndex1, palIndex0);
        }

        public void PutString(int x, int y, string str, int palIndex1, int palIndex0)
        {
            foreach (char ch in str)
                PutTile(x++, y, ch, palIndex1, palIndex0);
        }

        public void PutTile(int col, int row, Tile tile)
        {
            PutTile(col, row, tile.TileIx, tile.ForeColorIx, tile.BackColorIx);
        }

        public void PutTile(int col, int row, int charIndex, int palIndex1, int palIndex0)
        {
            if (col >= 0 && row >= 0 && col < TileBuffer.Cols && row < TileBuffer.Rows)
            {
                TileBuffer.Tiles[col, row].Set(charIndex, palIndex1, palIndex0);
                DrawTile(col, row, Palette.Get(palIndex1), Palette.Get(palIndex0), Tileset.Get(charIndex).PixelRows);
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

        private void DrawTile(int col, int row, int color1, int color0, byte[] rows)
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

                    FastBitmap.Pixels[pixelIndex] = (pixelRow & (1 << bit)) != 0 ? color1 : color0;

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
