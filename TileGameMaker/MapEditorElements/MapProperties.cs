using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;
using TileGameLib.GameElements;

namespace TileGameMaker.MapEditorElements
{
    public class MapProperties
    {
        [ReadOnly(true)]
        public string Id { set; get; }
        public string Name { set; get; }
        [ReadOnly(true)]
        public int Layers { set; get; }
        public string Width { set; get; }
        public string Height { set; get; }
        [ReadOnly(true)]
        public string Path { set; get; }
        [ReadOnly(true)]
        public string File { set; get; }

        public MapProperties(ObjectMap map, string mapFileFullPath)
        {
            if (mapFileFullPath != null)
            {
                FileInfo info = new FileInfo(mapFileFullPath);
                Path = info.Directory.FullName;
                File = info.Name;
            }

            Id = map.Id;
            Name = map.Name;
            Width = map.Width.ToString();
            Height = map.Height.ToString();
            Layers = map.Layers.Count;
        }
    }
}
