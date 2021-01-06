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
        private string Args;

        public CommandExecutor(ExecutionEnvironment env)
        {
            Env = env;
        }

        public void Execute(ProgramLine line)
        {
            Line = line;
            Args = line.Args;

            SetResult(CommandResult.Ok);

            switch (Line.Command)
            {
                case "NOP": Nop(); break;
                case "MSGBOX": MsgBox(); break;
                case "END": End(); break;

                default:
                    SetResult(CommandResult.Error, "Invalid command: " + Line.Command);
                    break;
            }
        }

        private void SetResult(CommandResult result, string msg = null)
        {
            Result = result;
            ResultMsg = msg;
        }

        private void Nop()
        {
            // Dummy (no operation)
        }

        private void End()
        {
            SetResult(CommandResult.Exit);
        }

        private void MsgBox()
        {
            Env.ShowMessageBox(Args);
        }
    }
}
