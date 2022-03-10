using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.File;
using TileGameLib.Util;
using TileGameMaker.MapEditorElements;
using TileGameMaker.Windows;

namespace TileGameMaker
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length == 0)
            {
                Application.Run(new StartWindow());
            }
            else
            {
                var proj = new Project();

                if (proj.Load(args[0]))
                {
                    var editor = new MapEditor(null, proj);
                    Application.Run(editor.MainWindow);
                }
                else
                {
                    Alert.Error($"Could not load project file: {args[0]}");
                }
            }
        }
    }
}
