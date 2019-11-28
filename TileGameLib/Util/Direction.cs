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

        public static string GetName(Direction direction)
        {
            switch (direction)
            {
                case Direction.None: return "none";
                case Direction.North: return "north";
                case Direction.Northeast: return "northeast";
                case Direction.East: return "east";
                case Direction.Southeast: return "southeast";
                case Direction.South: return "south";
                case Direction.Southwest: return "southwest";
                case Direction.West: return "west";
                case Direction.Northwest: return "northwest";
            }

            throw new TileGameLibException("Invalid direction: " + direction);
        }

        public static Direction GetByName(string name)
        {
            switch (name.Trim().ToLower())
            {
                case "none": return Direction.None;
                case "north": return Direction.North;
                case "northeast": return Direction.Northeast;
                case "east": return Direction.East;
                case "southeast": return Direction.Southeast;
                case "south": return Direction.South;
                case "southwest": return Direction.Southwest;
                case "west": return Direction.West;
                case "northwest": return Direction.Northwest;
            }

            throw new TileGameLibException("Invalid direction name: " + name);
        }
    }
}
