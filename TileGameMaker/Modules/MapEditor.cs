using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Core;
using TileGameLib.File;
using TileGameLib.Graphics;
using TileGameMaker.Component;

namespace TileGameMaker.Modules
{
    public class MapEditor
    {
        public static readonly string ArchiveFile = "maps.zip";

        public ObjectMap Map { get; private set; }
        public MapWindow MapWindow { get; private set; }
        public TilePickerWindow TilePickerWindow { get; private set; }
        public ColorPickerWindow ColorPickerWindow { get; private set; }
        public TemplateWindow TemplateWindow { get; private set; }

        private readonly Form Parent;
        private readonly int DefaultMapWidth = 31;
        private readonly int DefaultMapHeight = 21;

        public MapEditor(Form parent)
        {
            Parent = parent;
            Map = new ObjectMap(DefaultMapWidth, DefaultMapHeight);
            MapWindow = new MapWindow(this, Map);
            TemplateWindow = new TemplateWindow(this);
            TilePickerWindow = new TilePickerWindow(this, Map.Tileset);
            ColorPickerWindow = new ColorPickerWindow(this, Map.Palette);

            if (parent.IsMdiContainer)
            {
                TilePickerWindow.MdiParent = parent;
                ColorPickerWindow.MdiParent = parent;
                TemplateWindow.MdiParent = parent;
                MapWindow.MdiParent = parent;
            }

            Zip.CreateIfNotExists(ArchiveFile);
        }

        public void Show()
        {
            TilePickerWindow.Show();
            ColorPickerWindow.Show();
            TemplateWindow.Show();
            MapWindow.Show();
        }

        public Tile GetSelectedTile()
        {
            return new Tile(
                TilePickerWindow.GetTileIndex(),
                ColorPickerWindow.GetForeColorIndex(), 
                ColorPickerWindow.GetBackColorIndex());
        }

        public GameObject GetSelectedObject()
        {
            GameObject o = new GameObject();
            o.Type = TemplateWindow.Object.Type;
            o.Param = TemplateWindow.Object.Param;
            o.Data = TemplateWindow.Object.Data;
            o.Animation.SetEqual(TemplateWindow.CroppedAnimation);
            return o;
        }

        public void CreateNewMap(int width, int height)
        {
            Map = new ObjectMap(width, height);
            MapWindow.SetMap(Map);
        }
    }
}
