using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameRunner.Commands
{
    public class ReturnCommand : CommandBase
    {
        public override void Execute(List<string> paramList)
        {
            if (Interpreter.CallStack.Count == 0)
                Interpreter.FatalError("Can't return. Call stack empty");

            Interpreter.ProgramPtr = Interpreter.CallStack.Pop();
            Interpreter.Branching = true;
        }
    }
}
