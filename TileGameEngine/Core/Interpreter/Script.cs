using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Core
{
    public class Script
    {
        public List<ScriptLine> Lines { get; private set; } = new List<ScriptLine>();
        public string SourceCode { get; private set; }

        private static readonly char LineSeparator = '\n';
        private static readonly char ParamSeparator = ' ';

        public Script(string sourceCode)
        {
            SourceCode = sourceCode;

            Lines.Clear();

            int lineNumber = 0;
            int sourceLineNumber = 0;
            string[] lines = sourceCode.Split(LineSeparator);

            foreach (string fullLine in lines)
            {
                sourceLineNumber++;

                string line = fullLine.Trim();
                List<string> commandParams = new List<string>();
                int paramSeparatorIndex = line.IndexOf(ParamSeparator);

                string command;
                if (paramSeparatorIndex > 0)
                    command = line.Substring(0, paramSeparatorIndex).Trim();
                else
                    command = line.Trim();

                commandParams.Add(command);

                string param;
                if (paramSeparatorIndex > 0)
                    param = line.Substring(paramSeparatorIndex).Trim();
                else
                    param = "";

                commandParams.Add(param);

                if (commandParams.Count > 0)
                {
                    string name = commandParams[0];

                    if (name.Length > 0)
                    {
                        ScriptLine scriptLine = new ScriptLine(name, lineNumber, sourceLineNumber);

                        if (!scriptLine.IsComment())
                        {
                            for (int i = 1; i < commandParams.Count; i++)
                                scriptLine.Params.Add(commandParams[i]);

                            Lines.Add(scriptLine);

                            lineNumber++;
                        }
                    }
                }
            }
        }
    }
}
