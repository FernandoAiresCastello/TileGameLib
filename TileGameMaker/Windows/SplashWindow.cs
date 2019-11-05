using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using TileGameLib.Util;
using TileGameMaker.Util;

namespace TileGameMaker.Windows
{
    public partial class SplashWindow : Form
    {
        public SplashWindow()
        {
            InitializeComponent();
            LbTitle.Font = EmbeddedFontLoader.Load(Properties.Resources.PressStart2P, 18);

            LostFocus += OnClick;
            KeyDown += OnClick;

            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
            string version = fvi.FileVersion;
            string build = Config.ReadString("BuildNumber");

            LbVersionBuild.Text = LbVersionBuild.Text
                .Replace("{version}", version)
                .Replace("{build}", build);
        }

        private void OnClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
