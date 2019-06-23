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
        public string Data { set; get; }

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

        public GameObject(int type, int param, string data, Tile singleAnimFrame)
        {
            Data = data;
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

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            GameObject o = (GameObject)obj;

            return
                Data.Equals(o.Data) &&
                Animation.Equals(o.Animation);
        }

        public GameObject Copy()
        {
            return new GameObject(this);
        }

        public override string ToString()
        {
            int maxLength = 100;
            string data = Data.Length <= maxLength ? Data : Data.Substring(0, maxLength) + "...";
            return $"Data: {data}";
        }
    }
}
