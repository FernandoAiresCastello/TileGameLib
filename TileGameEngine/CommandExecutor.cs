using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine
{
    public class CommandExecutor
    {
        public CommandResult Result { get; private set; }
        public string ResultMsg { get; private set; }
        public int BranchTo { get; private set; }

        private readonly ExecutionEnvironment Env;
        private ProgramLine Line;
        private List<string> Args;
        private int Argc;

        public CommandExecutor(ExecutionEnvironment env)
        {
            Env = env;
        }

        public void Execute(ProgramLine line)
        {
            Line = line;
            Args = line.Args;
            Argc = line.Args.Count;

            SetResult(CommandResult.Ok);

            switch (Line.Command)
            {
                case "TEST": Test(); break;
                case "NOP": Nop(); break;

                default:
                    SetResult(CommandResult.Error, "Invalid command");
                    break;
            }
        }

        private void SetResult(CommandResult result, string msg = null)
        {
            Result = result;
            ResultMsg = msg;
        }

        private void Test()
        {
            Env.ShowMessageBox("TEST command executed");
        }

        private void Nop()
        {
            // Dummy (no operation)
        }
    }
}
