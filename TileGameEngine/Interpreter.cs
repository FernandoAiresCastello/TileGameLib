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
        public long CurrentLineNumber { get; private set; }

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
                try
                {
                    if (Program.IsEmpty() || ProgramPtr >= Program.LineCount)
                    {
                        Running = false;
                        break;
                    }

                    ProgramLine line = Program.GetLine(ProgramPtr);
                    CurrentLineNumber = line.SrcLineNumber;
                    CmdExecutor.Execute(line);

                    switch (CmdExecutor.Result)
                    {
                        case CommandResult.Branch:
                            ProgramPtr = CmdExecutor.BranchTo;
                            break;
                        case CommandResult.Error:
                            Engine.Error(CmdExecutor.ResultMsg);
                            break;
                        case CommandResult.Exit:
                            Engine.Exit();
                            break;
                        default:
                            ProgramPtr++;
                            break;
                    }
                }
                catch (Exception e)
                {
                    Engine.Error($"Unhandled exception in interpreter loop:\n\n{e.Message}\n\n{e.StackTrace}");
                }
            }

            Thread.Abort();
        }
    }
}
