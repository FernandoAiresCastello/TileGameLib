using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameRunner.Commands
{
    public class CallNotZeroCommand : CommandBase
    {
        public override void Execute(List<string> param)
        {
            if (TopInt() != 0)
            {
                string label = param[0];
                Call(label);
            }
        }
    }
}
