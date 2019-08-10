using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands
{
    public class ExitCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            Interpreter.Stop();
        }
    }
}
