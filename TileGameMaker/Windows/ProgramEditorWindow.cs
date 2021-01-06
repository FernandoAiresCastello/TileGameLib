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
using TileGameLib.Util;
using TileGameMaker.Util;

namespace TileGameMaker.Windows
{
    public partial class ProgramEditorWindow : Form
    {
        private MainWindow MainWindow;
        private Project Project;
        private string OriginalProgram;

        private ProgramEditorWindow()
        {
        }

        public ProgramEditorWindow(MainWindow win, Project project)
        {
            InitializeComponent();
            Icon = Global.WindowIcon;
            MainWindow = win;
            Project = project;
            TxtProgram.Text = project.Program;
            OriginalProgram = project.Program;
            Shown += ProgramEditorWindow_Shown;
            KeyPreview = true;
            KeyDown += ProgramEditorWindow_KeyDown;
        }

        private void ProgramEditorWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                SaveProgramAndRunEngine();
        }

        private void ProgramEditorWindow_Shown(object sender, EventArgs e)
        {
            TxtProgram.Select(0, 0);
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            Project.Program = TxtProgram.Text;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            ConfirmRevertChangesAndClose();
        }

        private void ConfirmRevertChangesAndClose()
        {
            if (Alert.Confirm("Revert all changes?"))
            {
                Project.Program = OriginalProgram;
                Project.Save();
                Close();
            }
        }

        private void BtnRunEngine_Click(object sender, EventArgs e)
        {
            SaveProgramAndRunEngine();
        }

        private void SaveProgramAndRunEngine()
        {
            Project.Program = TxtProgram.Text;
            MainWindow.RunEngine();
        }
    }
}
