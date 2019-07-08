using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.GameElements;

namespace TileGameLib.Engine
{
    public class GameContext
    {
        public Variables GlobalVars { get; private set; } = new Variables();
        public Variables LocalVars { get; private set; } = new Variables();

        public ObjectMap CurrentMap
        {
            get { return Map; }

            set
            {
                Map = value;
                LocalVars.Clear();
            }
        }

        private ObjectMap Map;
    }
}
