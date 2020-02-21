using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameMaker.MapEditorElements;
using TileGameMaker.Windows;
using TileGameMaker.TiledDisplays;
using TileGameLib.Util;
using TileGameMaker.Util;
using TileGameLib.File;
using TileGameLib.Graphics;

namespace TileGameMaker.Panels
{
    public partial class ColorPickerPanel : BasePanel
    {
        private MapEditor MapEditor;
        private ColorPickerDisplay ColorPicker;
        private ColorEditorWindow ColorEditorWindow;

        //private static readonly int MinTilesPerRowAllowed = 1;
        //private static readonly int MaxTilesPerRowAllowed = 16;

        public ColorPickerPanel()
        {
            InitializeComponent();
        }

        public ColorPickerPanel(MapEditor editor)
        {
            InitializeComponent();
            MapEditor = editor;

            ColorPicker = new ColorPickerDisplay(PnlColorPicker, 
                Config.ReadInt("ColorPickerCols"), 
                Config.ReadInt("ColorPickerRows"), 
                Config.ReadInt("ColorPickerZoom"));

            int colorsPerRow = Config.ReadInt("ColorPickerColorsPerRow");
            ColorPicker.ResizeGraphicsByTileCount(ColorPicker.Graphics.Palette.Size, colorsPerRow);
            //TxtColorsPerRow.Text = colorsPerRow.ToString();

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

            UpdateDefaultPaletteMenu();
            UpdatePanelColors();
            UpdateStatus();
            SetHoverStatus("");
        }

        private void UpdateDefaultPaletteMenu()
        {
            int defaultPaletteEnumValue = 0;

            foreach (string defaultTileset in Palette.GetDefaultPaletteNames())
            {
                ToolStripMenuItem item = new ToolStripMenuItem(defaultTileset);
                item.Click += DefaultPaletteItem_Click;
                item.Tag = defaultPaletteEnumValue;
                BtnRestoreDefault.DropDownItems.Add(item);
                defaultPaletteEnumValue++;
            }
        }

        private void DefaultPaletteItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            int defaultPaletteEnumValue = (int)item.Tag;
            ColorPicker.Graphics.Palette.InitDefault((Palette.Default)defaultPaletteEnumValue);
            UpdateStatus();
            Refresh();
        }

        public void SetForeColorIndex(int index)
        {
            ColorPicker.ForeColorIx = index;
            Refresh();
            UpdatePanelColors();
            UpdateStatus();
        }

        public void SetBackColorIndex(int index)
        {
            ColorPicker.BackColorIx = index;
            Refresh();
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
            int colorIx = ColorPicker.GetBackColorIndexAtMousePos(e.Location);
            if (colorIx < 0 || colorIx >= ColorPicker.Graphics.Palette.Size)
                return;

            ColorEditorWindow.SetColor(colorIx);
            ColorEditorWindow.Location = new Point(Location.X, Location.Y + 50);
            ColorEditorWindow.ShowDialog(this);
        }

        private void ColorPicker_MouseClick(object sender, MouseEventArgs e)
        {
            int colorIx = ColorPicker.GetBackColorIndexAtMousePos(e.Location);
            if (colorIx < 0 || colorIx >= ColorPicker.Graphics.Palette.Size)
                return;

            if (e.Button == MouseButtons.Left)
                ColorPicker.ForeColorIx = colorIx;
            else if (e.Button == MouseButtons.Right)
                ColorPicker.BackColorIx = colorIx;

            Refresh();
            UpdatePanelColors();
            UpdateStatus();
        }

        private void ColorPicker_MouseMove(object sender, MouseEventArgs e)
        {
            int colorIx = ColorPicker.GetBackColorIndexAtMousePos(e.Location);
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
            Refresh();
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

        private void TxtColorsPerRow_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ApplyColorsPerRowSetting();
        }

        private void TxtColorsPerRow_Leave(object sender, EventArgs e)
        {
            ApplyColorsPerRowSetting();
        }

        private void ApplyColorsPerRowSetting()
        {/*
            int originalTilesPerRow = ColorPicker.Cols;
            bool isNumber = int.TryParse(TxtColorsPerRow.Text, out int colorsPerRow);
            bool revert = false;

            if (isNumber)
            {
                if (colorsPerRow >= MinTilesPerRowAllowed && colorsPerRow <= MaxTilesPerRowAllowed)
                {
                    ColorPicker.ResizeGraphicsByTileCount(ColorPicker.Graphics.Tileset.Size, colorsPerRow);
                    ColorPicker.Refresh();
                }
                else
                {
                    Alert.Warning($"Maximum colors per row must be between {MinTilesPerRowAllowed} and {MaxTilesPerRowAllowed}");
                    revert = true;
                }
            }
            else
            {
                revert = true;
            }

            if (revert)
                TxtColorsPerRow.Text = originalTilesPerRow.ToString();*/
        }

        private void BtnExportRawBytes_Click(object sender, EventArgs e)
        {
            Export(PaletteExportFormat.RawBytes);
        }

        private void BtnExportHexRgb_Click(object sender, EventArgs e)
        {
            Export(PaletteExportFormat.HexadecimalRgb);
        }

        private void BtnExportHexCsv_Click(object sender, EventArgs e)
        {
            Export(PaletteExportFormat.HexadecimalCsv);
        }

        private void Export(PaletteExportFormat format)
        {
            string fileExt = PaletteExportFileExtension.Get(format);

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = MapEditor.WorkspacePath;
            dialog.Filter = $"TileGameMaker palette file (*.{fileExt})|*.{fileExt}";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                PaletteFile.Export(format, ColorPicker.Graphics.Palette, dialog.FileName);
                Alert.Info("Palette exported successfully!");
            }
        }

        private void BtnImportRawBytes_Click(object sender, EventArgs e)
        {
            Import(PaletteExportFormat.RawBytes);
        }

        private void Import(PaletteExportFormat format)
        {
            string fileExt = PaletteExportFileExtension.Get(format);

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = MapEditor.WorkspacePath;
            dialog.Filter = $"TileGameMaker palette file (*.{fileExt})|*.{fileExt}";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ColorPicker.Graphics.Palette.SetEqual(PaletteFile.Import(format, dialog.FileName));
                ColorPicker.Refresh();
                UpdatePanelColors();
                UpdateStatus();

                Alert.Info("Palette imported successfully!");
            }
        }
    }
}
