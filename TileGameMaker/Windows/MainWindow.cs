using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Components;
using TileGameLib.Graphics;
using TileGameMaker.Modules;

namespace TileGameMaker.Windows
{
    public partial class MainWindow : Form
    {
        private MapEditor MapEditor;

        public MainWindow()
        {
            InitializeComponent();
            Shown += MainWindow_Shown;

            MapEditor = new MapEditor(this);
            AddControl(MapEditor.MapEditorControl, MapEditorPanel);
            AddControl(MapEditor.TilePickerControl, TilePickerPanel);
            AddControl(MapEditor.ColorPickerControl, ColorPickerPanel);
            AddControl(MapEditor.TemplateControl, TemplatePanel);
            AddControl(MapEditor.MapPropertyControl, MapPropertiesPanel);
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            SplashWindow splash = new SplashWindow();
            splash.Show(this);
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

        private void MiCallDebugFunc_Click(object sender, EventArgs e)
        {
            Debug();
        }

        private void Debug()
        {
        }

        private void MiNewProject_Click(object sender, EventArgs e)
        {
            NewProjectWindow win = new NewProjectWindow();

            if (win.ShowDialog(this) == DialogResult.OK)
                MapEditor.CreateNewProject(win.Filename);
        }
    }
}
