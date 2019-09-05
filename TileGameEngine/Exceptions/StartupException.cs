using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Exceptions
{
    public class StartupException : Exception
    {
        public StartupException(string msg) : base(msg)
        {
        }
    }
}
