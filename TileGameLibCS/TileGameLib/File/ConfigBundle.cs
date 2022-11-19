using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TileGameLib.File
{
    public class ConfigBundle
    {
        private Dictionary<string, string> Entries = new Dictionary<string, string>();

        public override string ToString()
        {
            return JsonSerializer.Serialize(Entries);
        }

        public void Parse(string str)
        {
            Entries = JsonSerializer.Deserialize<Dictionary<string, string>>(str);
        }

        public void SetString(string key, string value)
        {
            Set(key, value);
        }

        public void SetBool(string key, bool value)
        {
            Set(key, value.ToString());
        }

        public void SetNumber(string key, int value)
        {
            Set(key, value.ToString());
        }

        private void Set(string key, object value)
        {
            Entries[key] = value.ToString();
        }

        public string GetString(string key)
        {
            return Get(key);
        }

        public int GetNumber(string key)
        {
            string value = Get(key);
            bool parseOk = int.TryParse(value, out int number);
            if (!parseOk)
                throw new Exception("Config does not contain a number: " + key);

            return number;
        }

        public bool GetBool(string key)
        {
            string value = Get(key).ToLower();
            bool parseOk = bool.TryParse(value, out bool flag);
            if (!parseOk)
                throw new Exception("Config does not contain a boolean: " + key);

            return flag;
        }

        private string Get(string key)
        {
            if (!Entries.ContainsKey(key))
                throw new Exception("Config not found with key: " + key);

            return Entries[key];
        }
    }
}
