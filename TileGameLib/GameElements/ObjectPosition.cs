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
        public int Layer { private set; get; }
        public int X { private set; get; }
        public int Y { private set; get; }

        public Point Point => new Point(X, Y);

        public ObjectPosition() : this(0, 0, 0)
        {
        }

        public ObjectPosition(ObjectPosition other)
        {
            SetEqual(other);
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

        public ObjectPosition Copy()
        {
            return new ObjectPosition(this);
        }

        public void SetEqual(ObjectPosition other)
        {
            Layer = other.Layer;
            X = other.X;
            Y = other.Y;
        }

        public int GetDistance(ObjectPosition other)
        {
            return (int)Math.Truncate(
                Math.Sqrt(
                    Math.Pow(other.X - X, 2) + Math.Pow(other.Y - Y, 2)
                )
            );
        }

        public void MoveTo(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void MoveDistance(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }

        public void MoveTowards(ObjectPosition other)
        {
            ObjectPosition newPosition = Towards(other);
            SetEqual(newPosition);
        }

        public void MoveAwayFrom(ObjectPosition other)
        {
            ObjectPosition newPosition = AwayFrom(other);
            SetEqual(newPosition);
        }

        public ObjectPosition AtDistance(int dx, int dy)
        {
            return new ObjectPosition(Layer, X + dx, Y + dy);
        }

        public ObjectPosition Above()
        {
            return new ObjectPosition(Layer + 1, X, Y);
        }

        public ObjectPosition Under()
        {
            return new ObjectPosition(Layer - 1, X, Y);
        }

        public ObjectPosition North(int distance = 1)
        {
            return new ObjectPosition(Layer, X, Y - distance);
        }

        public ObjectPosition South(int distance = 1)
        {
            return new ObjectPosition(Layer, X, Y + distance);
        }

        public ObjectPosition East(int distance = 1)
        {
            return new ObjectPosition(Layer, X + distance, Y);
        }

        public ObjectPosition West(int distance = 1)
        {
            return new ObjectPosition(Layer, X - distance, Y);
        }

        public ObjectPosition Northeast(int distance = 1)
        {
            return new ObjectPosition(Layer, X + distance, Y - distance);
        }

        public ObjectPosition Northwest(int distance = 1)
        {
            return new ObjectPosition(Layer, X - distance, Y - distance);
        }

        public ObjectPosition Southeast(int distance = 1)
        {
            return new ObjectPosition(Layer, X + distance, Y + distance);
        }

        public ObjectPosition Southwest(int distance = 1)
        {
            return new ObjectPosition(Layer, X - distance, Y + distance);
        }

        public ObjectPosition Towards(ObjectPosition other)
        {
            ObjectPosition position = new ObjectPosition(this);

            if (other.X > position.X)
                position.X++;
            else if (other.X < position.X)
                position.X--;
            if (other.Y > position.Y)
                position.Y++;
            else if (other.Y < position.Y)
                position.Y--;

            return position;
        }

        public ObjectPosition AwayFrom(ObjectPosition other)
        {
            ObjectPosition position = new ObjectPosition(this);

            if (other.X > position.X)
                position.X--;
            else if (other.X < position.X)
                position.X++;
            if (other.Y > position.Y)
                position.Y--;
            else if (other.Y < position.Y)
                position.Y++;

            return position;
        }
    }
}
