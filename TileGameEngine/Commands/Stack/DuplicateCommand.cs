using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameEngine.Exceptions;

namespace TileGameEngine.Commands.Stack
{
    public class DuplicateCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            AssertParamStackNotEmpty();
            ParamStack.DuplicateTop();
        }
    }
}
