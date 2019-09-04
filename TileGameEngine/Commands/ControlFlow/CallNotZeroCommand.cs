using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.ControlFlow
{
    public class CallNotZeroCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            if (TopInt() != 0)
            {
                string label = immediateParams[0];
                Call(label);
            }
        }
    }
}
