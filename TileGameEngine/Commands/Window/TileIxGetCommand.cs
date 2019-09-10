using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.Window
{
    public class TileIxGetCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int ix = Environment.GetWindowTileIndex();
            Push(ix);
        }
    }
}
