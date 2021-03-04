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
using TileGameLib.GameElements;

namespace TileGameMaker.Panels
{
    public partial class TilePickerPanel : UserControl
    {
        public bool PopOutAllowed
        {
            set { BtnPopOutWindow.Enabled = BtnPopOutWindow.Visible = value; }
            get { return BtnPopOutWindow.Enabled; }
        }

        public bool CloseOnTileSelected { set; get; } = false;

        public bool HideToolStrip
        {
            set
            {
                if (value)
                    ToolStrip.Hide();
            }
        }

        public int SelectedTile => TilePicker.TileIndex;

        private MapEditor MapEditor;
        private TilePickerDisplay TilePicker;
        private TileEditor8x8Window TileEditor8x8Window;
        private TileEditor16x16Window TileEditor16x16Window;
        private TilePixels ClipboardTile = new TilePixels();

        private bool RearrangeMode => BtnRearrange.Checked;

        public TilePickerPanel()
        {
            InitializeComponent();
        }

        public TilePickerPanel(MapEditor editor, int tilesPerRow)
        {
            InitializeComponent();

            MapEditor = editor;
            TilePicker = new TilePickerDisplay(PnlTilePicker, editor.Tileset, tilesPerRow);
            TilePicker.ShowGrid = true;

            TilePicker.MouseMove += TilePicker_MouseMove;
            TilePicker.MouseLeave += TilePicker_MouseLeave;
            TilePicker.MouseDown += TilePicker_MouseDown;
            TilePicker.MouseUp += TilePicker_MouseUp;
            TilePicker.MouseDoubleClick += TilePicker_MouseDoubleClick;

            UpdateDefaultTilesetMenu();
            SetHoverStatus("");
            UpdateStatus();
        }

        private void UpdateDefaultTilesetMenu()
        {
            int defaultTilesetEnumValue = 0;

            foreach (string defaultTileset in Tileset.GetDefaultTilesetNames())
            {
                ToolStripMenuItem item = new ToolStripMenuItem(defaultTileset);
                item.Click += DefaultTilesetItem_Click;
                item.Tag = defaultTilesetEnumValue;
                BtnRestoreDefault.DropDownItems.Add(item);
                defaultTilesetEnumValue++;
            }
       }

        private void DefaultTilesetItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            int defaultTilesetEnumValue = (int)item.Tag;
            TilePicker.Graphics.Tileset.InitDefault((Tileset.Default)defaultTilesetEnumValue);
            UpdateStatus();
            Refresh();
        }

        public void SetTileIndex(int index)
        {
            TilePicker.TileIndex = index;
            UpdateStatus();
            Refresh();
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
            if (tileIx == TilePickerDisplay.InvalidIndex)
                return;

            if (e.Button == MouseButtons.Left)
            {
                if (RearrangeMode)
                {
                    TilePicker.StartRearrange(tileIx);
                }
                else
                {
                    TilePicker.SelectTileIndex(tileIx);
                    MapEditor.SetClipboardTileIndex(tileIx);

                    if (CloseOnTileSelected)
                        ParentForm.Close();

                    UpdateStatus();
                }
            }
        }

        private void TilePicker_MouseMove(object sender, MouseEventArgs e)
        {
            int tileIx = TilePicker.GetTileIndexAtMousePos(e.Location);
            if (tileIx == TilePickerDisplay.InvalidIndex)
                return;

            if (RearrangeMode)
            {
                TilePicker.UpdateRearrange(tileIx);
            }

            if (tileIx >= 0 && tileIx < TilePicker.Graphics.Tileset.Size)
                SetHoverStatus("IX: " + tileIx);
            else
                SetHoverStatus("");
        }

        private void TilePicker_MouseUp(object sender, MouseEventArgs e)
        {
            int tileIx = TilePicker.GetTileIndexAtMousePos(e.Location);
            if (tileIx == TilePickerDisplay.InvalidIndex)
                return;

            if (e.Button == MouseButtons.Left)
            {
                if (RearrangeMode)
                {
                    TilePicker.EndRearrange(tileIx);
                }
            }
        }

        private void TilePicker_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int tileIx = TilePicker.GetTileIndexAtMousePos(e.Location);
            if (tileIx == TilePickerDisplay.InvalidIndex)
                return;

            if (BtnUse16x16TileEditor.Checked)
            {
                if (tileIx <= MapEditor.Tileset.Size - 4)
                {
                    TileEditor16x16Window = new TileEditor16x16Window(MapEditor.Tileset);
                    TileEditor16x16Window.Subscribe(this);
                    TileEditor16x16Window.Subscribe(TilePicker);
                    TileEditor16x16Window.Subscribe(MapEditor.MapEditorControl);
                    TileEditor16x16Window.SetTiles(tileIx, tileIx + 1, tileIx + 2, tileIx + 3);
                    TileEditor16x16Window.Show(this);
                }
                else
                {
                    Alert.Warning("Can't use 16x16 editor from this tile index");
                }
            }
            else
            {
                TileEditor8x8Window = new TileEditor8x8Window(MapEditor.Tileset);
                TileEditor8x8Window.Subscribe(this);
                TileEditor8x8Window.Subscribe(TilePicker);
                TileEditor8x8Window.Subscribe(MapEditor.MapEditorControl);
                TileEditor8x8Window.SetTile(tileIx);
                TileEditor8x8Window.Show(this);
            }
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

        private void BtnCopy_Click(object sender, EventArgs e)
        {
            CopyTile(TilePicker.TileIndex);
        }

