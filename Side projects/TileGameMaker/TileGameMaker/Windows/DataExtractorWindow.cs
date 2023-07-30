using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.File;
using TileGameLib.GameElements;
using TileGameLib.Graphics;
using TileGameLib.Util;
using TileGameMaker.MapEditorElements;
using TileGameMaker.Util;

namespace TileGameMaker.Windows
{
    public partial class DataExtractorWindow : Form
    {
        private MapEditor MapEditor;
        private ObjectMap Map => MapEditor.Map;
        private ConfigBundle Cfg => MapEditor.Project.Config;

        private DataExtractorWindow() : this(null)
        {
        }

        public DataExtractorWindow(MapEditor editor)
        {
            InitializeComponent();
            Icon = Global.WindowIcon;
            MapEditor = editor;

            for (int i = 0; i < Map.Layers.Count; i++)
                CmbLayer.Items.Add("Layer " + i);

            CmbLayer.SelectedIndex = 0;

            PaletteRangeFirst.Value = 0;
            PaletteRangeLast.Value = PaletteRangeLast.Maximum = Map.Palette.Size - 1;
            TilesetRangeFirst.Value = 0;
            TilesetRangeLast.Value = TilesetRangeLast.Maximum = Map.Tileset.Size - 1;

            KeyPreview = true;
            KeyDown += DataExtractorWindow_KeyDown;
        }

