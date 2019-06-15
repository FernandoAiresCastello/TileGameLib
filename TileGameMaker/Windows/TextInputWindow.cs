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
    public partial class TextInputWindow : Form
    {
        public string String => TxtString.Text;
        public int Type => int.Parse(TxtType.Text);
        public int Param => int.Parse(TxtParam.Text);

        public TextInputWindow()
        {
            InitializeComponent();
            Shown += TextInputWindow_Shown;
        }

        private void TextInputWindow_Shown(object sender, EventArgs e)
        {
            TxtString.Focus();
        }

        private void TxtBox_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(TxtType.Text, out int type);
            int.TryParse(TxtParam.Text, out int param);

            if (type < 0)
                type = 0;
            else if (type > byte.MaxValue)
                type = byte.MaxValue;

            if (param < 0)
                param = 0;
            else if (param > byte.MaxValue)
                param = byte.MaxValue;

            TxtType.Text = type.ToString();
            TxtParam.Text = param.ToString();
            Refresh();
        }

        private void TxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
