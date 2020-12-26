using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Exceptions;

namespace TileGameLib.Util
{
    public static class Alert
    {
        public static void Info(string msg)
        {
            MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Warning(string msg)
        {
            MessageBox.Show(msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void Error(string msg)
        {
            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void Except(string msg)
        {
            MessageBox.Show(msg, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            throw new TGLException(msg);
        }

        public static bool Confirm(string msg)
        {
            DialogResult result = MessageBox.Show(msg, "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            return result == DialogResult.OK;
        }

        public static DialogResult YesNoOrCancel(string msg)
        {
            return MessageBox.Show(msg, "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }
    }
}
