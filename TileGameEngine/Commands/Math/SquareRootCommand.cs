using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.Math
{
    public class SquareRootCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int number = PopInt();
            int result = Convert.ToInt32(
                global::System.Math.Truncate(
                    global::System.Math.Sqrt(number)));

            ParamStack.Push(result);
        }
    }
}
