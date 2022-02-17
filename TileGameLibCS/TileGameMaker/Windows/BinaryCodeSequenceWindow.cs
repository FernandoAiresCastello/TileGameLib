using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Util;

namespace TileGameMaker.Windows
{
    public partial class BinaryCodeSequenceWindow : Form
    {
        private Func<int, int, List<string>> CallbackToGetBytes;
        private Action<int, int, List<string>> CallbackToSetBytes;

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

        public BinaryCodeSequenceWindow(string title, string validFormatLabel, int firstIndex,
            Func<int, int, List<string>> callbackToGetBytes, 
            Action<int, int, List<string>> callbackToSetBytes)
        {
            InitializeComponent();
            Text = title;
            LbValidLineFormat.Text = validFormatLabel;
            FromValue = firstIndex;
            CallbackToGetBytes = callbackToGetBytes;
            CallbackToSetBytes = callbackToSetBytes;
        }

        private void BtnViewBytes_Click(object sender, EventArgs e)
        {
            if (FromValue > ToValue)
            {
                Alert.Warning("Invalid range\nThe last index must be larger or equal to the first index");
                return;
            }

            List<string> lines = CallbackToGetBytes(FromValue, ToValue);

            foreach (string line in lines)
                TxtBytes.AppendText(line.Trim() + Environment.NewLine);
        }

        private void BtnSetBytes_Click(object sender, EventArgs e)
        {
            if (FromValue > ToValue)
            {
                Alert.Warning("Invalid range\nThe last index must be larger or equal to the first index");
                return;
            }

            List<string> rawLines = TxtBytes.Lines.ToList();
            List<string> parsedLines = new List<string>();

            for (int i = 0; i < rawLines.Count; i++)
            {
                string line = rawLines[i].Trim();
                if (!string.IsNullOrWhiteSpace(line))
                    parsedLines.Add(line);
            }

            CallbackToSetBytes(FromValue, ToValue, parsedLines);
        }
    }
}
