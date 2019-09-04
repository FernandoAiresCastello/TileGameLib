using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.Window
{
    public class PrintCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            string text = ParamStack.PopStr();
            Environment.Print(text);
        }
    }
}
