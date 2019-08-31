using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.GameElements;
using TileGameLib.Util;
using TileGameEngine.Exceptions;
using TileGameEngine.Windows;

namespace TileGameEngine.Core
{
    public class Interpreter
    {
        public Environment Environment { get; private set; }
        public ScriptLabels Labels { get; private set; } = new ScriptLabels();
        public Stack<int> CallStack { get; private set; } = new Stack<int>();
        public Stack ParamStack { get; private set; } = new Stack();
        public bool Running { get; private set; } = false;
        public bool Branching { get; private set; } = false;
        public int ProgramPointer { get; private set; } = 0;

        public List<string> ScriptLinesForDebugger => GetScriptLinesForDebugger();
        public string CurrentLineForDebugger => GetCurrentLineForDebugger();

        private readonly Script Script;
        private readonly Timer CycleTimer;
        private readonly CommandDictionary CommandDict;
        private bool ExitOnException;

        public Interpreter(Environment env, Script script, int cycleInterval = 0)
        {
            Script = script;
            Environment = env;
            CommandDict = new CommandDictionary(this, env);

            try
            {
                FindLabels();
            }
            catch (ScriptException ex)
            {
                Alert.Error(ex.Message);
                Application.Exit();
            }

            CycleTimer = new Timer();
            CycleTimer.Tick += CycleTimer_Tick;
            if (cycleInterval > 0)
                CycleTimer.Interval = cycleInterval;
        }

        private List<string> GetScriptLinesForDebugger()
        {
            List<string> lines = new List<string>();

            foreach (ScriptLine line in Script.Lines)
                lines.Add(line.ToDebuggerString());

            return lines;
        }

        private string GetCurrentLineForDebugger()
        {
            if (Running)
            {
                if (ProgramPointer >= 0)
                {
                    if (ProgramPointer < Script.Lines.Count)
                        return Script.Lines[ProgramPointer].ToDebuggerString();
                    if (ProgramPointer >= Script.Lines.Count)
                        return "Program pointer past end of script";
                }

                return "Invalid program pointer";
            }

            return "Execution finished";
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
                        throw new ScriptException("Duplicate label: " + label);

                    Labels.Add(label, i);
                }
            }
        }

        public void Reset()
        {
            Environment.Reset();
            CallStack.Clear();
            ParamStack.Clear();
            Branching = false;
            Running = true;
            ProgramPointer = 0;
        }

        public void Run()
        {
            if (Running)
                throw new InterpreterException("Interpreter is already running");

            ExitOnException = true;
            Environment.ExitIfGameWindowClosed = true;
            Running = true;
            CycleTimer.Start();
        }

        public void Debug()
        {
            if (Running)
                throw new InterpreterException("Interpreter is already running");

            ExitOnException = false;
            Environment.ExitIfGameWindowClosed = false;
            Running = true;
        }

        private void CycleTimer_Tick(object sender, EventArgs e)
        {
            ExecuteCycle();

            if (!Running)
                CycleTimer.Stop();
        }

        public void ExecuteCycle()
        {
            try
            {
                if (ProgramPointer < 0 || ProgramPointer >= Script.Lines.Count)
                    throw new InterpreterException("Program pointer past end of script");
                    
                ScriptLine line = Script.Lines[ProgramPointer];
                if (!line.IsLabel() && !line.IsComment())
                    InterpretCommand(line);

                if (Running)
                {
                    if (Branching)
                        Branching = false;
                    else
                        ProgramPointer++;
                }

                if (ProgramPointer < 0 || ProgramPointer >= Script.Lines.Count)
                    Running = false;
            }
            catch (InterpreterException ex)
            {
                CycleTimer.Stop();
                Alert.Error(ex.Message);
                if (ExitOnException)
                    Application.Exit();
            }
            catch (ScriptException ex)
            {
                CycleTimer.Stop();
                AlertCurrentLineException(ex);
                if (ExitOnException)
                    Application.Exit();
            }
            catch (EnvironmentException ex)
            {
                CycleTimer.Stop();
                AlertCurrentLineException(ex);
                if (ExitOnException)
                    Application.Exit();
            }
        }

        private void AlertCurrentLineException(Exception ex)
        {
            Alert.Error(ex.Message + "\n" + Script.Lines[ProgramPointer].ToString());
        }

        private void InterpretCommand(ScriptLine line)
        {
            string command = line.Command.ToUpper();
            if (!CommandDict.HasCommand(command))
                throw new ScriptException($"Unknown command: {command}");

            CommandDict.Get(command).Execute(line.Params);
        }

        public void Branch(int line)
        {
            SetProgramPointer(line);
            Branching = true;
        }

        public void SetProgramPointer(int line)
        {
            if (line < 0 || line >= Script.Lines.Count)
                throw new InterpreterException($"Can't branch to invalid script line {line}");

            ProgramPointer = line;
        }

        public void Skip()
        {
            ProgramPointer++;
            if (ProgramPointer >= Script.Lines.Count)
                Running = false;
        }

        public void Stop()
        {
            Running = false;
            if (Environment.HasWindow)
                Environment.CloseWindow();
        }
    }
}
