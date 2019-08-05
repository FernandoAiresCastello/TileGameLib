using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameRunner.Exceptions;
using TileGameRunner.Windows;

namespace TileGameRunner.Commands
{
    public class WindowCommand : CommandBase
    {
        public override void Execute(List<string> param)
        {
            if (Environment.Window != null)
                throw new ScriptException("Window already opened");

            int rows = PopInt();
            int cols = PopInt();

            Environment.Window = new GameWindow(cols, rows);
            Environment.Window.Show();
        }
    }
}
