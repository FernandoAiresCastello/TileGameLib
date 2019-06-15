using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameMaker.Modules;
using TileGameLib.Util;

namespace TileGameMaker.Panels
{
    public partial class MapPropertyPanel : BasePanel
    {
        private MapEditor MapEditor;

        public string MapName => TxtName.Text.Trim();

        public MapPropertyPanel(MapEditor editor)
        {
            InitializeComponent();
            MapEditor = editor;
        }

        private void BtnDiscard_Click(object sender, EventArgs e)
        {
            UpdateProperties(null);
        }

        public void UpdateProperties(string file)
        {
            if (file != null)
                TxtFile.Text = file;

            TxtName.Text = MapEditor.Map.Name;
            TxtWidth.Text = MapEditor.Map.Width.ToString();
            TxtHeight.Text = MapEditor.Map.Height.ToString();
            TxtLayers.Text = MapEditor.Map.Layers.Count.ToString();
        }

        private void NumericTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            int.TryParse(TxtWidth.Text, out int width);
            int.TryParse(TxtHeight.Text, out int height);

            if (width != MapEditor.Map.Width || height != MapEditor.Map.Height)
            {
                if (Alert.Confirm("Resize map?"))
                    MapEditor.Resize(width, height);
            }
        }
    }
}
