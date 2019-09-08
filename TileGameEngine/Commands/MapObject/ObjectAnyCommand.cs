using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.GameElements;

namespace TileGameEngine.Commands.Map
{
    public class ObjectAnyCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int y = PopInt();
            int x = PopInt();
            int layer = PopInt();

            GameObject o = Environment.GetObjectRefAt(layer, x, y);

            Push(o != null ? 1 : 0);
        }
    }
}
