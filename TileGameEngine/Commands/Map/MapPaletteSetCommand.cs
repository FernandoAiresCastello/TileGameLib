using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.Map
{
    public class MapPaletteSetCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int rgb = PopInt();
            int index = PopInt();
            Environment.SetMapPalette(index, rgb);
        }
    }
}
