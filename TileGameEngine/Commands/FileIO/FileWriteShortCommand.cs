using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.FileIO
{
    public class FileWriteShortCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            short value = (short)PopInt();
            Environment.MemoryFile.WriteShort(value);
        }
    }
}
