using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.Math
{
    public class AddCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int number2 = PopInt();
            int number1 = PopInt();
            int result = number1 + number2;

            ParamStack.Push(result);
        }
    }
}
