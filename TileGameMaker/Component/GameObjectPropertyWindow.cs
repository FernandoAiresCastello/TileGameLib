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
    public partial class GameObjectPropertyWindow : Form
    {
        public GameObject Object { set; get; }
        public Point Position { set; get; }

        public GameObjectPropertyWindow()
        {
            InitializeComponent();

            Shown += GameObjectPropertyWindow_Shown;
            FormClosed += GameObjectPropertyWindow_FormClosed;
        }

        private void GameObjectPropertyWindow_Shown(object sender, EventArgs e)
        {
            TxtPosX.Text = Position.X.ToString();
            TxtPosY.Text = Position.Y.ToString();
            TxtType.Text = Object.Type.ToString();
            TxtParam.Text = Object.Param.ToString();
            TxtData.Text = Object.Data;
        }

        private void GameObjectPropertyWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Object.Type = int.Parse(TxtType.Text);
            Object.Param = int.Parse(TxtParam.Text);
            Object.Data = TxtData.Text;
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
