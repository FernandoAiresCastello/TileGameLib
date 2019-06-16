using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Core;
using TileGameLib.Graphics;
using TileGameLib.Util;

namespace TileGameLib.Components
{
    public partial class DisplayWindow : Form
    {
        public TiledDisplay Display { get; private set; }
        public GraphicsAdapter Graphics => Display.Graphics;

        public bool Fullscreen
        {
            get { return IsFullscreen; }

            set
            {
                IsFullscreen = value;
                if (IsFullscreen)
                    SwitchToFullscreenMode();
                else
                    SwitchToWindowedMode();
            }
        }

        public bool Border
        {
            get { return MapPanel.BorderStyle == BorderStyle.Fixed3D; }
            set { MapPanel.BorderStyle = value ? BorderStyle.Fixed3D : BorderStyle.None; }
        }

        protected Size OriginalSize;
        protected Point OriginalLocation;
        protected bool IsFullscreen;

        public DisplayWindow(int cols, int rows)
            : this(cols, rows, false, false)
        {
        }

        public DisplayWindow(int cols, int rows, bool fullscreen, bool border)
        {
            InitializeComponent();
            Display = new TiledDisplay(MapPanel, cols, rows, 1);
            Display.StretchImage = true;
            Display.Dock = DockStyle.Fill;
            OriginalSize = Size;
            OriginalLocation = Location;
            Fullscreen = fullscreen;
            Border = border;
            StartPosition = FormStartPosition.CenterScreen;
            KeyDown += MapDisplayWindow_KeyDown;
        }

        protected void MapDisplayWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                ToggleFullscreen();
            }
        }

        protected void SwitchToWindowedMode()
        {
            IsFullscreen = false;
            FormBorderStyle = FormBorderStyle.Sizable;
            StartPosition = FormStartPosition.Manual;
            WindowState = FormWindowState.Normal;
            Size = OriginalSize;
            Location = OriginalLocation;
            TopMost = false;
        }

        protected void SwitchToFullscreenMode()
        {
            IsFullscreen = true;
            OriginalSize = Size;
            OriginalLocation = Location;
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.Manual;
            WindowState = FormWindowState.Maximized;
            Size = Screen.PrimaryScreen.Bounds.Size;
            Location = Screen.PrimaryScreen.Bounds.Location;
            TopMost = true;
        }

        protected void ToggleFullscreen()
        {
            if (IsFullscreen)
                SwitchToWindowedMode();
            else
                SwitchToFullscreenMode();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Refresh();
        }
    }
}
