using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Core;
using TileGameMaker.Modules;
using TileGameMaker.Component;

namespace TileGameMaker.Component
{
    public partial class MainWindow : Form
    {
        private readonly MapEditor MapEditor;

        public MainWindow()
        {
            InitializeComponent();

            MapEditor = new MapEditor(this);
            MapEditor.MapWindow.Location = new Point(0, 0);
            MapEditor.ColorPickerWindow.Location = new Point(800, 0);
            MapEditor.TilePickerWindow.Location = new Point(1040, 0);
            MapEditor.TemplateWindow.Location = new Point(800, 365);
            MapEditor.MapPropertyWindow.Location = new Point(900, 365);
            MapEditor.Show();
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ShowMapPropertiesMenuItem_Click(object sender, EventArgs e)
        {
            ToggleView(MapEditor.MapPropertyWindow, sender);
        }

        private void ShowPaletteMenuItem_Click(object sender, EventArgs e)
        {
            ToggleView(MapEditor.ColorPickerWindow, sender);
        }

        private void ShowTilesetMenuItem_Click(object sender, EventArgs e)
        {
            ToggleView(MapEditor.TilePickerWindow, sender);
        }

        private void ShowTemplateMenuItem_Click(object sender, EventArgs e)
        {
            ToggleView(MapEditor.TemplateWindow, sender);
        }

        private void ToggleView(Form form, object eventSource)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)eventSource;

            if (form.Visible)
                form.Hide();
            else
                form.Show();

            item.Checked = form.Visible;
        }
    }
}
