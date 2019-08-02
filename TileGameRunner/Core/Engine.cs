using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameRunner.Exceptions;

namespace TileGameRunner.Core
{
    public class Engine
    {
        private readonly string MainScriptFile = "main.prg";

        private ProjectArchive ProjectArchive;
        private Interpreter Interpreter;
        private Environment Environment;
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
            Environment = new Environment();
            Script mainScript = ProjectArchive.LoadScript(MainScriptFile);
            Interpreter = new Interpreter(Environment, mainScript);
            Interpreter.Run();
        }
    }
}
