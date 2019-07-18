using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameMaker.Util;

namespace TileGameMaker.Windows
{
    public partial class SplashWindow : Form
    {
        public SplashWindow()
        {
            InitializeComponent();
            LostFocus += OnClick;
            KeyDown += OnClick;

            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string build = Config.ReadString("BuildNumber");

            MainLabel.Text = MainLabel.Text
                .Replace("{version}", version)
                .Replace("{build}", build);
        }

        private void OnClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
