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
using System.Threading;

namespace TileGameEngine.Windows
{
    public partial class StartWindow : Form
    {
        private static readonly string SettingsFile = Config.ReadString("SettingsFile");
        private static readonly string ScriptFileExt = Config.ReadString("ScriptFileExt");
        private static readonly string ScriptFileFilter = $"TileGameMaker script (*.{ScriptFileExt})|*.{ScriptFileExt}";

        private static readonly string ExecModeRun = "run";
        private static readonly string ExecModeDebug = "debug";

        private string SettingsMainScript;
        private string SettingsExecMode;

        public StartWindow()
        {
            InitializeComponent();
            Shown += StartWindow_Shown;
        }

        public void Start()
        {
            if (File.Exists(SettingsFile))
            {
                try
                {
                    LoadSettings();
                    ApplySettings();

                    if (SettingsExecMode == ExecModeDebug)
                        Opacity = 100;
                }
                catch (Exception ex)
                {
                    Alert.Error($"Error in settings file {SettingsFile}:\n\n{ex.Message}");
                    Exit();
                }
            }
            else
            {
                Opacity = 100;
            }
        }

        private void LoadSettings()
        {
            string file = File.ReadAllText(SettingsFile);
            string[] settings = file.Split(';');

            if (settings.Length == 2)
            {
                SettingsExecMode = settings[0].Trim().ToLower();
                SettingsMainScript = settings[1].Trim();
            }
            else
                throw new StartupException("Invalid settings file format");
        }

        private void ApplySettings()
        {
            if (SettingsMainScript != null)
            {
                if (SettingsExecMode == ExecModeRun)
                    RunScript(SettingsMainScript);
                else if (SettingsExecMode == ExecModeDebug)
                    DebugScript(SettingsMainScript);
                else
                    throw new StartupException("Invalid execution mode: " + SettingsExecMode);
            }
        }

        private void StartWindow_Shown(object sender, EventArgs e)
        {
            if (SettingsExecMode == ExecModeRun)
                Hide();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Exit();
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

        public void Exit()
        {
            Application.Exit();
        }

        private string LoadScript()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Application.StartupPath;
            dialog.Filter = ScriptFileFilter;

            if (dialog.ShowDialog(this) != DialogResult.OK)
                return null;

            return dialog.FileName;
        }

        private void RunScript(string path)
        {
            try
            {
                new Engine().Run(path);
            }
            catch (Exception ex)
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
                engine.Debug(path);
            }
            catch (Exception ex)
            {
                Alert.Error(ex.Message);
            }
        }
    }
}
