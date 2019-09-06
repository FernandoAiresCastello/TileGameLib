﻿using System;
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
        public ParameterStack ParamStack => Interpreter.ParamStack;
        public CallStack CallStack => Interpreter.CallStack;

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
            Interpreter.Branch(Interpreter.Labels.Get(label));
        }

        public void Call(string label)
        {
            AssertLabel(label);
            CallStack.Push(Interpreter.ProgramPointer + 1);
            Interpreter.Branch(Interpreter.Labels.Get(label));
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

        public void AssertParamStackNotEmpty()
        {
            if (ParamStack.IsEmpty)
                throw new ScriptException("Parameter stack is empty");
        }

        public int PopInt()
        {
            AssertParamStackNotEmpty();
            return ParamStack.PopInt();
        }

        public string PopStr()
        {
            AssertParamStackNotEmpty();
            return ParamStack.PopStr();
        }

        public int TopInt()
        {
            AssertParamStackNotEmpty();
            return ParamStack.TopInt();
        }

        public void Push(object value)
        {
            ParamStack.Push(value);
        }
    }
}
