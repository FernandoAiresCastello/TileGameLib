using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.GameElements;

namespace TileGameEngine.Commands.Map
{
    public class ObjectIdSetCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            string id = PopStr();
            int y = PopInt();
            int x = PopInt();
            int layer = PopInt();

            Environment.SetObjectId(layer, x, y, id);
        }
    }
}
