using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.Map
{
    public class MapFileGetCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            string file = Environment.MapFilePath;
            Push(file);
        }
    }
}
