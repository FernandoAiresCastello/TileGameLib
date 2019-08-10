using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Graphics;

namespace TileGameLib.GameElements
{
    public class GameObject
    {
        public string Id { get; private set; }
        public ObjectAnim Animation { set; get; } = new ObjectAnim();
        public string Extra { set; get; }

        public bool HasExtra => !string.IsNullOrWhiteSpace(Extra);

        public GameObject()
        {
            GenerateId();
            SetNull();
        }

        public GameObject(GameObject other)
        {
            GenerateId();
            SetEqual(other);
        }

        public GameObject(Tile singleAnimFrame)
        {
            GenerateId();
            SetNull();
            Animation.SetFrame(0, singleAnimFrame);
        }

        public GameObject(Tile singleAnimFrame, string script)
        {
            GenerateId();
            Extra = script;
            Animation.Clear(singleAnimFrame);
        }

        public void SetNull()
        {
            Extra = "";
            Animation.Clear(Tile.Null);
        }

        public bool IsNull()
        {
            return 
                Extra == "" && 
                Animation.IsSingleFrame() &&
                Animation.GetFirstFrame().Equals(Tile.Null);
        }

        public void SetEqual(GameObject o)
        {
            Extra = o.Extra;
            Animation.SetEqual(o.Animation);
        }

        public GameObject Copy()
        {
            return new GameObject(this);
        }

        public override string ToString()
        {
            return "ID: " + Id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            GameObject o = (GameObject)obj;

            return
                Extra.Equals(o.Extra) &&
                Animation.Equals(o.Animation);
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Animation, Extra).GetHashCode();
        }

        private void GenerateId()
        {
            Id = Guid.NewGuid().ToString("N");
        }
    }
}
