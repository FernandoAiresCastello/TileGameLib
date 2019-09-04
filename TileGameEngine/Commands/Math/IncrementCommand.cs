using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.Math
{
    public class IncrementCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int value = PopInt();
            ParamStack.Push(value + 1);
        }
    }
}
