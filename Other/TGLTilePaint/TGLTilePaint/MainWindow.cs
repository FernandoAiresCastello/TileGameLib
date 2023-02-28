using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;

namespace TGLTilePaint
{
    public partial class MainWindow : Form
    {
        private TileEditPanel PnlTileEdit;
        private string Title = "TGLTilePaint";
        private string CurrentFile = "";

        public MainWindow()
        {
            InitializeComponent();
            Size = new Size(787, 526);

            PnlTileEdit = new TileEditPanel(this);
            PnlTileEdit.Parent = TileEditPanelContainer;
            PnlTileEdit.Dock = DockStyle.Fill;
            KeyPreview = true;

            KeyDown += MainWindow_KeyDown;
            AllowDrop = true;
            DragEnter += MainWindow_DragEnter;
            DragDrop += MainWindow_DragDrop;

            Text = Title;
            StatusLabel.Text = "";
            UpdateColorButtons(true);
            UpdateLeftRightButtons();
        }

        private void MainWindow_DragEnter(object sender, DragEventArgs e)
        {
            string[] fmt = e.Data.GetFormats();

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void MainWindow_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            LoadBitmap(files[0]);
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (TxtColor0.Focused || TxtColor1.Focused || TxtColor2.Focused || TxtColor3.Focused)
                return;

            if (e.KeyCode == Keys.D0)
                PnlTileEdit.LeftColorIx = 0;
            else if (e.KeyCode == Keys.D1)
                PnlTileEdit.LeftColorIx = 1;
            else if (e.KeyCode == Keys.D2)
                PnlTileEdit.LeftColorIx = 2;
            else if (e.KeyCode == Keys.D3)
                PnlTileEdit.LeftColorIx = 3;

            UpdateLeftRightButtons();
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            Text = "Size: " + Width + ", " + Height;
        }

        private void BtnDigit_Click(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            if (e.Button == MouseButtons.Left)
            {
                if (btn.Text == "0") PnlTileEdit.LeftColorIx = 0;
                else if (btn.Text == "1") PnlTileEdit.LeftColorIx = 1;
                else if (btn.Text == "2") PnlTileEdit.LeftColorIx = 2;
                else if (btn.Text == "3") PnlTileEdit.LeftColorIx = 3;
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (btn.Text == "0") PnlTileEdit.RightColorIx = 0;
                else if (btn.Text == "1") PnlTileEdit.RightColorIx = 1;
                else if (btn.Text == "2") PnlTileEdit.RightColorIx = 2;
                else if (btn.Text == "3") PnlTileEdit.RightColorIx = 3;
            }
            else if (e.Button == MouseButtons.Middle)
            {
                if (btn.Text == "0") ShowColorPicker(0);
                else if (btn.Text == "1") ShowColorPicker(1);
                else if (btn.Text == "2") ShowColorPicker(2);
                else if (btn.Text == "3") ShowColorPicker(3);
            }

            UpdateLeftRightButtons();
        }

        private void ShowColorPicker(int targetColorIx)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (targetColorIx == 0)
                colorDialog.Color = PnlTileEdit.Color0;
            else if (targetColorIx == 1)
                colorDialog.Color = PnlTileEdit.Color1;
            else if (targetColorIx == 2)
                colorDialog.Color = PnlTileEdit.Color2;
            else if (targetColorIx == 3)
                colorDialog.Color = PnlTileEdit.Color3;

            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                if (targetColorIx == 0)
                    PnlTileEdit.Color0 = colorDialog.Color;
                else if (targetColorIx == 1)
                    PnlTileEdit.Color1 = colorDialog.Color;
                else if (targetColorIx == 2)
                    PnlTileEdit.Color2 = colorDialog.Color;
                else if (targetColorIx == 3)
                    PnlTileEdit.Color3 = colorDialog.Color;

