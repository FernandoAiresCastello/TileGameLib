using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Engine;
using TileGameLib.Util;

namespace TileGameMaker.Test
{
    public class TestEngine : GameEngine
    {
        private const int Cols = 20;
        private const int Rows = 24;
        private const int Zoom = 3;
        private const int UiRefreshInterval = 10;
        private const int CycleInterval = 10;

        public TestEngine() : base("Test", Cols, Rows, Zoom, UiRefreshInterval, CycleInterval, true, true)
        {
            //LoadUiMap("ui.tgmap");
            //Ui.SetMapViewport("map-tl", "map-br");
            Window.Size = new Size(500, 500);
            Ui.SetMapViewport(0, 0, 20, 19);
            LoadMap("test01.tgmap", new TestController());
            EnterMap("Test 01");
        }
    }
}
