using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Exceptions;
using TileGameLib.Util;

namespace TileGameLib.Graphics
{
    public class MCTileGraphicsDriver : GraphicsDriver
    {
        public MCPalette Palette { set; get; }
        public MCTileset Tileset { set; get; }
        public MCTileBuffer TileBuffer { get; private set; }
        public int BackColor { set; get; }

        private const char NewLineChar = '\n';

        public MCTileGraphicsDriver(int cols, int rows, int backColor)
            : this(cols, rows, new MCTileset(), new MCPalette(), backColor)
        {
        }

        public MCTileGraphicsDriver(int cols, int rows, MCTileset tileset, MCPalette palette, int backColor)
            : base(cols * MCTile.Width, rows * MCTile.Height)
        {
            if (rows <= 0)
                throw new ArgumentOutOfRangeException("rows");
            if (cols <= 0)
                throw new ArgumentOutOfRangeException("cols");

            Tileset = tileset ?? throw new ArgumentNullException("tileset");
            Palette = palette ?? throw new ArgumentNullException("palette");

            TileBuffer = new MCTileBuffer(cols, rows);
            BackColor = backColor;
        }

        public int GetTileIndex(int col, int row)
        {
            if (col < 0 || row < 0 || col >= TileBuffer.Cols || row >= TileBuffer.Rows)
                throw new TGLException();

            return TileBuffer.Tiles[col, row];
        }

        public MCTile GetTile(int col, int row)
        {
            if (col < 0 || row < 0 || col >= TileBuffer.Cols || row >= TileBuffer.Rows)
                throw new TGLException();

            return Tileset.Get(TileBuffer.Tiles[col, row]);
        }

        public MCTile CopyTile(int col, int row)
        {
            if (col < 0 || row < 0 || col >= TileBuffer.Cols || row >= TileBuffer.Rows)
                throw new TGLException();

            return Tileset.Get(TileBuffer.Tiles[col, row]).Copy();
        }

        public void Clear()
        {
            Fill(0);
        }

        public void ClearRect(int paletteIndex, int x, int y, int width, int height)
        {
            for (int px = x; px < x + width; px++)
                for (int py = y; py < y + height; py++)
                    PutTile(px, py, 0);
        }

        public void Fill(int index)
        {
            for (int y = 0; y < Rows; y++)
                for (int x = 0; x < Cols; x++)
                    PutTile(x, y, index);
        }

        public void PutString(int x, int y, int fontStartIndex, string str)
        {
            int px = x;

            foreach (char ch in str)
            {
                if (ch != '\r')
                {
                    if (ch == NewLineChar)
                    {
                        x = px;
                        y++;

                        if (y >= Rows)
                            break;
                    }
                    else
                    {
                        if (x < Cols && y < Rows)
                            PutTile(x++, y, fontStartIndex + ch);
                    }
                }
            }
        }

        public void PutTile(int x, int y, int index)
        {
            if (x >= 0 && y >= 0 && x < TileBuffer.Cols && y < TileBuffer.Rows)
            {
                TileBuffer.Set(x, y, index);
            }
            else
            {
                string msg =
                    "Invalid tile buffer index on PutTile\n" +
                    "X: " + x + " Y: " + y + "\n" +
                    "Tile buffer size: " + TileBuffer.Cols + "x" + TileBuffer.Rows;

                throw new TGLException(msg);
            }
        }

        public void Refresh()
        {
            for (int row = 0; row < Rows; row++)
                for (int col = 0; col < Cols; col++)
                    DrawTile(col, row, Tileset.Get(TileBuffer.Tiles[col, row]));
        }

        private void DrawTile(int x, int y, MCTile tile)
        {
            x *= MCTile.Width;
            y *= MCTile.Height;
            int px = x;

            for (int iy = 0; iy < MCTile.Height; iy++)
            {
                for (int ix = 0; ix < MCTile.Width; ix++)
                {
                    int paletteIndex = tile.GetPixelPaletteIndex(ix, iy);
                    int rgb = Palette.Get(paletteIndex > 0 ? paletteIndex : BackColor);
                    SetPixel(x, y, rgb);
                    x++;
                }
                x = px;
                y++;
            }
        }
    }
}
