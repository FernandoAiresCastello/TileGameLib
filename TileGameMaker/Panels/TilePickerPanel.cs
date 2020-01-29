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
using TileGameLib.Graphics;
using TileGameMaker.Util;
using TileGameLib.File;

namespace TileGameMaker.Panels
{
    public partial class TilePickerPanel : BasePanel
    {
        private MapEditor MapEditor;
        private TilePickerDisplay TilePicker;
        private TileEditorWindow TileEditorWindow;
        private TilePixels ClipboardTile = new TilePixels();

        private static readonly int MinTilesPerRowAllowed = 1;
        private static readonly int MaxTilesPerRowAllowed = 16;

        public TilePickerPanel()
        {
            InitializeComponent();
        }

        public TilePickerPanel(MapEditor editor)
        {
            InitializeComponent();
            MapEditor = editor;

            TilePicker = new TilePickerDisplay(PnlTilePicker, Config.ReadInt("TilePickerZoom"));
            int tilesPerRow = Config.ReadInt("TilePickerTilesPerRow");
            TilePicker.ResizeGraphicsByTileCount(TilePicker.Graphics.Tileset.Size, tilesPerRow);
            TxtTilesPerRow.Text = tilesPerRow.ToString();

            TilePicker.Graphics.Tileset = editor.Tileset;
            TilePicker.ShowGrid = true;
            TilePicker.MouseMove += TilePicker_MouseMove;
            TilePicker.MouseLeave += TilePicker_MouseLeave;
            TilePicker.MouseDown += TilePicker_MouseDown;
            TilePicker.MouseDoubleClick += TilePicker_MouseDoubleClick;
            SetHoverStatus("");
            UpdateStatus();
        }

        public void SetTileIndex(int index)
        {
            TilePicker.TileIndex = index;
            UpdateStatus();
            Refresh();
        }

        public int GetTileIndex()
        {
            return TilePicker.TileIndex;
        }

        private void CopyTile(int tileIx)
        {
            ClipboardTile = TilePicker.Graphics.Tileset.Copy(tileIx);
        }

        private void PasteTile(int tileIx)
        {
            TilePicker.Graphics.Tileset.Set(tileIx, ClipboardTile);
        }

        private void TilePicker_MouseDown(object sender, MouseEventArgs e)
        {
            int tileIx = TilePicker.GetTileIndexAtMousePos(e.Location);
            if (tileIx < 0 || tileIx >= TilePicker.Graphics.Tileset.Size)
                return;

            if (e.Button == MouseButtons.Left)
            {
                TilePicker.SelectTileIndex(tileIx);
                UpdateStatus();
            }
        }

        private void TilePicker_MouseMove(object sender, MouseEventArgs e)
        {
            int tileIx = TilePicker.GetTileIndexAtMousePos(e.Location);

            if (tileIx >= 0 && tileIx < TilePicker.Graphics.Tileset.Size)
                SetHoverStatus("IX: " + tileIx);
            else
                SetHoverStatus("");
        }

        private void TilePicker_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int tileIx = TilePicker.GetTileIndexAtMousePos(e.Location);

            TileEditorWindow = new TileEditorWindow(MapEditor.Tileset);
            TileEditorWindow.Subscribe(this);
            TileEditorWindow.Subscribe(TilePicker);
            TileEditorWindow.Subscribe(MapEditor.MapEditorControl);
            TileEditorWindow.Subscribe(MapEditor.TemplateControl);

            TileEditorWindow.SetTile(tileIx);

            TileEditorWindow.Show(this);
        }

        private void TilePicker_MouseLeave(object sender, EventArgs e)
        {
            SetHoverStatus("");
        }

        private void UpdateStatus()
        {
            StatusLabel.Text =
                "C: " + TilePicker.Graphics.Tileset.Size +
                " SEL: " + TilePicker.TileIndex;
        }

        private void SetHoverStatus(string status)
        {
            HoverLabel.Text = status;
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            if (Alert.Confirm("Clear tileset?"))
            {
                TilePicker.Clear();
                UpdateStatus();
            }
        }

