using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Components;

namespace TileGameMaker.Windows
{
    public partial class GridSetupWindow : Form
    {
        public Color MainGridColor
        {
            get => Color.FromArgb(decimal.ToInt32(TxtMainOpacity.Value), BtnMainColor.BackColor);
            set => BtnMainColor.BackColor = value;
        }

        public Color AuxGridColor
        {
            get => Color.FromArgb(decimal.ToInt32(TxtAuxOpacity.Value), BtnAuxColor.BackColor);
            set => BtnAuxColor.BackColor = value;
        }

        public int AuxGridInterval
        {
            get => decimal.ToInt32(TxtAuxInterval.Value);
            set => TxtAuxInterval.Value = value;
        }

        private GridSetupWindow()
        {
            InitializeComponent();
        }

        public GridSetupWindow(TiledDisplay display)
        {
            InitializeComponent();
            MainGridColor = display.GetMainGridColor();
            AuxGridColor = display.GetAuxGridColor();
            AuxGridInterval = display.GetAuxGridInterval();
            TxtMainOpacity.Value = display.GetMainGridColor().A;
            TxtAuxOpacity.Value = display.GetAuxGridColor().A;
        }

        private void BtnMainColor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = BtnMainColor.BackColor;
            if (dialog.ShowDialog(this) == DialogResult.OK)
                BtnMainColor.BackColor = Color.FromArgb(decimal.ToInt32(TxtMainOpacity.Value), dialog.Color);
        }

        private void BtnAuxColor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = BtnAuxColor.BackColor;
            if (dialog.ShowDialog(this) == DialogResult.OK)
                BtnAuxColor.BackColor = Color.FromArgb(decimal.ToInt32(TxtAuxOpacity.Value), dialog.Color);
        }
    }
}
