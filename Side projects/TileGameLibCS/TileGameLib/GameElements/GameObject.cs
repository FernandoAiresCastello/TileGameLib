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
        public bool Visible { set; get; }
        public ObjectAnimation Animation { set; get; } = new ObjectAnimation();
        public PropertyList Properties { set; get; } = new PropertyList();
        public Tile Tile => Animation.FirstFrame;

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
            Visible = true;
            Properties.RemoveAll();
            Animation.Clear();
            Animation.AddBlankFrame();
        }

        public void SetEqual(GameObject o)
        {
            if (o != null)
            {
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
            return $"Properties: {Properties.Entries.Count} Frames: {Animation.Frames.Count} Visible: {Visible}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            GameObject o = (GameObject)obj;

            return
                Visible.Equals(o.Visible) &&
                Properties.Equals(o.Properties) &&
                Animation.Equals(o.Animation);
        }

        public bool PropertiesEqual(object obj)
        {
            return Properties.Equals((obj as GameObject).Properties);
        }

        public bool HasProperties(params string[] properties)
        {
            return Properties.HasAll(properties);
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Visible, Properties, Animation).GetHashCode();
        }
    }
}
