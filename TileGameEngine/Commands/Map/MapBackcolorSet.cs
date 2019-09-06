using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameEngine.Exceptions;

namespace TileGameEngine.Commands.Map
{
    public class MapBackColorSetCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int color = PopInt();
            Environment.SetMapBackColor(color);
        }
    }
}
