using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        }

        private void BtnExtractMapData_Click(object sender, EventArgs e) => ExtractMapData();
        private void BtnExtractPaletteData_Click(object sender, EventArgs e) => ExtractPaletteData();
        private void BtnExtractTilesetData_Click(object sender, EventArgs e) => ExtractTilesetData();

        private void ExtractMapData()
        {
            int layerIndex = CmbLayer.SelectedIndex;
            bool extractTag = ChkObjectTag.Checked;
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

            if (extractTag)
            {
                output.AppendLine("[Tag]");

                for (int y = 0; y < layer.Height; y++)
                {
                    output.Append(linePrefix);

                    for (int x = 0; x < layer.Width; x++)
                    {
                        GameObject o = layer.GetObject(x, y);
                        output.Append(o == null || !o.HasTag ? emptyCell : o.Tag);

                        if (y <= layer.Height - 1 && x < layer.Width - 1)
                            output.Append(itemSeparator);
                    }

                    output.Append(lineSuffix);
                    output.AppendLine();
                }
            }

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
            bool decimalInt = RbPaletteFmtDecInt.Checked;
            bool hexadecimalInt = RbPaletteFmtHexInt.Checked;
            bool decimalRgb = RbPaletteFmtDecRgb.Checked;
            bool hexadecimalRgb = RbPaletteFmtHexRgb.Checked;
            bool appendAlpha = ChkColorAppendAlpha.Checked;
            string linePrefix = TxtColorLinePrefix.Text;
            string lineSuffix = TxtColorLineSuffix.Text;
            string hexPrefix = TxtColorHexPrefix.Text;
            string rgbSeparator = TxtColorComponentSeparator.Text;

            StringBuilder output = new StringBuilder();
            output.AppendLine($"Palette size: {Map.Palette.Size}");
            output.AppendLine();

            for (int colorIndex = 0; colorIndex < Map.Palette.Size; colorIndex++)
            {
                Color color = Map.Palette.GetColorObject(colorIndex);

                output.Append(linePrefix);

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
            bool decimalBytes = RbTileDecimal.Checked;
            bool hexadecimalBytes = RbTileHexadecimal.Checked;
            bool binaryString = RbTileBinaryString.Checked;
            bool base64 = RbTileBase64.Checked;
            string linePrefix = TxtTileLinePrefix.Text;
            string lineSuffix = TxtTileLineSuffix.Text;
            string hexPrefix = TxtTileHexPrefix.Text;
            string byteSeparator = TxtTileByteSeparator.Text;

            StringBuilder output = new StringBuilder();
            output.AppendLine($"Tileset size: {Map.Tileset.Size}");
            output.AppendLine();

            for (int tileIndex = 0; tileIndex < Map.Tileset.Size; tileIndex++)
            {
                TilePixels tile = Map.Tileset.Get(tileIndex);

                output.Append(linePrefix);

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
    }
}
