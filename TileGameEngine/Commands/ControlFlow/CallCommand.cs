using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.ControlFlow
{
    public class CallCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            string label = immediateParams[0];
            Call(label);
        }
    }
}
