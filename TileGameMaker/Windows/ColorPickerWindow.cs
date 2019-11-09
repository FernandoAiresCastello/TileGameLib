using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameMaker.MapEditorElements;
using TileGameMaker.TiledDisplays;
using TileGameMaker.Util;

namespace TileGameMaker.Windows
{
    public partial class ColorPickerWindow : Form
    {
        public int SelectedColor => ColorPicker.BackColorIx;

        private MapEditor MapEditor;
        private ColorPickerDisplay ColorPicker;

        public ColorPickerWindow()
        {
            InitializeComponent();
        }

        public ColorPickerWindow(MapEditor editor, string title)
        {
            InitializeComponent();
            MapEditor = editor;
            Text = title;

            ColorPicker = new ColorPickerDisplay(PnlColorPicker,
                Config.ReadInt("ColorPickerCols"),
                Config.ReadInt("ColorPickerRows"),
                Config.ReadInt("ColorPickerZoom"));

            ColorPicker.Graphics.Palette = editor.Palette;
            ColorPicker.ShowGrid = true;
            ColorPicker.MouseUp += ColorPicker_MouseUp;
        }

        private void ColorPicker_MouseUp(object sender, MouseEventArgs e)
        {
            int colorIx = ColorPicker.GetBackColorIndexAtMousePos(e.Location);
            if (colorIx < 0 || colorIx >= ColorPicker.Graphics.Palette.Size)
                return;

            ColorPicker.BackColorIx = colorIx;
            DialogResult = DialogResult.OK;
        }

        private void ColorPickerWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                DialogResult = DialogResult.Cancel;
        }
    }
}
