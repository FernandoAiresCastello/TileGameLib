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
        private const string WindowTitle = "Test Game";
        private const int WindowCols = 32;
        private const int WindowRows = 24;
        private const int CycleInterval = 250;
        private const int GfxRefreshInterval = 60;
        private const int MessageDuration = 2000;
        private const string MapsFolder = "maps/";

        public TestEngine() : base(WindowTitle, WindowCols, WindowRows, GfxRefreshInterval, CycleInterval, MapsFolder)
        {
            LoadUiMap("ui.tgmap");
            SetMapViewport("view0", "view1");

            ObjectMap test01 = LoadMap("test01.tgmap", new Test01Controller());

            EnterMap(test01);
        }

        public void ShowMessage(params string[] messages)
        {
            ShowMessage("bottom", MessageDuration, messages);
        }

        public void PrintUi(string text, int offsetX, int offsetY)
        {
            PrintUi("bottom", offsetX, offsetY, text);
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
