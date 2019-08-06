using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameRunner.Exceptions;

namespace TileGameRunner.Core
{
    public class Engine
    {
        private readonly string MainScriptFile = "main.prg";
        private readonly int CycleInterval = 100;

        private readonly ProjectArchive ProjectArchive;
        private bool Started = false;

        public Engine(string projectPath)
        {
            if (!File.Exists(projectPath))
                throw new EngineException($"Project file not found in {projectPath}");

            ProjectArchive = new ProjectArchive(projectPath);

            if (!ProjectArchive.Contains(MainScriptFile))
                throw new EngineException($"Main script {MainScriptFile} not found");
        }

        public void Start()
        {
            if (Started)
                throw new EngineException("Engine has already started");

            Started = true;

            new Interpreter(new Environment(ProjectArchive), ProjectArchive.LoadScript(MainScriptFile), CycleInterval).Run();
        }
    }
}
