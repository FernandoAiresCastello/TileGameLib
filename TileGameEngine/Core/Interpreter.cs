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
using TileGameEngine.Util;

namespace TileGameEngine.Core
{
    public class Interpreter
    {
        public Environment Environment { get; private set; }
        public ScriptLabels Labels { get; private set; } = new ScriptLabels();
        public CallStack CallStack { get; private set; } = new CallStack();
        public ParameterStack ParamStack { get; private set; } = new ParameterStack();
        public bool Running { get; private set; } = false;
        public bool Branching { get; private set; } = false;
        public int ProgramPointer { get; private set; } = 0;

        public List<string> ScriptLinesForDebugger => GetScriptLinesForDebugger();
        public string CurrentLineForDebugger => GetCurrentLineForDebugger();

        private readonly Script Script;
        private readonly Timer CycleTimer;
        private readonly CommandDictionary CommandDict;
        private bool DebugMode;

        private static readonly int CycleInterval = Config.ReadInt("InterpreterCycleInterval");

        public Interpreter(Environment env, Script script)
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
                Environment.ExitApplication();
            }

            CycleTimer = new Timer();
            CycleTimer.Tick += CycleTimer_Tick;
            CycleTimer.Interval = CycleInterval;
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
            Branching = true;
            Running = true;
            ProgramPointer = 0;
        }

        public void Run()
        {
            if (Running)
                throw new InterpreterException("Interpreter is already running");

            Environment.ExitIfGameWindowClosed = true;
            Running = true;
            DebugMode = false;
            CycleTimer.Start();
        }

        public void Debug()
        {
            if (Running)
                throw new InterpreterException("Interpreter is already running");

            Environment.ExitIfGameWindowClosed = false;
            Running = true;
            DebugMode = true;
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
                if (!DebugMode)
                    Environment.ExitApplication();
            }
            catch (ScriptException ex)
            {
                CycleTimer.Stop();
                AlertCurrentLineException(ex);
                if (!DebugMode)
                    Environment.ExitApplication();
            }
            catch (EnvironmentException ex)
            {
                CycleTimer.Stop();
                AlertCurrentLineException(ex);
                if (!DebugMode)
                    Environment.ExitApplication();
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

        public void SoftLock()
        {
            Running = false;
        }

        public void Exit()
        {
            Stop();
            if (!DebugMode)
                Environment.ExitApplication();
        }

        public void ForceExit()
        {
            Stop();
            Environment.ExitApplication();
        }
    }
}
