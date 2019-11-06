using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameMaker.MapEditor;
using TileGameMaker.Windows;
using TileGameMaker.TiledDisplays;
using TileGameLib.Util;
using TileGameMaker.Util;
using TileGameLib.File;

namespace TileGameMaker.Panels
{
    public partial class ColorPickerPanel : BasePanel
    {
        private MapEditorElements MapEditor;
        private ColorPickerDisplay ColorPicker;
        private ColorEditorWindow ColorEditorWindow;

        private static readonly string PaletteFileExt = Config.ReadString("PaletteFileExt");
        private static readonly string PaletteFileFilter = $"TileGameMaker palette file (*.{PaletteFileExt})|*.{PaletteFileExt}";

        public ColorPickerPanel()
        {
            InitializeComponent();
        }

        public ColorPickerPanel(MapEditorElements editor)
        {
            InitializeComponent();
            MapEditor = editor;

            ColorPicker = new ColorPickerDisplay(PnlColorPicker, 
                Config.ReadInt("ColorPickerCols"), 
                Config.ReadInt("ColorPickerRows"), 
                Config.ReadInt("ColorPickerZoom"));

            ColorPicker.Graphics.Palette = editor.Palette;
            ColorPicker.ShowGrid = true;
            ColorPicker.MouseMove += ColorPicker_MouseMove;
            ColorPicker.MouseLeave += ColorPicker_MouseLeave;
            ColorPicker.MouseDown += ColorPicker_MouseClick;
            ColorPicker.MouseDoubleClick += ColorPicker_MouseDoubleClick;
            ForeColorPanel.MouseDown += ColorPanel_Click;
            BackColorPanel.MouseDown += ColorPanel_Click;
            ColorEditorWindow = new ColorEditorWindow(ColorPicker.Graphics.Palette);
            ColorEditorWindow.Subscribe(this);
            ColorEditorWindow.Subscribe(ColorPicker);
            ColorEditorWindow.Subscribe(editor.MapEditorControl);
            ColorEditorWindow.Subscribe(editor.TemplateControl);
            UpdatePanelColors();
            UpdateStatus();
            SetHoverStatus("");
        }

        public void SetForeColorIndex(int index)
        {
            ColorPicker.ForeColorIx = index;
            UpdatePanelColors();
            UpdateStatus();
        }

        public void SetBackColorIndex(int index)
        {
            ColorPicker.BackColorIx = index;
            UpdatePanelColors();
            UpdateStatus();
        }

        public int GetForeColorIndex()
        {
            return ColorPicker.ForeColorIx;
        }

        public int GetBackColorIndex()
        {
            return ColorPicker.BackColorIx;
        }

        private void ColorPicker_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int colorIx = ColorPicker.GetColorIndexAtMousePos(e.Location);
            if (colorIx < 0 || colorIx >= ColorPicker.Graphics.Palette.Size)
                return;

            ColorEditorWindow.SetColor(colorIx);
            ColorEditorWindow.Location = new Point(Location.X, Location.Y + 50);
            ColorEditorWindow.ShowDialog(this);
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
                SetHoverStatus("I: " + colorIx + " RGB: " + rgb);
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

        public override void Refresh()
        {
            base.Refresh();
            UpdatePanelColors();
        }

        private void UpdateStatus()
        {
            LblStatus.Text = 
                "C: " + ColorPicker.Graphics.Palette.Size + 
                " F: " + ColorPicker.ForeColorIx + 
                " B: " + ColorPicker.BackColorIx;
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
            if (Alert.Confirm("Clear palette?"))
            {
                ColorPicker.Clear();
                UpdatePanelColors();
                UpdateStatus();
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            if (Alert.Confirm("Reset palette to default colors?"))
            {
                ColorPicker.ResetToDefault();
                UpdatePanelColors();
                UpdateStatus();
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = MapEditor.WorkspacePath;
            dialog.Filter = PaletteFileFilter;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                PaletteFile.Save(ColorPicker.Graphics.Palette, dialog.FileName);
                Alert.Info("Palette exported successfully!");
            }
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = MapEditor.WorkspacePath;
            dialog.Filter = PaletteFileFilter;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ColorPicker.Graphics.Palette.SetEqual(PaletteFile.Load(dialog.FileName));
                ColorPicker.Refresh();
                UpdatePanelColors();
                UpdateStatus();

                Alert.Info("Palette imported successfully!");
            }
        }
    }
}
