using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Engine;
using TileGameLib.GameElements;

namespace TileGameTest
{
    class TestEngine : GameEngine
    {
        private const string WindowTitle = "";
        private const int WindowCols = 32;
        private const int WindowRows = 24;
        private const int CycleInterval = 250;
        private const int GfxRefreshInterval = 60;
        private const int MessageDuration = 2000;

        public TestEngine() : base(WindowTitle, WindowCols, WindowRows, GfxRefreshInterval, CycleInterval)
        {
            MapsBasePath = "maps/";
            LoadUiMap("ui.tgmap");
            SetMapViewport("view0", "view1");

            ObjectMap test01 = LoadMap("test01.tgmap", new Test01Controller());

            EnterMap(test01);
        }

        public void ShowMessage(string text)
        {
            ShowMessage("bottom", text, MessageDuration);
        }

        public override void OnDrawUi()
        {
        }

        public override void OnExecuteCycle()
        {
        }

        public override bool OnMapTransition(MapController currentController, MapController nextController)
        {
            return true;
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
