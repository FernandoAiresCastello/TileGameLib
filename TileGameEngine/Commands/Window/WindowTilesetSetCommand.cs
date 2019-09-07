using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Graphics;

namespace TileGameEngine.Commands.Window
{
    public class WindowTilesetSetCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            byte[] pattern = new byte[TilePixels.RowCount];
            for (int line = pattern.Length - 1; line >= 0; line--)
                pattern[line] = (byte)PopInt();

            int index = PopInt();

            Environment.SetWindowTileset(index, pattern);
        }
    }
}
