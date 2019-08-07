using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameRunner.Commands
{
    public class PrintCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            string text = Interpreter.ParamStack.PopStr();
            Environment.Print(text);
        }
    }
}
