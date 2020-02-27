using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameMaker.MapEditorElements
{
    public class RecentFiles
    {
        public const string Path = "recent.ini";

        public List<string> Files { get; private set; } = new List<string>();

        public RecentFiles()
        {
            if (File.Exists(Path))
            {
                string[] lines = File.ReadAllLines(Path);
                if (lines.Length > 0)
                    Files.AddRange(lines);
            }
            else
            {
                File.Create(Path).Close();
            }
        }

        public void Add(string file)
        {
            if (!Files.Contains(file))
                Files.Add(file);
        }

        public void Save()
        {
            File.WriteAllLines(Path, Files);
        }
    }
}
