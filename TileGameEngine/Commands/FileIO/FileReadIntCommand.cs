using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.FileIO
{
    public class FileReadIntCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int value = Environment.MemoryFile.ReadInt();
            Push(value);
        }
    }
}
