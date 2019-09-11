using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.FileIO
{
    public class FileReadShortCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int value = Environment.MemoryFile.ReadShort();
            Push(value);
        }
    }
}
