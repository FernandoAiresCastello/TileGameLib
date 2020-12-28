using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.File;
using TileGameMaker.Util;

namespace TileGameMaker.Windows
{
    public partial class ProjectSettingsWindow : Form
    {
        public Project Project { get; private set; }

        private ProjectSettingsWindow()
        {
            InitializeComponent();
        }

        public ProjectSettingsWindow(Project project)
        {
            InitializeComponent();
            Icon = Global.WindowIcon;

            Project = new Project();
            TxtProjectName.Text = Project.Name = project.Name;
            TxtCols.Value = Project.EngineWindowCols = project.EngineWindowCols;
            TxtRows.Value = Project.EngineWindowRows = project.EngineWindowRows;
            TxtMagnification.Value = Project.EngineWindowMagnification = project.EngineWindowMagnification;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            Project.Name = TxtProjectName.Text.Trim();
            Project.EngineWindowCols = decimal.ToInt32(TxtCols.Value);
            Project.EngineWindowRows = decimal.ToInt32(TxtRows.Value);
            Project.EngineWindowMagnification = decimal.ToInt32(TxtMagnification.Value);
        }
    }
}
