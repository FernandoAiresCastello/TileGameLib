using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TileGameMaker.Component
{
    public partial class TextInputWindow : Form
    {
        public TextInputWindow()
        {
            InitializeComponent();
            Shown += TextInputWindow_Shown;
        }

        private void TextInputWindow_Shown(object sender, EventArgs e)
        {
            TxtText.Focus();
        }

        public string GetText()
        {
            return TxtText.Text;
        }
    }
}
