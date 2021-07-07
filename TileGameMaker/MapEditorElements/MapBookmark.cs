using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameMaker.MapEditorElements
{
    public class MapBookmark
    {
        public string MapId { set; get; }
        public string Name { set; get; }
        public int X { set; get; }
        public int Y { set; get; }

        private MapBookmark()
        {
        }

        public MapBookmark(string mapid, string name, int x, int y)
        {
            MapId = mapid;
            Name = name;
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return Name + " [" + X + ", " + Y + "]";
        }
    }
}
