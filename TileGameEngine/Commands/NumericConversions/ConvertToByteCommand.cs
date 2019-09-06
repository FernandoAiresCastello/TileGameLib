using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.NumericConversions
{
    public class ConvertToByteCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int number = PopInt();
            byte result = (byte)number;

            ParamStack.Push(result);
        }
    }
}
