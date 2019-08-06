using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameRunner.Commands
{
    public class PushCommand : CommandBase
    {
        public override void Execute(List<string> param)
        {
            string value = param[0];
            Interpreter.ParamStack.Push(value);
        }
    }
}
