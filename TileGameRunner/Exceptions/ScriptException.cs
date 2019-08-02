using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameRunner.Exceptions
{
    public class ScriptException : Exception
    {
        public ScriptException(string msg) : base(msg)
        {
        }
    }
}
