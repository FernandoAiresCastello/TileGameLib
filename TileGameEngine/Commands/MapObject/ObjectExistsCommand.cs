using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameEngine.Exceptions;
using TileGameLib.GameElements;

namespace TileGameEngine.Commands.Map
{
    public class ObjectExistsCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            string tag = PopStr();

            ObjectPosition pos = Environment.FindObjectPositionByTag(tag);

            Push(pos == null ? 0 : 1);
        }
    }
}
