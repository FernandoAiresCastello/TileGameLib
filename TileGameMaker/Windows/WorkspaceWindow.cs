using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameMaker.MapEditorElements;

namespace TileGameMaker.Windows
{
    public partial class WorkspaceWindow : BaseWindow
    {
        public WorkspaceWindow() : this(null)
        {
        }

        public WorkspaceWindow(MapEditor editor)
        {
            InitializeComponent();
            WorkspacePanel.MapEditor = editor;
            WorkspacePanel.UpdateWorkspace();
        }
    }
}
