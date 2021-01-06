using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine
{
    public class GameProgram
    {
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

            foreach (string srcLine in srcLines)
            {
                string srcText = srcLine.Trim();

                if (!string.IsNullOrEmpty(srcText) && !srcText.StartsWith("'"))
                {
                    ProgramLine line = new ProgramLine(srcLineNumber, srcText);
                    Lines.Add(line);
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
