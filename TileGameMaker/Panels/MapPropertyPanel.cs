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
using System.IO;

namespace TileGameMaker.Panels
{
    public partial class MapPropertyPanel : BasePanel
    {
        private MapEditor MapEditor;

        public string MapName => TxtName.Text.Trim();
        public string MapMusic => TxtMusicFile.Text.Trim();

        public MapPropertyPanel(MapEditor editor)
        {
            InitializeComponent();
            MapEditor = editor;
        }

        private void BtnDiscard_Click(object sender, EventArgs e)
        {
            UpdateProperties();
        }

        public void UpdateProperties()
        {
            if (MapEditor.MapFile != null)
            {
                FileInfo info = new FileInfo(MapEditor.MapFile);
                TxtPath.Text = info.Directory.FullName;
                TxtFile.Text = info.Name;
            }
            else
            {
                TxtPath.Text = "";
                TxtFile.Text = "";
            }

            TxtName.Text = MapEditor.Map.Name;
            TxtWidth.Text = MapEditor.Map.Width.ToString();
            TxtHeight.Text = MapEditor.Map.Height.ToString();
            TxtMusicFile.Text = MapEditor.Map.MusicFile;
            TxtLayers.Text = MapEditor.Map.Layers.Count.ToString();
        }

        private void NumericTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            MapEditor.Map.Name = TxtName.Text;
            MapEditor.Map.MusicFile = TxtMusicFile.Text;

            int.TryParse(TxtWidth.Text, out int width);
            int.TryParse(TxtHeight.Text, out int height);

            if (width != MapEditor.Map.Width || height != MapEditor.Map.Height)
            {
                if (Alert.Confirm($"Resize map to {width}x{height}?"))
                    MapEditor.ResizeMap(width, height);
            }

            Alert.Info("Map properties applied successfully");
        }
    }
}
