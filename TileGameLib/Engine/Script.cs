using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.Engine
{
    public class Script
    {
        public List<Command> Commands { get; private set; } = new List<Command>();

        private static readonly char LineSeparator = '\n';
        private static readonly char NameParamSeparator = ' ';

        public Script(string script)
        {
            Commands.Clear();

            string[] lines = script.Split(LineSeparator);

            foreach (string line in lines)
            {
                string[] nameParam = line.Split(NameParamSeparator);
                Commands.Add(new Command(line));
            }
        }
    }
}
