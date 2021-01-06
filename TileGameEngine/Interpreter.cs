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
        private readonly GameEngine Engine;
        private readonly ExecutionEnvironment Env;
        private readonly Thread Thread;
        private readonly Project Project;
        private readonly GameWindow Window;
        private readonly GameProgram Program;
        private readonly CommandExecutor CmdExecutor;
        private bool Running;
        private int ProgramPtr;

        public Interpreter(GameEngine engine, ExecutionEnvironment env)
        {
            Engine = engine;
            Env = env;
            Project = env.Project;
            Window = env.Window;
            Thread = new Thread(Run);
            Program = new GameProgram();
            CmdExecutor = new CommandExecutor(env);
            Running = false;
        }

        public void Start()
        {
            Thread.Start();
        }

        public void Exit()
        {
            Running = false;
        }

        private void Run()
        {
            if (Running)
                return;

            Program.Parse(Project.Program);
            ProgramPtr = 0;
            Running = true;

            while (Running)
            {
                ProgramLine line = Program.GetLine(ProgramPtr);
                CmdExecutor.Execute(line);

                switch (CmdExecutor.Result)
                {
                    case CommandResult.Branch:
                        ProgramPtr = CmdExecutor.BranchTo;
                        break;
                    case CommandResult.Error:
                        Engine.Error(CmdExecutor.ResultMsg);
                        break;
                    default:
                        ProgramPtr++;
                        break;
                }
            }

            Thread.Abort();
        }
    }
}
