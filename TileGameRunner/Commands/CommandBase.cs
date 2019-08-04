using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameRunner.Core;
using TileGameRunner.Exceptions;
using Environment = TileGameRunner.Core.Environment;

namespace TileGameRunner.Commands
{
    public class CommandBase
    {
        public Interpreter Interpreter { set; get; }
        public Environment Environment { set; get; }

        public CommandBase()
        {
        }

        public virtual void Execute(List<string> paramList)
        {
            FatalError("Command not implemented");
        }

        public void FatalError(string msg)
        {
            Interpreter.FatalError(msg);
        }

        public void Jump(string label)
        {
            if (!Interpreter.Labels.HasLabel(label))
                FatalError($"Label {label} not found");

            Interpreter.ProgramPtr = Interpreter.Labels.Get(label);
            Interpreter.Branching = true;
        }

        public void Call(string label)
        {
            if (!Interpreter.Labels.HasLabel(label))
                FatalError($"Label {label} not found");

            Interpreter.CallStack.Push(Interpreter.ProgramPtr);
            Interpreter.ProgramPtr = Interpreter.Labels.Get(label);
            Interpreter.Branching = true;
        }
    }
}
