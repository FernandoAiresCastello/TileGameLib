using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.GameElements
{
    public class PositionedCell
    {
        public ObjectCell Cell { set; get; }
        public ObjectPosition Position { set; get; }

        public PositionedCell(ObjectCell cell, int layer, int x, int y)
            : this(cell, new ObjectPosition(layer, x, y))
        {
        }

        public PositionedCell(ObjectCell cell, ObjectPosition position)
        {
            Cell = cell;
            Position = position;
        }

        public override string ToString()
        {
            return Cell.ToString() + " " + Position.ToString();
        }
    }
}
