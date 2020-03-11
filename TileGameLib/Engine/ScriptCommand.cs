using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.Engine
{
    public class ScriptCommand
    {
        public int SourceLine { set; get; }
        public string Command { set; get; }
        public List<string> Params { set; get; }

        public ScriptCommand()
        {
        }

        public ScriptCommand(int sourceLine, string command, params string[] args)
        {
            SourceLine = sourceLine;
            Command = command;
            Params = args.ToList();
        }
    }
}
