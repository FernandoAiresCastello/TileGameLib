using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Graphics;

namespace TileGameLib.Core
{
    public class GameObject
    {
        public int Type { set; get; }
        public int Param { set; get; }
        public string Data { set; get; }
        public ObjectAnim Animation { set; get; } = new ObjectAnim();

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
            Type = 0;
            Param = 0;
            Data = "";
            Animation.Clear();
        }

        public bool IsNull()
        {
            return 
                Type == 0 && 
                Param == 0 && 
                Data == "" && 
                Animation.IsSingleFrame();
        }

        public void SetEqual(GameObject o)
        {
            Type = o.Type;
            Param = o.Param;
            Data = o.Data;
            Animation.SetEqual(o.Animation);
        }

        public override bool Equals(object other)
        {
            if (other == null || GetType() != other.GetType())
                return false;

            GameObject o = (GameObject)other;

            return
                Type == o.Type &&
                Param == o.Param &&
                Data.Equals(o.Data) &&
                Animation.Equals(o.Animation);
        }

        public GameObject Copy()
        {
            return new GameObject(this);
        }

        public override string ToString()
        {
            Tile tile = Animation.Frames[0];
            return string.Format("T: {0} P: {1} A: {2} - IX: {3} FG: {4} BG: {5} - DL: {6}",
                Type, Param, Animation.Frames.Count, tile.TileIx, tile.ForeColorIx, tile.BackColorIx, Data.Length);
        }
    }
}
