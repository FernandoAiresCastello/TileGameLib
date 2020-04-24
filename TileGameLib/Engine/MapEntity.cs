using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.GameElements;

namespace TileGameLib.Engine
{
    public class MapEntity
    {
        protected readonly MapController Controller;
        protected ObjectMap Map => Controller.Map;
        protected UserInterface Ui => Controller.Ui;

        public MapEntity(MapController controller)
        {
            Controller = controller;
        }

        public virtual void Start()
        {
        }

        public virtual void DrawUi()
        {
        }
    }
}
