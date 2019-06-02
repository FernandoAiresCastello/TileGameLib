using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.Graphics
{
    public class TileBuffer
    {
        public Tile[,] Tiles { set; get; }
        public int Cols { get; private set; }
        public int Rows { get; private set; }

        public TileBuffer(int cols, int rows)
        {
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
            Tiles[x, y].SetEqual(tile);
        }

        public ref Tile Get(int x, int y)
        {
            return ref Tiles[x, y];
        }

        public Tile Copy(int x, int y)
        {
            return Tiles[x, y].Copy();
        }

        public void SetNull(int col, int row)
        {
            Tiles[col, row].SetNull();
        }
    }
}
