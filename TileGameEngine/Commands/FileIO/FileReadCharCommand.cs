using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.FileIO
{
    public class FileReadCharCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            char value = Environment.MemoryFile.ReadChar();
            Push(value);
        }
    }
}
