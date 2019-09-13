using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.String
{
    public class StringEqualsCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            string string1 = PopStr();
            string string2 = PopStr();
            bool equals = string1.Equals(string2);

            ParamStack.Push(equals ? 1 : 0);
        }
    }
}
