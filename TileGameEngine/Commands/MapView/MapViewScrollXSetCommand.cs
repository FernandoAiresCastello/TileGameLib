using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameEngine.Exceptions;

namespace TileGameEngine.Commands.MapView
{
    public class MapViewScrollXSetCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int x = PopInt();
            Environment.SetMapViewScrollX(x);
        }
    }
}
