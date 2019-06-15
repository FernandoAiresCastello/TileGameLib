using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.Exceptions
{
    public class InvalidMapAccessException : RuntimeException
    {
        public InvalidMapAccessException(string msg) : base(msg)
        {
        }
    }
}
