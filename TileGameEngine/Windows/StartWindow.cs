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
using TileGameLib.Util;
using System.Threading;

namespace TileGameEngine.Windows
{
    public partial class StartWindow : Form
    {
        private static readonly string ScriptFileExt = Config.ReadString("ScriptFileExt");
        private static readonly string ScriptFileFilter = $"TileGameMaker script (*.{ScriptFileExt})|*.{ScriptFileExt}";

        public StartWindow()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
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
            OpenFileDialog dialog = new OpenFileDialog
            {
                InitialDirectory = Application.StartupPath,
                Filter = ScriptFileFilter
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
                return null;

            return dialog.FileName;
        }

        private void RunScript(string path)
        {
            try
            {
                new Engine(this).Run(path);
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
                new Engine(this).Debug(path);
            }
            catch (Exception ex)
            {
                Alert.Error(ex.Message);
            }
        }
    }
}
