using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.GameElements;

namespace TileGameRunner
{
    public class Interpreter
    {
        private readonly Script Script;
        private readonly Stack ParamStack = new Stack();
        private readonly Stack CallStack = new Stack();
        private readonly Variables Variables = new Variables();
        private readonly Dictionary<string, int> Labels = new Dictionary<string, int>();
        private int ProgramPtr = 0;

        public Interpreter(Script script)
        {
            Script = script;
            FindLabels();
        }

        private void FindLabels()
        {

        }
    }
}
