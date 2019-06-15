using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Core;
using TileGameLib.File;
using TileGameLib.Graphics;
using TileGameLib.Component;
using TileGameMaker.Panels;

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
                o.Type = TemplateControl.Object.Type;
                o.Param = TemplateControl.Object.Param;
                o.Data = TemplateControl.Object.Data;
                o.Animation.SetEqual(TemplateControl.CroppedAnimation);
                return o;
            }

            set
            {
                TemplateControl.Object.SetEqual(value);
                TemplateControl.UpdateAnimation(value.Animation);
                Tile firstFrame = value.Animation.GetFirstFrame();
                TilePickerControl.SetTileIndex(firstFrame.TileIx);
                ColorPickerControl.SetForeColorIndex(firstFrame.ForeColorIx);
                ColorPickerControl.SetBackColorIndex(firstFrame.BackColorIx);
                TemplateControl.Refresh();
            }
        }

        public Tile SelectedTile
        {
            get
            {
                return new Tile(
                    TilePickerControl.GetTileIndex(),
                    ColorPickerControl.GetForeColorIndex(),
                    ColorPickerControl.GetBackColorIndex());
            }
        }

        public MapEditorControl MapEditorControl { get; private set; }
        public TilePickerControl TilePickerControl { get; private set; }
        public ColorPickerControl ColorPickerControl { get; private set; }
        public TemplateControl TemplateControl { get; private set; }
        public MapPropertyControl MapPropertyControl { get; private set; }

        public Palette Palette { get; private set; }
        public Tileset Tileset { get; private set; }

        private readonly int DefaultMapWidth = 31;
        private readonly int DefaultMapHeight = 21;
        private readonly List<Control> Children = new List<Control>();

        public MapEditor(Form parent)
        {
            Map = new ObjectMap(DefaultMapWidth, DefaultMapHeight);
            Palette = Map.Palette;
            Tileset = Map.Tileset;
            Tile.Null.SetEqual(new Tile(0, 0, Palette.Size - 1));

            MapEditorControl = new MapEditorControl(this);
            TemplateControl = new TemplateControl(this);
            TilePickerControl = new TilePickerControl(this);
            ColorPickerControl = new ColorPickerControl(this);
            MapPropertyControl = new MapPropertyControl(this);
            UpdateMapProperties();

            Children.Add(TilePickerControl);
            Children.Add(TemplateControl);
            Children.Add(ColorPickerControl);
            Children.Add(MapPropertyControl);
            Children.Add(MapEditorControl);

            Archive.CreateIfNotExists(ArchiveFile);
        }

        public void Show()
        {
            foreach (Control ctl in Children)
                ctl.Show();
        }

        public void Refresh()
        {
            foreach (Control ctl in Children)
                ctl.Refresh();
        }

        public void UpdateMapProperties(string file = null)
        {
            MapPropertyControl.UpdateProperties(file);
        }

        public void Resize(int width, int height)
        {
            if (width != Map.Width || height != Map.Height)
                Map.Resize(width, height);

            MapEditorControl.ResizeMapView(width, height);
            Refresh();
        }
    }
}
