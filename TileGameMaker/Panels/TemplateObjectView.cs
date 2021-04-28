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
    public partial class TemplateObjectView : UserControl
    {
        public TemplateObjectList ObjectList { set; get; }
        private MapEditor Editor;

        private TemplateObjectView()
        {
            InitializeComponent();
        }

        public TemplateObjectView(MapEditor editor)
        {
            Editor = editor;
        }
    }
}
