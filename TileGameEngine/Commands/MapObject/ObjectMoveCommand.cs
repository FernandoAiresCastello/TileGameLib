using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.GameElements;

namespace TileGameEngine.Commands.Map
{
    public class ObjectMoveCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int destY = PopInt();
            int destX = PopInt();
            int destLayer = PopInt();

            Environment.MoveObject(new ObjectPosition(destLayer, destX, destY));
        }
    }
}
