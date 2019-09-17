using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.File;
using TileGameLib.GameElements;
using TileGameLib.Graphics;

namespace TileGameLib.Engine
{
    public class MapController
    {
        public GameEngine Engine { set; get; }
        public GameWindow Window { set; get; }
        public ObjectMap Map { set; get; }

        public MapController(string mapfile)
        {
            Map = MapFile.Load(mapfile);
        }

        public virtual void OnExecuteCycle()
        {
        }

        public virtual void OnKeyDown(KeyEventArgs e)
        {
        }

        public virtual void OnKeyUp(KeyEventArgs e)
        {
        }

        public void Exit(MapController mapController)
        {
            Engine.SetMapController(mapController);
        }

        public void MoveObjectWithTag(string tag, int dx, int dy)
        {
            ObjectPosition pos = Map.FindObjectPositionByTag(tag);
            if (pos != null)
                Map.MoveObject(pos, dx, dy);
        }

        public GameObject GetObjectAtDistance(string tag, int distLayer, int distX, int distY)
        {
            ObjectPosition pos = Map.FindObjectPositionByTag(tag);

            if (pos != null)
            {
                pos.Layer += distLayer;
                pos.X += distX;
                pos.Y += distY;

                return Map.GetObjectRef(pos);
            }

            return null;
        }
    }
}
