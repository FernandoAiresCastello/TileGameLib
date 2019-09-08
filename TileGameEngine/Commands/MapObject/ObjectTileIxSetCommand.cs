using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.GameElements;

namespace TileGameEngine.Commands.Map
{
    public class ObjectTileIxSetCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int ix = PopInt();
            int frame = PopInt();
            int y = PopInt();
            int x = PopInt();
            int layer = PopInt();

            Environment.SetObjectTileIx(layer, x, y, frame, ix);
        }
    }
}
