using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
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
        public ReadOnlyCollection<ObjectCell> Cells => ToReadOnlyList();

        private ObjectCell[,] ObjectCells;

        public ObjectLayer(int width, int height)
        {
            Width = width;
            Height = height;

            ObjectCells = new ObjectCell[width, height];

            for (int row = 0; row < height; row++)
                for (int col = 0; col < width; col++)
                    ObjectCells[col, row] = new ObjectCell();
        }

        public void SetEqual(ObjectLayer other)
        {
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    GameObject o = other.GetObject(col, row);

                    if (o != null)
                        ObjectCells[col, row].SetObjectEqual(o);
                    else
                        ObjectCells[col, row].DeleteObject();
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
                        newCells[col, row] = new ObjectCell(ObjectCells[col, row]);
                    else
                        newCells[col, row] = new ObjectCell();
                }
            }

            ObjectCells = newCells;
            Width = width;
            Height = height;
        }

        public void Clear()
        {
            for (int row = 0; row < Height; row++)
                for (int col = 0; col < Width; col++)
                    ObjectCells[col, row].DeleteObject();
        }

        public void Fill(GameObject o)
        {
            for (int row = 0; row < Height; row++)
                for (int col = 0; col < Width; col++)
                    ObjectCells[col, row].SetObjectEqual(o);
        }

        public void SetObject(GameObject o, int x, int y)
        {
            if (x >= 0 && y >= 0 && x < Width && y < Height)
                ObjectCells[x, y].SetObjectEqual(o);
            else
                throw GetInvalidLayerPositionException(x, y);
        }

        public void PutObject(GameObject o, int x, int y)
        {
            if (x >= 0 && y >= 0 && x < Width && y < Height)
                ObjectCells[x, y].PutObject(o);
            else
                throw GetInvalidLayerPositionException(x, y);
        }

        public void DeleteObject(int x, int y)
        {
            ObjectCells[x, y].DeleteObject();
        }

        public ObjectCell GetCell(int x, int y)
        {
            return ObjectCells[x, y];
        }

        public GameObject GetObject(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < Width && y < Height)
                return ObjectCells[x, y].Object;

            throw GetInvalidLayerPositionException(x, y);
        }

        private TGLException GetInvalidLayerPositionException(int x, int y)
        {
            return new TGLException(
                string.Format("Invalid layer position X:{0} Y:{1}. Layer size is {2}x{3}", 
                x, y, Width, Height));
        }

        private ReadOnlyCollection<ObjectCell> ToReadOnlyList()
        {
            List<ObjectCell> cells = new List<ObjectCell>();

            for (int row = 0; row < Height; row++)
                for (int col = 0; col < Width; col++)
                    cells.Add(ObjectCells[col, row]);

            return new ReadOnlyCollection<ObjectCell>(cells);
        }
    }
}
