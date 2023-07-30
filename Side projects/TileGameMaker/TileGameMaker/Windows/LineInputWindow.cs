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
    public partial class LineInputWindow : Form
    {
        public string TextValue
        {
            get { return TxtLine.Text; }
        }

        public int NumericValue
        {
            get { return int.Parse(TxtLine.Text); }
        }

        public LineInputWindow(string title, string initialText = "")
        {
            InitializeComponent();
            LbCaption.Text = title;
            TxtLine.Text = initialText;
        }
    }
}
