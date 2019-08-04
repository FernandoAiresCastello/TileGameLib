using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.GameElements;
using TileGameLib.Util;
using TileGameRunner.Exceptions;

namespace TileGameRunner.Core
{
    public class Interpreter
    {
        public ScriptLabels Labels { get; private set; } = new ScriptLabels();
        public Stack<int> CallStack { get; private set; } = new Stack<int>();
        public Stack ParamStack { get; private set; } = new Stack();
        public bool Running { get; set; } = false;
        public bool Branching { get; set; } = false;
        public int ProgramPtr { get; set; } = 0;

        private readonly Environment Environment;
        private readonly Script Script;
        private readonly CommandDictionary CommandDict;

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

                if (line.IsLabel())
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

            try
            {
                while (Running)
                {
                    ScriptLine line = Script.Lines[ProgramPtr];
                    if (!line.IsLabel() && !line.IsComment())
                        InterpretCommand(line);

                    if (Running)
                    {
                        if (Branching)
                            Branching = false;
                        else
                            ProgramPtr++;
                    }
                }
            }
            catch (ScriptException e)
            {
                Alert.Error(e.Message + "\n" + Script.Lines[ProgramPtr].ToString());
                Application.Exit();
            }
            catch (Exception e)
            {
                Alert.Error(e.Message);
                Application.Exit();
            }
        }

        private void InterpretCommand(ScriptLine line)
        {
            string command = line.CommandName.ToUpper();
            if (!CommandDict.HasCommand(command))
                FatalError($"Unknown command: {command}");

            CommandDict.Get(command).Execute(line.Params);
        }

        public void FatalError(string msg)
        {
            throw new ScriptException(msg);
        }
    }
}
