﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Engine;
using TileGameLib.GameElements;

namespace TestPlayground
{
    class TestGameEngine : GameEngine
    {
        private const string WindowTitle = "";
        private const int WindowCols = 32;
        private const int WindowRows = 24;
        private const int CycleInterval = 250;
        private const int GfxRefreshInterval = 60;

        private int Cycle = 0;

        public TestGameEngine() : base(WindowTitle, WindowCols, WindowRows, GfxRefreshInterval, CycleInterval)
        {
            MapsBasePath = "maps/";
            LoadUiMap("ui.tgmap");
            SetMapViewport("view0", "view1");

            ObjectMap test01 = LoadMap("test01.tgmap", new TestMapController());

            EnterMap(test01);
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