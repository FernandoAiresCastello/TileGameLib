using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.File;
using TileGameLib.GameElements;
using TileGameLib.Util;

namespace TileGameLib.Engine
{
    public class MapControllerCollection
    {
        private readonly Dictionary<ObjectMap, MapController> Controllers;

        public MapControllerCollection()
        {
            Controllers = new Dictionary<ObjectMap, MapController>();
        }

        public MapController Get(string mapName)
        {
            foreach (var mapAndController in Controllers)
            {
                if (mapAndController.Key.Name.Equals(mapName))
                    return mapAndController.Value;
            }

            return null;
        }

        public ObjectMap LoadMapSetController(string mapFile, MapController controller)
        {
            ObjectMap map = MapFile.Load(mapFile);
            controller.Map = map;
            Controllers.Add(map, controller);

            return map;
        }
    }
}
