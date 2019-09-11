using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.System
{
    public class SpeedSetCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int cycles = PopInt();
            Interpreter.CyclesPerMillisecond = cycles;
        }
    }
}
