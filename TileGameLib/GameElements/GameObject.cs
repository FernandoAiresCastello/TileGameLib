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
        public string Id { get; private set; }
        public string Tag { set; get; }
        public ObjectAnim Animation { set; get; } = new ObjectAnim();
        public ObjectProperties Properties { set; get; } = new ObjectProperties();

        public bool HasTag => !string.IsNullOrWhiteSpace(Tag);
        public bool HasProperty(string prop) => Properties.HasProperty(prop);
        public bool HasPropertyValue(string prop, object value) => Properties.HasPropertyValue(prop, value);
        public void SetProperty(string prop, object value) => Properties.SetProperty(prop, value);
        public string GetProperty(string prop) => Properties.GetProperty(prop);
        public void RemoveProperty(string prop) => Properties.RemoveProperty(prop);

        public GameObject()
        {
            SetNull();
            PostConstruct();
        }

        public GameObject(GameObject other)
        {
            SetEqual(other);
            PostConstruct();
        }

        public GameObject(Tile singleAnimFrame)
        {
            SetNull();
            Animation.SetFrame(0, singleAnimFrame);
            PostConstruct();
        }

        private void PostConstruct()
        {
            Id = RandomID.Generate(8);
        }

        public void SetNull()
        {
            Tag = "";
            Properties.RemoveAllProperties();
            Animation.Clear(Tile.Null);
        }

        public void SetEqual(GameObject o)
        {
            if (o != null)
            {
                Tag = o.Tag;
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
            return $"ID: {Id} Frames: {Animation.Frames.Count} Properties: {Properties.Entries.Count} Tag: {Tag}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            GameObject o = (GameObject)obj;

            return
                Tag.Equals(o.Tag) &&
                Properties.Equals(o.Properties) &&
                Animation.Equals(o.Animation);
        }

        public bool StrictEquals(object obj)
        {
            return Equals(obj) && Id == ((GameObject)obj).Id;
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Id, Tag, Properties, Animation).GetHashCode();
        }
    }
}
