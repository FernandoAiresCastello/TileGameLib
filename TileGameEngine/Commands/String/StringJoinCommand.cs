using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.String
{
    public class StringJoinCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int joinCharacter = PopInt();
            string string2 = PopStr();
            string string1 = PopStr();
            string result = string1 + char.ConvertFromUtf32(joinCharacter) + string2;

            ParamStack.Push(result);
        }
    }
}
