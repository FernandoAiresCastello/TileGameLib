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

namespace TileGameMaker.Panels
{
    public partial class ScriptPanel : BasePanel
    {
        public string Script
        {
            get => TxtScript.Text;
            set => TxtScript.Text = value;
        }

        private MapEditor MapEditor;

        public ScriptPanel() : this(null)
        {
        }

        public ScriptPanel(MapEditor editor)
        {
            InitializeComponent();
            MapEditor = editor;
        }
    }
}
