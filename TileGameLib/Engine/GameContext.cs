using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.Engine
{
    public class GameContext
    {
        public Variables GlobalVars { get; private set; } = new Variables();

        public GameContext()
        {
        }
    }
}
