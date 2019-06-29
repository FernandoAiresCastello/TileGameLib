using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.GameElements;

namespace TileGameLib.Engine
{
    public class MapEngine
    {
        private GameContext GameContext;
        private Interpreter Interpreter;
        private List<ScriptedGameObject> ScriptedObjects = new List<ScriptedGameObject>();
        private readonly Stack ParamStack = new Stack();
        private readonly Variables LocalVars = new Variables();

        public MapEngine(GameContext ctx, Interpreter interpreter)
        {
            GameContext = ctx;
            Interpreter = interpreter;
            FindScriptedObjects();
        }

        private void FindScriptedObjects()
        {
            ScriptedObjects.Clear();
            ObjectMap map = GameContext.CurrentMap;

            for (int layer = 0; layer < map.Layers.Count; layer++)
            {
                for (int y = 0; y < map.Height; y++)
                {
                    for (int x = 0; x < map.Width; x++)
                    {
                        GameObject o = map.GetObject(layer, x, y);
                        if (o.HasScript)
                            ScriptedObjects.Add(new ScriptedGameObject(o));
                    }
                }
            }
        }

        public void ExecuteCycle()
        {
            foreach (ScriptedGameObject o in ScriptedObjects)
            {
                Interpreter.Run(o);
            }
        }
    }
}
