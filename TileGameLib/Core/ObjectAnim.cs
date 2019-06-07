using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Graphics;

namespace TileGameLib.Core
{
    public class ObjectAnim
    {
        public List<Tile> Frames { set; get; } = new List<Tile>();

        public Tile this[int index]
        {
            get { return GetFrame(index); }
        }

        public ObjectAnim()
        {
            Clear();
        }

        public ObjectAnim(ObjectAnim other)
        {
            SetEqual(other);
        }

        public void Clear()
        {
            Frames.Clear();
            Frames.Add(new Tile());
        }

        public bool IsSingleFrame()
        {
            return Frames.Count == 1;
        }

        public Tile GetFirstFrame()
        {
            if (Frames.Count > 0)
                return Frames[0];

            return null;
        }

        public void SetEqual(ObjectAnim other)
        {
            Frames.Clear();
            foreach (Tile ch in other.Frames)
                Frames.Add(new Tile(ch.TileIx, ch.ForeColorIx, ch.BackColorIx));
        }

        public override bool Equals(object o)
        {
            if (o == null || GetType() != o.GetType())
                return false;

            ObjectAnim other = (ObjectAnim)o;

            if (Frames.Count != other.Frames.Count)
                return false;

            for (int i = 0; i < Frames.Count; i++)
                if (!Frames[i].Equals(other.Frames[i]))
                    return false;

            return true;
        }

        public void AddFrame(Tile ch)
        {
            Frames.Add(ch.Copy());
        }

        public void SetFrame(int index, Tile ch)
        {
            Frames[index] = ch;
        }

        public Tile GetFrame(int index)
        {
            return Frames[index % Frames.Count];
        }
    }
}
