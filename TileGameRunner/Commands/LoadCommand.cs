using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameRunner.Commands
{
    public class LoadCommand : CommandBase
    {
        public override void Execute(List<string> param)
        {
            string variable = param[0];
            AssertParamVariable(variable);
            string value = Environment.Variables.GetStr(VariableName(variable));
            Interpreter.ParamStack.Push(value);
        }
    }
}
