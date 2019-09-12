using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.File;
using TileGameLib.GameElements;

namespace TileGameEngine.Core.RuntimeEnvironment
{
    public partial class Environment
    {
        public string MapFilePath { get; private set; } = "";
        public MapCursor MapCursor { get; private set; } = new MapCursor();

        private ObjectMap Map;

        public void LoadMapFromCurrentFolder(string filename)
        {
            MapFile.Load(ref Map, filename);
            MapFilePath = filename;

            MapCursor = new MapCursor(Map);

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

        public int GetMapWidth()
        {
            return Map.Width;
        }

        public int GetMapHeight()
        {
            return Map.Height;
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

        public void CreateNewObject()
        {
            if (MapCursor.IsValid)
                Map.CreateNewObject(MapCursor.Position);
        }

        public ref GameObject GetObjectRef()
        {
            return ref Map.GetObjectRef(MapCursor.Position);
        }

        public void MoveObject(ObjectPosition destPos)
        {
            if (MapCursor.IsValid)
                Map.MoveObject(MapCursor.Position, destPos);
        }

        public void MoveObjectRight(int distance)
        {
            if (MapCursor.IsValid)
                Map.MoveObject(MapCursor.Position, new ObjectPosition(
                    MapCursor.Position.Layer, MapCursor.Position.X + distance, MapCursor.Position.Y));
        }

        public void MoveObjectLeft(int distance)
        {
            if (MapCursor.IsValid)
                Map.MoveObject(MapCursor.Position, new ObjectPosition(
                    MapCursor.Position.Layer, MapCursor.Position.X - distance, MapCursor.Position.Y));
        }

        public void MoveObjectUp(int distance)
        {
            if (MapCursor.IsValid)
                Map.MoveObject(MapCursor.Position, new ObjectPosition(
                    MapCursor.Position.Layer, MapCursor.Position.X, MapCursor.Position.Y - distance));
        }

        public void MoveObjectDown(int distance)
        {
            if (MapCursor.IsValid)
                Map.MoveObject(MapCursor.Position, new ObjectPosition(
                    MapCursor.Position.Layer, MapCursor.Position.X, MapCursor.Position.Y + distance));
        }

        public void DuplicateObject(ObjectPosition destPos)
        {
            if (MapCursor.IsValid)
                Map.DuplicateObject(MapCursor.Position, destPos);
        }

        public void SwapObjects(ObjectPosition destPos)
        {
            if (MapCursor.IsValid)
                Map.SwapObjects(MapCursor.Position, destPos);
        }

        public void DeleteObject()
        {
            if (MapCursor.IsValid)
                Map.DeleteObject(MapCursor.Position);
        }

        public void SetObjectTag(string tag)
        {
            if (MapCursor.IsValid)
            {
                GameObject o = Map.GetObjectRef(MapCursor.Position);
                if (o != null)
                    o.Tag = tag;
            }
        }

        public string GetObjectTag()
        {
            if (MapCursor.IsValid)
            {
                GameObject o = Map.GetObjectRef(MapCursor.Position);
                if (o != null)
                    return o.Tag;
            }

            return null;
        }

        public void SetObjectProperty(string property, string value)
        {
            if (MapCursor.IsValid)
            {
                GameObject o = Map.GetObjectRef(MapCursor.Position);
                if (o != null)
                    o.Properties.SetProperty(property, value);
            }
        }

        public string GetObjectProperty(string property)
        {
            if (MapCursor.IsValid)
            {
                GameObject o = Map.GetObjectRef(MapCursor.Position);
                if (o != null)
                    return o.Properties.GetProperty(property);
            }

            return null;
        }

        public void SetObjectTileIx(int frame, int ix)
        {
            if (MapCursor.IsValid)
            {
                GameObject o = Map.GetObjectRef(MapCursor.Position);
                if (o != null && o.Animation.Frames.Count > frame)
                    o.Animation.GetFrame(frame).TileIx = ix;
            }
        }

        public int? GetObjectTileIx(int frame)
        {
            if (MapCursor.IsValid)
            {
                GameObject o = Map.GetObjectRef(MapCursor.Position);
                if (o != null && o.Animation.Frames.Count > frame)
                    return o.Animation.GetFrame(frame).TileIx;
            }

            return null;
        }

        public void SetObjectTileForeColor(int frame, int color)
        {
            if (MapCursor.IsValid)
            {
                GameObject o = Map.GetObjectRef(MapCursor.Position);
                if (o != null && o.Animation.Frames.Count > frame)
                    o.Animation.GetFrame(frame).ForeColorIx = color;
            }
        }

        public int? GetObjectTileForeColor(int frame)
        {
            if (MapCursor.IsValid)
            {
                GameObject o = Map.GetObjectRef(MapCursor.Position);
                if (o != null && o.Animation.Frames.Count > frame)
                    return o.Animation.GetFrame(frame).ForeColorIx;
            }

            return null;
        }

        public void SetObjectTileBackColor(int frame, int color)
        {
            if (MapCursor.IsValid)
            {
                GameObject o = Map.GetObjectRef(MapCursor.Position);
                if (o != null && o.Animation.Frames.Count > frame)
                    o.Animation.GetFrame(frame).BackColorIx = color;
            }
        }

        public int? GetObjectTileBackColor(int frame)
        {
            if (MapCursor.IsValid)
            {
                GameObject o = Map.GetObjectRef(MapCursor.Position);
                if (o != null && o.Animation.Frames.Count > frame)
                    return o.Animation.GetFrame(frame).BackColorIx;
            }

            return null;
        }

        public void CursorMoveNext()
        {
            int layer = MapCursor.Position.Layer;
            int x = MapCursor.Position.X;
            int y = MapCursor.Position.Y;

            x++;

            if (x >= Map.Width)
            {
                x = 0;
                y++;

                if (y >= Map.Height)
                {
                    y = 0;
                    layer++;
                }
            }

            MapCursor.Position = new ObjectPosition(layer, x, y);
        }
    }
}
