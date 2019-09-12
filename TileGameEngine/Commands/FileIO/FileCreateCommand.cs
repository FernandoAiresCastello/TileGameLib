using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.FileIO
{
    public class FileCreateCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            string path = PopStr();
            Environment.CreateFile(path);
        }
    }
}
