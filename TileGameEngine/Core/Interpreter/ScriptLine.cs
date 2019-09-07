using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Core
{
    public class ScriptLine
    {
        public string Command { set; get; }
        public List<string> Params { get; private set; } = new List<string>();
        public int LineNumber { set; get; }
        public int SourceLineNumber { set; get; }

        public ScriptLine(string commandName, int lineNumber, int sourceLineNumber)
        {
            Command = commandName;
            LineNumber = lineNumber;
            SourceLineNumber = sourceLineNumber;
        }

        public override string ToString()
        {
            return "[line " + SourceLineNumber + "] " + Command + " " + ParamsToString();
        }

        public string ToDebuggerString()
        {
            return LineNumber + " " + Command + " " + ParamsToString();
        }

        private string ParamsToString()
        {
            StringBuilder paramList = new StringBuilder();

            for (int i = 0; i < Params.Count; i++)
                paramList.Append(Params[i] + (i < Params.Count - 1 ? ", " : ""));

            return paramList.ToString();
        }

        public bool IsLabel()
        {
            return Command.StartsWith(":");
        }

        public bool IsComment()
        {
            return Command.StartsWith("#");
        }
    }
}
