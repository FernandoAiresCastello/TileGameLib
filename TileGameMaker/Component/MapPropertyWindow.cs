using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameMaker.Modules;

namespace TileGameMaker.Component
{
    public partial class MapPropertyWindow : Form
    {
        private MapEditor MapEditor;

        public MapPropertyWindow(MapEditor editor)
        {
            InitializeComponent();
            MapEditor = editor;
        }
    }
}
