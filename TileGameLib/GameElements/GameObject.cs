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
        public string Id { get; set; }
        public string Tag { set; get; }
        public ObjectAnim Animation { set; get; } = new ObjectAnim();
        public ObjectProperties Properties { set; get; } = new ObjectProperties();

        public bool HasTag => !string.IsNullOrWhiteSpace(Tag);

        public GameObject()
        {
            SetNull();
        }

        public GameObject(GameObject other)
        {
            SetEqual(other);
        }

        public GameObject(Tile singleAnimFrame)
        {
            SetNull();
            Animation.SetFrame(0, singleAnimFrame);
        }

        public void SetNull()
        {
            Tag = "";
            Properties.RemoveAllProperties();
            Animation.Clear(Tile.Null);
            Id = IdGenerator.Generate(8);
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
            string tag = HasTag ? $"[{Tag}]" : "";
            return $"ID: {Id} {tag}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            GameObject o = (GameObject)obj;

            return
                Properties.Equals(o.Properties) &&
                Animation.Equals(o.Animation);
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Tag, Properties, Animation).GetHashCode();
        }
    }
}
