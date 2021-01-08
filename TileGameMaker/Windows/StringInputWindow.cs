using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameMaker.Util;

namespace TileGameMaker.Windows
{
    public partial class StringInputWindow : Form
    {
        private StringInputWindow()
        {
            InitializeComponent();
        }

        public StringInputWindow(string title, string label, string initialValue = null)
        {
            InitializeComponent();
            Icon = Global.WindowIcon;
            KeyPreview = true;
            Text = title;
            LbLabel.Text = label;
            TxtValue.Text = initialValue;
        }

        public string ShowDialog(Control parent)
        {
            DialogResult result = base.ShowDialog(parent);
            return result == DialogResult.OK ? TxtValue.Text : null;
        }

        private void TxtValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult = DialogResult.OK;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                TxtValue.Text = null;
                DialogResult = DialogResult.Cancel;
            }
        }
    }
}
