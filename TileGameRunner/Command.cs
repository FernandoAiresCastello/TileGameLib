using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameRunner
{
    public class Command
    {
        public string Name { set; get; }
        public List<string> Params { get; private set; } = new List<string>();
        public string Param => Params.Count > 0 ? Params[0] : null;

        public Command(string name)
        {
            Name = name;
        }

        public Command(string name, string param)
        {
            Name = name;
            Params.Add(param);
        }
    }
}
