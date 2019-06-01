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
        private GraphicsAdapter Gr;
        private ColorPicker ColorPicker;

        public ColorPickerWindow()
        {
            InitializeComponent();
            StatusLabel.Text = "";
            Gr = new GraphicsAdapter(8, 32);
            ColorPicker = new ColorPicker(ColorPickerPanel, Gr, 3);
            ColorPicker.ShowGrid = true;
            ColorPicker.MouseMove += ColorPicker_MouseMove;
            ColorPicker.MouseLeave += ColorPicker_MouseLeave;
            ColorPicker.MouseDown += ColorPicker_MouseClick;
            ColorPicker.MouseDoubleClick += ColorPicker_MouseDoubleClick;
            ForeColorPanel.MouseDown += ColorPanel_Click;
            BackColorPanel.MouseDown += ColorPanel_Click;
            UpdatePanelColors();
        }

        private void ColorPicker_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = ColorPicker.GetMouseToCellIndex(e.Location);
            if (index >= ColorPicker.Pal.Size)
                return;

            Color currentColor = Color.FromArgb(ColorPicker.GetColor(index));
            ColorDialog dialog = new ColorDialog();
            dialog.Color = currentColor;

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                ColorPicker.SetColor(index, dialog.Color);
                ColorPicker.Refresh();
                UpdatePanelColors();
            }
        }

        private void ColorPicker_MouseClick(object sender, MouseEventArgs e)
        {
            int index = ColorPicker.GetMouseToCellIndex(e.Location);
            if (index >= ColorPicker.Pal.Size)
                return;

            if (e.Button == MouseButtons.Left)
                ColorPicker.ForeColorIx = index;
            else if (e.Button == MouseButtons.Right)
                ColorPicker.BackColorIx = index;

            UpdatePanelColors();
        }

        private void ColorPicker_MouseMove(object sender, MouseEventArgs e)
        {
            int index = ColorPicker.GetMouseToCellIndex(e.Location);

            if (index < ColorPicker.Pal.Size)
            {
                int color = ColorPicker.GetColor(index);
                string rgb = color.ToString("X").Substring(2);
                SetStatus("Index: " + index + " RGB: 0x" + rgb);
            }
            else
            {
                ClearStatus();
            }
        }

        private void ColorPicker_MouseLeave(object sender, EventArgs e)
        {
            ClearStatus();
        }

        private void ClearStatus()
        {
            SetStatus("");
        }

        private void SetStatus(string status)
        {
            StatusLabel.Text = status;
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
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ColorPicker.Pal.Clear(64, Color.White);
            ColorPicker.Refresh();
            UpdatePanelColors();
        }
    }
}
