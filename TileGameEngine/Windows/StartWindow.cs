using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.File;
using TileGameEngine.Core;
using TileGameEngine.Util;
using TileGameEngine.Exceptions;
using TileGameLib.Util;

namespace TileGameEngine.Windows
{
    public partial class StartWindow : Form
    {
        private static readonly string SettingsFile = Config.ReadString("SettingsFile");
        private static readonly string ScriptFileFilter = "*." + Config.ReadString("ScriptFileExt");

        private string MainScript;

        public StartWindow()
        {
            InitializeComponent();
            if (File.Exists(SettingsFile))
                ReadSettings();

            if (MainScript != null)
                RunScript(MainScript);
        }

        private void ReadSettings()
        {
            string[] settings = File.ReadAllLines(SettingsFile);

            if (settings.Length > 0)
                MainScript = settings[0];
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            string file = LoadScript();
            if (file != null)
                RunScript(file);
        }

        private void BtnDebug_Click(object sender, EventArgs e)
        {
            string file = LoadScript();
            if (file != null)
                DebugScript(file);
        }

        private string LoadScript()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Application.StartupPath;
            dialog.Filter = $"TileGameMaker script ({ScriptFileFilter})|{ScriptFileFilter}";

            if (dialog.ShowDialog(this) != DialogResult.OK)
                return null;

            return dialog.FileName;
        }

        private void RunScript(string path)
        {
            Hide();

            try
            {
                new Engine().Run(path);
            }
            catch (EngineException ex)
            {
                Alert.Error(ex.Message);
            }
        }

        private void DebugScript(string path)
        {
            try
            {
                Engine engine = new Engine();
                engine.ParentForm = this;
                engine.DebugScript(path);
            }
            catch (EngineException ex)
            {
                Alert.Error(ex.Message);
            }
        }
    }
}
