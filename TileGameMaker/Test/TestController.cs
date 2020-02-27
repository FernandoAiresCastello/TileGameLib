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
        int msgcol = 0;

        public override void OnEnter()
        {
        }

        public override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
                msgcol++;
            if (e.KeyCode == Keys.Left)
                msgcol--;
        }

        public override void OnDrawUi()
        {
            Ui.PrintWrap("In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface.", 
                "bottom", Ui.Graphics.Cols, msgcol);
        }
    }
}
