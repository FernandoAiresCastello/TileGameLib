using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameEngine.Exceptions;

namespace TileGameEngine.Commands.MapView
{
    public class MapViewWidthSetCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int width = PopInt();
            Environment.SetMapViewWidth(width);
        }
    }
}
