using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameRunner.Commands
{
    public class JumpZeroCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            if (TopInt() == 0)
            {
                string label = immediateParams[0];
                Jump(label);
            }
        }
    }
}
