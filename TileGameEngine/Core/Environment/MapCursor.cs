using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.GameElements;

namespace TileGameEngine.Core.RuntimeEnvironment
{
    public class MapCursor
    {
        public ObjectPosition Position { set; get; }

        public bool IsValid
        {
            get
            {
                return Map != null && Position != null &&
                    Position.Layer >= 0 && Position.Layer < Map.Layers.Count &&
                    Position.X >= 0 && Position.X < Map.Width &&
                    Position.Y >= 0 && Position.Y < Map.Height;
            }
        }

        private readonly ObjectMap Map;

        public MapCursor() : this(null, null)
        {
        }

        public MapCursor(ObjectMap map) : this(map, null)
        {
        }

        public MapCursor(ObjectMap map, ObjectPosition position)
        {
            Map = map;
            Position = position;
        }
    }
}
