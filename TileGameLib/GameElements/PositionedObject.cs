using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.GameElements
{
    public class PositionedObject
    {
        public GameObject Object { set; get; }
        public ObjectPosition Position { set; get; }

        public PositionedObject(GameObject o, int layer, int x, int y)
            : this(o, new ObjectPosition(layer, x, y))
        {
        }

        public PositionedObject(GameObject o, ObjectPosition position)
        {
            Object = o;
            Position = position;
        }

        public override string ToString()
        {
            return Object.ToString() + " " + Position.ToString();
        }
    }
}