                UpdateColorButtons(true);
                Refresh();
            }
        }

        private void UpdateColorButtons(bool updateRgbText)
        {
            UpdateColorButton(Btn0, TxtColor0, 0, updateRgbText);
            UpdateColorButton(Btn1, TxtColor1, 1, updateRgbText);
            UpdateColorButton(Btn2, TxtColor2, 2, updateRgbText);
            UpdateColorButton(Btn3, TxtColor3, 3, updateRgbText);

            UpdateLeftRightButtons();
        }

        private void UpdateColorButton(Button btn, TextBox txt, int colorIx, bool updateRgbText)
        {
            Color color = PnlTileEdit.Color0;

            if (colorIx == 0)
                color = PnlTileEdit.Color0;
            else if (colorIx == 1)
                color = PnlTileEdit.Color1;
            else if (colorIx == 2)
                color = PnlTileEdit.Color2;
            else if (colorIx == 3)
                color = PnlTileEdit.Color3;

            btn.BackColor = color;

            if (updateRgbText)
            {
                string rgb = color.ToArgb().ToString("X06");
                txt.Text = rgb.Length > 6 ? rgb.Substring(2) : rgb;
            }
        }

        private void BtnFill_Click(object sender, EventArgs e)
        {
            PnlTileEdit.FillPixelsColorLeft();
        }

        private void BtnFillRight_Click(object sender, EventArgs e)
        {
            PnlTileEdit.FillPixelsColorRight();
        }

        public void UpdateLeftRightButtons()
        {
            if (PnlTileEdit.LeftColorIx == 0)
                BtnLeft.BackColor = PnlTileEdit.Color0;
            if (PnlTileEdit.LeftColorIx == 1)
                BtnLeft.BackColor = PnlTileEdit.Color1;
            if (PnlTileEdit.LeftColorIx == 2)
                BtnLeft.BackColor = PnlTileEdit.Color2;
            if (PnlTileEdit.LeftColorIx == 3)
                BtnLeft.BackColor = PnlTileEdit.Color3;

            if (PnlTileEdit.RightColorIx == 0)
                BtnRight.BackColor = PnlTileEdit.Color0;
            if (PnlTileEdit.RightColorIx == 1)
                BtnRight.BackColor = PnlTileEdit.Color1;
            if (PnlTileEdit.RightColorIx == 2)
                BtnRight.BackColor = PnlTileEdit.Color2;
            if (PnlTileEdit.RightColorIx == 3)
                BtnRight.BackColor = PnlTileEdit.Color3;
        }

        private void TxtColor_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt == null) return;

            if (!IsHexKey(e.KeyCode))
                e.SuppressKeyPress = true;
        }

        private void TxtColor_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt == null) return;

            if (txt.Text.Length == 6)
            {
                string stringRgb = txt.Text;
                int rgb = int.Parse(stringRgb, NumberStyles.HexNumber);
                Color color = Color.FromArgb(255, Color.FromArgb(rgb));

                if (txt == TxtColor0)
                    PnlTileEdit.Color0 = color;
                else if (txt == TxtColor1)
                    PnlTileEdit.Color1 = color;
                else if (txt == TxtColor2)
                    PnlTileEdit.Color2 = color;
                else if (txt == TxtColor3)
                    PnlTileEdit.Color3 = color;

                UpdateColorButtons(false);
                Refresh();
            }
        }

        private bool IsHexKey(Keys key)
        {
            return new[]
            {
                Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9,
                Keys.NumPad0, Keys.NumPad1, Keys.NumPad2, Keys.NumPad3, Keys.NumPad4,
                Keys.NumPad5, Keys.NumPad6, Keys.NumPad7, Keys.NumPad8, Keys.NumPad9,
                Keys.A, Keys.B, Keys.C, Keys.D, Keys.E, Keys.F,
                Keys.Back, Keys.Delete, Keys.Home, Keys.End, Keys.Right, Keys.Left

            }.Contains(key);
        }

        private void TxtColor_Enter(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt == null) return;

            txt.SelectAll();
        }

        private void ShowPixelCodes(bool show)
        {
            PnlTileEdit.ShowPixelCodes = show;
            PnlTileEdit.Refresh();
        }

        private void ShowMainGrid(bool show)
        {
            PnlTileEdit.ShowMainGrid = show;
            PnlTileEdit.Refresh();
        }

        private void ShowSubGrid(bool show)
        {
            PnlTileEdit.ShowSubGrid = show;
            PnlTileEdit.Refresh();
        }

        private void BtnTogglePixelCodes_Click(object sender, EventArgs e)
        {
            ShowPixelCodes(BtnTogglePixelCodes.Checked);
        }

        private void BtnToggleMainGrid_Click(object sender, EventArgs e)
        {
            ShowMainGrid(BtnToggleMainGrid.Checked);
        }

        private void BtnToggleSubGrid_Click(object sender, EventArgs e)
        {
            ShowSubGrid(BtnToggleSubGrid.Checked);
        }

        private void BtnCopy8x8_Click(object sender, EventArgs e)
        {
            MenuBtnCopy_Click(sender, e);
        }

        private void BtnPaste_Click(object sender, EventArgs e)
        {
            MenuBtnPaste_Click(sender, e);
        }

        private void MenuBtnCopy_Click(object sender, EventArgs e)
        {
            if (PnlTileEdit.Is8x8())
                Clipboard.SetText(PnlTileEdit.Tile.ToStringSingle8x8());
            else if (PnlTileEdit.Is16x16())
                Clipboard.SetText(PnlTileEdit.Tile.ToStringComposite());

            ShowTempStatus("Tile pattern copied to clipboard!");
        }

        private void MenuBtnPaste_Click(object sender, EventArgs e)
        {
            if (PnlTileEdit.Tile.Parse(Clipboard.GetText()))
            {
                Refresh();
                ShowTempStatus("Tile pattern parsed from clipboard!");
            }
            else
            {
                MessageBox.Show("Invalid string format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnTileSize8x8_Click(object sender, EventArgs e)
        {
            PnlTileEdit.Mode8x8();
            BtnCopy8x8.Text = "Copy 8x8";
            MenuBtnCopy.Text = BtnCopy8x8.Text;
        }

        private void BtnTileSize16x16_Click(object sender, EventArgs e)
        {
            PnlTileEdit.Mode16x16();
            BtnCopy8x8.Text = "Copy 4x 8x8";
            MenuBtnCopy.Text = BtnCopy8x8.Text;
        }

        private void LoadBitmap(string filename)
        {
            Bitmap bitmap = new Bitmap(filename);
            PnlTileEdit.ParseBitmapImageTGL(bitmap);
            bitmap.Dispose();

            OnFileLoaded(filename);
            PnlTileEdit.ResetColors();
            UpdateColorButtons(true);
            Refresh();

            PnlTileEdit.Enabled = false;
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (s, ev) =>
            {
                PnlTileEdit.Enabled = true;
                timer.Stop();
            };
            timer.Start();
        }

        private void BtnLoadBmp_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Open TGL bitmap file";
            dialog.Filter = "Bitmap (*.bmp)|*.bmp";
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            LoadBitmap(dialog.FileName);
        }

        private void BtnSaveBmp_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = PnlTileEdit.GetBitmapImageTGL();
            ShowSaveImageDialog(bitmap, "Save TGL bitmap file", false);
            bitmap.Dispose();
        }

        private void BtnSaveAs_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = PnlTileEdit.GetBitmapImageTGL();
            ShowSaveImageDialog(bitmap, "Save TGL bitmap file", true);
            bitmap.Dispose();
        }

        private void BtnExportBmp_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = PnlTileEdit.GetBitmapImageRGB();
            ShowSaveImageDialog(bitmap, "Export RGB bitmap file", false);
            bitmap.Dispose();
        }

        private bool ShowSaveImageDialog(Bitmap image, string title, bool saveAs)
        {
            if (CurrentFile == "" || saveAs)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Title = title;
                dialog.Filter = "Bitmap (*.bmp)|*.bmp";

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    string file = dialog.FileName;
                    if (!file.ToLower().EndsWith(".bmp"))
                        file += ".bmp";

                    image.Save(file, System.Drawing.Imaging.ImageFormat.Bmp);
                    OnFileSaved(file);
                    return true;
                }
            }
            else
            {
                image.Save(CurrentFile, System.Drawing.Imaging.ImageFormat.Bmp);
                OnFileSaved(CurrentFile);
                return true;
            }

            return false;
        }

        private void BtnPermutate_Click(object sender, EventArgs e)
        {
            PnlTileEdit.PermutateColors();
            UpdateColorButtons(true);
            Refresh();
        }

        private void BtnResetPal_Click(object sender, EventArgs e)
        {
            ResetPalette();
        }

        private void ResetPalette()
        {
            PnlTileEdit.ResetColors();
            UpdateColorButtons(true);
            Refresh();
        }

        private void OnFileSaved(string filename)
        {
            CurrentFile = filename;
            Text = Title + " - " + CurrentFile;
            ShowTempStatus("File saved!");
        }

        private void OnFileLoaded(string filename)
        {
            CurrentFile = filename;
            Text = Title + " - " + CurrentFile;
            ShowTempStatus("File loaded!");
        }

        private void ShowTempStatus(string msg)
        {
            StatusLabel.Text = msg;
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (s, ev) =>
            {
                StatusLabel.Text = CurrentFile;
                timer.Stop();
            };
            timer.Start();
        }

        private void BtnToggleMode_Click(object sender, EventArgs e)
        {
            PnlTileEdit.ToggleMode();

            if (PnlTileEdit.Is8x8())
            {
                BtnCopy8x8.Text = "Copy 8x8";
                MenuBtnCopy.Text = BtnCopy8x8.Text;
            }
            else
            {
                BtnCopy8x8.Text = "Copy 4x 8x8";
                MenuBtnCopy.Text = BtnCopy8x8.Text;
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            PnlTileEdit.Tile.Fill(0);
            ResetPalette();
            CurrentFile = "";
            Text = Title;
            ShowTempStatus("New tile created");
        }
    }
}
