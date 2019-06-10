using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.File;
using TileGameLib.Util;

namespace TileGameMaker.Component
{
    public partial class ArchiveManager : Form
    {
        public string ArchiveFile { get; private set; }
        public List<string> EntryFiles { get; private set; }
        public enum Mode { Browse, Save, Load }
        public Mode OperationMode { get; set; } = Mode.Browse;
        public string SelectedEntry { get { return TxtEntry.Text.Trim(); } }

        public ArchiveManager(string archiveFile)
        {
            InitializeComponent();
            ArchiveFile = archiveFile;
            TxtArchive.Text = archiveFile;
            UpdateList();
        }

        public DialogResult ShowDialog(Form owner, Mode mode)
        {
            OperationMode = mode;

            switch (mode)
            {
                case Mode.Browse:
                    Text = "Browse archive";
                    SetButton(BtnOk, 0);
                    SetButton(BtnDelete, 1);
                    SetButton(BtnCancel, 2);
                    HideButton(BtnLoad);
                    HideButton(BtnSave);
                    break;
                case Mode.Save:
                    Text = "Save file to archive";
                    SetButton(BtnSave, 0);
                    SetButton(BtnDelete, 1);
                    SetButton(BtnCancel, 2);
                    HideButton(BtnLoad);
                    HideButton(BtnOk);
                    break;
                case Mode.Load:
                    Text = "Load file from archive";
                    SetButton(BtnLoad, 0);
                    SetButton(BtnDelete, 1);
                    SetButton(BtnCancel, 2);
                    HideButton(BtnSave);
                    HideButton(BtnOk);
                    break;
            }

            return ShowDialog(owner);
        }

        private void HideButton(Button button)
        {
            button.Hide();
        }

        private void SetButton(Button button, int cell)
        {
            ButtonLayout.SetCellPosition(button, new TableLayoutPanelCellPosition(cell, 0));
            button.Show();
        }

        public bool Contains(string entry)
        {
            return EntryFiles.Contains(entry);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedEntry();
        }

        private void DeleteSelectedEntry()
        {
            if (EntriesListBox.SelectedValue == null)
                return;

            string entry = EntriesListBox.SelectedValue.ToString();
            if (Alert.Confirm($"Delete entry file \"{entry}\"?"))
            {
                Archive.Delete(ArchiveFile, entry);
                UpdateList();
            }
        }

        private void UpdateList()
        {
            EntryFiles = Archive.List(ArchiveFile);
            EntriesListBox.DataSource = EntryFiles;
            EntriesListBox.Refresh();
        }

        private void EntriesListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (EntriesListBox.SelectedValue != null)
                TxtEntry.Text = EntriesListBox.SelectedValue.ToString();
            else
                TxtEntry.Text = "";
        }

        private void EntriesListBox_DoubleClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void TxtEntry_KeyDown(object sender, KeyEventArgs e)
        {
            Common_KeyDown(e);
        }

        private void EntriesListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (Common_KeyDown(e))
                return;

            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
                DeleteSelectedEntry();
            }
        }

        private bool Common_KeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                return true;
            }
            else if (e.KeyCode == Keys.Return && !string.IsNullOrWhiteSpace(SelectedEntry))
            {
                e.Handled = true;
                DialogResult = DialogResult.OK;
                return true;
            }

            return false;
        }
    }
}
