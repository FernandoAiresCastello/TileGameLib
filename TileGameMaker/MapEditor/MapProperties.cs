using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.GameElements;

namespace TileGameMaker.MapEditor
{
    public class MapProperties
    {
        [ReadOnly(true)]
        public string Path { set; get; }
        [ReadOnly(true)]
        public string File { set; get; }
        public string Name { set; get; }
        public string Music { set; get; }
        public string Width { set; get; }
        public string Height { set; get; }
        [ReadOnly(true)]
        public int Layers { set; get; }

        private ObjectMap Map;
        private string MapFullPath;

        public MapProperties(ObjectMap map, string mapFileFullPath)
        {
            Map = map;
            MapFullPath = mapFileFullPath;

            if (MapFullPath != null)
            {
                FileInfo info = new FileInfo(MapFullPath);
                Path = info.Directory.FullName;
                File = info.Name;
            }

            Name = Map.Name;
            Width = Map.Width.ToString();
            Height = Map.Height.ToString();
            Music = Map.MusicFile;
            Layers = Map.Layers.Count;
        }
    }
}
