using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Engine;
using TileGameLib.Util;

namespace TileGameMaker.Test
{
    public class TestController : MapController
    {
        public override void OnEnter()
        {
            Ui.SetModalMessage("msg", "Hello world");
        }

        public override void OnKeyDown(KeyEventArgs e)
        {
        }

        public override void OnDrawUi()
        {
            int y = 19;
            Ui.Print("H 100", 0, y++, 1);
            Ui.Print("M  20", 0, y++, 1);
            Ui.Print("G   0", 0, y++, 1);
        }
    }
}
