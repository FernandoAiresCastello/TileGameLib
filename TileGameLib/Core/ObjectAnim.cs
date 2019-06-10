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
        public int Size => Frames.Count;

        public ObjectAnim()
        {
            Clear();
        }

        public ObjectAnim(bool addEmptyFirstFrame)
        {
            Clear(addEmptyFirstFrame);
        }

        public ObjectAnim(ObjectAnim other)
        {
            SetEqual(other);
        }

        public ObjectAnim CopyFrames(int frames)
        {
            ObjectAnim anim = new ObjectAnim(false);
            for (int i = 0; i < frames && i < Frames.Count; i++)
                anim.AddFrame(Frames[i]);

            return anim;
        }

        public void Clear()
        {
            Clear(true);
        }

        public void Clear(bool addEmptyFirstFrame)
        {
            Frames.Clear();
            if (addEmptyFirstFrame)
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

        public void AddFrames(int count, Tile ch)
        {
            for (int i = 0; i < count; i++)
                AddFrame(ch);
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
