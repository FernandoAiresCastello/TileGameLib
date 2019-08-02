using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.GameElements;
using TileGameRunner.Exceptions;

namespace TileGameRunner.Core
{
    public class Interpreter
    {
        private readonly Environment Environment;
        private readonly Script Script;
        private readonly ScriptLabels Labels = new ScriptLabels();
        private readonly Stack ParamStack = new Stack();
        private readonly Stack<int> CallStack = new Stack<int>();
        private readonly CommandDictionary CommandDict;
        private int ProgramPtr = 0;
        private bool Running = false;
        private bool Branching = false;

        public Interpreter(Environment env, Script script)
        {
            Script = script;
            Environment = env;
            CommandDict = new CommandDictionary(this, env);
            FindLabels();
        }

        private void FindLabels()
        {
            Labels.Clear();

            for (int i = 0; i < Script.Lines.Count; i++)
            {
                ScriptLine line = Script.Lines[i];

                if (line.CommandName.StartsWith(Script.Label))
                {
                    string label = line.CommandName.Substring(1);
                    if (Labels.HasLabel(label))
                        FatalError($"Duplicate label {label}");

                    Labels.Add(label, i + 1);
                }
            }
        }

        public void Reset()
        {
            Environment.Reset();
            ParamStack.Clear();
            CallStack.Clear();
            ProgramPtr = 0;
        }

        public void Run()
        {
            if (Running)
                throw new InterpreterException("Interpreter is already running");

            Running = true;
            Branching = false;

            while (Running)
            {
                ScriptLine cmd = Script.Lines[ProgramPtr];
                InterpretCommand(cmd);

                if (Running)
                {
                    if (Branching)
                        Branching = false;
                    else
                        ProgramPtr++;
                }
            }
        }

        private void InterpretCommand(ScriptLine cmd)
        {
            if (!CommandDict.HasCommand(cmd.CommandName))
                FatalError($"Unknown command: {cmd.CommandName}");

            CommandDict.Get(cmd.CommandName).Execute(cmd.Params);
        }

        public void FatalError(string msg)
        {
            throw new ScriptException(msg);
        }

        public void Exit()
        {
            Running = false;
        }

        public void Jump(string label)
        {
            if (!Labels.HasLabel(label))
                FatalError($"Label {label} not found");

            ProgramPtr = Labels.Get(label);
            Branching = true;
        }

        public void Call(string label)
        {
            if (!Labels.HasLabel(label))
                FatalError($"Label {label} not found");

            CallStack.Push(ProgramPtr);
            ProgramPtr = Labels.Get(label);
            Branching = true;
        }

        public void Return()
        {
            if (CallStack.Count == 0)
                FatalError("Can't return. Call stack empty");

            ProgramPtr = CallStack.Pop();
            Branching = true;
        }
    }
}
