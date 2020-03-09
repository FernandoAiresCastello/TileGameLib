using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameMaker.Util
{
    public class UserSettings
    {
        public const string Path = "settings.ini";

        private readonly Dictionary<string, string> Settings = new Dictionary<string, string>();

        public UserSettings()
        {
            if (File.Exists(Path))
            {
                string[] lines = File.ReadAllLines(Path);
                if (lines.Length > 0)
                    Load(lines);
            }
            else
            {
                File.Create(Path).Close();
            }
        }

        private void Load(string[] lines)
        {
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line) || line.Trim().Equals("#"))
                    continue;

                int equalSignIndex = line.IndexOf('=');
                string key = line.Substring(0, equalSignIndex).Trim();
                string value = line.Substring(equalSignIndex + 1).Trim();
                Settings[key] = value;
            }
        }

        public void Save()
        {
            List<string> lines = new List<string>();

            foreach (var setting in Settings)
            {
                string line = setting.Key + "=" + setting.Value;
                lines.Add(line);
            }

            File.WriteAllLines(Path, lines);
        }

        public bool Has(string setting)
        {
            return Settings.TryGetValue(setting, out string value);
        }

        public string Get(string setting)
        {
            try
            {
                return Settings[setting];
            }
            catch
            {
                return null;
            }
        }

        public int GetInteger(string setting)
        {
            return int.Parse(Get(setting));
        }

        public bool GetBool(string setting)
        {
            return bool.Parse(Get(setting));
        }

        public void Set(string setting, string value)
        {
            Settings[setting] = value;
        }
    }
}
