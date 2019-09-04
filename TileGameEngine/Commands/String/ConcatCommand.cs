using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.String
{
    public class ConcatCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            string string2 = PopStr();
            string string1 = PopStr();
            string result = string1 + string2;

            ParamStack.Push(result);
        }
    }
}
