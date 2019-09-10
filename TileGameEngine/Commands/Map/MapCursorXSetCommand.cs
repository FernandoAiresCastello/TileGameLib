using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.Map
{
    public class MapCursorXSetCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int x = PopInt();

            Environment.MapCursor.Position.X = x;
        }
    }
}
