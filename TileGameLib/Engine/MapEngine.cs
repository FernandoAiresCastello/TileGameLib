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
        private ObjectMap Map;
        private Interpreter Interpreter;
        private List<ScriptedGameObject> ScriptedObjects = new List<ScriptedGameObject>();
        private readonly Stack ParamStack = new Stack();
        private readonly Variables LocalVars = new Variables();

        public MapEngine(GameContext ctx, ObjectMap map)
        {
            GameContext = ctx;
            Map = map;
            Interpreter = new Interpreter(ctx, map);
            FindScriptedObjects();
        }

        private void FindScriptedObjects()
        {
            ScriptedObjects.Clear();

            for (int layer = 0; layer < Map.Layers.Count; layer++)
            {
                for (int y = 0; y < Map.Height; y++)
                {
                    for (int x = 0; x < Map.Width; x++)
                    {
                        GameObject o = Map.GetObject(layer, x, y);
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
