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
        public ObjectMap CurrentMap { get; private set; }

        private Interpreter Interpreter;
        private MapEngine MapEngine;

        public GameContext(Interpreter interpreter)
        {
            Interpreter = interpreter;
        }

        public void SetCurrentMap(ObjectMap map)
        {
            if (CurrentMap == null)
                CurrentMap = new ObjectMap(map);
            else
                CurrentMap.SetEqual(map);

            Interpreter.Map = map;
            Interpreter.GameContext = this;
            MapEngine = new MapEngine(this, Interpreter);
        }

        public void ExecuteCycle()
        {
            MapEngine.ExecuteCycle();
        }
    }
}
