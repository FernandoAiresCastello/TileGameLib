using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameRunner.Commands
{
    public class ProjectCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            string archivePath = ParamStack.PopStr();
            Environment.SetProjectArchive(archivePath);
        }
    }
}
