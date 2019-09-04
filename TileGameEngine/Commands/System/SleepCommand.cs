using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.System
{
    public class SleepCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int ms = PopInt();
            Thread.Sleep(ms);
        }
    }
}
