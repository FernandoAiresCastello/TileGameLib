using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.Stack
{
    public class PopCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            ParamStack.DiscardTop();
        }
    }
}
