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
using TileGameMaker.Component;

namespace TileGameMaker.Forms
{
    public partial class MainWindow : Form
    {
        ObjectMap DefaultMap;

        public MainWindow()
        {
            InitializeComponent();

            DefaultMap = new ObjectMap(31, 16);

            MapWindow win = new MapWindow(DefaultMap);
            win.MdiParent = this;
            win.Location = new Point(0, 0);
            win.Show();

            ColorPickerWindow colorPicker = new ColorPickerWindow();
            colorPicker.MdiParent = this;
            colorPicker.Location = new Point(800, 0);
            colorPicker.Show();

            TilePickerWindow charPicker = new TilePickerWindow();
            charPicker.MdiParent = this;
            charPicker.Location = new Point(1050, 0);
            charPicker.Show();
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
