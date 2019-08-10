using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Exceptions
{
    public class EnvironmentException : Exception
    {
        public EnvironmentException(string msg) : base(msg)
        {
        }
    }
}
