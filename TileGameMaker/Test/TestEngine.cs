using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Engine;
using TileGameLib.GameElements;
using TileGameLib.Util;

namespace TileGameMaker.Test
{
    public class TestEngine : GameEngine
    {
        private const int Cols = 25;
        private const int Rows = 25;
        private const int Zoom = 3;
        private const int CycleInterval = 10;

        public TestEngine() : base("Test", Cols, Rows, Zoom, CycleInterval, true, true)
        {
        }

        public override bool OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Exit();
                return true;
            }

            return false;
        }
    }
}
