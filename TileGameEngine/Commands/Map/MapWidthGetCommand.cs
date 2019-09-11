using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.Map
{
    public class MapWidthGetCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int width = Environment.GetMapWidth();
            Push(width);
        }
    }
}
