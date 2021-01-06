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
        public long RealLineNumber { get; private set; }
        public string Command { get; private set; }
        public string Args { get; private set; }

        public ProgramLine(long srcLineNumber, long realLineNumber, string srcText)
        {
            SrcLineNumber = srcLineNumber;
            RealLineNumber = realLineNumber;
            SrcText = srcText;

            int cmdBoundary = srcText.IndexOf(' ');

            if (cmdBoundary > 0)
            {
                Command = srcText.Substring(0, cmdBoundary).ToUpper();
                Args = srcText.Substring(cmdBoundary);
            }
            else
            {
                Command = srcText.ToUpper();
                Args = "";
            }
        }
    }
}
