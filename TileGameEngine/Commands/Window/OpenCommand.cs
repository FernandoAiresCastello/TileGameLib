using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameEngine.Exceptions;
using TileGameEngine.Windows;

namespace TileGameEngine.Commands.Window
{
    public class OpenCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            if (Environment.HasWindow)
                throw new ScriptException("Window already opened");

            int rows = PopInt();
            int cols = PopInt();

            Environment.CreateWindow(cols, rows);
        }
    }
}
