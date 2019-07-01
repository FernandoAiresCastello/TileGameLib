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
            Tile[] lastCol = GetLastCol();

            for (int x = 0; x < Cols - 1; x++)
                SetColumn(x + 1, GetColumn(x));

            SetColumn(0, lastCol);
        }

        public void ScrollLeft()
        {
            Tile[] firstCol = GetFirstCol();

            for (int x = Cols - 1; x > 1; x--)
                SetColumn(x - 1, GetColumn(x));

            SetColumn(Cols - 1, firstCol);
        }

        public void ScrollDown()
        {
            Tile[] lastRow = GetLastRow();

            for (int y = 0; y < Rows - 1; y++)
                SetRow(y + 1, GetRow(y));

            SetColumn(0, lastRow);
        }

        public void ScrollUp()
        {
            Tile[] firstRow = GetFirstRow();

            for (int y = Rows - 1; y > 1; y--)
                SetRow(y - 1, GetRow(y));

            SetColumn(Rows - 1, firstRow);
        }

        public void SetColumn(int col, Tile[] tiles)
        {
            if (tiles.Length != Rows)
                throw new ArgumentException();

            for (int row = 0; row < Rows; row++)
                Tiles[col, row] = tiles[row];
        }

        public void SetRow(int row, Tile[] tiles)
        {
            if (tiles.Length != Cols)
                throw new ArgumentException();

            for (int col = 0; col < Cols; col++)
                Tiles[col, row] = tiles[col];
        }

        public Tile[] GetColumn(int col)
        {
            if (col < 0 || col >= Cols)
                throw new ArgumentException();

            Tile[] tiles = new Tile[Rows];
            for (int row = 0; row < Rows; row++)
                tiles[row] = Tiles[col, row];

            return tiles;
        }

        public Tile[] GetRow(int row)
        {
            if (row < 0 || row >= Rows)
                throw new ArgumentException();

            Tile[] tiles = new Tile[Cols];
            for (int col = 0; col < Cols; col++)
                tiles[col] = Tiles[col, row];

            return tiles;
        }

        public Tile[] GetFirstCol()
        {
            return GetColumn(0);
        }

        public Tile[] GetLastCol()
        {
            return GetColumn(Cols - 1);
        }

        public Tile[] GetFirstRow()
        {
            return GetRow(0);
        }

        public Tile[] GetLastRow()
        {
            return GetRow(Rows - 1);
        }
    }
}
