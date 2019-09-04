using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.String
{
    public class FormatCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            string format = PopStr();
            int number = PopInt();
            string result = number.ToString(format);

            ParamStack.Push(result);
        }
    }
}
