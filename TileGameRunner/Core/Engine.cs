using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameRunner.Exceptions;
using TileGameRunner.Windows;

namespace TileGameRunner.Core
{
    public class Engine
    {
        private readonly string MainScriptFile = "main.prg";
        private readonly int CycleInterval = 100;

        private bool Started = false;

        public Engine()
        {
        }

        public void Run(ProjectArchive project)
        {
            if (Started)
                throw new EngineException("Engine has already started");
            if (!project.Contains(MainScriptFile))
                throw new EngineException($"Main script {MainScriptFile} not found");

            Started = true;

            new Interpreter(new Environment(project), project.LoadScript(MainScriptFile), CycleInterval).Run();
        }

        public void DebugScript(string scriptFile)
        {
            if (Started)
                throw new EngineException("Engine has already started");

            Started = true;

            new DebuggerWindow(new Interpreter(new Environment(null), new Script(scriptFile))).Show();
        }
    }
}
