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
        public string Script { private set; get; }

        public ScriptInputWindow()
        {
            InitializeComponent();
        }

        public DialogResult ShowDialog(Control parent, string script)
        {
            Script = script;
            TxtData.Text = script;
            return ShowDialog(parent);
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            Script = TxtData.Text;
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
