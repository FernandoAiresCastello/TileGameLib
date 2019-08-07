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

        public static readonly char LineSeparator = '\n';
        public static readonly char NameParamSeparator = ' ';

        public Script(string script)
        {
            Lines.Clear();
            string[] lines = script.Split(LineSeparator);
            int lineNumber = 0;

            foreach (string line in lines)
            {
                string trimmedLine = line.Trim();
                string[] commandParam = trimmedLine.Split(NameParamSeparator);

                if (commandParam.Length > 0)
                {
                    string name = commandParam[0].Trim();
                    ScriptLine scriptLine = new ScriptLine(name, lineNumber);

                    if (!scriptLine.IsComment())
                    {
                        for (int i = 1; i < commandParam.Length; i++)
                            scriptLine.Params.Add(commandParam[i].Trim());

                        Lines.Add(scriptLine);
                    }
                }

                lineNumber++;
            }
        }
    }
}
