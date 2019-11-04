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
        public Point Point => new Point(X, Y);

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

        public override string ToString()
        {
            return $"Layer: {Layer} X: {X} Y: {Y}";
        }

        public int GetDistance(ObjectPosition otherPos)
        {
            return (int)Math.Truncate(
                Math.Sqrt(
                    Math.Pow(otherPos.X - X, 2) + Math.Pow(otherPos.Y - Y, 2)
                )
            );
        }

        public static ObjectPosition AtDistance(ObjectPosition pos, int dx, int dy)
        {
            return new ObjectPosition(pos.Layer, pos.X + dx, pos.Y + dy);
        }

        public static ObjectPosition Above(ObjectPosition pos)
        {
            return new ObjectPosition(pos.Layer + 1, pos.X, pos.Y);
        }

        public static ObjectPosition Under(ObjectPosition pos)
        {
            return new ObjectPosition(pos.Layer - 1, pos.X, pos.Y);
        }

        public static ObjectPosition North(ObjectPosition pos, int distance = 1)
        {
            return new ObjectPosition(pos.Layer, pos.Y - distance, pos.X);
        }

        public static ObjectPosition South(ObjectPosition pos, int distance = 1)
        {
            return new ObjectPosition(pos.Layer, pos.Y + distance, pos.X);
        }

        public static ObjectPosition East(ObjectPosition pos, int distance = 1)
        {
            return new ObjectPosition(pos.Layer, pos.Y, pos.X + distance);
        }

        public static ObjectPosition West(ObjectPosition pos, int distance = 1)
        {
            return new ObjectPosition(pos.Layer, pos.Y, pos.X - distance);
        }

        public static ObjectPosition Northeast(ObjectPosition pos, int distance = 1)
        {
            return new ObjectPosition(pos.Layer, pos.Y - distance, pos.X + distance);
        }

        public static ObjectPosition Northwest(ObjectPosition pos, int distance = 1)
        {
            return new ObjectPosition(pos.Layer, pos.Y - distance, pos.X - distance);
        }

        public static ObjectPosition Southeast(ObjectPosition pos, int distance = 1)
        {
            return new ObjectPosition(pos.Layer, pos.Y + distance, pos.X + distance);
        }

        public static ObjectPosition Southwest(ObjectPosition pos, int distance = 1)
        {
            return new ObjectPosition(pos.Layer, pos.Y + distance, pos.X - distance);
        }
    }
}
