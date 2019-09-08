using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.GameElements;

namespace TileGameEngine.Commands.Map
{
    public class ObjectTagSetCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            string tag = PopStr();
            int y = PopInt();
            int x = PopInt();
            int layer = PopInt();

            Environment.SetObjectTag(layer, x, y, tag);
        }
    }
}