        private void BtnPaste_Click(object sender, EventArgs e)
        {
            PasteTile(TilePicker.TileIndex);
            Refresh();
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
            dialog.InitialDirectory = MapEditor.Project.Folder;
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
            dialog.InitialDirectory = MapEditor.Project.Folder;
            dialog.Filter = $"TileGameMaker tileset file (*.{fileExt})|*.{fileExt}";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Tileset tileset = TilesetFile.Import(format, dialog.FileName);
                TilePicker.Graphics.Tileset.SetEqual(tileset);
                TilePicker.UpdateSize();
                MapEditor.Map.Tileset.SetEqual(tileset);
                MapEditor.Refresh();
                UpdateStatus();

                Alert.Info("Tileset imported successfully!");
            }
        }

        private void BtnExportToImage_Click(object sender, EventArgs e)
        {
            ExportToImage();
        }

        private void ExportToImage()
        {
            TilesetExportImportWindow win = new TilesetExportImportWindow(MapEditor.Tileset);
            win.InitialFolder = MapEditor.Project.Folder;
            win.ShowDialog(this);
        }

        private void BtnSwitchTileEditor_Click(object sender, EventArgs e)
        {
            BtnUse16x16TileEditor.Checked = !BtnUse16x16TileEditor.Checked;
        }

        private void BtnClearAll_Click(object sender, EventArgs e)
        {
            if (Alert.Confirm("Clear entire tileset?"))
            {
                TilePicker.Clear();
                UpdateStatus();
            }
        }

        private void BtnClearRange_Click(object sender, EventArgs e)
        {
            RangeInputWindow win = new RangeInputWindow();
            win.FromMinValue = 0;
            win.ToMinValue = 0;
            win.FromMaxValue = TilePicker.Graphics.Tileset.Size - 1;
            win.ToMaxValue = TilePicker.Graphics.Tileset.Size - 1;
            win.FromIncrement = 1;
            win.ToIncrement = 1;
            win.FromValue = 0;
            win.ToValue = 0;

            if (win.ShowDialog(this) == DialogResult.OK)
            {
                int from = win.FromValue;
                int to = win.ToValue;

                if (to == from)
                    return;

                if (to > from)
                {
                    TilePicker.ClearRange(from, to);
                    UpdateStatus();
                }
                else
                {
                    Alert.Warning("Invalid range");
                }
            }
        }

        private void BtnAdd8Tiles_Click(object sender, EventArgs e)
        {
            TilePicker.Add8Tiles();
            UpdateStatus();
        }

        private void BtnRearrange_Click(object sender, EventArgs e)
        {
            BtnRearrange.Checked = !BtnRearrange.Checked;
        }

        private void BtnPopOutWindow_Click(object sender, EventArgs e)
        {
            if (!PopOutAllowed)
                return;

            Hide();

            Form window = new Form();
            window.Text = "Tileset";
            window.Size = new Size(619, 626);
            window.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            window.StartPosition = FormStartPosition.CenterScreen;

            Panel panel = new Panel();
            panel.Dock = DockStyle.Fill;
            panel.Parent = window;

            TilePickerPanel poppedOutPicker = new TilePickerPanel(MapEditor, 24);
            poppedOutPicker.PopOutAllowed = false;
            poppedOutPicker.Dock = DockStyle.Fill;
            poppedOutPicker.Parent = panel;

            window.ShowDialog(this);

            Refresh();
            Show();
        }

        private void BtnCode_Click(object sender, EventArgs e)
        {
            BinaryCodeSequenceWindow win = new BinaryCodeSequenceWindow(
                "View / edit tile sequence as code", 
                "8 hexadecimal bytes (ex. 7E,FF,DB,FF,C3,E7,FF,7E)", SelectedTile,
                GetTileLines, SetTileLines);

            win.ShowDialog(this);
        }

        private List<string> GetTileLines(int firstTileIndex, int lastTileIndex)
        {
            List<string> lines = new List<string>();

            for (int i = firstTileIndex; i <= lastTileIndex; i++)
            {
                TilePixels row = TilePicker.Tileset.Get(i);
                lines.Add(row.ToHexCsvString());
            }

            return lines;
        }

        private void SetTileLines(int firstTileIndex, int lastTileIndex, List<string> tileBytes)
        {
            try
            {
                int listIndex = 0;

                for (int i = firstTileIndex; i <= lastTileIndex; i++)
                {
                    if (i < TilePicker.Tileset.Size && listIndex < tileBytes.Count)
                    {
                        string[] rows = tileBytes[listIndex++].Split(',');
                        int rowIndex = 0;
                        byte row1 = byte.Parse(rows[rowIndex++], System.Globalization.NumberStyles.HexNumber);
                        byte row2 = byte.Parse(rows[rowIndex++], System.Globalization.NumberStyles.HexNumber);
                        byte row3 = byte.Parse(rows[rowIndex++], System.Globalization.NumberStyles.HexNumber);
                        byte row4 = byte.Parse(rows[rowIndex++], System.Globalization.NumberStyles.HexNumber);
                        byte row5 = byte.Parse(rows[rowIndex++], System.Globalization.NumberStyles.HexNumber);
                        byte row6 = byte.Parse(rows[rowIndex++], System.Globalization.NumberStyles.HexNumber);
                        byte row7 = byte.Parse(rows[rowIndex++], System.Globalization.NumberStyles.HexNumber);
                        byte row8 = byte.Parse(rows[rowIndex], System.Globalization.NumberStyles.HexNumber);

                        TilePicker.Tileset.Set(i, row1, row2, row3, row4, row5, row6, row7, row8);
                        TilePicker.Refresh();
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Alert.Error("There was an error while setting tile sequence bytes:\n\n" + ex.Message);
            }
        }
    }
}
