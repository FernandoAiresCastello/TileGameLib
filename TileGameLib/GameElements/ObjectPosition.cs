using System;
using System.Collections.Generic;
using System.Drawing;
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

        public ObjectPosition(ObjectPosition other) : this(other.Layer, other.X, other.Y)
        {
        }

        public ObjectPosition(int layer, Point point) : this(layer, point.X, point.Y)
        {
        }

        public ObjectPosition(int layer, int x, int y)
        {
            Layer = layer;
            X = x;
            Y = y;
        }

        public int GetDistance(ObjectPosition otherPos)
        {
            return (int)Math.Truncate(
                Math.Sqrt(
                    Math.Pow(otherPos.X - X, 2) + Math.Pow(otherPos.Y - Y, 2)
                )
            );
        }

        public static ObjectPosition Above(ObjectPosition pos)
        {
            return new ObjectPosition(pos.Layer + 1, pos.X, pos.Y);
        }

        public static ObjectPosition Under(ObjectPosition pos)
        {
            return new ObjectPosition(pos.Layer - 1, pos.X, pos.Y);
        }

        public static ObjectPosition AtDistance(ObjectPosition pos, int dx, int dy)
        {
            return new ObjectPosition(pos.Layer, pos.X + dx, pos.Y + dy);
        }
    }
}
