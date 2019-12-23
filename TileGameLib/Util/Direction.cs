using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Exceptions;

namespace TileGameLib.Util
{
    public enum Direction
    {
        None,
        North,
        Northeast,
        East,
        Southeast,
        South,
        Southwest,
        West,
        Northwest
    }

    public static class DirectionUtils
    {
        public static Direction GetDirection(int dx, int dy)
        {
            if (dx == 0 && dy == 0)
                return Direction.None;
            else if (dx == 0 && dy < 0)
                return Direction.North;
            else if (dx == 0 && dy > 0)
                return Direction.South;
            else if (dx < 0 && dy == 0)
                return Direction.West;
            else if (dx > 0 && dy == 0)
                return Direction.East;
            else if (dx < 0 && dy < 0)
                return Direction.Northwest;
            else if (dx > 0 && dy < 0)
                return Direction.Northeast;
            else if (dx < 0 && dy > 0)
                return Direction.Southwest;
            else if (dx > 0 && dy > 0)
                return Direction.Southeast;

            return Direction.None;
        }

        public static Point GetOffset(Direction direction)
        {
            switch (direction)
            {
                case Direction.None: return new Point(0, 0);
                case Direction.North: return new Point(0, -1);
                case Direction.Northeast: return new Point(1, -1);
                case Direction.East: return new Point(1, 0);
                case Direction.Southeast: return new Point(1, 1);
                case Direction.South: return new Point(0, 1);
                case Direction.Southwest: return new Point(-1, 1);
                case Direction.West: return new Point(-1, 0);
                case Direction.Northwest: return new Point(-1, -1);

                default: throw new TileGameLibException("Invalid direction: " + direction);
            }
        }
    }
}
