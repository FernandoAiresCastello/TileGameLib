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
        public string Script { set; get; }

        public bool HasScript => !string.IsNullOrWhiteSpace(Script);

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
            Script = script;
            Animation.Clear(singleAnimFrame);
        }

        public void SetNull()
        {
            Script = "";
            Animation.Clear(Tile.Null);
        }

        public bool IsNull()
        {
            return 
                Script == "" && 
                Animation.IsSingleFrame() &&
                Animation.GetFirstFrame().Equals(Tile.Null);
        }

        public void SetEqual(GameObject o)
        {
            Script = o.Script;
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
                Script.Equals(o.Script) &&
                Animation.Equals(o.Animation);
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Animation, Script).GetHashCode();
        }

        private void GenerateId()
        {
            Id = Guid.NewGuid().ToString("N");
        }
    }
}
