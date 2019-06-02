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
    public partial class ColorPickerWindow : Form
    {
        private ColorPicker ColorPicker;

        public ColorPickerWindow()
        {
        }

        public ColorPickerWindow(Palette palette) : this()
        {
            InitializeComponent();
            ColorPicker = new ColorPicker(ColorPickerPanel, 8, 32, 3);
            ColorPicker.Graphics.Palette = palette;
            ColorPicker.ShowGrid = true;
            ColorPicker.MouseMove += ColorPicker_MouseMove;
            ColorPicker.MouseLeave += ColorPicker_MouseLeave;
            ColorPicker.MouseDown += ColorPicker_MouseClick;
            ColorPicker.MouseDoubleClick += ColorPicker_MouseDoubleClick;
            ForeColorPanel.MouseDown += ColorPanel_Click;
            BackColorPanel.MouseDown += ColorPanel_Click;
            UpdatePanelColors();
            UpdateStatus();
            SetHoverStatus("");
        }

        private void ColorPicker_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int colorIx = ColorPicker.GetColorIndexAtMousePos(e.Location);
            if (colorIx < 0 || colorIx >= ColorPicker.Graphics.Palette.Size)
                return;

            Color currentColor = Color.FromArgb(ColorPicker.GetColor(colorIx));
            ColorDialog dialog = new ColorDialog();
            dialog.Color = currentColor;

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                ColorPicker.SetColor(colorIx, dialog.Color);
                ColorPicker.Refresh();
                UpdatePanelColors();
                UpdateStatus();
            }
        }

        private void ColorPicker_MouseClick(object sender, MouseEventArgs e)
        {
            int colorIx = ColorPicker.GetColorIndexAtMousePos(e.Location);
            if (colorIx < 0 || colorIx >= ColorPicker.Graphics.Palette.Size)
                return;

            if (e.Button == MouseButtons.Left)
                ColorPicker.ForeColorIx = colorIx;
            else if (e.Button == MouseButtons.Right)
                ColorPicker.BackColorIx = colorIx;

            UpdatePanelColors();
            UpdateStatus();
        }

        private void ColorPicker_MouseMove(object sender, MouseEventArgs e)
        {
            int colorIx = ColorPicker.GetColorIndexAtMousePos(e.Location);
            if (colorIx >= 0 && colorIx < ColorPicker.Graphics.Palette.Size)
            {
                int color = ColorPicker.GetColor(colorIx);
                string rgb = color.ToString("X").Substring(2);
                SetHoverStatus("IX: " + colorIx + " RGB: 0x" + rgb);
            }
            else
            {
                SetHoverStatus("");
            }
        }

        private void ColorPicker_MouseLeave(object sender, EventArgs e)
        {
            SetHoverStatus("");
        }

        private void UpdateStatus()
        {
            LblStatus.Text = "FG: " + ColorPicker.ForeColorIx + " BG: " + ColorPicker.BackColorIx;
        }

        private void SetHoverStatus(string status)
        {
            LblHover.Text = status;
        }

        private void ColorPanel_Click(object sender, EventArgs e)
        {
            SwapColors();
        }

        private void UpdatePanelColors()
        {
            ForeColorPanel.BackColor = ColorPicker.GetForeColor();
            BackColorPanel.BackColor = ColorPicker.GetBackColor();
        }

        private void SwapColors()
        {
            int temp = ColorPicker.ForeColorIx;
            ColorPicker.ForeColorIx = ColorPicker.BackColorIx;
            ColorPicker.BackColorIx = temp;
            UpdatePanelColors();
            UpdateStatus();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ColorPicker.Clear();
            UpdatePanelColors();
            UpdateStatus();
        }
    }
}
