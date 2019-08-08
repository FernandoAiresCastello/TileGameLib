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

        public static readonly char LineSeparator = '\n';
        public static readonly char NameParamSeparator = ' ';

        public Script(string sourceCode)
        {
            SourceCode = sourceCode;

            Lines.Clear();

            int lineNumber = 0;
            int sourceLineNumber = 0;
            string[] lines = sourceCode.Split(LineSeparator);

            foreach (string line in lines)
            {
                sourceLineNumber++;

                string trimmedLine = line.Trim();
                string[] commandParam = trimmedLine.Split(NameParamSeparator);

                if (commandParam.Length > 0)
                {
                    string name = commandParam[0].Trim();

                    if (name.Length > 0)
                    {
                        ScriptLine scriptLine = new ScriptLine(name, lineNumber, sourceLineNumber);

                        if (!scriptLine.IsComment())
                        {
                            for (int i = 1; i < commandParam.Length; i++)
                                scriptLine.Params.Add(commandParam[i].Trim());

                            Lines.Add(scriptLine);

                            lineNumber++;
                        }
                    }
                }
            }
        }
    }
}
