using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.Window
{
    public class WindowPaletteSetCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int rgb = PopInt();
            int index = PopInt();
            Environment.SetWindowPalette(index, rgb);
        }
    }
}
