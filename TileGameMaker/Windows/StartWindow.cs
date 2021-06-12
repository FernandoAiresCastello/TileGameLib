using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
        private RecentProjects RecentProjects;

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

            RecentProjects = new RecentProjects();
            UpdateRecentProjectsList();
        }

        private void UpdateRecentProjectsList()
        {
            LstRecent.Items.Clear();
            RecentProjects.Files.Reverse();
            LstRecent.Items.AddRange(RecentProjects.Files.ToArray());
            LstRecent.DoubleClick += LstRecent_DoubleClick;
            LstRecent.MouseDown += LstRecent_MouseDown;
        }

        private void LstRecent_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                LstRecent.SelectedIndex = LstRecent.IndexFromPoint(e.Location);
        }

        private void LstRecent_DoubleClick(object sender, EventArgs e)
        {
            object item = LstRecent.SelectedItem;
            if (item != null)
                OpenProject((string)item);
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
            if (!File.Exists(path))
            {
                Alert.Error("File not found:\n\n" + path);
                return;
            }

            Project project = new Project();
            bool ok = project.Load(path);

            if (ok)
            {
                RecentProjects.Add(path);
                RecentProjects.Save();

                MapEditor editor = new MapEditor(this, project);
                editor.MapEditorControl.DisableEditorTemporarily();
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

            RecentProjects.Add(path);
            RecentProjects.Save();

            MapEditor editor = new MapEditor(this, project);
            editor.Show();
            Hide();
        }

        private void BtnOpenFileLocation_Click(object sender, EventArgs e)
        {
            string path = (string)LstRecent.SelectedItem;

            if (path == null)
            {
                Alert.Warning("Select a file to open location");
                return;
            }

            string folder = Path.GetDirectoryName(path);
            Process.Start("explorer.exe", folder);
        }

        private void BtnRemoveFromList_Click(object sender, EventArgs e)
        {
            string path = (string)LstRecent.SelectedItem;

            if (path == null)
            {
                Alert.Warning("Select a file to remove");
                return;
            }

            if (Alert.Confirm("Remove this file from the list?"))
            {
                RecentProjects.Remove(path);
                RecentProjects.Save();
                UpdateRecentProjectsList();
            }
        }
    }
}
