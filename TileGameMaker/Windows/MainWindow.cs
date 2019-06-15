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
using TileGameMaker.Modules;

namespace TileGameMaker.Windows
{
    public partial class MainWindow : Form
    {
        private MapEditor MapEditor;

        public MainWindow()
        {
            InitializeComponent();

            MapEditor = new MapEditor(this);
            AddControl(MapEditor.MapEditorControl, MapEditorPanel);
            AddControl(MapEditor.TilePickerControl, TilePickerPanel);
            AddControl(MapEditor.ColorPickerControl, ColorPickerPanel);
            AddControl(MapEditor.TemplateControl, TemplatePanel);
            AddControl(MapEditor.MapPropertyControl, MapPropertiesPanel);
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
            DisplayWindow win = new DisplayWindow(31, 21);
            win.Text = "Debug Window";
            win.Graphics.Clear(5);
            win.Graphics.PutString(0, 0, "Hello World!", 255, 5);
            win.ShowDialog(this);
        }
    }
}
