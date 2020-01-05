﻿using System;
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

namespace TileGameMaker.Panels
{
    public partial class ColorPickerPanel : BasePanel
    {
        private MapEditor MapEditor;
        private ColorPickerDisplay ColorPicker;
        private ColorEditorWindow ColorEditorWindow;

        private static readonly string PaletteFileExt = "tgpal";
        private static readonly string PaletteFileFilter = $"TileGameMaker palette file (*.{PaletteFileExt})|*.{PaletteFileExt}";
        private static readonly int MinTilesPerRowAllowed = 1;
        private static readonly int MaxTilesPerRowAllowed = 16;

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
            TxtColorsPerRow.Text = colorsPerRow.ToString();

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
        {
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
                TxtColorsPerRow.Text = originalTilesPerRow.ToString();
        }
    }
}
