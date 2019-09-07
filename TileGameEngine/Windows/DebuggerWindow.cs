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
using System.IO;

namespace TileGameEngine.Windows
{
    public partial class DebuggerWindow : Form
    {
        private Interpreter Interpreter;
        private FileSystemWatcher FileWatcher;

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
                FormClosed += DebuggerWindow_FormClosed;
                SetupLogFileWatcher();
            }
        }

        ~DebuggerWindow()
        {
            FileWatcher.Dispose();
        }

        private void SetupLogFileWatcher()
        {
            TxtLog.Text = "";
            FileWatcher = new FileSystemWatcher(new FileInfo(Core.Environment.LogFile).DirectoryName, Core.Environment.LogFile);
            FileWatcher.NotifyFilter =
                NotifyFilters.LastWrite |
                NotifyFilters.LastAccess |
                NotifyFilters.FileName |
                NotifyFilters.DirectoryName;

            FileWatcher.Changed += FileWatcher_Changed;
            FileWatcher.Deleted += FileWatcher_Changed;
            FileWatcher.EnableRaisingEvents = true;
        }

        private void FileWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (File.Exists(Core.Environment.LogFile))
                UpdateLogViewAsync(File.ReadAllText(Core.Environment.LogFile));
            else
                UpdateLogViewAsync("");
        }

        private void UpdateLogViewAsync(string log)
        {
            BeginInvoke(new MethodInvoker(() => TxtLog.Text = log));
        }

        private void DebuggerWindow_Shown(object sender, EventArgs e)
        {
            Refresh();
        }

        private void DebuggerWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Interpreter.Stop();
        }

        private void MiExit_Click(object sender, EventArgs e)
        {
        }

        private void MiClose_Click(object sender, EventArgs e)
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
            if (Alert.Confirm("Reset engine?"))
            {
                Interpreter.Reset();
                Refresh();
            }
        }

        public void SkipCurrentLine()
        {
            if (Interpreter.Running)
            {
                Interpreter.Skip();
                Refresh();
            }
            else
            {
                AlertExecutionFinishedThenSuggestReset();
            }
        }

        public void JumpToSelectedLine()
        {
            if (Interpreter.Running)
            {
                int line = LstScript.SelectedIndex;

                if (line >= 0)
                {
                    Interpreter.SetProgramPointer(line);
                    Refresh();
                }
            }
            else
            {
                AlertExecutionFinishedThenSuggestReset();
            }
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
                AlertExecutionFinishedThenSuggestReset();
            }
        }

        private void AlertExecutionFinishedThenSuggestReset()
        {
            if (Alert.Confirm("Execution finished. Reset?"))
            {
                Interpreter.Reset();
                Refresh();
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
            LstScript.Items.AddRange(Interpreter.ScriptLinesForDebugger.ToArray());

            if (LstScript.Items.Count > 0 && Interpreter.Running)
                LstScript.SelectedIndex = Interpreter.ProgramPointer;
            else
                LstScript.SelectedIndex = -1;
        }

        private void UpdateLabelsView()
        {
            LstLabels.Items.Clear();

            foreach (string label in Interpreter.Labels.ToList())
                LstLabels.Items.Add(label);
        }

        private void UpdateCurrentLineView()
        {
            TxtCurrentLine.Text = Interpreter.CurrentLineForDebugger;
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
