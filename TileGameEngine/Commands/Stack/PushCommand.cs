using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.Stack
{
    public class PushCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            string value = immediateParams[0];
            ParamStack.Push(value);
        }
    }
}
