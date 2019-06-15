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
                Tile firstFrame = value.Animation.GetFirstFrame();
                TilePickerWindow.SetTileIndex(firstFrame.TileIx);
                ColorPickerWindow.SetForeColorIndex(firstFrame.ForeColorIx);
                ColorPickerWindow.SetBackColorIndex(firstFrame.BackColorIx);
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
        public MapPropertyWindow MapPropertyWindow { get; private set; }

        public Palette Palette { get; private set; }
        public Tileset Tileset { get; private set; }

        private readonly int DefaultMapWidth = 31;
        private readonly int DefaultMapHeight = 21;
        private readonly List<Form> Children = new List<Form>();

        public MapEditor(Form parent)
        {
            Map = new ObjectMap(DefaultMapWidth, DefaultMapHeight);
            Palette = Map.Palette;
            Tileset = Map.Tileset;
            Tile.Null.SetEqual(new Tile(0, 0, Palette.Size - 1));

            MapWindow = new MapWindow(this);
            TemplateWindow = new TemplateWindow(this);
            TilePickerWindow = new TilePickerWindow(this);
            ColorPickerWindow = new ColorPickerWindow(this);
            MapPropertyWindow = new MapPropertyWindow(this);
            UpdateMapProperties();

            Children.Add(TilePickerWindow);
            Children.Add(TemplateWindow);
            Children.Add(ColorPickerWindow);
            Children.Add(MapPropertyWindow);
            Children.Add(MapWindow);

            if (parent.IsMdiContainer)
            {
                foreach (Form form in Children)
                    form.MdiParent = parent;
            }

            Archive.CreateIfNotExists(ArchiveFile);
        }

        public void Show()
        {
            foreach (Form form in Children)
                form.Show();
        }

        public void Refresh()
        {
            foreach (Form form in Children)
                form.Refresh();
        }

        public void UpdateMapProperties(string file = null)
        {
            MapPropertyWindow.UpdateProperties(file);
        }

        public void Resize(int width, int height)
        {
            if (width != Map.Width || height != Map.Height)
                Map.Resize(width, height);

            MapWindow.ResizeMapView(width, height);
            Refresh();
        }
    }
}
