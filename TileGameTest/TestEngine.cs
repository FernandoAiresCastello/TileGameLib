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
        private const string MapsFolder = "maps/";

        public static readonly int MessageDuration = 2000;
        public static readonly string BottomPanelTag = "bottom";
        public static readonly string RightPanelTag = "right";

        public Player Player { get; private set; }

        public TestEngine() : base(WindowTitle, WindowCols, WindowRows, GfxRefreshInterval, CycleInterval, MapsFolder)
        {
            Player = new Player();

            LoadUiMap("ui.tgmap");
            Ui.SetMapViewport("view0", "view1");

            ObjectMap firstMap = LoadMap("test01.tgmap", new Test01Controller());
            LoadMap("test02.tgmap", new Test01Controller());

            EnterMap(firstMap);
        }

        public override void OnDrawUi()
        {
        }

        public override void OnExecuteCycle()
        {
        }

        public override bool OnMapTransition(MapController currentController, MapController nextController)
        {
            Player.Map = nextController.Map;

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
