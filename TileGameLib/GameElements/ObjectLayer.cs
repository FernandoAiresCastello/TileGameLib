using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Exceptions;
using TileGameLib.Util;

namespace TileGameLib.GameElements
{
    public class ObjectLayer
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        private ObjectCell[,] Cells;

        public ObjectLayer(int width, int height)
        {
            Width = width;
            Height = height;

            Cells = new ObjectCell[width, height];

            for (int row = 0; row < height; row++)
                for (int col = 0; col < width; col++)
                    Cells[col, row] = new ObjectCell();
        }

        public void SetEqual(ObjectLayer other)
        {
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    GameObject o = other.GetObject(col, row);

                    if (o != null)
                        Cells[col, row].SetObjectEqual(o);
                    else
                        Cells[col, row].DeleteObject();
                }
            }
        }

        public void Resize(int width, int height)
        {
            ObjectCell[,] newCells = new ObjectCell[width, height];

            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    if (col < Width && row < Height)
                        newCells[col, row] = new ObjectCell(Cells[col, row]);
                    else
                        newCells[col, row] = new ObjectCell();
                }
            }

            Cells = newCells;
            Width = width;
            Height = height;
        }

        public void Clear()
        {
            for (int row = 0; row < Height; row++)
                for (int col = 0; col < Width; col++)
                    Cells[col, row].DeleteObject();
        }

        public void Fill(GameObject o)
        {
            for (int row = 0; row < Height; row++)
                for (int col = 0; col < Width; col++)
                    Cells[col, row].SetObjectEqual(o);
        }

        public void SetObject(GameObject o, int x, int y)
        {
            if (x >= 0 && y >= 0 && x < Width && y < Height)
                Cells[x, y].SetObjectEqual(o);
            else
                throw GetInvalidLayerPositionException(x, y);
        }

        public void DeleteObject(int x, int y)
        {
            Cells[x, y].DeleteObject();
        }

        public ObjectCell GetCell(int x, int y)
        {
            return Cells[x, y];
        }

        public GameObject GetObject(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < Width && y < Height)
                return Cells[x, y].GetObject();

            throw GetInvalidLayerPositionException(x, y);
        }

        public GameObject GetObjectCopy(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < Width && y < Height)
                return Cells[x, y].GetObjectCopy();

            throw GetInvalidLayerPositionException(x, y);
        }

        private TileGameLibException GetInvalidLayerPositionException(int x, int y)
        {
            return new TileGameLibException(
                string.Format("Invalid layer position X:{0} Y:{1}. Layer size is {2}x{3}", 
                x, y, Width, Height));
        }
    }
}
