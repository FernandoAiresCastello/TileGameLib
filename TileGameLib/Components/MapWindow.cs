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
    public partial class MapWindow : Form
    {
        protected TiledDisplay Display;
        protected ObjectMap Map;
        protected MapRenderer MapRenderer;
        protected Size OriginalSize;
        protected Point OriginalLocation;
        protected bool IsFullscreen;

        protected static readonly int DefaultAnimationInterval = 256;

        public bool Fullscreen
        {
            get
            {
                return IsFullscreen;
            }

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

        public MapWindow(ObjectMap map, int zoom)
            : this(map, zoom, DefaultAnimationInterval, false, false, false)
        {
        }

        public MapWindow(ObjectMap map, int zoom, int animationInterval, bool fullscreen, bool autoscroll, bool border)
        {
            InitializeComponent();
            Map = map;
            Display = new TiledDisplay(MapPanel, map.Width, map.Height, zoom);
            MapRenderer = new MapRenderer(map, Display, animationInterval);
            OriginalSize = Size;
            OriginalLocation = Location;
            Fullscreen = fullscreen;
            Border = border;
            MapPanel.AutoScroll = autoscroll;
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
