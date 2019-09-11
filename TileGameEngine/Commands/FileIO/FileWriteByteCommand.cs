using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.FileIO
{
    public class FileWriteByteCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            byte value = (byte)PopInt();
            Environment.MemoryFile.WriteByte(value);
        }
    }
}
