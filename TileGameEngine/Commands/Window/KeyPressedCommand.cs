using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.Window
{
    public class KeyPressedCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            string keyname = PopStr();
            bool pressed = Environment.IsKeyPressed(keyname);
            Push(pressed ? 1 : 0);
        }
    }
}
