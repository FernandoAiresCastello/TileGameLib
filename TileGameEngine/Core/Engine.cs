using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameEngine.Exceptions;
using TileGameEngine.Windows;

namespace TileGameEngine.Core
{
    public class Engine
    {
        public Form ParentForm { set; get; }
        public int CycleInterval { set; get; } = 100;

        private bool Started = false;

        public Engine()
        {
        }

        public void Run(string mainScriptFile, int cycleInterval)
        {
            CycleInterval = cycleInterval;
            Run(mainScriptFile);
        }

        public void Run(string mainScriptFile)
        {
            if (Started)
                throw new EngineException("Engine has already started");
            if (!File.Exists(mainScriptFile))
                throw new EngineException($"Script file {mainScriptFile} not found");

            Started = true;

            string sourceCode = File.ReadAllText(mainScriptFile);
            Script mainScript = new Script(sourceCode);
            Environment environment = new Environment();
            Interpreter interpreter = new Interpreter(environment, mainScript, CycleInterval);

            interpreter.Run();
        }

        public void DebugScript(string scriptFile)
        {
            if (Started)
                throw new EngineException("Engine has already started");
            if (!File.Exists(scriptFile))
                throw new EngineException($"Script file {scriptFile} not found");

            Started = true;

            string sourceCode = File.ReadAllText(scriptFile);
            Script mainScript = new Script(sourceCode);
            Environment environment = new Environment();
            Interpreter interpreter = new Interpreter(environment, mainScript);
            DebuggerWindow debugger = new DebuggerWindow(interpreter);

            interpreter.Debug();

            if (ParentForm != null)
                debugger.ShowDialog(ParentForm);
            else
                debugger.Show();
        }
    }
}
