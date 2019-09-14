using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.Window
{
    public class TileFillCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int bg = PopInt();
            int fg = PopInt();
            int ix = PopInt();

            Environment.FillWindowTiles(ix, fg, bg);
        }
    }
}
