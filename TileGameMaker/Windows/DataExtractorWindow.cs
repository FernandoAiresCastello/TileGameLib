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

            StringBuilder output = new StringBuilder();
            ObjectLayer layer = Map.Layers[layerIndex];

            output.AppendLine($"Map name: {Map.Name}");
            output.AppendLine($"Map size: W{Map.Width} H{Map.Height}");
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
                    output.Append(Environment.NewLine);
                }
            }

            TxtOutput.Text = output.ToString();
        }

        private void ExtractPaletteData()
        {
            throw new NotImplementedException();
        }

        private void ExtractTilesetData()
        {
            throw new NotImplementedException();
        }
    }
}
