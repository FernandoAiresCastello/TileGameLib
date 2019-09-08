using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.Window
{
    public class TilePutCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int ix = PopInt();
            Environment.PutTile(ix);
        }
    }
}
