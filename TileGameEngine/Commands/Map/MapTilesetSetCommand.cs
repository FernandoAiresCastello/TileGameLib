using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Graphics;

namespace TileGameEngine.Commands.Map
{
    public class MapTilesetSetCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            byte[] pattern = new byte[TilePixels.RowCount];
            for (int line = pattern.Length - 1; line >= 0; line--)
                pattern[line] = (byte)PopInt();

            int index = PopInt();

            Environment.SetMapTileset(index, pattern);
        }
    }
}
