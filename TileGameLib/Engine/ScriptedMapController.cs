using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TileGameLib.Engine
{
    public class ScriptedMapController : MapController
    {
        protected List<ScriptCommand> Script;
        protected List<ScriptCommand> CommandSectionOnEnter;
        protected List<ScriptCommand> CommandSectionOnLeave;
        protected List<ScriptCommand> CommandSectionOnExecuteCycle;
        protected List<ScriptCommand> CommandSectionOnDrawUi;
        protected List<ScriptCommand> CommandSectionOnKeyDown;
        protected List<ScriptCommand> CommandSectionOnKeyUp;

        protected bool Break = false;
        protected KeyEventArgs KeyEventArgs;

        public ScriptedMapController()
        {
        }

        public override void OnLoad()
        {
            if (string.IsNullOrEmpty(Map.Script.Trim()))
                return;

            string[] sourceLines = Map.Script.Split('\n');
            if (sourceLines.Length == 0)
                return;

            LoadScript(sourceLines);
            LoadSections();
        }

        private void LoadScript(string[] sourceLines)
        {
            Script = new List<ScriptCommand>();

            int sourceLineIndex = 0;

            foreach (string sourceLine in sourceLines)
            {
                string line = sourceLine.Trim();

                if (!string.IsNullOrEmpty(line))
                {
                    int indexOfFirstSpace = line.IndexOf(' ');
                    string commandName = indexOfFirstSpace >= 0 ? line.Substring(0, indexOfFirstSpace).Trim() : line;
                    string paramList = indexOfFirstSpace >= 0 ? line.Substring(indexOfFirstSpace).Trim() : null;
                    string[] param = paramList != null ? paramList.Split(',') : new string[] {};

                    ScriptCommand command = new ScriptCommand(sourceLineIndex, commandName.ToUpper(), param);
                    Script.Add(command);
                }

                sourceLineIndex++;
            }
        }

        private void LoadSections()
        {
            int onEnterStart = Script.FindIndex(cmd => cmd.Command == "BEGIN ENTER");
            int onLeaveStart = Script.FindIndex(cmd => cmd.Command == "BEGIN EXIT");
            int onCycleStart = Script.FindIndex(cmd => cmd.Command == "BEGIN CYCLE");
            int onDrawUiStart = Script.FindIndex(cmd => cmd.Command == "BEGIN DRAWUI");
            int onKeyDownStart = Script.FindIndex(cmd => cmd.Command == "BEGIN KEYDOWN");
            int onKeyUpStart = Script.FindIndex(cmd => cmd.Command == "BEGIN KEYUP");
            int onEnterEnd = Script.FindIndex(cmd => cmd.Command == "END ENTER");
            int onLeaveEnd = Script.FindIndex(cmd => cmd.Command == "END EXIT");
            int onCycleEnd = Script.FindIndex(cmd => cmd.Command == "END CYCLE");
            int onDrawUiEnd = Script.FindIndex(cmd => cmd.Command == "END DRAWUI");
            int onKeyDownEnd = Script.FindIndex(cmd => cmd.Command == "END KEYDOWN");
            int onKeyUpEnd = Script.FindIndex(cmd => cmd.Command == "END KEYUP");

            if (onEnterStart >= 0 && onEnterEnd >= 0)
            {
                CommandSectionOnEnter = new List<ScriptCommand>();
                CommandSectionOnEnter.AddRange(Script.GetRange(onEnterStart, onEnterEnd - onEnterStart));
            }

            if (onLeaveStart >= 0 && onLeaveEnd >= 0)
            {
                CommandSectionOnLeave = new List<ScriptCommand>();
                CommandSectionOnLeave.AddRange(Script.GetRange(onLeaveStart, onLeaveEnd - onLeaveStart));
            }

            if (onCycleStart >= 0 && onCycleEnd >= 0)
            {
                CommandSectionOnExecuteCycle = new List<ScriptCommand>();
                CommandSectionOnExecuteCycle.AddRange(Script.GetRange(onCycleStart, onLeaveEnd - onCycleStart));
            }

            if (onDrawUiStart >= 0 && onDrawUiEnd >= 0)
            {
                CommandSectionOnDrawUi = new List<ScriptCommand>();
                CommandSectionOnDrawUi.AddRange(Script.GetRange(onDrawUiStart, onDrawUiEnd - onDrawUiStart));
            }

            if (onKeyDownStart >= 0 && onKeyDownEnd >= 0)
            {
                CommandSectionOnKeyDown = new List<ScriptCommand>();
                CommandSectionOnKeyDown.AddRange(Script.GetRange(onKeyDownStart, onKeyDownEnd - onKeyDownStart));
            }

            if (onKeyUpStart >= 0 && onKeyUpEnd >= 0)
            {
                CommandSectionOnKeyUp = new List<ScriptCommand>();
                CommandSectionOnKeyUp.AddRange(Script.GetRange(onKeyUpStart, onKeyUpEnd - onKeyUpStart));
            }
        }

        public override void OnEnter()
        {
            if (CommandSectionOnEnter.Count > 0)
                ExecuteScript(CommandSectionOnEnter);
        }

        public override void OnLeave()
        {
            if (CommandSectionOnLeave.Count > 0)
                ExecuteScript(CommandSectionOnLeave);
        }

        public override void OnExecuteCycle()
        {
            if (CommandSectionOnExecuteCycle.Count > 0)
                ExecuteScript(CommandSectionOnExecuteCycle);
        }

        public override void OnDrawUi()
        {
            if (CommandSectionOnDrawUi.Count > 0)
                ExecuteScript(CommandSectionOnDrawUi);
        }

        public override void OnKeyDown(KeyEventArgs e)
        {
            KeyEventArgs = e;
            if (CommandSectionOnKeyDown.Count > 0)
                ExecuteScript(CommandSectionOnKeyDown);
        }

        public override void OnKeyUp(KeyEventArgs e)
        {
            KeyEventArgs = e;
            if (CommandSectionOnKeyUp.Count > 0)
                ExecuteScript(CommandSectionOnKeyUp);
        }

        protected void ExecuteScript(List<ScriptCommand> script)
        {
            foreach (ScriptCommand command in script)
            {
                ExecuteCommand(command);
                if (Break)
                    break;
            }
        }

        public virtual void ExecuteCommand(ScriptCommand command)
        {
            // Override this to execute a script command
        }
    }
}
