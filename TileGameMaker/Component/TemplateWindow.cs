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

namespace TileGameMaker.Component
{
    public partial class TemplateWindow : Form
    {
        public GameObject Object { set; get; }

        public TemplateWindow()
        {
            InitializeComponent();

            Object = new GameObject();
        }

        public override void Refresh()
        {
            base.Refresh();
            TxtType.Text = Object.Type.ToString();
            TxtParam.Text = Object.Param.ToString();
            TxtData.Text = Object.Data;
        }

        private void TxtBox_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(TxtType.Text, out int type);
            int.TryParse(TxtParam.Text, out int param);

            Object.Type = type;
            Object.Param = param;
            Object.Data = TxtData.Text;
        }

        private void TxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            Object.SetNull();
            Refresh();
        }
    }
}
