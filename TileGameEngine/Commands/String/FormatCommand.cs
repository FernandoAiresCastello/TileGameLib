using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameEngine.Exceptions;

namespace TileGameEngine.Commands.String
{
    public class FormatCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            string formatString = PopStr();
            int number = PopInt();

            ScriptException formatException = new ScriptException("Invalid format: " + formatString);

            string[] format = formatString.Split(',');
            if (format.Length != 2)
                throw formatException;
            if (!int.TryParse(format[0].Trim(), out int length))
                throw formatException;
            if (length < 1)
                throw formatException;

            string result = "";
            string notation = format[1].Trim();

            if (notation == "X" || notation == "x")
            {
                result = Convert.ToString(number, 16).PadLeft(length, '0');
                result = notation == "X" ? result.ToUpper() : result.ToLower();
            }
            else if (notation.ToUpper() == "B")
            {
                result = Convert.ToString(number, 2).PadLeft(length, '0');
            }
            else
            {
                throw formatException;
            }

            ParamStack.Push(result);
        }
    }
}
