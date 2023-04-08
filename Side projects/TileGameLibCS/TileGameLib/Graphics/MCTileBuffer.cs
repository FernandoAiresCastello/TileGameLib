using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Exceptions;

namespace TileGameLib.Graphics
{
    public class MCTileBuffer
    {
        public int[,] Tiles { set; get; }
        public int Cols { get; private set; }
        public int Rows { get; private set; }

        public MCTileBuffer(int cols, int rows)
        {
            if (cols <= 0 || rows <= 0)
                throw new ArgumentException();

            Cols = cols;
            Rows = rows;

            Tiles = new int[cols, rows];
            Clear();
        }

        public void Clear()
        {
            for (int row = 0; row < Rows; row++)
                for (int col = 0; col < Cols; col++)
                    Tiles[col, row] = 0;
        }

        public void Set(int x, int y, int index)
        {
            if (x < 0 || y < 0 || x >= Cols || y >= Rows)
                throw new TGLException();

            Tiles[x, y] = index;
        }

        public int Get(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Cols || y >= Rows)
                throw new TGLException();

            return Tiles[x, y];
        }

        public void ScrollRight()
        {
            int[] lastCol = CopyLastCol();

            for (int x = Cols - 2; x >= 0; x--)
                SetColumn(x + 1, CopyColumn(x));

            SetColumn(0, lastCol);
        }

        public void ScrollLeft()
        {
            int[] firstCol = CopyFirstCol();

            for (int x = 1; x < Cols; x++)
                SetColumn(x - 1, CopyColumn(x));

            SetColumn(Cols - 1, firstCol);
        }

        public void ScrollDown()
        {
            int[] lastRow = CopyLastRow();

            for (int y = Rows - 2; y >= 0; y--)
                SetRow(y + 1, CopyRow(y));

            SetRow(0, lastRow);
        }

        public void ScrollUp()
        {
            int[] firstRow = CopyFirstRow();

            for (int y = 1; y < Rows; y++)
                SetRow(y - 1, CopyRow(y));

            SetRow(Rows - 1, firstRow);
        }

        public void SetColumn(int col, int[] tiles)
        {
            if (tiles.Length != Rows)
                throw new ArgumentException();

            for (int row = 0; row < Rows; row++)
                Tiles[col, row] = tiles[row];
        }

        public void SetRow(int row, int[] tiles)
        {
            if (tiles.Length != Cols)
                throw new ArgumentException();

            for (int col = 0; col < Cols; col++)
                Tiles[col, row] = tiles[col];
        }

        public int[] CopyColumn(int col)
        {
            if (col < 0 || col >= Cols)
                throw new ArgumentException();

            int[] tiles = new int[Rows];
            for (int row = 0; row < Rows; row++)
                tiles[row] = Tiles[col, row];

            return tiles;
        }

        public int[] CopyRow(int row)
        {
            if (row < 0 || row >= Rows)
                throw new ArgumentException();

            int[] tiles = new int[Cols];
            for (int col = 0; col < Cols; col++)
                tiles[col] = Tiles[col, row];

            return tiles;
        }

        public int[] CopyFirstCol()
        {
            return CopyColumn(0);
        }

        public int[] CopyLastCol()
        {
            return CopyColumn(Cols - 1);
        }

        public int[] CopyFirstRow()
        {
            return CopyRow(0);
        }

        public int[] CopyLastRow()
        {
            return CopyRow(Rows - 1);
        }
    }
}
