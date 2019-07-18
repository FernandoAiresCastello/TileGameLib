using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TileGameMaker.Windows
{
    public partial class NewProjectWindow : Form
    {
        public string Filename => TxtFilename.Text.Trim();

        public NewProjectWindow()
        {
            InitializeComponent();
        }

        private void TxtFilename_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
