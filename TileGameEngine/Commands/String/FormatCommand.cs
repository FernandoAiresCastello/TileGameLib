using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.String
{
    public class FormatCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            string formatString = PopStr();
            int number = PopInt();

            string[] format = formatString.Split(',');
            if (format.Length != 2)
                FormatError(formatString);
            if (!int.TryParse(format[0].Trim(), out int length))
                FormatError(formatString);
            if (length < 1)
                FormatError(formatString);

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
            else if (notation.ToUpper() == "D")
            {
                result = number.ToString().PadLeft(length, '0');
            }
            else
            {
                FormatError(formatString);
            }

            ParamStack.Push(result);
        }

        private void FormatError(string formatString)
        {
            TileGameEngineApplication.Error("SCRIPT ERROR", "Invalid format string: " + formatString);
        }
    }
}
