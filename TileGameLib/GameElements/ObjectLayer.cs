using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Exceptions;
using TileGameLib.Util;

namespace TileGameLib.GameElements
{
    public class ObjectLayer
    {
        public GameObject[,] Objects { set; get; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public ObjectLayer(int width, int height)
        {
            Width = width;
            Height = height;

            Objects = new GameObject[width, height];

            for (int row = 0; row < height; row++)
                for (int col = 0; col < width; col++)
                    Objects[col, row] = new GameObject();
        }

        public void SetEqual(ObjectLayer other)
        {
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    GameObject o = other.GetObject(col, row);
                    Objects[col, row].SetEqual(o);
                }
            }
        }

        public void Clear()
        {
            for (int row = 0; row < Height; row++)
                for (int col = 0; col < Width; col++)
                    Objects[col, row].SetNull();
        }

        public void Fill(GameObject o)
        {
            for (int row = 0; row < Height; row++)
                for (int col = 0; col < Width; col++)
                    Objects[col, row].SetEqual(o);
        }

        public void SetObject(GameObject o, int x, int y)
        {
            if (x >= 0 && y >= 0 && x < Width && y < Height)
                Objects[x, y].SetEqual(o);
            else
                throw new OutOfBoundsException(GetExceptionMessage(x, y));
        }

        public ref GameObject GetObject(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < Width && y < Height)
                return ref Objects[x, y];

            throw new OutOfBoundsException(GetExceptionMessage(x, y));
        }

        public GameObject CopyObject(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < Width && y < Height)
                return Objects[x, y].Copy();

            throw new OutOfBoundsException(GetExceptionMessage(x, y));
        }

        private string GetExceptionMessage(int x, int y)
        {
            return string.Format("Invalid object layer index. X:{0} Y:{1} Layer size:{2}x{3}", x, y, Width, Height);
        }

        public void Resize(int width, int height)
        {
            GameObject[,] newObjects = new GameObject[width, height];

            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    if (col < Width && row < Height)
                        newObjects[col, row] = new GameObject(Objects[col, row]);
                    else
                        newObjects[col, row] = new GameObject();
                }
            }

            Objects = newObjects;
            Width = width;
            Height = height;
        }
    }
}
