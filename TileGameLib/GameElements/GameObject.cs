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
            Data = script;
            Animation.Clear(singleAnimFrame);
        }

        public void SetNull()
        {
            Id = "";
            Data = "";
            Animation.Clear(Tile.Null);
        }

        public void SetEqual(GameObject o)
        {
            if (o != null)
            {
                Id = o.Id;
                Data = o.Data;
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
    }
}
