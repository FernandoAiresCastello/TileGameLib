using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameRunner.Commands
{
    public class JumpNotZeroCommand : CommandBase
    {
        public override void Execute(List<string> param)
        {
            if (TopInt() != 0)
            {
                string label = param[0];
                Jump(label);
            }
        }
    }
}
