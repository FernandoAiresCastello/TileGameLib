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
    public partial class TemplateObjectList : UserControl
    {
        public TemplateObjectView ObjectView { set; get; }
        private MapEditor Editor;

        private TemplateObjectList()
        {
            InitializeComponent();
        }

        public TemplateObjectList(MapEditor editor)
        {
            Editor = editor;
        }
    }
}
