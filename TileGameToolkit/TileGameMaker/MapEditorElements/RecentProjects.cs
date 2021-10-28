﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameMaker.MapEditorElements
{
    public class RecentProjects
    {
        public const string Path = "recent_projects.ini";

        public List<string> Files { get; private set; } = new List<string>();

        public RecentProjects()
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

        public void Remove(string file)
        {
            if (Files.Contains(file))
                Files.Remove(file);
        }

        public void Save()
        {
            File.WriteAllLines(Path, Files);
        }
    }
}
