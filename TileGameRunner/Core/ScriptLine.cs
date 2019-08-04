using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameRunner.Core
{
    public class ScriptLine
    {
        public string CommandName { set; get; }
        public List<string> Params { get; private set; } = new List<string>();
        public string Param => Params.Count > 0 ? Params[0] : null;
        public int SourceLineNumber { set; get; }

        public ScriptLine(string commandName, int sourceLineNumber)
        {
            CommandName = commandName;
            SourceLineNumber = sourceLineNumber;
        }

        public override string ToString()
        {
            StringBuilder paramList = new StringBuilder();
            for (int i = 0; i < Param.Length; i++)
                paramList.Append(Param[i] + (i < Param.Length - 1 ? ", " : ""));

            return "[line " + SourceLineNumber + "] " + CommandName + " " + paramList;
        }

        public bool IsLabel()
        {
            return CommandName.StartsWith(":");
        }

        public bool IsComment()
        {
            return CommandName.StartsWith("#");
        }
    }
}
