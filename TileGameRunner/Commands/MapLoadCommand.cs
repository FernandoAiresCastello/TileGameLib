using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameRunner.Exceptions;

namespace TileGameRunner.Commands
{
    public class MapLoadCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            string filename = ParamStack.PopStr();

            if (Environment.HasProjectArchive())
                Environment.LoadMapFromProjectArchive(filename);
            else
                Environment.LoadMapFromCurrentFolder(filename);
        }
    }
}
