using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameEngine.Core;
using TileGameEngine.Exceptions;
using TileGameEngine.Util;
using TileGameEngine.Windows;
using TileGameLib.Util;

namespace TileGameEngine
{
    public static class TileGameEngineApplication
    {
        public static string MainScriptFile => Config.ReadString("MainScriptFile");
        public static Icon ApplicationIcon => Icon.FromHandle(Properties.Resources.app_icon.GetHicon());
        public static bool ExitIfGameWindowClosed { get; set; } = false;
        public static bool ExitIfErrorRaised { get; set; } = false;
        public static bool ErrorRaised { get; private set; } = false;

        public static void Run()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartWindow());
        }

        public static void RunMainScript()
        {
            Run(MainScriptFile);
        }

        public static void Run(string scriptFile)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (File.Exists(scriptFile))
            {
                try
                {
                    ExitIfErrorRaised = true;
                    Application.Run(new StartWindow(scriptFile));
                }
                catch (Exception ex)
                {
                    Alert.Error(ex.Message);
                }
            }
            else
            {
                Alert.Warning("Script file not found: " + scriptFile);
                Application.Run(new StartWindow());
            }
        }

        public static void Exit()
        {
            Application.Exit();
        }

        public static void Error(string title, string message)
        {
            ErrorRaised = true;
            throw new TileGameEngineException(title, message);
        }
    }
}
