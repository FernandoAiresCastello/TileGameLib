using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameEngine.Exceptions;
using TileGameEngine.Windows;
using TileGameLib.Util;

namespace TileGameEngine
{
    public static class TileGameEngineApplication
    {
        public static bool ErrorRaised { get; private set; } = false;

        public static void Run()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartWindow());
        }

        public static void Error(string title, string message)
        {
            ErrorRaised = true;
            throw new TileGameEngineException(title, message);
        }
    }
}
