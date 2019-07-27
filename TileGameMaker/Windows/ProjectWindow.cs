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
using TileGameLib.Util;
using TileGameMaker.Util;

namespace TileGameMaker.Windows
{
    public partial class ProjectWindow : Form
    {
        public string Filename => TxtProject.Text.Trim();
        public List<string> ProjectFiles { get; private set; }

        private string WorkspacePath;
        private readonly string ProjectFileExt = Config.ReadString("ProjectFileExt");

        public ProjectWindow(string workspacePath)
        {
            InitializeComponent();
            WorkspacePath = workspacePath;
            TxtWorkspace.Text = workspacePath;
            UpdateList();
        }

        public DialogResult ShowNewProjectDialog(Form parent)
        {
            Text = "Create new project";
            ProjectsListBox.Enabled = false;
            ProjectsListBox.ClearSelected();
            TxtProject.Enabled = true;

            SetButton(BtnSave, 0);
            SetButton(BtnCancel, 1);
            HideButton(BtnDelete);
            HideButton(BtnLoad);
            HideButton(BtnOk);

            return ShowDialog(parent);
        }

        public DialogResult ShowOpenProjectDialog(Form parent)
        {
            Text = "Open project";
            ProjectsListBox.Enabled = true;
            TxtProject.Enabled = false;

            SetButton(BtnLoad, 0);
            SetButton(BtnDelete, 1);
            SetButton(BtnCancel, 2);
            HideButton(BtnSave);
            HideButton(BtnOk);

            return ShowDialog(parent);
        }

        private void UpdateList()
        {
            List<string> paths = Directory.EnumerateFiles(WorkspacePath, "*." + ProjectFileExt).ToList();

            ProjectFiles = new List<string>();
            foreach (string path in paths)
                ProjectFiles.Add(Path.GetFileName(path));

            ProjectsListBox.DataSource = ProjectFiles;
            ProjectsListBox.Refresh();
        }

        private void HideButton(Button button)
        {
            button.Hide();
        }

        private void SetButton(Button button, int cell)
        {
            ButtonLayout.SetCellPosition(button, new TableLayoutPanelCellPosition(cell, 0));
            button.Show();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedEntry();
        }

        private void DeleteSelectedEntry()
        {
            if (ProjectsListBox.SelectedValue == null)
                return;

            string entry = ProjectsListBox.SelectedValue.ToString();
            if (Alert.Confirm($"Delete project file \"{entry}\"?"))
            {
                File.Delete(WorkspacePath + "\\" + entry);
                UpdateList();
            }
        }

        private void ProjectsListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ProjectsListBox.SelectedValue != null)
                TxtProject.Text = ProjectsListBox.SelectedValue.ToString();
            else
                TxtProject.Text = "";
        }

        private void ProjectsListBox_DoubleClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void TxtProject_KeyDown(object sender, KeyEventArgs e)
        {
            Common_KeyDown(e);
        }

        private void ProjectsListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (Common_KeyDown(e))
                return;

            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
                DeleteSelectedEntry();
            }
        }

        private bool Common_KeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                return true;
            }
            else if (e.KeyCode == Keys.Return && !string.IsNullOrWhiteSpace(Filename))
            {
                e.Handled = true;
                DialogResult = DialogResult.OK;
                return true;
            }

            return false;
        }
    }
}
