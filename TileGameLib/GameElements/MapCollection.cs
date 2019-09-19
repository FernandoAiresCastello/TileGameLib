using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.File;
using TileGameLib.Util;

namespace TileGameLib.GameElements
{
    public class MapCollection
    {
        public List<ObjectMap> Maps { set; get; } = new List<ObjectMap>();

        public MapCollection()
        {
        }

        public void LoadAllMaps()
        {
            LoadAllMaps(Application.StartupPath);
        }

        public void LoadAllMaps(string path)
        {
            var files = Directory.EnumerateFiles(path, "*." + Constants.FileMapExtension);

            foreach (string file in files)
                Maps.Add(MapFile.Load(file));
        }

        public ObjectMap FindByName(string name)
        {
            foreach (ObjectMap map in Maps)
            {
                if (map.Name.Equals(name))
                    return map;
            }

            return null;
        }
    }
}
