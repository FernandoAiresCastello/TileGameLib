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
        public ObjectCell[,] Cells { set; get; }
        public int Width { get; private set; }
        public int Height { get; private set; }

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
                throw new OutOfBoundsException(GetExceptionMessage(x, y));
        }

        public void DeleteObject(int x, int y)
        {
            Cells[x, y].DeleteObject();
        }

        public ref ObjectCell GetCell(int x, int y)
        {
            return ref Cells[x, y];
        }

        public ref GameObject GetObject(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < Width && y < Height)
                return ref Cells[x, y].GetObject();

            throw new OutOfBoundsException(GetExceptionMessage(x, y));
        }

        public GameObject CopyObject(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < Width && y < Height)
                return Cells[x, y].CopyObject();

            throw new OutOfBoundsException(GetExceptionMessage(x, y));
        }

        private string GetExceptionMessage(int x, int y)
        {
            return string.Format("Invalid object layer index. X:{0} Y:{1} Layer size:{2}x{3}", x, y, Width, Height);
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

        public Point? FindObjectPositionByTag(string tag)
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    GameObject o = Cells[x, y].GetObject();
                    if (o != null && o.HasTag && o.Tag.Equals(tag))
                        return new Point(x, y);
                }
            }

            return null;
        }
    }
}
