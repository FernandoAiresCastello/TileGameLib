using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameMaker.MapEditorElements
{
    public class MapBookmarks
    {
        public const string Filename = "bookmarks.dat";

        public List<MapBookmark> Bookmarks { set; get; }

        public MapBookmarks()
        {
            Bookmarks = new List<MapBookmark>();
        }

        public void Add(string mapid, string name, int x, int y)
        {
            Bookmarks.Add(new MapBookmark(mapid, name, x, y));
        }

        public List<MapBookmark> FindByMapId(string mapid)
        {
            List<MapBookmark> bookmarks = new List<MapBookmark>();

            Bookmarks.ForEach(bm => 
            {
                if (bm.MapId == mapid)
                    bookmarks.Add(bm);
            });

            return bookmarks;
        }

        public MapBookmark FindByName(string name)
        {
            foreach (MapBookmark bookmark in Bookmarks)
            {
                if (bookmark.Name == name)
                    return bookmark;
            }

            return null;
        }

        public void Remove(string name)
        {
            Bookmarks.RemoveAll(bm => bm.Name == name);
        }

        public void Save(string path)
        {
            List<string> lines = new List<string>();

            Bookmarks.ForEach(bm =>
                lines.Add(bm.MapId + "|" + bm.Name + "|" + bm.X + "|" + bm.Y)
            );

            File.WriteAllLines(path, lines);
        }

        public void Load(string path)
        {
            string[] lines = File.ReadAllLines(path);

            Bookmarks.Clear();

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                Bookmarks.Add(new MapBookmark(
                    parts[0], parts[1], int.Parse(parts[2]), int.Parse(parts[3])));
            }
        }
    }
}
