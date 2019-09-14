using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Core.RuntimeEnvironment
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

        public string RemovePrefix(string variableIdentifier)
        {
            if (variableIdentifier.StartsWith("$"))
                return variableIdentifier.Substring(1);

            return variableIdentifier;
        }

        public void Set(string name, object value)
        {
            name = RemovePrefix(name);

            if (Vars.ContainsKey(name))
                Vars.Remove(name);

            Vars.Add(name, value.ToString());
        }

        public string GetStr(string name)
        {
            name = RemovePrefix(name);
            Vars.TryGetValue(name, out string value);
            return value;
        }

        public int GetInt(string name)
        {
            name = RemovePrefix(name);
            int.TryParse(GetStr(name), out int value);
            return value;
        }

        public void Delete(string name)
        {
            name = RemovePrefix(name);
            if (Contains(name))
                Vars.Remove(name);
        }

        public bool Contains(string name)
        {
            name = RemovePrefix(name);
            return Vars.ContainsKey(name);
        }

        public List<string> ToList()
        {
            List<string> list = new List<string>();
            
            foreach (var variable in Vars.AsEnumerable())
                list.Add(variable.Key + " = " + variable.Value);

            return list;
        }

        public void Add(string variable, int value)
        {
            variable = RemovePrefix(variable);

            if (Vars.ContainsKey(variable))
            {
                int originalValue = GetInt(variable);
                int newValue = originalValue + value;
                Set(variable, newValue);
            }
        }

        public void Multiply(string variable, int value)
        {
            variable = RemovePrefix(variable);

            if (Vars.ContainsKey(variable))
            {
                int originalValue = GetInt(variable);
                int newValue = originalValue * value;
                Set(variable, newValue);
            }
        }

        public void Divide(string variable, int value)
        {
            variable = RemovePrefix(variable);

            if (Vars.ContainsKey(variable))
            {
                int originalValue = GetInt(variable);
                int newValue = originalValue / value;
                Set(variable, newValue);
            }
        }
    }
}
