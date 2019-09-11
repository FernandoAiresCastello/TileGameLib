using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.GameElements;
using TileGameLib.Util;
using TileGameEngine.Windows;
using TileGameEngine.Util;
using Timer = System.Windows.Forms.Timer;
using Environment = TileGameEngine.Core.RuntimeEnvironment.Environment;
using System.Threading;

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

        private int SleepTime = 0;

        private static readonly int CycleInterval = Config.ReadInt("InterpreterCycleInterval");

        public Interpreter(Environment env, Script script)
        {
            Script = script;
            Environment = env;
            CommandDict = new CommandDictionary(this, env);

            FindLabels();

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

            if (TileGameEngineApplication.ErrorRaised)
                return "Execution aborted due to script error";
            else
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
                        TileGameEngineApplication.Error("SCRIPT ERROR", "Duplicate label: " + label);

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
                TileGameEngineApplication.Error("INTERPRETER ERROR", "Interpreter is already running");

            Running = true;
            CycleTimer.Start();
        }

        public void Debug()
        {
            if (Running)
                TileGameEngineApplication.Error("INTERPRETER ERROR", "Interpreter is already debugging");

            Running = true;
        }

        private void CycleTimer_Tick(object sender, EventArgs e)
        {
            WakeUpIfSleeping();
            ExecuteCycle();

            if (!Running)
                CycleTimer.Stop();

            SleepIfRequested();
        }

        private void SleepIfRequested()
        {
            if (Running && SleepTime > 0)
            {
                CycleTimer.Stop();
                CycleTimer.Interval = SleepTime;
                CycleTimer.Start();
                SleepTime = 0;
            }
        }

        private void WakeUpIfSleeping()
        {
            CycleTimer.Interval = CycleInterval;
        }

        public void ExecuteCycle()
        {
            try
            {
                if (ProgramPointer < 0 || ProgramPointer >= Script.Lines.Count)
                    TileGameEngineApplication.Error("INTERPRETER ERROR", "Program pointer past end of script");
                    
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
            catch (Exception ex)
            {
                Stop();
                Alert.Error(ex.Message + "\n" + Script.Lines[ProgramPointer].ToString());

                if (TileGameEngineApplication.ExitIfErrorRaised)
                    TileGameEngineApplication.Exit();
            }
        }

        private void InterpretCommand(ScriptLine line)
        {
            string command = line.Command.ToUpper();
            if (!CommandDict.HasCommand(command))
                TileGameEngineApplication.Error("SCRIPT ERROR", "Unknown command: " + command);

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
                TileGameEngineApplication.Error("INTERPRETER ERROR", "Can't branch to invalid script line: " + line);

            ProgramPointer = line;
        }

        public void Skip()
        {
            ProgramPointer++;
            if (ProgramPointer >= Script.Lines.Count)
                Running = false;
        }

        public void StopAndCloseGameWindow()
        {
            Stop();
            if (Environment.HasWindow)
                Environment.CloseWindow();
        }

        public void Stop()
        {
            Running = false;
            if (CycleTimer != null)
                CycleTimer.Stop();
            
        }

        public void SoftLock()
        {
            Running = false;
        }

        public void Sleep(int ms)
        {
            SleepTime = ms;
        }
    }
}
