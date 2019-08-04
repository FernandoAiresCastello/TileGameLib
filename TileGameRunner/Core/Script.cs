using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameRunner.Core
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
                string[] nameParam = trimmedLine.Split(NameParamSeparator);

                if (nameParam.Length > 0)
                {
                    string name = nameParam[0].Trim();
                    ScriptLine scriptLine = new ScriptLine(name, lineNumber);

                    if (!scriptLine.IsComment())
                    {
                        for (int i = 1; i < nameParam.Length; i++)
                            scriptLine.Params.Add(nameParam[i].Trim());

                        Lines.Add(scriptLine);
                    }
                }

                lineNumber++;
            }
        }
    }
}
