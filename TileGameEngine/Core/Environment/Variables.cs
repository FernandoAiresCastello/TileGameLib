using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Core
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

        public void Set(string name, object value)
        {
            if (Vars.ContainsKey(name))
                Vars.Remove(name);

            Vars.Add(name, value.ToString());
        }

        public string GetStr(string name)
        {
            Vars.TryGetValue(name, out string value);
            return value;
        }

        public int GetInt(string name)
        {
            int.TryParse(GetStr(name), out int value);
            return value;
        }

        public void Delete(string name)
        {
            if (Contains(name))
                Vars.Remove(name);
        }

        public bool Contains(string name)
        {
            return Vars.ContainsKey(name);
        }

        public List<string> ToList()
        {
            List<string> list = new List<string>();
            
            foreach (var variable in Vars.AsEnumerable())
                list.Add(variable.Key + " = " + variable.Value);

            return list;
        }
    }
}
