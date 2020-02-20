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

        public TileEditor8x8Window(Tileset tileset)
        {
            InitializeComponent();
            Tileset = tileset;

            TileEditor = new TileEditor8x8Display(TilePanel, Config.ReadInt("TileEditorZoom"));

            TileEditor.ShowGrid = true;
            TileEditor.MouseMove += TileEditor_MouseMove;
            TileEditor.MouseLeave += TileEditor_MouseLeave;
            TileEditor.MouseDown += TileEditor_MouseDown;
            TxtStringRep.KeyDown += TxtStringRep_KeyDown;
            HoverLabel.Text = "";
        }

        private void TxtStringRep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Undo();
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
            StatusLabel.Text = "IX: " + index;
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
            StringBuilder reps = new StringBuilder();
            reps.AppendLine("B:" + Tileset.Get(TileIndex).ToBinaryString());
            reps.AppendLine("H:" + Tileset.Get(TileIndex).ToHexCsvString());
            reps.AppendLine("C:" + Tileset.Get(TileIndex).ToCsvString());

            TxtStringRep.Text = reps.ToString();
            TxtStringRep.Select(0, 0);
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
    }
}