        private void BtnCopy_Click(object sender, EventArgs e)
        {
            CopyTile(TilePicker.TileIndex);
        }

        private void BtnPaste_Click(object sender, EventArgs e)
        {
            PasteTile(TilePicker.TileIndex);
            Refresh();
            MapEditor.TemplateControl.Refresh();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            if (Alert.Confirm("Reset tileset to default tiles?"))
            {
                TilePicker.ResetToDefault();
                UpdateStatus();
            }
        }

        private void TxtTilesPerRow_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ApplyTilesPerRowSetting();
        }

        private void TxtTilesPerRow_Leave(object sender, EventArgs e)
        {
            ApplyTilesPerRowSetting();
        }

        private void ApplyTilesPerRowSetting()
        {
            int originalTilesPerRow = TilePicker.Cols;
            bool isNumber = int.TryParse(TxtTilesPerRow.Text, out int tilesPerRow);
            bool revert = false;

            if (isNumber)
            {
                if (tilesPerRow >= MinTilesPerRowAllowed && tilesPerRow <= MaxTilesPerRowAllowed)
                {
                    TilePicker.ResizeGraphicsByTileCount(TilePicker.Graphics.Tileset.Size, tilesPerRow);
                    TilePicker.Refresh();
                }
                else
                {
                    Alert.Warning($"Maximum tiles per row must be between {MinTilesPerRowAllowed} and {MaxTilesPerRowAllowed}");
                    revert = true;
                }
            }
            else
            {
                revert = true;
            }

            if (revert)
                TxtTilesPerRow.Text = originalTilesPerRow.ToString();
        }

        private void BtnExportRawBytes_Click(object sender, EventArgs e)
        {
            Export(TilesetExportFormat.RawBytes);
        }

        private void BtnExportBinaryStrings_Click(object sender, EventArgs e)
        {
            Export(TilesetExportFormat.BinaryStrings);
        }

        private void BtnExportHex_Click(object sender, EventArgs e)
        {
            Export(TilesetExportFormat.HexadecimalCsv);
        }

        private void Export(TilesetExportFormat format)
        {
            string fileExt = TilesetExportFileExtension.Get(format);

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = MapEditor.WorkspacePath;
            dialog.Filter = $"TileGameMaker tileset file (*.{fileExt})|*.{fileExt}";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                TilesetFile.Export(format, TilePicker.Graphics.Tileset, dialog.FileName);
                Alert.Info("Tileset exported successfully!");
            }
        }

        private void BtnImportRawBytes_Click(object sender, EventArgs e)
        {
            Import(TilesetExportFormat.RawBytes);
        }

        private void BtnImportBinaryStrings_Click(object sender, EventArgs e)
        {
            Import(TilesetExportFormat.BinaryStrings);
        }

        private void BtnImportHex_Click(object sender, EventArgs e)
        {
            Import(TilesetExportFormat.HexadecimalCsv);
        }

        private void Import(TilesetExportFormat format)
        {
            string fileExt = TilesetExportFileExtension.Get(format);

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = MapEditor.WorkspacePath;
            dialog.Filter = $"TileGameMaker tileset file (*.{fileExt})|*.{fileExt}";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                TilePicker.Graphics.Tileset.SetEqual(TilesetFile.Import(format, dialog.FileName));
                TilePicker.Refresh();
                UpdateStatus();

                Alert.Info("Tileset imported successfully!");
            }
        }

        private void BtnImportFromImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = MapEditor.WorkspacePath;
            dialog.Filter = $"PNG image file (*.png)|*.png";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                TilePicker.Graphics.Tileset.LoadFromImage(dialog.FileName);
            }
        }

        private void BtnExportToImage_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = MapEditor.WorkspacePath;
            dialog.Filter = $"PNG image file (*.png)|*.png";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                TilePicker.DrawTiles(false);
                TilePicker.Graphics.SaveImage(dialog.FileName);
                TilePicker.DrawTiles(true);
                Alert.Info("Tileset successfully saved to image!");
            }
        }
    }
}
