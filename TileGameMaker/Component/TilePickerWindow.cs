using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Graphics;

namespace TileGameMaker.Component
{
    public partial class TilePickerWindow : Form
    {
        private TilePicker CharPicker;

        public TilePickerWindow()
        {
            InitializeComponent();
            CharPicker = new TilePicker(CharPickerPanel, 8, 64, 3);
            CharPicker.ShowGrid = true;
            CharPicker.MouseMove += CharPicker_MouseMove;
            CharPicker.MouseLeave += CharPicker_MouseLeave;
            CharPicker.MouseDown += CharPicker_MouseDown;
            SetHoverStatus("");
            UpdateStatus();
        }

        private void CharPicker_MouseDown(object sender, MouseEventArgs e)
        {
            int tileIx = CharPicker.GetTileIndexAtMousePos(e.Location);
            if (tileIx < 0 || tileIx >= CharPicker.Graphics.Tileset.Size)
                return;

            if (e.Button == MouseButtons.Left)
            {
                CharPicker.SelectTiileIndex(tileIx);
                UpdateStatus();
            }
        }

        private void CharPicker_MouseMove(object sender, MouseEventArgs e)
        {
            int tileIx = CharPicker.GetTileIndexAtMousePos(e.Location);
            if (tileIx >= 0 && tileIx < CharPicker.Graphics.Tileset.Size)
            {
                SetHoverStatus("IX: " + tileIx);
            }
            else
            {
                SetHoverStatus("");
            }
        }

        private void CharPicker_MouseLeave(object sender, EventArgs e)
        {
            SetHoverStatus("");
        }

        private void UpdateStatus()
        {
            StatusLabel.Text = "Selected IX: " + CharPicker.TileIndex;
        }

        private void SetHoverStatus(string status)
        {
            HoverLabel.Text = status;
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            CharPicker.Clear();
            UpdateStatus();
        }
    }
}
