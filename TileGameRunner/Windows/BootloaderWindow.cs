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
        private Engine Engine;

        public BootloaderWindow()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Application.StartupPath;
            dialog.Filter = "Tile Game Maker project (*.tgm)|*.tgm";
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            LoadProject(dialog.FileName);
        }

        private void LoadProject(string path)
        {
            Hide();
            Engine = new Engine(path);
            Engine.Start();
        }
    }
}
