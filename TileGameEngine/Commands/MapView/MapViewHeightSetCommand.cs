using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameEngine.Exceptions;

namespace TileGameEngine.Commands.MapView
{
    public class MapViewHeightSetCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int height = PopInt();
            Environment.SetMapViewHeight(height);
        }
    }
}
