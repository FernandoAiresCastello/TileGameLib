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
        public Script Script { get; set; }

        private readonly Timer CycleTimer;
        private readonly Environment Environment;
        private readonly CommandDictionary CommandDict;

        public Interpreter(Environment env, Script script, int cycleInterval)
        {
            Script = script;
            Environment = env;
            CommandDict = new CommandDictionary(this, env);
            FindLabels();

            CycleTimer = new Timer();
            CycleTimer.Interval = cycleInterval;
            CycleTimer.Tick += CycleTimer_Tick;
        }

        private void FindLabels()
        {
            Labels.Clear();

            for (int i = 0; i < Script.Lines.Count; i++)
            {
                ScriptLine line = Script.Lines[i];

                if (line.IsLabel())
                {
                    string label = line.Command.Substring(1);
                    if (Labels.HasLabel(label))
                        throw new ScriptException($"Duplicate label {label}");

                    Labels.Add(label, i + 1);
                }
            }
        }

        public void Run()
        {
            if (Running)
                throw new InterpreterException("Interpreter is already running");

            Running = true;
            Branching = false;
            CycleTimer.Start();
        }

        private void CycleTimer_Tick(object sender, EventArgs e)
        {
            ExecuteCycle();

            if (!Running)
                CycleTimer.Stop();
        }

        private void ExecuteCycle()
        {
            try
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

                if (ProgramPtr < 0 || ProgramPtr >= Script.Lines.Count)
                    Running = false;
            }
            catch (ScriptException ex)
            {
                Alert.Error(ex.Message + "\n" + Script.Lines[ProgramPtr].ToString());
                Application.Exit();
            }
            catch (Exception ex)
            {
                Alert.Error(ex.Message);
                Application.Exit();
            }
        }

        private void InterpretCommand(ScriptLine line)
        {
            string command = line.Command.ToUpper();
            if (!CommandDict.HasCommand(command))
                throw new ScriptException($"Unknown command: {command}");

            CommandDict.Get(command).Execute(line.Params);
        }
    }
}
