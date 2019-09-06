using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.LogicalOperators
{
    public class LogicalNotCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int number = PopInt();
            int result = ~number;

            ParamStack.Push(result);
        }
    }
}
