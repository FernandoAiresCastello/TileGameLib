﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameMaker.Modules;
using TileGameMaker.Windows;
using TileGameMaker.TiledDisplays;
using TileGameLib.Util;
using TileGameLib.Graphics;

namespace TileGameMaker.Panels
{
    public partial class TilePickerPanel : BasePanel
    {
        private MapEditor MapEditor;
        private TilePickerDisplay TilePicker;
        private TileEditorWindow TileEditorWindow;
        private TilePixels ClipboardTile = new TilePixels();

        public TilePickerPanel()
        {
            InitializeComponent();
        }

        public TilePickerPanel(MapEditor editor)
        {
            InitializeComponent();
            MapEditor = editor;
            TilePicker = new TilePickerDisplay(PnlTilePicker, 8, 64, 3);
            TilePicker.Graphics.Tileset = editor.Tileset;
            TilePicker.ShowGrid = true;
            TilePicker.MouseMove += TilePicker_MouseMove;
            TilePicker.MouseLeave += TilePicker_MouseLeave;
            TilePicker.MouseDown += TilePicker_MouseDown;
            TilePicker.MouseDoubleClick += TilePicker_MouseDoubleClick;
            TileEditorWindow = new TileEditorWindow(editor.Tileset);
            TileEditorWindow.Subscribe(this);
            TileEditorWindow.Subscribe(TilePicker);
            TileEditorWindow.Subscribe(editor.MapEditorControl);
            TileEditorWindow.Subscribe(editor.TemplateControl);
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
            else if (e.Button == MouseButtons.Right)
            {
                // TODO: Show context menu to copy/paste tile
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
            TileEditorWindow.SetTile(tileIx);
            TileEditorWindow.Location = new Point(Location.X, Location.Y + 50);
            TileEditorWindow.ShowDialog(this);
        }

        private void TilePicker_MouseLeave(object sender, EventArgs e)
        {
            SetHoverStatus("");
        }

        private void UpdateStatus()
        {
            StatusLabel.Text = "SEL: " + TilePicker.TileIndex;
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
    }
}