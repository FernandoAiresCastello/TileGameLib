using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.GameElements
{
    public class TrackedObject
    {
        public ObjectPosition Position { get; private set; }
        public ObjectPosition InitialPosition { get; private set; }

        public TrackedObject(ObjectMap map, string objectId)
        {
            PositionedObject obj = map.FindObjectById(objectId);
            InitialPosition = obj.Position;
        }
    }
}
