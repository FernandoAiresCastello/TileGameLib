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
            Objects = new GameObject[width, height];

            for (int row = 0; row < Height; row++)
                for (int col = 0; col < Width; col++)
                    Objects[col, row] = new GameObject();

            Width = width;
            Height = height;
        }

        public void Clear()
        {
            for (int row = 0; row < Height; row++)
                for (int col = 0; col < Width; col++)
                    Objects[col, row].SetNull();
        }

        public void Set(GameObject o, int x, int y)
        {
            Objects[x, y].SetEqual(o);
        }

        public ref GameObject Get(int x, int y)
        {
            return ref Objects[x, y];
        }

        public GameObject Copy(int x, int y)
        {
            return Objects[x, y].Copy();
        }
    }
}
