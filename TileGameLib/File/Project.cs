using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.GameElements;
using TileGameLib.Graphics;

namespace TileGameLib.File
{
    public class Project
    {
        public const int DefaultMapWidth = 32;
        public const int DefaultMapHeight = 24;

        public string Path { get; private set; }
        public string Name { get; set; }
        public string CreationDate { get; set; }
        public Tileset Tileset { get; set; }
        public Palette Palette { get; set; }
        public List<ObjectMap> Maps { get; set; }
        public string Program { get; set; }
        public int EngineWindowCols { get; set; }
        public int EngineWindowRows { get; set; }
        public int EngineWindowMagnification { get; set; }
        public int EngineWindowWidth { get; set; }
        public int EngineWindowHeight { get; set; }
        public ObjectMap TemplateObjects { get; set; }

        public string Folder
        {
            get
            {
                FileInfo info = new FileInfo(Path);
                return info.DirectoryName;
            }
        }

        public Project()
        {
            Name = "New Project";
            Tileset = new Tileset();
            Palette = new Palette();
            Maps = new List<ObjectMap>();
            Program = string.Empty;
            EngineWindowCols = 32;
            EngineWindowRows = 24;
            EngineWindowMagnification = 2;
            EngineWindowWidth = 640;
            EngineWindowHeight = 480;
            TemplateObjects = new ObjectMap(this, 16, 16);
        }

        public void DeleteMap(ObjectMap map)
        {
            Maps.Remove(map);
        }

        public ObjectMap FindMapById(string id)
        {
            return Maps.Find(map => map.Id == id);
        }

        public void AddBlankMap()
        {
            Maps.Add(new ObjectMap(this, DefaultMapWidth, DefaultMapHeight));
        }

        public void Save(string path)
        {
            Path = path;
            ProjectFile.Save(this);
        }

        public void Save()
        {
            ProjectFile.Save(this);
        }

        public bool Load(string path)
        {
            Path = path;
            return ProjectFile.Load(this);
        }
    }
}
