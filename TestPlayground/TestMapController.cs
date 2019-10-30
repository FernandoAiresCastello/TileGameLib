using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Engine;

namespace TestPlayground
{
    class TestMapController : MapController
    {
        public TestMapController() : base("test01.tgmap")
        {
        }

        public override void OnEnter()
        {
        }

        public override void OnLeave()
        {
        }

        public override void OnExecuteCycle()
        {
        }

        public override void OnKeyDown(KeyEventArgs e)
        {
        }

        public override void OnKeyUp(KeyEventArgs e)
        {
        }
    }
}
