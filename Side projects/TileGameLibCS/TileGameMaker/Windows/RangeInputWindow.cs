using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameMaker.Util;

namespace TileGameMaker.Windows
{
    public partial class RangeInputWindow : Form
    {
        public int FromValue
        {
            set { Txt1.Value = value; }
            get { return decimal.ToInt32(Txt1.Value); }
        }

        public int ToValue
        {
            set { Txt2.Value = value; }
            get { return decimal.ToInt32(Txt2.Value); }
        }

        public int FromMinValue
        {
            set { Txt1.Minimum = value; }
        }

        public int FromMaxValue
        {
            set { Txt1.Maximum = value; }
        }

        public int ToMinValue
        {
            set { Txt2.Minimum = value; }
        }

        public int ToMaxValue
        {
            set { Txt2.Maximum = value; }
        }

        public int FromIncrement
        {
            set { Txt1.Increment = value; }
        }

        public int ToIncrement
        {
            set { Txt2.Increment = value; }
        }

        public RangeInputWindow()
        {
            InitializeComponent();
            Icon = Global.WindowIcon;
        }

        public RangeInputWindow(string labelCaption, string label1, string label2)
        {
            InitializeComponent();
            Icon = Global.WindowIcon;
            LbCaption.Text = labelCaption;
            Lb1.Text = label1;
            Lb2.Text = label2;
        }
    }
}
