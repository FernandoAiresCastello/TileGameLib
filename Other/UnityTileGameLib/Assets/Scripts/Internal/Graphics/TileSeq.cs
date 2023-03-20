using System;
using System.Collections;
using System.Collections.Generic;

namespace TileGameLib
{
    public class TileSeq
    {
        public int length => tiles.Count;
        public Tile first => tiles.Count > 0 ? tiles[0] : throw new InvalidOperationException();

        private List<Tile> tiles;

        public Tile Get(int index)
        {
            return tiles[index % tiles.Count];
        }

    public void Add(Tile tile)
        {
            tiles.Add(tile);
        }
    }
}
