using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Components;
using TileGameLib.Graphics;
using TileGameLib.Util;
using TileGameMaker.TiledDisplays;

namespace TileGameMaker.Windows
{
    public partial class TilesetExportImportWindow : Form
    {
        public string InitialFolder { set; get; }

        private Tileset Tileset;
        private TiledDisplay Display;
        private int Rows;
        private int Cols;

        public TilesetExportImportWindow(Tileset tileset, int cols = 16)
        {
            InitializeComponent();
            Tileset = tileset;
            Cols = cols;

            TxtCols.Value = cols;
            TxtCols.Minimum = 1;
            TxtCols.Maximum = 256;

            TxtFrom.Minimum = TxtTo.Minimum = 0;
            TxtFrom.Maximum = TxtTo.Maximum = tileset.Size - 1;
            TxtFrom.Value = 0;

            TxtTo.Value = tileset.Size - 1;

            CalculateAndUpdateSize();

            Display.Graphics.Tileset = tileset;
            Display.Graphics.Palette.Clear();

            UpdatePreview();
        }

        private TilesetExportImportWindow()
        {
        }

        private void BtnPreview_Click(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void ValueChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void CalculateAndUpdateSize()
        {
            int from = decimal.ToInt32(TxtFrom.Value);
            int to = decimal.ToInt32(TxtTo.Value);
            int tileCount = to - from;

            Cols = decimal.ToInt32(TxtCols.Value);
            Rows = tileCount / Cols + 1;

            if (Display == null)
            {
                Display = new TiledDisplay(TilesetPanel, Cols, Rows, 3);
            }
            else
            {
                Display.ResizeGraphics(Cols, Rows);
            }
        }

        private void UpdatePreview()
        {
            CalculateAndUpdateSize();

            int from = decimal.ToInt32(TxtFrom.Value);
            int to = decimal.ToInt32(TxtTo.Value);
            int x = 0;
            int y = 0;

            Display.Graphics.Clear(Color.White);

            for (int tileIndex = from; tileIndex <= to; tileIndex++)
            {
                Display.Graphics.PutTile(x, y, tileIndex, 0, 1);

                x++;
                if (x >= Display.Graphics.Cols)
                {
                    x = 0;
                    y++;
                    if (y >= Display.Graphics.Rows)
                        break;
                }
            }

            Display.Refresh();
        }

        private void Save()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.AddExtension = true;
            dialog.DefaultExt = "bmp";
            dialog.Filter = "Bitmap image (*.bmp)|*.bmp";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Display.Graphics.SaveImage(dialog.FileName, ImageFormat.Bmp);
                Alert.Info("Tileset image successfully saved to file!");
            }
        }
    }
}
