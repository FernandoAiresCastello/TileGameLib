using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.GameElements;

namespace TileGameMaker.Windows
{
    public partial class ObjectDataInputWindow : Form
    {
        public string ObjectTag => TxtTag.Text.Trim();
        public ObjectProperties ObjectProperties { set; get; }

        public ObjectDataInputWindow() : this("")
        {
        }

        public ObjectDataInputWindow(string title)
        {
            InitializeComponent();
            Text = title;
            ObjectProperties = new ObjectProperties();
        }

        public DialogResult ShowDialog(Control parent, GameObject o)
        {
            TxtId.Text = o.Id;
            TxtId.Select(0, 0);
            TxtTag.Text = o.Tag;
            TxtTag.Select(0, 0);
            ObjectProperties.SetEqual(o.Properties);
            TxtProperties.Text = o.Properties.ToString();
            TxtProperties.Select(0, 0);
            return ShowDialog(parent);
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            ObjectProperties.Parse(TxtProperties.Text);
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
