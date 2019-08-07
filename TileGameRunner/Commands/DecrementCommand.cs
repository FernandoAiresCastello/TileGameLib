using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameRunner.Commands
{
    public class DecrementCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int value = PopInt();
            Interpreter.ParamStack.Push((value - 1).ToString());
        }
    }
}
