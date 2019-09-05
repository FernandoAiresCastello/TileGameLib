using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.System
{
    public class ResetCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            Interpreter.Reset();
        }
    }
}
