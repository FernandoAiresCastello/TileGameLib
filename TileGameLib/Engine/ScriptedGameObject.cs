using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.GameElements;

namespace TileGameLib.Engine
{
    public class ScriptedGameObject
    {
        public GameObject GameObject { get; private set; }
        public Script Script { get; private set; }

        public ScriptedGameObject(GameObject o)
        {
            GameObject = o;
            Script = new Script(o.Script);
        }
    }
}
