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
using TileGameLib.Util;
using TileGameMaker.MapEditorElements;

namespace TileGameMaker.Windows
{
    public partial class ScriptWindow : Form
    {
        private readonly ScriptRunner ScriptRunner;

        private ScriptWindow()
        {
            InitializeComponent();
        }

        public ScriptWindow(ObjectMap map)
        {
            InitializeComponent();
            ScriptRunner = new ScriptRunner(map);
            FormClosing += ScriptWindow_FormClosing;
            TopMost = true;
            KeyPreview = true;
        }

        private void ScriptWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void BtnRun_Click(object sender, EventArgs e)
        {
            InterpretScript();
        }

        private void InterpretScript()
        {
            foreach (string line in TxtScript.Lines)
            {
                string command = "";
                string args = "";
                string trimmedLine = line.Trim();
                int indexOfFirstSpace = trimmedLine.IndexOf(' ');

                if (indexOfFirstSpace >= 0)
                {
                    command = trimmedLine.Substring(0, indexOfFirstSpace).Trim();
                    args = trimmedLine.Substring(indexOfFirstSpace).Trim();
                }
                else
                {
                    command = trimmedLine;
                }

                ExecuteCommand(command.ToLower(), args);
            }
        }

        private void ExecuteCommand(string command, string args)
        {
            switch (command)
            {
                case "test": ScriptRunner.Test(args); break;

                default:
                    Alert.Error("Invalid command: " + command);
                    break;
            }
        }

        private void ScriptWindow_KeyDown(object sender, KeyEventArgs e)
        {
            HandleKeyPress(e);
        }

        private void HandleKeyPress(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                InterpretScript();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                Hide();
            }
        }
    }
}
