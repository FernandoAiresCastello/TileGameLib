using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Core
{
    public class ScriptLabels
    {
        private readonly Dictionary<string, int> Labels = new Dictionary<string, int>();

        public ScriptLabels()
        {
        }

        public void Clear()
        {
            Labels.Clear();
        }

        public void Add(string label, int line)
        {
            Labels[label] = line;
        }

        public int Get(string label)
        {
            return Labels[label];
        }

        public bool HasLabel(string label)
        {
            return Labels.ContainsKey(label);
        }
    }
}
