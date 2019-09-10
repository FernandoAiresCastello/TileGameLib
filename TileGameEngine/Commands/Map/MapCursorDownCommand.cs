using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.Map
{
    public class MapCursorDownCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int distance = PopInt();

            Environment.MapCursor.Position.Y = Environment.MapCursor.Position.Y + distance;
        }
    }
}
