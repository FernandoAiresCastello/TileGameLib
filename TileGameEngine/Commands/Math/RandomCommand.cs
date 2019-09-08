using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.Math
{
    public class RandomCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int max = PopInt();
            int min = PopInt();
            int result = Environment.GetRandomNumber(min, max);

            ParamStack.Push(result);
        }
    }
}
