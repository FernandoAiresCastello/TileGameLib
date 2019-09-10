using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameEngine.Windows;
using Environment = TileGameEngine.Core.RuntimeEnvironment.Environment;

namespace TileGameEngine.Core
{
    public class Engine
    {
        public Form ParentForm { set; get; }
        public int CycleInterval { set; get; }

        private bool Started = false;

        public Engine(Form parent)
        {
            ParentForm = parent;
        }

        public void Run(string mainScriptFile)
        {
            Initialize(mainScriptFile).Run();
        }

        public void Debug(string scriptFile)
        {
            Interpreter interpreter = Initialize(scriptFile);
            DebuggerWindow debugger = new DebuggerWindow(interpreter);

            interpreter.Debug();

            if (ParentForm != null)
                debugger.ShowDialog(ParentForm);
            else
                debugger.Show();
        }

        private Interpreter Initialize(string scriptFile)
        {
            if (Started)
                TileGameEngineApplication.Error("ENGINE ERROR", "Engine has already started");
            if (!File.Exists(scriptFile))
                TileGameEngineApplication.Error("ENGINE ERROR", "Main script file not found: " + scriptFile);

            Started = true;

            string sourceCode = File.ReadAllText(scriptFile);
            Script mainScript = new Script(sourceCode);
            Environment environment = new Environment();
            return new Interpreter(environment, mainScript);
        }
    }
}
