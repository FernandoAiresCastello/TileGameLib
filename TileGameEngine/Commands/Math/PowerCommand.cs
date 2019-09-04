using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.Math
{
    public class PowerCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int exponent = PopInt();
            int number = PopInt();
            int result = Convert.ToInt32(
                global::System.Math.Pow(number, exponent));

            ParamStack.Push(result);
        }
    }
}
