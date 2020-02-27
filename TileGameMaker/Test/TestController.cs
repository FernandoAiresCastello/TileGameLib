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
            //Ui.SetTimedMessage("bottom", "Henlo world! How are you", 2000);
            //Ui.SetModalMessage("bottom", "Henlo world!", "How are you doing?");
        }

        public override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Ui.TextInput.Input("Enter your name, but beware this\nis going to be a very touch\ndesicion to make. Are you \nabsolutely certain sure you want\nto do it?", 
                    "bottom", "input-start", "input-end", "name", ProcessInput);
            }
        }

        private void ProcessInput(string id, string input)
        {
            Alert.Info(id + "\n" + input);
        }
    }
}
