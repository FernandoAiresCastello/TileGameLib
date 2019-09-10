using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.File;
using TileGameLib.GameElements;

namespace TileGameEngine.Core
{
    public partial class Environment
    {
        private ObjectMap Map;

        public string MapFilePath { get; private set; } = "";

        public void LoadMapFromCurrentFolder(string filename)
        {
            MapFile.Load(ref Map, filename);
            MapFilePath = filename;

            if (MapRenderer == null)
                StartMapRenderer();
            else
                MapRenderer.Map = Map;
        }

        public void SetMapName(string name)
        {
            Map.Name = name;
        }

        public string GetMapName()
        {
            return Map.Name;
        }

        public void SetMapBackColor(int color)
        {
            Map.BackColor = color;
        }

        public void SetMapPalette(int index, int rgb)
        {
            Map.Palette.Set(index, rgb);
        }

        public void SetMapTileset(int index, byte[] pattern)
        {
            Map.Tileset.Set(index,
                pattern[0], pattern[1], pattern[2], pattern[3],
                pattern[4], pattern[5], pattern[6], pattern[7]);
        }

        public void CreateNewObject(int layer, int x, int y)
        {
            Map.CreateNewObject(layer, x, y);
        }

        public ObjectPosition FindObjectPositionByTag(string tag)
        {
            return Map.FindObjectPositionByTag(tag);
        }

        public ref GameObject GetObjectRefAt(int layer, int x, int y)
        {
            return ref Map.GetObjectRef(layer, x, y);
        }

        public void MoveObject(ObjectPosition srcPos, ObjectPosition destPos)
        {
            Map.MoveObject(srcPos, destPos);
        }

        public void DuplicateObject(ObjectPosition srcPos, ObjectPosition destPos)
        {
            Map.DuplicateObject(srcPos, destPos);
        }

        public void SwapObjects(ObjectPosition pos1, ObjectPosition pos2)
        {
            Map.SwapObjects(pos1, pos2);
        }

        public void DeleteObject(ObjectPosition pos)
        {
            Map.DeleteObject(pos);
        }

        public void SetObjectId(int layer, int x, int y, string id)
        {
            GameObject o = Map.GetObjectRef(layer, x, y);
            if (o != null)
                o.Id = id;
        }

        public void SetObjectTag(int layer, int x, int y, string tag)
        {
            GameObject o = Map.GetObjectRef(layer, x, y);
            if (o != null)
                o.Tag = tag;
        }

        public void SetObjectProperty(int layer, int x, int y, string property, string value)
        {
            GameObject o = Map.GetObjectRef(layer, x, y);
            if (o != null)
                o.Properties.SetProperty(property, value);
        }

        public void SetObjectTileIx(int layer, int x, int y, int frame, int ix)
        {
            GameObject o = Map.GetObjectRef(layer, x, y);
            if (o != null)
                o.Animation.GetFrame(frame).TileIx = ix;
        }

        public void SetObjectTileForeColor(int layer, int x, int y, int frame, int color)
        {
            GameObject o = Map.GetObjectRef(layer, x, y);
            if (o != null)
                o.Animation.GetFrame(frame).ForeColorIx = color;
        }

        public void SetObjectTileBackColor(int layer, int x, int y, int frame, int color)
        {
            GameObject o = Map.GetObjectRef(layer, x, y);
            if (o != null)
                o.Animation.GetFrame(frame).BackColorIx = color;
        }
    }
}
