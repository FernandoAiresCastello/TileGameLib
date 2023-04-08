using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.GameElements;
using TileGameLib.Util;

namespace TileGameMaker.MapEditorElements
{
    public class ScriptRunner
    {
        private readonly ObjectMap Map;

        public ScriptRunner(ObjectMap map)
        {
            Map = map;
        }

        public void Test(string message)
        {
            Alert.Info("This is a test message. You wrote:\n" + message);
        }
    }
}
