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
        public ObjectAnim Animation { set; get; } = new ObjectAnim();
        public string Script { set; get; }

        public bool HasScript => !string.IsNullOrWhiteSpace(Script);

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

        public GameObject(Tile singleAnimFrame, string script)
        {
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

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            GameObject o = (GameObject)obj;

            return
                Script.Equals(o.Script) &&
                Animation.Equals(o.Animation);
        }

        public GameObject Copy()
        {
            return new GameObject(this);
        }

        public override string ToString()
        {
            int maxLength = 100;
            string script = Script.Length <= maxLength ? Script : Script.Substring(0, maxLength) + "...";
            return $"Script: {script}";
        }
    }
}
