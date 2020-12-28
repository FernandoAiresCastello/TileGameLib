using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TileGameLib.File;

namespace TileGameEngine
{
    public class Interpreter
    {
        private readonly Environment Env;
        private readonly Thread Thread;
        private readonly Project Project;
        private readonly GameWindow Window;
        private readonly GameProgram Program;
        private bool Running;

        public Interpreter(Environment env)
        {
            Env = env;
            Project = env.Project;
            Window = env.Window;
            Thread = new Thread(Run);
            Program = new GameProgram();
            Running = false;
        }

        public void Start()
        {
            Thread.Start();
        }

        private void Run()
        {
            if (Running)
                return;

            Program.Parse(Project.Program);

            Running = true;
            while (Running)
            {
                // todo
            }

            Thread.Abort();
        }
    }
}
