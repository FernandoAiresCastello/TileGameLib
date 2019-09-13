using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.Variable
{
    public class VariableSubtractCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            string variable = immediateParams[0];
            AssertVariable(variable);

            int value = PopInt();
            Environment.AddToVariable(variable, -value);
        }
    }
}
