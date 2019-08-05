using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameRunner.Commands
{
    public class IncrementCommand : CommandBase
    {
        public override void Execute(List<string> param)
        {
            int value = PopInt();
            Interpreter.ParamStack.Push((value + 1).ToString());
        }
    }
}
