using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.Engine
{
    public class Machine
    {
        private Script MainScript = new Script();
        private Interpreter Interpreter = new Interpreter();
        private readonly Stack CallStack = new Stack();
        private readonly Stack ParamStack = new Stack();
        private readonly Variables Variables = new Variables();

        public Machine()
        {
        }

        public void Run(Script script)
        {
            Reset();
            MainScript = script;
            Interpreter.SetScript(script);
        }

        public void Reset()
        {
            CallStack.Clear();
            ParamStack.Clear();
            Variables.Clear();
        }
    }
}
