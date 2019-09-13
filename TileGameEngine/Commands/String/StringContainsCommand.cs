using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.String
{
    public class StringContainsCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            string search = PopStr();
            string str = PopStr();
            bool contains = str.Contains(search);

            ParamStack.Push(contains ? 1 : 0);
        }
    }
}
