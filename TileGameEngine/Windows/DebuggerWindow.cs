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
using TileGameEngine.Core;

namespace TileGameEngine.Windows
{
    public partial class DebuggerWindow : Form
    {
        private Interpreter Interpreter;

        public DebuggerWindow() : this(null)
        {
        }

        public DebuggerWindow(Interpreter interpreter)
        {
            InitializeComponent();

            if (interpreter != null)
            {
                Interpreter = interpreter;
                Shown += DebuggerWindow_Shown;
            }
        }

        private void DebuggerWindow_Shown(object sender, EventArgs e)
        {
            Refresh();
        }

        private void MiExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void BtnExecute_Click(object sender, EventArgs e)
        {
            ExecuteCycle();
        }

        private void BtnSkip_Click(object sender, EventArgs e)
        {
            SkipCurrentLine();
        }

        private void BtnJump_Click(object sender, EventArgs e)
        {
            JumpToSelectedLine();
        }

        public void Reset()
        {
            Interpreter.Reset();
            Refresh();
        }

        public void SkipCurrentLine()
        {
            Interpreter.ProgramPtr++;
            Refresh();
        }

        public void JumpToSelectedLine()
        {
            int line = LstScript.SelectedIndex;
            Interpreter.ProgramPtr = line;
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

            foreach (ScriptLine line in Interpreter.Script.Lines)
                LstScript.Items.Add(line.ToDebuggerString());

            LstScript.SelectedIndex = Interpreter.ProgramPtr;
        }

        private void UpdateLabelsView()
        {
            LstLabels.Items.Clear();

            foreach (string label in Interpreter.Labels.ToList())
                LstLabels.Items.Add(label);
        }

        private void UpdateCurrentLineView()
        {
            TxtCurrentLine.Text = Interpreter.CurrentLine;
        }

        private void UpdateParamStackView()
        {
            LstParamStack.Items.Clear();

            foreach (string param in Interpreter.ParamStack.ToList())
                LstParamStack.Items.Add(param);
        }

        private void UpdateCallStackView()
        {
            LstCallStack.Items.Clear();

            foreach (int returnPtr in Interpreter.CallStack.ToList())
                LstCallStack.Items.Add(returnPtr.ToString());
        }

        private void UpdateVariablesView()
        {
            StringBuilder vars = new StringBuilder();

            foreach (string var in Interpreter.Environment.Variables.ToList())
                vars.Append(var + "\r\n");

            TxtVariables.Text = vars.ToString();
        }
    }
}
