﻿using System;
using System.Collections.Generic;
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

        public MapController Get(string mapName)
        {
            foreach (var mapAndController in Controllers)
            {
                if (mapAndController.Key.Name.Equals(mapName))
                    return mapAndController.Value;
            }

            return null;
        }

        public bool HasMap(string mapName)
        {
            return Get(mapName) != null;
        }

        public ObjectMap AddController(string mapFile, MapController controller)
        {
            if (!System.IO.File.Exists(mapFile))
                throw new TileGameLibException($"Map file not found: {mapFile}");

            ObjectMap map = MapFile.Load(mapFile);

            if (HasMap(map.Name))
                throw new TileGameLibException($"There is already a map with the name {map.Name}");

            controller.Map = map;
            controller.MapFile = mapFile;
            Controllers.Add(controller.Map, controller);

            return controller.Map;
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
