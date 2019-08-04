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
using TileGameRunner.Core;

namespace TileGameRunner.Windows
{
    public partial class BootloaderWindow : Form
    {
        private static readonly string SettingsFile = "TileGameRunner.ini";

        private Engine Engine;
        private string InitialPath;

        public BootloaderWindow()
        {
            InitializeComponent();
            InitialPath = Application.StartupPath;
            if (File.Exists(SettingsFile))
                ReadSettings();
        }

        private void ReadSettings()
        {
            string[] settings = File.ReadAllLines(SettingsFile);

            if (settings.Length > 0)
            {
                InitialPath = settings[0];
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            string file = LoadProject();
            if (file != null)
                RunProject(file);
        }

        private string LoadProject()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = InitialPath;
            dialog.Filter = "Tile Game Maker project (*.tgm)|*.tgm";
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return null;

            return dialog.FileName;
        }

        private void RunProject(string path)
        {
            Hide();
            Engine = new Engine(path);
            Engine.Start();
        }
    }
}
