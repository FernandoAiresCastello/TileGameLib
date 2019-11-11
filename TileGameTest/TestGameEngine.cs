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
        private const int CycleInterval = 250;

        private int Cycle = 0;

        public TestGameEngine() : base(WindowTitle, WindowCols, WindowRows, CycleInterval)
        {
            LoadUiMap("maps/ui.tgmap");
            SetMapViewport("view0", "view1");
            AddMapController("maps/test01.tgmap", new TestMapController());
            EnterMap("test01");
        }

        public override void OnDrawUi()
        {
            PrintUi("bottom", "Cycle: " + Cycle);
        }

        public override void OnExecuteCycle()
        {
            Cycle++;
        }

        public override bool OnKeyDown(KeyEventArgs e)
        {
            return false;
        }

        public override bool OnKeyUp(KeyEventArgs e)
        {
            return false;
        }
    }
}
