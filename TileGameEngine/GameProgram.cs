using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine
{
    public class GameProgram
    {
        public long LineCount => Lines.Count;
        public bool IsEmpty() => Lines.Count == 0;

        private readonly List<ProgramLine> Lines;

        public GameProgram()
        {
            Lines = new List<ProgramLine>();
        }

        public void Parse(string program)
        {
            Lines.Clear();
            string[] srcLines = program.Split('\n');
            long srcLineNumber = 0;
            long realLineNumber = 0;

            foreach (string srcLine in srcLines)
            {
                string srcText = srcLine.Trim();

                if (!string.IsNullOrEmpty(srcText) && !srcText.StartsWith("'"))
                {
                    ProgramLine line = new ProgramLine(srcLineNumber, realLineNumber, srcText);
                    Lines.Add(line);
                    realLineNumber++;
                }

                srcLineNumber++;
            }
        }

        public ProgramLine GetLine(int index)
        {
            return Lines[index];
        }
    }
}
