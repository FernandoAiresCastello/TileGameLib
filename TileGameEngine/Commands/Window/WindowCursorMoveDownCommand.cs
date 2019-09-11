using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.Window
{
    public class WindowCursorMoveDownCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int distance = PopInt();
            Environment.MoveWindowCursor(0, distance);
        }
    }
}
