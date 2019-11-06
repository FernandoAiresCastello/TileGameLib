using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Engine;

namespace TestPlayground
{
    class TestGameEngine : GameEngine
    {
        private const string WindowTitle = "";
        private const int WindowCols = 32;
        private const int WindowRows = 24;
        private const int CycleInterval = 500;

        public TestGameEngine() : base(WindowTitle, WindowCols, WindowRows, CycleInterval)
        {
            LoadUiMap("maps/ui.tgmap");
            SetMapViewport("mapview-top-left", "mapview-bottom-right");
            DrawUi();
            AddMapController("maps/test01.tgmap", new TestMapController());
            AddMapController("maps/test02.tgmap", new TestMapController());
            EnterMap("test02");
        }

        public override void OnDrawUi()
        {
            PrintUi("ind-life", "666");
        }

        public override void OnExecuteCycle()
        {
        }

        public override bool OnGlobalKeyDown(KeyEventArgs e)
        {
            return false;
        }

        public override bool OnGlobalKeyUp(KeyEventArgs e)
        {
            return false;
        }
    }
}
