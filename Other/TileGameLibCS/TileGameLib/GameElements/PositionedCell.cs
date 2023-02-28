using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.GameElements
{
    public class PositionedCell
    {
        public ObjectMap Map { set; get; }
        public ObjectCell Cell { set; get; }
        public ObjectPosition Position { set; get; }

        public PositionedCell(ObjectMap map, int layer, int x, int y)
            : this(map, new ObjectPosition(layer, x, y))
        {
        }

        public PositionedCell(ObjectMap map, ObjectPosition position)
        {
            Map = map;
            Position = position;
            Cell = map.GetCell(position);
        }

        public override string ToString()
        {
            return Cell.ToString() + " " + Position.ToString();
        }
    }
}
