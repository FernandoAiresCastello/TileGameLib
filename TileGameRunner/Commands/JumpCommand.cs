using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameRunner.Commands
{
    public class JumpCommand : CommandBase
    {
        public override void Execute(List<string> paramList)
        {
            string label = paramList[0];
            Jump(label);
        }
    }
}
