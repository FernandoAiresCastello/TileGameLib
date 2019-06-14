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

        public GameObject SelectedObject
        {
            get
            {
                GameObject o = new GameObject();
                o.Type = TemplateWindow.Object.Type;
                o.Param = TemplateWindow.Object.Param;
                o.Data = TemplateWindow.Object.Data;
                o.Animation.SetEqual(TemplateWindow.CroppedAnimation);
                return o;
            }

            set
            {
                TemplateWindow.Object.SetEqual(value);
                TemplateWindow.UpdateAnimation(value.Animation);
                TemplateWindow.Refresh();
            }
        }

        public Tile SelectedTile
        {
            get
            {
                return new Tile(
                    TilePickerWindow.GetTileIndex(),
                    ColorPickerWindow.GetForeColorIndex(),
                    ColorPickerWindow.GetBackColorIndex());
            }
        }

        public MapWindow MapWindow { get; private set; }
        public TilePickerWindow TilePickerWindow { get; private set; }
        public ColorPickerWindow ColorPickerWindow { get; private set; }
        public TemplateWindow TemplateWindow { get; private set; }
        public Palette Palette { get; private set; }
        public Tileset Tileset { get; private set; }

        private readonly int DefaultMapWidth = 31;
        private readonly int DefaultMapHeight = 21;
        private readonly Form Parent;

        public MapEditor(Form parent)
        {
            Parent = parent;
            Map = new ObjectMap(DefaultMapWidth, DefaultMapHeight);
            Palette = Map.Palette;
            Tileset = Map.Tileset;
            MapWindow = new MapWindow(this);
            TemplateWindow = new TemplateWindow(this);
            TilePickerWindow = new TilePickerWindow(this);
            ColorPickerWindow = new ColorPickerWindow(this);

            if (parent.IsMdiContainer)
            {
                TilePickerWindow.MdiParent = parent;
                ColorPickerWindow.MdiParent = parent;
                TemplateWindow.MdiParent = parent;
                MapWindow.MdiParent = parent;
            }

            Archive.CreateIfNotExists(ArchiveFile);
        }

        public void Show()
        {
            TilePickerWindow.Show();
            ColorPickerWindow.Show();
            TemplateWindow.Show();
            MapWindow.Show();
        }

        public void Refresh()
        {
            TilePickerWindow.Refresh();
            ColorPickerWindow.Refresh();
            TemplateWindow.Refresh();
            MapWindow.Refresh();
        }
    }
}
