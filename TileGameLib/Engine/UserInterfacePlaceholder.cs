using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.GameElements;
using TileGameLib.Graphics;

namespace TileGameLib.Engine
{
    public class UserInterfacePlaceholder
    {
        private readonly PositionedObject PositionedObject;

        public Tile Tile => PositionedObject.Object.Tile;
        public ObjectPosition Position => PositionedObject.Position;
        public GameObject Object => PositionedObject.Object;
        public ObjectMap Map => PositionedObject.Map;

        public UserInterfacePlaceholder(PositionedObject po)
        {
            PositionedObject = po;
        }

        public UserInterfacePlaceholder(UserInterfacePlaceholder placeholder)
        {
            PositionedObject = new PositionedObject(placeholder.Map, placeholder.Object, placeholder.Position);
        }

        public UserInterfacePlaceholder(UserInterfacePlaceholder placeholder, int offsetX, int offsetY)
        {
            PositionedObject = new PositionedObject(placeholder.Map, placeholder.Object, 
                placeholder.Position.AtDistance(offsetX, offsetY));
        }

        public UserInterfacePlaceholder Copy()
        {
            return new UserInterfacePlaceholder(this);
        }
    }
}
