using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.Window
{
    public class WindowCursorMoveLeftCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int distance = PopInt();
            Environment.MoveWindowCursor(-distance, 0);
        }
    }
}
