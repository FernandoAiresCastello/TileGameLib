using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.Core
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
            Objects[x, y].SetEqual(o);
        }

        public ref GameObject GetObject(int x, int y)
        {
            return ref Objects[x, y];
        }

        public GameObject CopyObject(int x, int y)
        {
            return Objects[x, y].Copy();
        }
    }
}
