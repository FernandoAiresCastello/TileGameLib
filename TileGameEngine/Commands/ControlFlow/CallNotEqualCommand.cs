using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.ControlFlow
{
    public class CallNotEqualCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int value2 = PopInt();
            int value1 = PopInt();

            if (value2 != value1)
            {
                string label = immediateParams[0];
                Call(label);
            }
        }
    }
}
