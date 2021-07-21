using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Components;
using TileGameLib.Graphics;

namespace TileGameLib.Components
{
    public partial class DisplayWindow : Form
    {
        public Display Display { get; private set; }
        public GraphicsDriver Graphics => Display?.Graphics;
        public HashSet<Keys> KeysPressed { get; private set; } = new HashSet<Keys>();

        public bool Fullscreen
        {
            get => IsFullscreen;

            set
            {
                if (AllowFullscreen)
                {
                    IsFullscreen = value;

                    if (IsFullscreen)
                        SwitchToFullscreenMode();
                    else
                        SwitchToWindowedMode();
                }
            }
        }

        public bool Border
        {
            get { return DisplayPanel.BorderStyle == BorderStyle.Fixed3D; }
            set { DisplayPanel.BorderStyle = value ? BorderStyle.Fixed3D : BorderStyle.None; }
        }

        protected Size OriginalSize;
        protected Point OriginalLocation;
        protected bool IsFullscreen;
        protected bool AllowFullscreen;
        protected bool AllowResize;

        public DisplayWindow(int displayWidth, int displayHeight, int zoom, bool border, bool allowFullscreen, bool allowResize)
        {
            InitializeComponent();

            OriginalSize = Size;
            OriginalLocation = Location;
            Display = new Display(DisplayPanel, displayWidth, displayHeight, zoom);
            Display.StretchImage = true;
            Display.Dock = DockStyle.Fill;
            Fullscreen = false;
            Border = border;
            AllowResize = allowResize;
            AllowFullscreen = allowFullscreen;
            FormBorderStyle = allowResize ? FormBorderStyle.Sizable : FormBorderStyle.FixedSingle;
            MaximizeBox = allowResize;
            StartPosition = FormStartPosition.CenterScreen;
            KeyDown += DisplayWindow_KeyDown;
            KeyUp += DisplayWindow_KeyUp;
            Display.MouseDown += DisplayWindow_MouseDown;
        }

        protected virtual void HandleKeyDownEvent(KeyEventArgs e)
        {
        }

        protected virtual void HandleKeyUpEvent(KeyEventArgs e)
        {
        }

        protected virtual void HandleMouseDownEvent(MouseEventArgs e)
        {
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Refresh();
        }

        protected void DisplayWindow_MouseDown(object sender, MouseEventArgs e)
        {
            HandleMouseDownEvent(e);
        }

        protected void DisplayWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    ToggleFullscreen();
                }
            }
            else
            {
                KeysPressed.Add(e.KeyCode);
                HandleKeyDownEvent(e);
            }
        }

        private void DisplayWindow_KeyUp(object sender, KeyEventArgs e)
        {
            KeysPressed.Remove(e.KeyCode);
            HandleKeyUpEvent(e);
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
            if (!AllowFullscreen)
                return;

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
    }
}
