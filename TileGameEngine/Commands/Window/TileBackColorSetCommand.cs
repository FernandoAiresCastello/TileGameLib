using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.Window
{
    public class TileBackColorSetCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int color = PopInt();
            Environment.SetWindowTileBackColor(color);
        }
    }
}
