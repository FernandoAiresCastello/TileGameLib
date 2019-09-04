using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameEngine.Exceptions;

namespace TileGameEngine.Commands.ControlFlow
{
    public class ReturnCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            if (Interpreter.CallStack.Count == 0)
                throw new ScriptException("Can't return. Call stack empty");

            Interpreter.Branch(Interpreter.CallStack.Pop());
        }
    }
}
