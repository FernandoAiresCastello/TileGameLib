using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using TileGameLib.GameElements;
using TileGameLib.Graphics;
using TileGameLib.Util;

namespace TileGameLib.Components
{
    public partial class TiledDisplayWindow : Form
    {
        public TiledDisplay Display { get; private set; }
        public TileGraphicsDriver Graphics => Display?.Graphics;
        public HashSet<Keys> KeysPressed { get; private set; } = new HashSet<Keys>();

        private bool AllowFullscreen;
        private bool AllowResize;

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
            get { return MapPanel.BorderStyle == BorderStyle.Fixed3D; }
            set { MapPanel.BorderStyle = value ? BorderStyle.Fixed3D : BorderStyle.None; }
        }

        protected Size OriginalSize;
        protected Point OriginalLocation;
        protected bool IsFullscreen;

        public TiledDisplayWindow(int cols, int rows, int zoom, bool border, bool allowFullscreen, bool allowResize)
        {
            InitializeComponent();

            Display = new TiledDisplay(MapPanel, cols, rows, zoom);
            Display.StretchImage = true;
            Display.Dock = DockStyle.Fill;
            OriginalSize = Size;
            OriginalLocation = Location;
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

        public override string ToString()
        {
            return Text;
        }

        public bool IsKeyPressed(Keys key)
        {
            return KeysPressed.Contains(key);
        }

        public bool IsKeyPressed(string keyname)
        {
            Keys key = (Keys)new KeysConverter().ConvertFrom(keyname);
            return KeysPressed.Contains(key);
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

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Refresh();
        }

        public override void Refresh()
        {
            if (Graphics != null)
                Graphics.Refresh();

            base.Refresh();
        }
    }
}
