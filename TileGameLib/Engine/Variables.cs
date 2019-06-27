using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.Engine
{
    public class Variables
    {
        private readonly Dictionary<string, string> Vars = new Dictionary<string, string>();

        public int Size => Vars.Count;

        public Variables()
        {
        }

        public void Clear()
        {
            Vars.Clear();
        }

        public void Set(string name, string value)
        {
            if (Vars.ContainsKey(name))
                Vars.Remove(name);

            Vars.Add(name, value);
        }

        public string GetStr(string name)
        {
            string value = "";
            if (Vars.ContainsKey(name))
                Vars.TryGetValue(name, out value);

            return value;
        }

        public int GetInt(string name)
        {
            int.TryParse(GetStr(name), out int value);
            return value;
        }

        public bool Contains(string name)
        {
            return Vars.ContainsKey(name);
        }
    }
}
