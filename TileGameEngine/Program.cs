using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TileGameEngine
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string[] args = Environment.GetCommandLineArgs();

            if (args.Length > 1)
                new GameEngine().Start(args[1].Trim());
            else
                new GameEngine().Start();
        }
    }
}
