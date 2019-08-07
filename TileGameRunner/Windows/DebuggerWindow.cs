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
using TileGameRunner.Core;

namespace TileGameRunner.Windows
{
    public partial class DebuggerWindow : Form
    {
        private Interpreter Interpreter;

        public DebuggerWindow()
        {
            InitializeComponent();
            Shown += DebuggerWindow_Shown;
        }

        public DebuggerWindow(Interpreter interpreter)
        {
            Interpreter = interpreter;
        }

        private void DebuggerWindow_Shown(object sender, EventArgs e)
        {
            Refresh();
        }

        private void MiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MiReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void BtnExecute_Click(object sender, EventArgs e)
        {
            ExecuteCycle();
        }

        private void MiExecute_Click(object sender, EventArgs e)
        {
            ExecuteCycle();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        public void Reset()
        {
            Interpreter.Reset();
            Refresh();
        }

        public void ExecuteCycle()
        {
            if (Interpreter.Running)
            {
                Interpreter.ExecuteCycle();
                Refresh();
            }
            else
            {
                if (Alert.Confirm("Execution finished. Reset?"))
                {
                    Interpreter.Reset();
                    Refresh();
                }
            }
        }

        public override void Refresh()
        {
            UpdateViews();
            base.Refresh();
        }

        private void UpdateViews()
        {
            UpdateScriptView();
            UpdateLabelsView();
            UpdateCurrentLineView();
            UpdateParamStackView();
            UpdateCallStackView();
            UpdateVariablesView();
        }

        private void UpdateScriptView()
        {
            LstScript.Items.Clear();
        }

        private void UpdateLabelsView()
        {
            LstLabels.Items.Clear();
        }

        private void UpdateCurrentLineView()
        {
            TxtCurrentLine.Text = "";
        }

        private void UpdateParamStackView()
        {
            LstParamStack.Items.Clear();
        }

        private void UpdateCallStackView()
        {
            LstCallStack.Items.Clear();
        }

        private void UpdateVariablesView()
        {
            TxtVariables.Text = "";
        }
    }
}
