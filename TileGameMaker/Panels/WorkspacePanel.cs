using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameMaker.MapEditorElements;
using System.IO;
using TileGameLib.Util;

namespace TileGameMaker.Panels
{
    public partial class WorkspacePanel : BasePanel
    {
        private MapEditor MapEditor;

        public WorkspacePanel() : this(null)
        {
        }

        public WorkspacePanel(MapEditor editor)
        {
            InitializeComponent();
            MapEditor = editor;
        }

        private void BtnOpenWorkspace_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.RootFolder = Environment.SpecialFolder.MyComputer;
            dialog.SelectedPath = MapEditor.WorkspacePath;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                MapEditor.WorkspacePath = dialog.SelectedPath;
                UpdateWorkspace();
            }
        }

        public void UpdateWorkspace()
        {
            TxtPath.Text = MapEditor.WorkspacePath;
            var filenames = Directory.EnumerateFiles(MapEditor.WorkspacePath);

            foreach (string name in filenames)
            {
                FileInfo file = new FileInfo(name);

                if (file.Extension == ".tgmap")
                {
                    double kb = file.Length / 1024d;
                    WorkspaceGrid.Rows.Add(file.Name, kb.ToString("0.##"), file.LastWriteTime);
                }
            }

            Refresh();
        }

        private void WorkspaceGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (WorkspaceGrid.SelectedRows.Count > 0)
            {
                string file = WorkspaceGrid.SelectedRows[0].Cells[0].Value.ToString();
                string path = Path.Combine(MapEditor.WorkspacePath, file);
                MapEditor.MapEditorControl.LoadMap(path);
            }
        }
    }
}
