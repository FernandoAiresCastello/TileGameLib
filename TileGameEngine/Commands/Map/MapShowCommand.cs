using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameEngine.Exceptions;

namespace TileGameEngine.Commands.Map
{
    public class MapShowCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            Environment.StartMapRenderer();
        }
    }
}
