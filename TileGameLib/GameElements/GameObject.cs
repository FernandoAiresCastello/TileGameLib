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
        public string Id { get; set; }
        public string Data { set; get; }
        public ObjectAnim Animation { set; get; } = new ObjectAnim();

        public bool HasData => !string.IsNullOrWhiteSpace(Data);

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
            Data = script;
            Animation.Clear(singleAnimFrame);
        }

        public void SetNull()
        {
            Data = "";
            Animation.Clear(Tile.Null);
        }

        public bool IsNull()
        {
            return 
                Data == "" && 
                Animation.IsSingleFrame() &&
                Animation.GetFirstFrame().Equals(Tile.Null);
        }

        public void SetEqual(GameObject o)
        {
            Data = o.Data;
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
                Data.Equals(o.Data) &&
                Animation.Equals(o.Animation);
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Animation, Data).GetHashCode();
        }

        private void GenerateId()
        {
            Id = Guid.NewGuid().ToString("N");
        }
    }
}
