using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Graphics;

namespace TileGameMaker.Component
{
    public partial class CharPickerWindow : Form
    {
        private GraphicsAdapter Gr;

        public CharPickerWindow()
        {
            InitializeComponent();
            StatusLabel.Text = "";

            Gr = new GraphicsAdapter(16, 16);
            CharPicker charPicker = new CharPicker(CharPickerPanel, Gr, 3);
            charPicker.ShowGrid = true;
        }
    }
}
