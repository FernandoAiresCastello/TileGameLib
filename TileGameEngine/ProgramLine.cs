using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine
{
    public class ProgramLine
    {
        public string SrcText { get; private set; }
        public long SrcLineNumber { get; private set; }
        public string Text { get; private set; }
        public long LineNumber { get; private set; }
        public string Command { get; private set; }
        public List<string> Args { get; private set; }

        public ProgramLine(long srcLineNumber, string srcText)
        {
            SrcLineNumber = srcLineNumber;
            SrcText = srcText;
        }
    }
}
