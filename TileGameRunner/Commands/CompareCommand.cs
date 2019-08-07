using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameRunner.Commands
{
    public class CompareCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int value2 = PopInt();
            int value1 = PopInt();
            int result = value1 - value2;

            Interpreter.ParamStack.Push(result.ToString());
        }
    }
}
