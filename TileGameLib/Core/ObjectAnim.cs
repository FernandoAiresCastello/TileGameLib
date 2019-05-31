using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.Core
{
    public class ObjectAnim
    {
        public List<ObjectChar> Frames { set; get; } = new List<ObjectChar>();

        public ObjectChar this[int index]
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
            Frames.Add(new ObjectChar());
        }

        public bool IsSingleFrame()
        {
            return Frames.Count == 1;
        }

        public void SetEqual(ObjectAnim other)
        {
            Frames.Clear();
            foreach (ObjectChar ch in other.Frames)
                Frames.Add(new ObjectChar(ch.CharIx, ch.ForeColorIx, ch.BackColorIx));
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

        public void AddFrame(ObjectChar ch)
        {
            Frames.Add(ch.Copy());
        }

        public void SetFrame(int index, ObjectChar ch)
        {
            Frames[index] = ch;
        }

        public ObjectChar GetFrame(int index)
        {
            return Frames[index % Frames.Count];
        }
    }
}
