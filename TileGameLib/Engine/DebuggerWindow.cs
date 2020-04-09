using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TileGameLib.Engine
{
    public partial class DebuggerWindow : Form
    {
        private readonly GameEngine Engine;

        private DebuggerWindow()
        {
            InitializeComponent();
        }

        public DebuggerWindow(GameEngine engine)
        {
            InitializeComponent();
            TopMost = true;
            Engine = engine;
            FormClosing += DebuggerWindow_FormClosing;
        }

        private void DebuggerWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        public void Log(object o)
        {
            TxtLog.AppendText(o.ToString() + Environment.NewLine);
        }
    }
}
