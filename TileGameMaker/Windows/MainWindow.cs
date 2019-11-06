using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Components;
using TileGameLib.Graphics;
using TileGameLib.Util;
using TileGameMaker.MapEditor;
using TileGameMaker.Util;

namespace TileGameMaker.Windows
{
    public partial class MainWindow : Form
    {
        private MapEditorElements MapEditor;

        private static readonly int BestWidth = Config.ReadInt("MapEditorWindowBestWidth");
        private static readonly int BestHeight = Config.ReadInt("MapEditorWindowBestHeight");

        public MainWindow()
        {
            InitializeComponent();
            Shown += MainWindow_Shown;

            Rectangle screenArea = Screen.PrimaryScreen.Bounds;
            Size = new Size(BestWidth, BestHeight);
            MinimumSize = Size;

            if (screenArea.Width > BestWidth && screenArea.Height > BestHeight)
                WindowState = FormWindowState.Normal;
            else
                WindowState = FormWindowState.Maximized;

            MapEditor = new MapEditorElements(this);
            AddControl(MapEditor.MapEditorControl, MapEditorPanel);
            AddControl(MapEditor.TilePickerControl, TilePickerPanel);
            AddControl(MapEditor.ColorPickerControl, ColorPickerPanel);
            AddControl(MapEditor.TemplateControl, TemplatePanel);
            AddControl(MapEditor.MapPropertyControl, MapPropertiesPanel);
        }

        private void ShowSplashWindow()
        {
            SplashWindow splash = new SplashWindow();
            splash.Show(this);
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            ShowSplashWindow();
        }

        private void AddControl(Control control, Control panel)
        {
            control.Parent = panel;
            control.Dock = DockStyle.Fill;
        }

        private void MiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MiAbout_Click(object sender, EventArgs e)
        {
            ShowSplashWindow();
        }
    }
}
