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
        private readonly ExecutionEnvironment Env;
        private readonly Thread Thread;
        private readonly Project Project;
        private readonly GameWindow Window;
        private readonly GameProgram Program;
        private readonly Commands Commands;
        private bool Running;

        public Interpreter(ExecutionEnvironment env)
        {
            Env = env;
            Project = env.Project;
            Window = env.Window;
            Thread = new Thread(Run);
            Program = new GameProgram();
            Commands = new Commands(env);
            Running = false;
        }

        public void Start()
        {
            Thread.Start();
        }

        public void Exit()
        {
            Thread.Abort();
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
