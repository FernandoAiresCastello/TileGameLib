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
    public partial class ScriptInputWindow : Form
    {
        public string Script { get; private set; }

        public ScriptInputWindow()
        {
            InitializeComponent();
        }

        public DialogResult ShowDialog(Control parent, string script)
        {
            Script = script;
            TxtText.Text = script;
            TxtText.Select(0, 0);
            return ShowDialog(parent);
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            Script = TxtText.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
