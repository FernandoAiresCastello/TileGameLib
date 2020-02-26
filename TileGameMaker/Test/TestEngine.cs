using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Engine;
using TileGameLib.Util;

namespace TileGameMaker.Test
{
    public class TestEngine : GameEngine
    {
        public TestEngine() : base("Test", 32, 24, 2, 10, 10, true, true, "")
        {
            LoadUiMap("ui.tgmap");
            Ui.SetMapViewport("map-tl", "map-br");

            LoadMap("test01.tgmap", new TestController());
            EnterMap("Test 01");
        }
    }
}
