using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.GameElements;

namespace TileGameTest
{
    public class Player
    {
        public ObjectMap Map { set; get; }
        public int YellowKeys { set; get; } = 0;
        public int PinkKeys { set; get; } = 0;

        public GameObject Object => Find().Object;
        public ObjectPosition Position => Find().Position.Copy();
        public int X => Find().Position.X;
        public int Y => Find().Position.Y;

        public Player()
        {
        }

        public PositionedObject Find()
        {
            return Map.FindObjectByTag("player");
        }
    }
}
