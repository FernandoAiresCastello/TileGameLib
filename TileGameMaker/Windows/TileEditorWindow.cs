﻿using System;
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

namespace TileGameMaker.Windows
{
    public partial class TileEditorWindow : BaseWindow
    {
        private readonly TileEditorDisplay TileEditor;
        private readonly Tileset Tileset;
        private TilePixels OriginalPixels;

        public TileEditorWindow(Tileset tileset)
        {
            InitializeComponent();
            Tileset = tileset;
            TileEditor = new TileEditorDisplay(TilePanel, 8, 8, 3);
            TileEditor.ShowGrid = true;
            TileEditor.MouseMove += TileEditor_MouseMove;
            TileEditor.MouseLeave += TileEditor_MouseLeave;
            TileEditor.MouseDown += TileEditor_MouseDown;
            HoverLabel.Text = "";
        }

        private void TileEditor_MouseDown(object sender, MouseEventArgs e)
        {
            Point p = TileEditor.GetMouseToCellPos(e.Location);
            if (e.Button == MouseButtons.Left)
                TileEditor.SetTilePixel(p.X, p.Y, 1);
            else if (e.Button == MouseButtons.Right)
                TileEditor.SetTilePixel(p.X, p.Y, 0);

            RefreshSubscribed();
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
            TileEditor.SetTile(Tileset, index);
            OriginalPixels = new TilePixels(Tileset.Get(index));
            StatusLabel.Text = "IX: " + index;
        }

        private void Undo()
        {
            TileEditor.SetTilePixels(OriginalPixels);
            RefreshSubscribed();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            TileEditor.ClearTile();
            RefreshSubscribed();
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
            RefreshSubscribed();
        }

        private void BtnFlipH_Click(object sender, EventArgs e)
        {
            TileEditor.FlipHorizontal();
            RefreshSubscribed();
        }

        private void BtnFlipV_Click(object sender, EventArgs e)
        {
            TileEditor.FlipVertical();
            RefreshSubscribed();
        }

        private void BtnRotateRight_Click(object sender, EventArgs e)
        {
            TileEditor.RotateRight();
            RefreshSubscribed();
        }

        private void BtnRotateLeft_Click(object sender, EventArgs e)
        {
            TileEditor.RotateLeft();
            RefreshSubscribed();
        }

        private void BtnRotateUp_Click(object sender, EventArgs e)
        {
            TileEditor.RotateUp();
            RefreshSubscribed();
        }

        private void BtnRotateDown_Click(object sender, EventArgs e)
        {
            TileEditor.RotateDown();
            RefreshSubscribed();
        }
    }
}