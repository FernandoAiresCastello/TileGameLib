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

        public static ObjectPosition AtDistance(ObjectPosition pos, int dx, int dy)
        {
            return new ObjectPosition(pos.Layer, pos.X + dx, pos.Y + dy);
        }

        public int GetDistance(ObjectPosition otherPos)
        {
            return (int)Math.Truncate(Math.Sqrt(Math.Pow(otherPos.X - X, 2) + Math.Pow(otherPos.Y - Y, 2)));
        }
    }
}