        private void DataExtractorWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.F5)
            {
                Close();
            }
        }

        protected override void OnShown(EventArgs e)
        {
            ParseConfig();

            base.OnShown(e);
        }

        protected override void OnClosed(EventArgs e)
        {
            StoreConfig();

            base.OnClosed(e);
        }

        private void BtnExtractMapData_Click(object sender, EventArgs e) => ExtractMapData();
        private void BtnExtractPaletteData_Click(object sender, EventArgs e) => ExtractPaletteData();
        private void BtnExtractTilesetData_Click(object sender, EventArgs e) => ExtractTilesetData();

        private void ExtractMapData()
        {
            StoreConfig();

            int layerIndex = CmbLayer.SelectedIndex;
            bool extract1stTileIndex = ChkObject1stTileIndex.Checked;
            bool extract1stTileForeColor = ChkObject1stTileForeColor.Checked;
            bool extract1stTileBackColor = ChkObject1stTileBackColor.Checked;
            string itemSeparator = TxtObjectDataItemSeparator.Text;
            string emptyCell = TxtObjectEmptyCell.Text;
            string linePrefix = TxtObjectLinePrefix.Text;
            string lineSuffix = TxtObjectLineSuffix.Text;

            ObjectLayer layer = Map.Layers[layerIndex];

            StringBuilder output = new StringBuilder();
            output.AppendLine($"Name: {Map.Name}");
            output.AppendLine($"Size: W{Map.Width} H{Map.Height}");
            output.AppendLine($"Layer: {layerIndex}");
            output.AppendLine($"Objects: {layer.Width * layer.Height}");
            output.AppendLine();

            if (extract1stTileIndex)
            {
                output.AppendLine("[1st tile index]");

                for (int y = 0; y < layer.Height; y++)
                {
                    output.Append(linePrefix);

                    for (int x = 0; x < layer.Width; x++)
                    {
                        GameObject o = layer.GetObject(x, y);
                        output.Append(o == null ?
                            emptyCell : o.Animation.FirstFrame.Index.ToString());

                        if (y <= layer.Height - 1 && x < layer.Width - 1)
                            output.Append(itemSeparator);
                    }

                    output.Append(lineSuffix);
                    output.Append(Environment.NewLine);
                }
            }

            if (extract1stTileForeColor)
            {
                output.AppendLine("[1st tile forecolor]");

                for (int y = 0; y < layer.Height; y++)
                {
                    output.Append(linePrefix);

                    for (int x = 0; x < layer.Width; x++)
                    {
                        GameObject o = layer.GetObject(x, y);
                        output.Append(o == null ?
                            emptyCell : o.Animation.FirstFrame.ForeColor.ToString());

                        if (y <= layer.Height - 1 && x < layer.Width - 1)
                            output.Append(itemSeparator);
                    }

                    output.Append(lineSuffix);
                    output.Append(Environment.NewLine);
                }
            }

            if (extract1stTileBackColor)
            {
                output.AppendLine("[1st tile backcolor]");

                for (int y = 0; y < layer.Height; y++)
                {
                    output.Append(linePrefix);

                    for (int x = 0; x < layer.Width; x++)
                    {
                        GameObject o = layer.GetObject(x, y);
                        output.Append(o == null ?
                            emptyCell : o.Animation.FirstFrame.BackColor.ToString());

                        if (y <= layer.Height - 1 && x < layer.Width - 1)
                            output.Append(itemSeparator);
                    }

                    output.Append(lineSuffix);
                    output.AppendLine();
                }
            }

            TxtOutput.Text = output.ToString();
        }

        private void ExtractPaletteData()
        {
            StoreConfig();

            bool decimalInt = RbPaletteFmtDecInt.Checked;
            bool hexadecimalInt = RbPaletteFmtHexInt.Checked;
            bool decimalRgb = RbPaletteFmtDecRgb.Checked;
            bool hexadecimalRgb = RbPaletteFmtHexRgb.Checked;
            bool appendAlpha = ChkColorAppendAlpha.Checked;
            string linePrefix = TxtColorLinePrefix.Text;
            string lineSuffix = TxtColorLineSuffix.Text;
            string hexPrefix = TxtColorHexPrefix.Text;
            string rgbSeparator = TxtColorComponentSeparator.Text;
            int first = decimal.ToInt32(PaletteRangeFirst.Value);
            int last = decimal.ToInt32(PaletteRangeLast.Value);

            StringBuilder output = new StringBuilder();
            output.AppendLine($"Palette size: {Map.Palette.Size}");
            output.AppendLine($"Range: {first}-{last}");
            output.AppendLine();

            for (int colorIndex = first; colorIndex <= last; colorIndex++)
            {
                Color color = Map.Palette.GetColorObject(colorIndex);

                output.Append(linePrefix);

                if (ChkAppendColorIndex.Checked)
                {
                    if (hexadecimalInt || hexadecimalRgb)
                        output.Append("0x" + colorIndex.ToString("x2"));
                    else
                        output.Append(colorIndex);

                    output.Append(rgbSeparator);
                }

                if (decimalInt)
                {
                    if (appendAlpha)
                        output.Append(color.ToArgb());
                    else
                        output.Append(Color.FromArgb(255, color).ToArgb());
                }
                else if (hexadecimalInt)
                {
                    output.Append(hexPrefix);
                    string value = color.ToArgb().ToString("x8");

                    if (!appendAlpha)
                        value = value.Substring(2);

                    output.Append(value);
                }
                else if (decimalRgb)
                {
                    if (appendAlpha)
                        output.Append(color.A + rgbSeparator);

                    output.Append(color.R + rgbSeparator);
                    output.Append(color.G + rgbSeparator);
                    output.Append(color.B);
                }
                else if (hexadecimalRgb)
                {
                    if (appendAlpha)
                        output.Append(hexPrefix + color.A.ToString("x2") + rgbSeparator);

                    output.Append(hexPrefix + color.R.ToString("x2") + rgbSeparator);
                    output.Append(hexPrefix + color.G.ToString("x2") + rgbSeparator);
                    output.Append(hexPrefix + color.B.ToString("x2"));
                }

                output.Append(lineSuffix);
                output.AppendLine();
            }

            TxtOutput.Text = output.ToString();
        }

        private void ExtractTilesetData()
        {
            StoreConfig();

            bool decimalBytes = RbTileDecimal.Checked;
            bool hexadecimalBytes = RbTileHexadecimal.Checked;
            bool binaryString = RbTileBinaryString.Checked;
            bool base64 = RbTileBase64.Checked;
            string linePrefix = TxtTileLinePrefix.Text;
            string lineSuffix = TxtTileLineSuffix.Text;
            string hexPrefix = TxtTileHexPrefix.Text;
            string byteSeparator = TxtTileByteSeparator.Text;
            int first = decimal.ToInt32(TilesetRangeFirst.Value);
            int last = decimal.ToInt32(TilesetRangeLast.Value);

            StringBuilder output = new StringBuilder();
            output.AppendLine($"Tileset size: {Map.Tileset.Size}");
            output.AppendLine($"Range: {first}-{last}");
            output.AppendLine();

            for (int tileIndex = first; tileIndex <= last; tileIndex++)
            {
                TilePixels tile = Map.Tileset.Get(tileIndex);

                output.Append(linePrefix);
                
                if (ChkAppendTileIndex.Checked)
                {
                    if (hexadecimalBytes)
                        output.Append("0x" + tileIndex.ToString("x2"));
                    else
                        output.Append(tileIndex);

                    output.Append(byteSeparator);
                }

                if (decimalBytes)
                {
                    for (int row = 0; row < tile.PixelRows.Length; row++)
                    {
                        byte rowByte = tile.PixelRows[row];
                        output.Append(rowByte);
                        if (row < tile.PixelRows.Length - 1)
                            output.Append(byteSeparator);
                    }
                }
                else if (hexadecimalBytes)
                {
                    for (int row = 0; row < tile.PixelRows.Length; row++)
                    {
                        byte rowByte = tile.PixelRows[row];
                        output.Append(hexPrefix);
                        output.Append(rowByte.ToString("x2"));
                        if (row < tile.PixelRows.Length - 1)
                            output.Append(byteSeparator);
                    }
                }
                else if (binaryString)
                {
                    StringBuilder binary = new StringBuilder();

                    for (int row = 0; row < tile.PixelRows.Length; row++)
                    {
                        byte rowByte = tile.PixelRows[row];
                        binary.Append(rowByte.ToBinaryString());
                    }

                    output.Append(binary);
                }
                else if (base64)
                {
                    output.Append(Convert.ToBase64String(tile.PixelRows));
                }

                output.Append(lineSuffix);
                output.AppendLine();
            }

            TxtOutput.Text = output.ToString();
        }

        private void BtnCopyOutput_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TxtOutput.Text))
            {
                string text = string.Join(Environment.NewLine, TxtOutput.Lines.Skip(3)); // Skip header
                Clipboard.SetText(text);
            }
        }

        private void StoreConfig()
        {
            Cfg.SetBool("dataExtractor.tileset.decimalBytes", RbTileDecimal.Checked);
            Cfg.SetBool("dataExtractor.tileset.hexadecimalBytes", RbTileHexadecimal.Checked);
            Cfg.SetBool("dataExtractor.tileset.binaryString", RbTileBinaryString.Checked);
            Cfg.SetBool("dataExtractor.tileset.base64", RbTileBase64.Checked);
            Cfg.SetString("dataExtractor.tileset.linePreffix", TxtTileLinePrefix.Text);
            Cfg.SetString("dataExtractor.tileset.lineSuffix", TxtTileLineSuffix.Text);
            Cfg.SetString("dataExtractor.tileset.hexPrefix", TxtTileHexPrefix.Text);
            Cfg.SetString("dataExtractor.tileset.byteSeparator", TxtTileByteSeparator.Text);
            Cfg.SetBool("dataExtractor.tileset.appendTileIndex", ChkAppendTileIndex.Checked);

            Cfg.SetBool("dataExtractor.palette.decimalInt", RbPaletteFmtDecInt.Checked);
            Cfg.SetBool("dataExtractor.palette.hexadecimalInt", RbPaletteFmtHexInt.Checked);
            Cfg.SetBool("dataExtractor.palette.decimalRgb", RbPaletteFmtDecRgb.Checked);
            Cfg.SetBool("dataExtractor.palette.hexadecimalRgb", RbPaletteFmtHexRgb.Checked);
            Cfg.SetBool("dataExtractor.palette.appendAlpha", ChkColorAppendAlpha.Checked);
            Cfg.SetString("dataExtractor.palette.linePrefix", TxtColorLinePrefix.Text);
            Cfg.SetString("dataExtractor.palette.lineSuffix", TxtColorLineSuffix.Text);
            Cfg.SetString("dataExtractor.palette.hexPrefix", TxtColorHexPrefix.Text);
            Cfg.SetString("dataExtractor.palette.rgbSeparator", TxtColorComponentSeparator.Text);
            Cfg.SetBool("dataExtractor.palette.appendColorIndex", ChkAppendColorIndex.Checked);
        }

        private void ParseConfig()
        {
            RbTileDecimal.Checked = Cfg.GetBool("dataExtractor.tileset.decimalBytes");
            RbTileHexadecimal.Checked = Cfg.GetBool("dataExtractor.tileset.hexadecimalBytes");
            RbTileBinaryString.Checked = Cfg.GetBool("dataExtractor.tileset.binaryString");
            RbTileBase64.Checked = Cfg.GetBool("dataExtractor.tileset.base64");
            TxtTileLinePrefix.Text = Cfg.GetString("dataExtractor.tileset.linePreffix");
            TxtTileLineSuffix.Text = Cfg.GetString("dataExtractor.tileset.lineSuffix");
            TxtTileHexPrefix.Text = Cfg.GetString("dataExtractor.tileset.hexPrefix");
            TxtTileByteSeparator.Text = Cfg.GetString("dataExtractor.tileset.byteSeparator");
            ChkAppendTileIndex.Checked = Cfg.GetBool("dataExtractor.tileset.appendTileIndex");

            RbPaletteFmtDecInt.Checked = Cfg.GetBool("dataExtractor.palette.decimalInt");
            RbPaletteFmtHexInt.Checked = Cfg.GetBool("dataExtractor.palette.hexadecimalInt");
            RbPaletteFmtDecRgb.Checked = Cfg.GetBool("dataExtractor.palette.decimalRgb");
            RbPaletteFmtHexRgb.Checked = Cfg.GetBool("dataExtractor.palette.hexadecimalRgb");
            ChkColorAppendAlpha.Checked = Cfg.GetBool("dataExtractor.palette.appendAlpha");
            TxtColorLinePrefix.Text = Cfg.GetString("dataExtractor.palette.linePrefix");
            TxtColorLineSuffix.Text = Cfg.GetString("dataExtractor.palette.lineSuffix");
            TxtColorHexPrefix.Text = Cfg.GetString("dataExtractor.palette.hexPrefix");
            TxtColorComponentSeparator.Text = Cfg.GetString("dataExtractor.palette.rgbSeparator");
            ChkAppendColorIndex.Checked = Cfg.GetBool("dataExtractor.palette.appendColorIndex");
        }
    }
}
