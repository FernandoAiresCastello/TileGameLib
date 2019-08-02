using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameRunner.Exceptions
{
    public class EngineException : Exception
    {
        public EngineException(string msg) : base(msg)
        {
        }
    }
}
