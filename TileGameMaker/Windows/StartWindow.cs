using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.File;
using TileGameLib.Util;
using TileGameMaker.MapEditorElements;
using TileGameMaker.Util;

namespace TileGameMaker.Windows
{
    public partial class StartWindow : Form
    {
        public StartWindow()
        {
            InitializeComponent();
            Icon = Global.WindowIcon;
            LbTitle.Font = EmbeddedFontLoader.Load(Properties.Resources.PressStart2P, 18);

            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
            string version = fvi.FileVersion;
            string build = Config.ReadString("BuildNumber");

            LbVersionBuild.Text = LbVersionBuild.Text
                .Replace("{version}", version)
                .Replace("{build}", build);
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Select location and filename for the project";
            dialog.Filter = "TileGameMaker project file (*.tgpro)|*.tgpro";
            if (dialog.ShowDialog() == DialogResult.OK)
                NewProject(dialog.FileName);
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select project file to open";
            dialog.Filter = "TileGameMaker project file (*.tgpro)|*.tgpro";
            if (dialog.ShowDialog() == DialogResult.OK)
                OpenProject(dialog.FileName);
        }

        private void OpenProject(string path)
        {
            Project project = new Project();
            bool ok = project.Load(path);
            if (ok)
            {
                MapEditor editor = new MapEditor(this, project);
                editor.Show();
                Hide();
            }
        }

        private void NewProject(string path)
        {
            Project project = new Project();
            project.CreationDate = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            project.AddBlankMap();
            project.Save(path);
            MapEditor editor = new MapEditor(this, project);
            editor.Show();
            Hide();
        }
    }
}
