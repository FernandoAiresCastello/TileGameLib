using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.Map
{
    public class MapHeightGetCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int height = Environment.GetMapHeight();
            Push(height);
        }
    }
}
