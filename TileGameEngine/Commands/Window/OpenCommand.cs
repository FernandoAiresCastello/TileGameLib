using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameEngine.Windows;

namespace TileGameEngine.Commands.Window
{
    public class OpenCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            if (Environment.HasWindow)
            {
                TileGameEngineApplication.Error("SCRIPT ERROR", "Window already opened");
            }
            else
            {
                int rows = PopInt();
                int cols = PopInt();

                Environment.CreateWindow(cols, rows);
            }
        }
    }
}
