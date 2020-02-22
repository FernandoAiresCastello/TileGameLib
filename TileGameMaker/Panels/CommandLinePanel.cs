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
using TileGameLib.Util;
using TileGameLib.GameElements;

namespace TileGameMaker.Panels
{
    public partial class CommandLinePanel : UserControl
    {
        private MapEditor MapEditor;
        private string LastCommand;
        private ObjectMap Map => MapEditor.Map;

        public CommandLinePanel()
        {
            InitializeComponent();
        }

        public CommandLinePanel(MapEditor editor)
        {
            InitializeComponent();
            MapEditor = editor;
            TxtInput.KeyDown += TxtInput_KeyDown;
        }

        private void TxtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                string commandLine = TxtInput.Text.Trim();

                if (!string.IsNullOrWhiteSpace(commandLine))
                {
                    TxtInput.Text = "";
                    LastCommand = commandLine;
                    Print(">" + commandLine);
                    Execute(commandLine);
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                RetypeLastCommand();
            }
        }

        private void RetypeLastCommand()
        {
            if (!string.IsNullOrWhiteSpace(LastCommand))
            {
                TxtInput.Text = LastCommand;
            }
        }

        private void ScrollToBottom()
        {
            TxtOutput.Select(TxtOutput.Text.Length - 1, 0);
            TxtOutput.ScrollToCaret();
        }

        private void ClearOutput()
        {
            TxtOutput.Text = "";
        }

        private void ClearInput()
        {
            TxtInput.Text = "";
        }

        private void Print(string text)
        {
            TxtOutput.Text += text + Environment.NewLine;
            ScrollToBottom();
        }

        private string[] ParseCommandLine(string commandLine)
        {
            string command = "";
            string args = "";

            commandLine = commandLine.Trim();
            int firstSpaceIndex = commandLine.IndexOf(' ');
            
            if (firstSpaceIndex >= 0)
            {
                command = commandLine.Substring(0, firstSpaceIndex).Trim().ToLower();
                args = commandLine.Substring(firstSpaceIndex + 1).Trim();
            }
            else
            {
                command = commandLine;
            }

            return new string[] { command, args };
        }

        private void Execute(string commandLine)
        {
            string[] commandAndArgs = ParseCommandLine(commandLine);
            string command = commandAndArgs.Length > 0 ? commandAndArgs[0] : "";
            string args = commandAndArgs.Length > 1 ? commandAndArgs[1] : "";

            try
            {
                switch (command)
                {
                    case "cls":
                        ClearOutput();
                        break;
                    case "exit":
                        ClearOutput();
                        ClearInput();
                        MapEditor.ShowCommandLine(false);
                        break;
                    case "macro":
                        MacroPlayer mp = new MacroPlayer(Map);
                        string result = mp.Execute(args);
                        Print(result);
                        break;
                    default:
                        Print("Invalid command");
                        break;
                }
            }
            catch (Exception ex)
            {
                Print("Error: " + ex.Message);
            }
        }
    }
}
