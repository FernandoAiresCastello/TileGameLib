using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.FileIO
{
    public class FileSeekCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int filePointer = PopInt();
            Environment.MemoryFile.Seek(filePointer);
        }
    }
}
