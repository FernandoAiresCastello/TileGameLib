using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.GameElements
{
    public class PositionedObject
    {
        public ObjectMap Map { set; get; }
        public GameObject Object { set; get; }
        public ObjectPosition Position { set; get; }

        public PositionedObject(ObjectMap map, GameObject o, int layer, int x, int y)
            : this(map, o, new ObjectPosition(layer, x, y))
        {
        }

        public PositionedObject(ObjectMap map, GameObject o, ObjectPosition position)
        {
            Map = map;
            Object = o;
            Position = position;
        }

        public PositionedObject(PositionedObject other)
        {
            Map = other.Map;
            Object = other.Object.Copy();
            Position = other.Position.Copy();
        }

        public PositionedObject Copy()
        {
            return new PositionedObject(this);
        }

        public override string ToString()
        {
            return Map.Name + " " + Object.ToString() + " " + Position.ToString();
        }
    }
}
