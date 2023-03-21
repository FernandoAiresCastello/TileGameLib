using System;
using System.Collections;
using System.Collections.Generic;

namespace TileGameLib
{
    public class TileSeq
    {
        public int Length => tiles.Count;
        public Tile First => tiles.Count > 0 ? tiles[0] : throw new InvalidOperationException();
        public static TileSeq Blank => new TileSeq(Tile.Blank());

        private readonly List<Tile> tiles = new List<Tile>();

        public TileSeq(Tile first)
        {
            Add(first);
        }

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
