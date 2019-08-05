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

        public virtual void Execute(List<string> param)
        {
            throw new ScriptException("Command not implemented");
        }

        public void Jump(string label)
        {
            AssertParamLabel(label);
            Interpreter.ProgramPtr = Interpreter.Labels.Get(label);
            Interpreter.Branching = true;
        }

        public void Call(string label)
        {
            AssertParamLabel(label);
            Interpreter.CallStack.Push(Interpreter.ProgramPtr);
            Interpreter.ProgramPtr = Interpreter.Labels.Get(label);
            Interpreter.Branching = true;
        }

        public void AssertParamVariable(string param)
        {
            if (!param.StartsWith("$"))
                throw new ScriptException("Expected a variable name");
        }

        public void AssertParamInt(string param)
        {
            bool ok = true;

            if (param.StartsWith("0x"))
                ok = param.ToUpper().All(c => (c >= '0' && c <= '9') || c >= 'A' && c <= 'F');
            else if (param.StartsWith("0b"))
                ok = param.All(c => c == '0' || c == '1');
            else
                ok = param.All(c => c >= '0' || c <= '9');

            if (!ok)
                throw new ScriptException("Expected an integer number");
        }

        public void AssertParamLabel(string param)
        {
            if (!Interpreter.Labels.HasLabel(param))
                throw new ScriptException($"Label {param} not found");
        }

        public string VariableName(string param)
        {
            return param.Substring(1);
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
