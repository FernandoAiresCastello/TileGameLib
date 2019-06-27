using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.Engine
{
    public class Interpreter
    {
        private Script Script = new Script();
        private int CommandPointer = 0;
        private readonly Dictionary<string, int> Labels = new Dictionary<string, int>();

        public Interpreter()
        {
        }

        public void Reset()
        {
            CommandPointer = 0;
            Labels.Clear();
        }

        public void SetScript(Script script)
        {
            Script = script;
            Reset();
            ProcessLabels();
        }

        private void ProcessLabels()
        {
            // todo
        }
    }
}
