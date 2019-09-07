using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.GameElements
{
    public class ObjectPosition
    {
        public int Layer { set; get; }
        public int X { set; get; }
        public int Y { set; get; }

        public ObjectPosition() : this(0, 0, 0)
        {
        }

        public ObjectPosition(int layer, int x, int y)
        {
            Layer = layer;
            X = x;
            Y = y;
        }
    }
}
