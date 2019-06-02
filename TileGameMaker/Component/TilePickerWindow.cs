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
        private TilePicker TilePicker;

        public TilePickerWindow()
        {
            InitializeComponent();
            TilePicker = new TilePicker(CharPickerPanel, 8, 64, 3);
            TilePicker.ShowGrid = true;
            TilePicker.MouseMove += CharPicker_MouseMove;
            TilePicker.MouseLeave += CharPicker_MouseLeave;
            TilePicker.MouseDown += CharPicker_MouseDown;
            SetHoverStatus("");
            UpdateStatus();
        }

        public TilePickerWindow(Tileset tileset) : this()
        {
            TilePicker.Graphics.Tileset = tileset;
            UpdateStatus();
        }

        private void CharPicker_MouseDown(object sender, MouseEventArgs e)
        {
            int tileIx = TilePicker.GetTileIndexAtMousePos(e.Location);
            if (tileIx < 0 || tileIx >= TilePicker.Graphics.Tileset.Size)
                return;

            if (e.Button == MouseButtons.Left)
            {
                TilePicker.SelectTiileIndex(tileIx);
                UpdateStatus();
            }
        }

        private void CharPicker_MouseMove(object sender, MouseEventArgs e)
        {
            int tileIx = TilePicker.GetTileIndexAtMousePos(e.Location);
            if (tileIx >= 0 && tileIx < TilePicker.Graphics.Tileset.Size)
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
            StatusLabel.Text = "Selected IX: " + TilePicker.TileIndex;
        }

        private void SetHoverStatus(string status)
        {
            HoverLabel.Text = status;
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            TilePicker.Clear();
            UpdateStatus();
        }
    }
}
