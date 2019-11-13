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
        public int YellowKeys { set; get; }
        public int PinkKeys { set; get; }

        public GameObject Object => Find().Object;
        public ObjectPosition Position => Find().Position.Copy();
        public int X => Find().Position.X;
        public int Y => Find().Position.Y;

        public Player()
        {
            Init();
        }

        public void Init()
        {
            Map = null;
            YellowKeys = 0;
            PinkKeys = 0;
        }

        public PositionedObject Find()
        {
            return Map.FindObjectByTag("player");
        }
    }
}
