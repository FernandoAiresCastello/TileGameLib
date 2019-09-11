using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            if (File.Exists(TileGameEngineApplication.MainScriptFile))
                TileGameEngineApplication.RunMainScript();
            else
                TileGameEngineApplication.Run();
        }
    }
}
