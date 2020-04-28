using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Exceptions;
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

        public MapController Get(string id)
        {
            foreach (var mapAndController in Controllers)
            {
                if (mapAndController.Key.Id.Equals(id))
                    return mapAndController.Value;
            }

            return null;
        }

        public bool HasMap(string id)
        {
            return Get(id) != null;
        }

        public ObjectMap AddController(string mapFile, MapController controller)
        {
            if (!System.IO.File.Exists(mapFile))
                throw new TileGameLibException($"Map file not found: {mapFile}");

            ObjectMap map = MapFile.LoadFromRawBytes(mapFile);

            if (HasMap(map.Id))
                throw new TileGameLibException($"There is already a map with id {map.Id}");

            controller.Map = map;
            controller.MapFile = Path.GetFileName(mapFile);
            Controllers.Add(controller.Map, controller);

            return controller.Map;
        }

        public void AddController(ObjectMap map, MapController controller)
        {
            if (HasMap(map.Id))
                throw new TileGameLibException($"There is already a map with id {map.Id}");

            controller.Map = map;
            controller.MapFile = null;
            Controllers.Add(controller.Map, controller);
        }

        public void RemoveController(MapController controller)
        {
            Controllers.Remove(controller.Map);
        }

        public List<MapController> GetControllers()
        {
            List<MapController> controllers = new List<MapController>();

            foreach (var controller in Controllers)
                controllers.Add(controller.Value);

            return controllers;
        }
    }
}
