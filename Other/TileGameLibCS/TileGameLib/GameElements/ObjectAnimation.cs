using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Graphics;

namespace TileGameLib.GameElements
{
    public class ObjectAnimation
    {
        public List<Tile> Frames { set; get; } = new List<Tile>();
        public int Size => Frames.Count;
        public Tile FirstFrame => Frames.Count > 0 ? Frames[0] : null;

        public ObjectAnimation()
        {
            Frames.Clear();
        }

        public ObjectAnimation(bool addFirstFrame)
        {
            Frames.Clear();
            if (addFirstFrame)
                Frames.Add(Tile.Blank);
        }

        public ObjectAnimation(Tile firstFrame)
        {
            Frames.Clear();
            Frames.Add(firstFrame);
        }

        public ObjectAnimation(ObjectAnimation other)
        {
            SetEqual(other);
        }

        public void Clear()
        {
            Frames.Clear();
        }

        public ObjectAnimation CopyFrames(int frames)
        {
            ObjectAnimation anim = new ObjectAnimation();
            for (int i = 0; i < frames && i < Frames.Count; i++)
                anim.AddFrame(Frames[i]);

            return anim;
        }

        public bool IsSingleFrame()
        {
            return Frames.Count == 1;
        }

        public void SetEqual(ObjectAnimation other)
        {
            Frames.Clear();
            foreach (Tile ch in other.Frames)
                Frames.Add(new Tile(ch.Index, ch.ForeColor, ch.BackColor));
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

        public void AddBlankFrame()
        {
            AddFrame(Tile.Blank);
        }

        public void SetFrame(int index, Tile ch)
        {
            Frames[index] = ch;
        }

        public Tile GetFrame(int index)
        {
            if (Frames.Count > 0)
                return Frames[index % Frames.Count];
            else
                return null;
        }

        public override bool Equals(object o)
        {
            if (o == null || GetType() != o.GetType())
                return false;

            ObjectAnimation other = (ObjectAnimation)o;

            if (Frames.Count != other.Frames.Count)
                return false;

            for (int i = 0; i < Frames.Count; i++)
                if (!Frames[i].Equals(other.Frames[i]))
                    return false;

            return true;
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Frames).GetHashCode();
        }
    }
}
