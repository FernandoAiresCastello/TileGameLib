using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.FileIO
{
    public class FileEofCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            bool eof = Environment.MemoryFile.EndOfFile;

            Push(eof ? 1 : 0);
        }
    }
}
