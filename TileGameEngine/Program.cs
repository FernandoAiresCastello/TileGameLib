using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameEngine.Windows;
using TileGameLib.Util;

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
                Alert.Error(ex.ToString());
                Application.Exit();
            }
        }
    }
}
