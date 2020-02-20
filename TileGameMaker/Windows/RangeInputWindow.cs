using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TileGameMaker.Windows
{
    public partial class RangeInputWindow : Form
    {
        public int FromValue
        {
            set { TxtFrom.Value = value; }
            get { return decimal.ToInt32(TxtFrom.Value); }
        }

        public int ToValue
        {
            set { TxtTo.Value = value; }
            get { return decimal.ToInt32(TxtTo.Value); }
        }

        public int FromMinValue
        {
            set { TxtFrom.Minimum = value; }
        }

        public int FromMaxValue
        {
            set { TxtFrom.Maximum = value; }
        }

        public int ToMinValue
        {
            set { TxtTo.Minimum = value; }
        }

        public int ToMaxValue
        {
            set { TxtTo.Maximum = value; }
        }

        public int FromIncrement
        {
            set { TxtFrom.Increment = value; }
        }

        public int ToIncrement
        {
            set { TxtTo.Increment = value; }
        }

        public RangeInputWindow()
        {
            InitializeComponent();
        }
    }
}
