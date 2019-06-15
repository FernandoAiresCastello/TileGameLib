using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Graphics;

namespace TileGameMaker.Windows
{
    public partial class ColorEditorWindow : BaseWindow
    {
        private Palette Palette;
        private int ColorIndex;
        private Color Color;
        private Color OriginalColor;

        public ColorEditorWindow(Palette palette)
        {
            InitializeComponent();
            DoubleBuffered = true;
            Palette = palette;

            RedSlider.ValueChanged += Slider_ValueChanged;
            GreenSlider.ValueChanged += Slider_ValueChanged;
            BlueSlider.ValueChanged += Slider_ValueChanged;

            RedTextBox.TextChanged += TextBox_TextChanged;
            GreenTextBox.TextChanged += TextBox_TextChanged;
            BlueTextBox.TextChanged += TextBox_TextChanged;

            ColorHex.TextChanged += ColorHex_TextChanged;
        }
            
        public void SetColor(int colorIx)
        {
            ColorIndex = colorIx;
            Color color = Color.FromArgb(Palette.Colors[colorIx]);
            Color = color;
            OriginalColor = color;
            ColorPanel.BackColor = color;
            OriginalColorPanel.BackColor = OriginalColor;
            OriginalColorHex.Text = OriginalColor.ToArgb().ToString("X").PadLeft(6, '0').Substring(2);
            StatusLabel.Text = "IX: " + colorIx;

            UpdateAllControls();
        }

        public Color GetColor()
        {
            return Color;
        }

        public void UpdateAllControls()
        {
            UpdateSliders();
            UpdateTextBoxes();
            UpdateColorHex();
        }

        private void ColorHex_TextChanged(object sender, EventArgs e)
        {
            string hex = ColorHex.Text;
            if (hex.Length != 6)
                return;

            int.TryParse(hex, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int color);

            Color newColor = Color.FromArgb(color);
            Color = Color.FromArgb(255, newColor);

            UpdateSliders();
            UpdateTextBoxes();
            PostValueChanged();
        }

        private void UpdateColorHex()
        {
            ColorHex.Text = Color.ToArgb().ToString("X").Substring(2);
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;

            if (!int.TryParse(box.Text, out int value))
                return;
            if (value < 0 || value > 255)
                return;

            if (box == RedTextBox)
                Color = Color.FromArgb(value, Color.G, Color.B);
            else if (box == GreenTextBox)
                Color = Color.FromArgb(Color.R, value, Color.B);
            else if (box == BlueTextBox)
                Color = Color.FromArgb(Color.R, Color.G, value);

            UpdateSliders();
            UpdateColorHex();
            PostValueChanged();
        }

        private void Slider_ValueChanged(object sender, EventArgs e)
        {
            TrackBar bar = (TrackBar)sender;

            if (bar == RedSlider)
                Color = Color.FromArgb(bar.Value, Color.G, Color.B);
            else if (bar == GreenSlider)
                Color = Color.FromArgb(Color.R, bar.Value, Color.B);
            else if (bar == BlueSlider)
                Color = Color.FromArgb(Color.R, Color.G, bar.Value);

            UpdateTextBoxes();
            UpdateColorHex();
            PostValueChanged();
        }

        private void PostValueChanged()
        {
            Palette.Set(ColorIndex, Color);
            ColorPanel.BackColor = Color;
            RefreshSubscribed();
        }

        private void UpdateSliders()
        {
            RedSlider.Value = Color.R;
            GreenSlider.Value = Color.G;
            BlueSlider.Value = Color.B;
        }

        private void UpdateTextBoxes()
        {
            RedTextBox.Text = Color.R.ToString();
            GreenTextBox.Text = Color.G.ToString();
            BlueTextBox.Text = Color.B.ToString();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Color = OriginalColor;
            Palette.Set(ColorIndex, OriginalColor);
            Refresh();
            Close();
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            Color = OriginalColor;
            Palette.Set(ColorIndex, OriginalColor);
            UpdateAllControls();
            Refresh();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        public override void Refresh()
        {
            base.Refresh();
            RefreshSubscribed();
            ColorPanel.BackColor = Color;
        }
    }
}
