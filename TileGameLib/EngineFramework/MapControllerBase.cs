using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.File;
using TileGameLib.GameElements;
using TileGameLib.Graphics;

namespace TileGameLib.EngineFramework
{
    public class MapController
    {
        public GameEngineBase Engine { set; get; }
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
    }
}
