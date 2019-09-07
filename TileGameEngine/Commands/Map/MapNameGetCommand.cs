using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.Map
{
    public class MapNameGetCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            string name = Environment.GetMapName();
            Push(name);
        }
    }
}
