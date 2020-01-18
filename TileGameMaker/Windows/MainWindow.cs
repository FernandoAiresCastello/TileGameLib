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
using TileGameMaker.MapEditorElements;
using TileGameMaker.Testing;
using TileGameMaker.Util;

namespace TileGameMaker.Windows
{
    public partial class MainWindow : Form
    {
        private MapEditor MapEditor;

        private static readonly int BestWidth = Config.ReadInt("MapEditorWindowBestWidth");
        private static readonly int BestHeight = Config.ReadInt("MapEditorWindowBestHeight");

        public MainWindow()
        {
            InitializeComponent();
            Shown += MainWindow_Shown;
            TestMenu.Visible = false;

            Rectangle screenArea = Screen.PrimaryScreen.Bounds;
            Size = new Size(BestWidth, BestHeight);
            MinimumSize = Size;

            if (screenArea.Width > BestWidth && screenArea.Height > BestHeight)
                WindowState = FormWindowState.Normal;
            else
                WindowState = FormWindowState.Maximized;

            MapEditor = new MapEditor(this);
            AddControl(MapEditor.MapEditorControl, MapEditorPanel);
            AddControl(MapEditor.TilePickerControl, TilePickerPanel);
            AddControl(MapEditor.ColorPickerControl, ColorPickerPanel);
            AddControl(MapEditor.TemplateControl, TemplatePanel);
            AddControl(MapEditor.MapPropertyGridControl, MapPropertiesPanel);
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

        private void MiOpenTestWindow_Click(object sender, EventArgs e)
        {
            Test();
        }

        private void Test()
        {
            int width = 100;
            int height = 80;
            //Color yellow = Color.Yellow;
            //Color blueTrans = Color.FromArgb(80, Color.Blue);
            int yellow = 0xffff00;
            int blue = 0x0000ff;

            DisplayWindow win = new DisplayWindow(width, height, 1, false, true, true);

            win.Graphics.Clear(Color.White);

            for (int y = 0; y < height; y++)
            {
                win.Graphics.SetPixel(0, y, yellow);
                win.Graphics.SetPixel(width - 1, y, blue);
            }
            for (int x = 0; x < width; x++)
            {
                win.Graphics.SetPixel(x, 0, blue);
                win.Graphics.SetPixel(x, height - 1, yellow);
            }

            win.ShowDialog(this);
        }
    }
}
