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
        public Tile Tile { set; get; }
        public ObjectPosition Position { set; get; }

        public UserInterfacePlaceholder(Tile tile, int x, int y)
        {
            Tile = tile.Copy();
            Position = new ObjectPosition(0, x, y);
        }
    }
}
