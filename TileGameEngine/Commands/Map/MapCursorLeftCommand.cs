using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.Map
{
    public class MapCursorLeftCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int distance = PopInt();

            Environment.MapCursor.Position.X = Environment.MapCursor.Position.X - distance;
        }
    }
}
