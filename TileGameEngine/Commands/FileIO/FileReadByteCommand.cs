using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.FileIO
{
    public class FileReadByteCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            byte value = Environment.MemoryFile.ReadByte();
            Push(value);
        }
    }
}
