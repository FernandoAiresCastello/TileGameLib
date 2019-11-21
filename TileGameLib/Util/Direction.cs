using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.Util
{
    public enum Direction
    {
        None, North, Northeast, East, Southeast, South, Southwest, West, Northwest
    }

    public static class DirectionUtils
    {
        public static Point GetOffset(Direction direction)
        {
            if (direction == Direction.East)
                return new Point(1, 0);
            else if (direction == Direction.West)
                return new Point(-1, 0);
            else if (direction == Direction.North)
                return new Point(0, -1);
            else if (direction == Direction.South)
                return new Point(0, 1);
            else if (direction == Direction.Northeast)
                return new Point(1, -1);
            else if (direction == Direction.Northwest)
                return new Point(-1, -1);
            else if (direction == Direction.Southeast)
                return new Point(1, 1);
            else if (direction == Direction.Southwest)
                return new Point(-1, 1);

            return new Point(0, 0);
        }

        public static Direction GetDirection(int dx, int dy)
        {
            if (dx > 0 && dy == 0)
                return Direction.East;
            else if (dx < 0 && dy == 0)
                return Direction.West;
            else if (dy > 0 && dx == 0)
                return Direction.South;
            else if (dy < 0 && dx == 0)
                return Direction.North;
            else if (dx > 0 && dy > 0)
                return Direction.Southeast;
            else if (dx < 0 && dy > 0)
                return Direction.Southwest;
            else if (dx > 0 && dy < 0)
                return Direction.Northeast;
            else if (dx < 0 && dy < 0)
                return Direction.Northwest;

            return Direction.None;
        }
    }
}
