using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.Window
{
    public class WindowBgGetCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int color = Environment.GetWindowBackColor();
            Push(color);
        }
    }
}
