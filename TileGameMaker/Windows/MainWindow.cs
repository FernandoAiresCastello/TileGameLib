using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Components;
using TileGameLib.Graphics;
using TileGameLib.Util;
using TileGameMaker.MapEditorElements;
using TileGameMaker.Test;
using TileGameMaker.Util;

namespace TileGameMaker.Windows
{
    public partial class MainWindow : Form
    {
        private MapEditor MapEditor;
        private DataExtractorWindow DataExtractor;

        private static readonly int BestWidth = Config.ReadInt("MapEditorWindowBestWidth");
        private static readonly int BestHeight = Config.ReadInt("MapEditorWindowBestHeight");

        public MainWindow()
        {
            InitializeComponent();
            Icon = Global.WindowIcon;
            Shown += MainWindow_Shown;
            KeyPreview = true;
            KeyDown += MainWindow_KeyDown;

            Rectangle screenArea = Screen.PrimaryScreen.Bounds;
            Size = new Size(BestWidth, BestHeight);
            MinimumSize = Size;

            if (screenArea.Width > BestWidth && screenArea.Height > BestHeight)
                WindowState = FormWindowState.Normal;
            else
                WindowState = FormWindowState.Maximized;

            MapEditor = new MapEditor(this);
            AddControl(MapEditor.MapEditorControl, MapEditorPanel);
            AddControl(MapEditor.TilePickerControl, TilePickerPanel);
            AddControl(MapEditor.ColorPickerControl, ColorPickerPanel);
            AddControl(MapEditor.WorkspacePanel, WorkspacePanel);
            AddControl(MapEditor.MapPropertyGridControl, MapPropertiesPanel);
            AddControl(MapEditor.CommandLinePanel, CommandLinePanel);
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                RunTestEngine();
                return;
            }

            MapEditor.MapEditorControl.HandleKeyEvent(sender, e);
        }

        private void ShowSplashWindow()
        {
            SplashWindow splash = new SplashWindow();
            splash.Show(this);
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            if (!MapEditor.Settings.Has("ShowSplashWindow") || MapEditor.Settings.GetBool("ShowSplashWindow"))
                ShowSplashWindow();
        }

        private void AddControl(Control control, Control panel)
        {
            control.Parent = panel;
            control.Dock = DockStyle.Fill;
        }

        private void MiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MiAbout_Click(object sender, EventArgs e)
        {
            ShowSplashWindow();
        }

        private void RunTestEngine()
        {
            TestEngine engine = new TestEngine();
            engine.Run(this);
        }

        private void BtnToggleCommandLine_Click(object sender, EventArgs e)
        {
            ToggleCommandLine();
        }

        public void ToggleCommandLine()
        {
            bool visible = MapAndCommandLineSplitContainer.Panel2Collapsed;
            MapAndCommandLineSplitContainer.Panel2Collapsed = !visible;

            if (visible)
                MapEditor.CommandLinePanel.Focus();
        }

        public void ShowCommandLine(bool show)
        {
            MapAndCommandLineSplitContainer.Panel2Collapsed = !show;
        }

        private void BtnDataExtractor_Click(object sender, EventArgs e)
        {
            ShowDataExtractor();
        }

        private void ShowDataExtractor()
        {
            if (DataExtractor == null)
            {
                DataExtractor = new DataExtractorWindow(MapEditor);
                DataExtractor.ShowDialog(this);
            }
            else
            {
                if (DataExtractor.Visible)
                {
                    DataExtractor.BringToFront();
                    if (DataExtractor.WindowState == FormWindowState.Minimized)
                        DataExtractor.WindowState = FormWindowState.Normal;
                }
                else
                {
                    if (DataExtractor.IsDisposed)
                        DataExtractor = new DataExtractorWindow(MapEditor);

                    DataExtractor.ShowDialog(this);
                }
            }
        }

        private void BtnViewWorkspace_Click(object sender, EventArgs e)
        {
            WorkspaceWindow window = new WorkspaceWindow(MapEditor);
            window.ShowDialog(this);
        }

        private void BtnOpenMusicComposer_Click(object sender, EventArgs e)
        {
            Process.Start("https://beepbox.co/");
        }
    }
}
