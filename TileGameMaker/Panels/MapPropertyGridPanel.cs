﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameMaker.MapEditor;
using TileGameLib.Util;

namespace TileGameMaker.Panels
{
    public partial class MapPropertyGridPanel : UserControl
    {
        public MapProperties Properties { get; private set; }

        private MapEditorElements MapEditor;

        public MapPropertyGridPanel() : this(null)
        {
        }

        public MapPropertyGridPanel(MapEditorElements editor)
        {
            InitializeComponent();
            MapEditor = editor;
            UpdateProperties();
        }

        public void UpdateProperties()
        {
            Properties = new MapProperties(MapEditor.Map, MapEditor.MapFile);
            Grid.SelectedObject = Properties;
            Grid.Refresh();
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            UpdateProperties();
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            MapEditor.Map.Name = Properties.Name;
            MapEditor.Map.MusicFile = Properties.Music;

            bool widthOk = int.TryParse(Properties.Width, out int width);
            bool heightOk = int.TryParse(Properties.Height, out int height);

            if (!widthOk)
            {
                Alert.Warning("Width must be a number");
                Properties.Width = MapEditor.Map.Width.ToString();
                Grid.Refresh();
                return;
            }

            if (!heightOk)
            {
                Alert.Warning("Height must be a number");
                Properties.Height = MapEditor.Map.Height.ToString();
                Grid.Refresh();
                return;
            }

            if ((width != MapEditor.Map.Width || height != MapEditor.Map.Height) &&
                Alert.Confirm($"Resize map to {Properties.Width}x{Properties.Height}?"))
            {
                MapEditor.ResizeMap(width, height);
            }

            Alert.Info("Map properties applied successfully");
        }
    }
}
