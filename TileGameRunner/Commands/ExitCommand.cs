using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameRunner.Commands
{
    public class ExitCommand : CommandBase
    {
        public override void Execute(List<string> param)
        {
            Interpreter.Running = false;
            if (Environment.HasWindow())
                Environment.CloseWindow();
        }
    }
}
