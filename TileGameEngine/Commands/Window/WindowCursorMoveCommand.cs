using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.Window
{
    public class WindowCursorMoveCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int y = PopInt();
            int x = PopInt();
            Environment.SetWindowCursorXY(x, y);
        }
    }
}
