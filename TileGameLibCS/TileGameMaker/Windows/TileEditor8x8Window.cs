using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Graphics;
using TileGameLib.Util;
using TileGameMaker.TiledDisplays;
using TileGameMaker.Util;

namespace TileGameMaker.Windows
{
    public partial class TileEditor8x8Window : BaseWindow
    {
        private int TileIndex = 0;

        private readonly TileEditor8x8Display TileEditor;
        private readonly Tileset Tileset;
        private TilePixels OriginalPixels;
        private readonly int PixelOn = Config.ReadInt("TileEditorPixelOnValue");
        private readonly int PixelOff = Config.ReadInt("TileEditorPixelOffValue");

        public TileEditor8x8Window(Tileset tileset, bool ptmFormatHexIndex)
        {
            InitializeComponent();
            Tileset = tileset;
            KeyPreview = true;

            TileEditor = new TileEditor8x8Display(TilePanel, Config.ReadInt("TileEditorZoom"));

            TileEditor.ShowGrid = true;
            TileEditor.MouseMove += TileEditor_MouseMove;
            TileEditor.MouseLeave += TileEditor_MouseLeave;
            TileEditor.MouseDown += TileEditor_MouseDown;
            KeyDown += TileEditor8x8Window_KeyDown;

            HoverLabel.Text = "";
            ChkHexIndex.Checked = ptmFormatHexIndex;
        }

        private void TileEditor8x8Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                Close();
            }
        }

        private void TileEditor_MouseDown(object sender, MouseEventArgs e)
        {
            Point p = TileEditor.GetMouseToCellPos(e.Location);
            if (e.Button == MouseButtons.Left)
                TileEditor.SetTilePixel(p.X, p.Y, PixelOn);
            else if (e.Button == MouseButtons.Right)
                TileEditor.SetTilePixel(p.X, p.Y, PixelOff);

            OnTileChanged();
        }

        private void TileEditor_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                TileEditor_MouseDown(sender, e);
            }
            else
            {
                Point p = TileEditor.GetMouseToCellPos(e.Location);
                HoverLabel.Text = p.X + ", " + p.Y;
            }
        }

        private void TileEditor_MouseLeave(object sender, EventArgs e)
        {
            HoverLabel.Text = "";
        }

        public void SetTile(int index)
        {
            TileIndex = index;
            TileEditor.SetTile(Tileset, index);
            OriginalPixels = new TilePixels(Tileset.Get(index));
            StatusLabel.Text = "IX: " + index + " (" + index.ToString("X2") + ")";
            UpdateStringRepresentations();
        }

        private void OnTileChanged()
        {
            RefreshSubscribed();
            UpdateStringRepresentations();
        }

        private void Undo()
        {
            TileEditor.SetTilePixels(OriginalPixels);
            OnTileChanged();
        }

        private void UpdateStringRepresentations()
        {
            TxtBinaryString.Text = Tileset.Get(TileIndex).ToBinaryString();
            TxtBinaryString.Select(0, 0);
            TxtCsvHex.Text = Tileset.Get(TileIndex).ToHexCsvString();
            TxtCsvHex.Select(0, 0);
            TxtCsvDec.Text = Tileset.Get(TileIndex).ToCsvString();
            TxtCsvDec.Select(0, 0);

            UpdatePtmFormat();
        }

        private void UpdatePtmFormat()
        {
            TxtBinaryBlock.Clear();

            var rows = SplitBinaryString(TxtBinaryString.Text);
            string prefix;

            if (ChkHexIndex.Checked)
                prefix = "CHR &h" + TileIndex.ToString("x2");
            else
                prefix = "CHR " + TileIndex;

            string suffix = "";

            for (int i = 0; i < rows.Count; i++)
            {
                string row = rows[i];
                TxtBinaryBlock.AppendText(prefix + "," + i + ",&b" + row + suffix + Environment.NewLine);
            }

            TxtBinaryBlock.Select(0, 0);
        }

        static List<string> SplitBinaryString(string str)
        {
            const int chunkSize = 8;
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize))
                .ToList();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            TileEditor.ClearTile();
            OnTileChanged();
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Undo();
            Close();
        }

        private void BtnInvert_Click(object sender, EventArgs e)
        {
            TileEditor.InvertTile();
            OnTileChanged();
        }

        private void BtnFlipH_Click(object sender, EventArgs e)
        {
            TileEditor.FlipHorizontal();
            OnTileChanged();
        }

        private void BtnFlipV_Click(object sender, EventArgs e)
        {
            TileEditor.FlipVertical();
            OnTileChanged();
        }

        private void BtnRotateRight_Click(object sender, EventArgs e)
        {
            TileEditor.RotateRight();
            OnTileChanged();
        }

        private void BtnRotateLeft_Click(object sender, EventArgs e)
        {
            TileEditor.RotateLeft();
            OnTileChanged();
        }

        private void BtnRotateUp_Click(object sender, EventArgs e)
        {
            TileEditor.RotateUp();
            OnTileChanged();
        }

        private void BtnRotateDown_Click(object sender, EventArgs e)
        {
            TileEditor.RotateDown();
            OnTileChanged();
        }

        private void Txt_Click(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.SelectAll();
            //Clipboard.SetText(textBox.Text);
        }

        private void PnlStrings_Click(object sender, EventArgs e)
        {
            foreach (Control ctl in PnlStrings.Controls)
            {
                if (ctl is TextBox)
                {
                    (ctl as TextBox).DeselectAll();
                }
            }
        }

        private void ChkHexIndex_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePtmFormat();
        }
    }
}
