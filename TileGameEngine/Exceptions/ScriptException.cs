using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Exceptions
{
    public class ScriptException : Exception
    {
        public ScriptException(string msg) : base(msg)
        {
        }
    }
}
