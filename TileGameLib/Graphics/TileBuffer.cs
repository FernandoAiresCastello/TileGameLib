using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Exceptions;

namespace TileGameLib.Graphics
{
    public class TileBuffer
    {
        public Tile[,] Tiles { set; get; }
        public int Cols { get; private set; }
        public int Rows { get; private set; }

        public TileBuffer(int cols, int rows)
        {
            if (cols <= 0 || rows <= 0)
                throw new ArgumentException();

            Cols = cols;
            Rows = rows;

            Tiles = new Tile[cols, rows];

            for (int row = 0; row < rows; row++)
                for (int col = 0; col < cols; col++)
                    Tiles[col, row] = new Tile();
        }

        public void Clear()
        {
            for (int row = 0; row < Rows; row++)
                for (int col = 0; col < Cols; col++)
                    Tiles[col, row].SetNull();
        }

        public void Set(Tile tile, int x, int y)
        {
            if (x < 0 || y < 0 || x >= Cols || y >= Rows)
                throw new OutOfBoundsException();

            Tiles[x, y].SetEqual(tile);
        }

        public ref Tile Get(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Cols || y >= Rows)
                throw new OutOfBoundsException();

            return ref Tiles[x, y];
        }

        public Tile Copy(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Cols || y >= Rows)
                throw new OutOfBoundsException();

            return Tiles[x, y].Copy();
        }

        public void SetNull(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Cols || y >= Rows)
                throw new OutOfBoundsException();

            Tiles[x, y].SetNull();
        }

        public void ScrollRight()
        {
            Tile[] lastCol = CopyLastCol();

            for (int x = Cols - 2; x > 0; x--)
                SetColumn(x + 1, CopyColumn(x));

            SetColumn(0, lastCol);
        }

        public void ScrollLeft()
        {
            Tile[] firstCol = CopyFirstCol();

            for (int x = 1; x < Cols - 2; x++)
                SetColumn(x - 1, CopyColumn(x));

            SetColumn(Cols - 1, firstCol);
        }

        public void ScrollDown()
        {
            Tile[] lastRow = CopyLastRow();

            for (int y = 0; y < Rows - 1; y++)
                SetRow(y + 1, CopyRow(y));

            SetColumn(0, lastRow);
        }

        public void ScrollUp()
        {
            Tile[] firstRow = CopyFirstRow();

            for (int y = Rows - 1; y > 1; y--)
                SetRow(y - 1, CopyRow(y));

            SetColumn(Rows - 1, firstRow);
        }

        public void SetColumn(int col, Tile[] tiles)
        {
            if (tiles.Length != Rows)
                throw new ArgumentException();

            for (int row = 0; row < Rows; row++)
                Tiles[col, row].SetEqual(tiles[row]);
        }

        public void SetRow(int row, Tile[] tiles)
        {
            if (tiles.Length != Cols)
                throw new ArgumentException();

            for (int col = 0; col < Cols; col++)
                Tiles[col, row].SetEqual(tiles[col]);
        }

        public Tile[] CopyColumn(int col)
        {
            if (col < 0 || col >= Cols)
                throw new ArgumentException();

            Tile[] tiles = new Tile[Rows];
            for (int row = 0; row < Rows; row++)
                tiles[row] = new Tile(Tiles[col, row]);

            return tiles;
        }

        public Tile[] CopyRow(int row)
        {
            if (row < 0 || row >= Rows)
                throw new ArgumentException();

            Tile[] tiles = new Tile[Cols];
            for (int col = 0; col < Cols; col++)
                tiles[col] = new Tile(Tiles[col, row]);

            return tiles;
        }

        public Tile[] CopyFirstCol()
        {
            return CopyColumn(0);
        }

        public Tile[] CopyLastCol()
        {
            return CopyColumn(Cols - 1);
        }

        public Tile[] CopyFirstRow()
        {
            return CopyRow(0);
        }

        public Tile[] CopyLastRow()
        {
            return CopyRow(Rows - 1);
        }
    }
}
