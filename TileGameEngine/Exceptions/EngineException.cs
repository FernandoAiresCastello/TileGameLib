using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Exceptions
{
    public class EngineException : Exception
    {
        public EngineException(string msg) : base(msg)
        {
        }
    }
}
