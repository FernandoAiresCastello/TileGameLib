using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.Window
{
    public class WindowTitleSetCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            string title = PopStr();
            Environment.SetWindowTitle(title);
        }
    }
}
