using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Graphics;
using TileGameLib.Util;

namespace TileGameLib.GameElements
{
    public class GameObject
    {
        public string Id { set; get; }
        public string Tag { set; get; }
        public bool Visible { set; get; }
        public ObjectAnim Animation { set; get; } = new ObjectAnim();
        public ObjectProperties Properties { set; get; } = new ObjectProperties();

        public bool HasTag => !string.IsNullOrWhiteSpace(Tag);

        public GameObject()
        {
            SetNull();
            GenerateId();
        }

        public GameObject(GameObject other)
        {
            SetEqual(other);
            GenerateId();
        }

        public GameObject(Tile singleAnimFrame)
        {
            SetNull();
            Animation.SetFrame(0, singleAnimFrame);
            GenerateId();
        }

        public void SetNull()
        {
            Tag = "";
            Visible = true;
            Properties.RemoveAll();
            Animation.Clear(Tile.Null);
        }

        public void SetEqual(GameObject o)
        {
            if (o != null)
            {
                Tag = o.Tag;
                Visible = o.Visible;
                Properties.SetEqual(o.Properties);
                Animation.SetEqual(o.Animation);
            }
            else
            {
                SetNull();
            }
        }

        public GameObject Copy()
        {
            return new GameObject(this);
        }

        public override string ToString()
        {
            return $"ID: {Id} Frames: {Animation.Frames.Count} Properties: {Properties.Entries.Count} Visible: {Visible} Tag: {Tag}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            GameObject o = (GameObject)obj;

            return
                Tag.Equals(o.Tag) &&
                Visible.Equals(o.Visible) &&
                Properties.Equals(o.Properties) &&
                Animation.Equals(o.Animation);
        }

        public virtual bool StrictEquals(object obj)
        {
            return Equals(obj) && Id == ((GameObject)obj).Id;
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Id, Tag, Visible, Properties, Animation).GetHashCode();
        }

        private void GenerateId()
        {
            Id = RandomID.Generate(8);
        }
    }
}
