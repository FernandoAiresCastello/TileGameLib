using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameEngine.Core;
using TileGameEngine.Exceptions;
using Environment = TileGameEngine.Core.Environment;

namespace TileGameEngine.Commands
{
    public class CommandBase
    {
        public Interpreter Interpreter { set; get; }
        public Environment Environment { set; get; }
        public Stack ParamStack => Interpreter.ParamStack;

        public CommandBase()
        {
        }

        public virtual void Execute(List<string> immediateParams)
        {
            throw new ScriptException("Command not implemented");
        }

        public void Jump(string label)
        {
            AssertLabel(label);
            Interpreter.ProgramPtr = Interpreter.Labels.Get(label);
            Interpreter.Branching = true;
        }

        public void Call(string label)
        {
            AssertLabel(label);
            Interpreter.CallStack.Push(Interpreter.ProgramPtr + 1);
            Interpreter.ProgramPtr = Interpreter.Labels.Get(label);
            Interpreter.Branching = true;
        }

        public void AssertVariable(string param)
        {
            if (!param.StartsWith("$"))
                throw new ScriptException("Expected a variable name");
        }

        public void AssertLabel(string param)
        {
            if (!Interpreter.Labels.HasLabel(param))
                throw new ScriptException($"Label {param} not found");
        }

        public int PopInt()
        {
            if (Interpreter.ParamStack.Size == 0)
                throw new ScriptException("Parameter stack is empty");

            return Interpreter.ParamStack.PopInt();
        }

        public string PopStr()
        {
            if (Interpreter.ParamStack.Size == 0)
                throw new ScriptException("Parameter stack is empty");

            return Interpreter.ParamStack.PopStr();
        }

        public int TopInt()
        {
            if (Interpreter.ParamStack.Size == 0)
                throw new ScriptException("Parameter stack is empty");

            return Interpreter.ParamStack.TopInt();
        }
    }
}
