using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameEngine.Windows;

namespace TileGameEngine
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                Application.Run(new StartWindow());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Application.Exit();
            }
        }
    }
}
