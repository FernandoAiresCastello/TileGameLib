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
    public partial class ObjectDataInputWindow : Form
    {
        public string ObjectId => TxtId.Text.Trim();
        public string ObjectData => TxtData.Text;

        public ObjectDataInputWindow() : this("")
        {
        }

        public ObjectDataInputWindow(string title)
        {
            InitializeComponent();
            Text = title;
        }

        public DialogResult ShowDialog(Control parent, string id, string data)
        {
            TxtId.Text = id;
            TxtData.Text = data;
            TxtId.Select(0, 0);
            TxtData.Select(0, 0);
            return ShowDialog(parent);
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
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
