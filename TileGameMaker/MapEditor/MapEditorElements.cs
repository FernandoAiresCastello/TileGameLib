using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.GameElements;
using TileGameLib.Graphics;
using TileGameMaker.Panels;
using TileGameMaker.Util;
using TileGameMaker.Windows;

namespace TileGameMaker.MapEditor
{
    public class MapEditorElements
    {
        public string WorkspacePath { get; private set; }
        public string MapFile { get; set; }
        public string MapName => MapPropertyGridControl.Properties.Name;
        public string MapMusic => MapPropertyGridControl.Properties.Music;
        public GameObject BlankObject => CreateBlankObject();

        public ObjectMap Map { get; private set; }
        public Palette Palette { get; private set; }
        public Tileset Tileset { get; private set; }

        public MainWindow MainWindow { get; private set; }
        public MapEditorPanel MapEditorControl { get; private set; }
        public TilePickerPanel TilePickerControl { get; private set; }
        public ColorPickerPanel ColorPickerControl { get; private set; }
        public TemplatePanel TemplateControl { get; private set; }
        public MapPropertyPanel MapPropertyControl { get; private set; }
        public MapPropertyGridPanel MapPropertyGridControl { get; private set; }

        public static readonly string DefaultWorkspacePath = Config.ReadString("DefaultWorkspacePath");
        public static readonly int DefaultMapWidth = Config.ReadInt("DefaultMapWidth");
        public static readonly int DefaultMapHeight = Config.ReadInt("DefaultMapHeight");

        private readonly List<Control> Children = new List<Control>();

        public GameObject SelectedObject
        {
            get
            {
                GameObject o = new GameObject();
                o.Tag = TemplateControl.Object.Tag;
                o.Visible = TemplateControl.Object.Visible;
                o.Properties.SetEqual(TemplateControl.Object.Properties);
                o.Animation.SetEqual(TemplateControl.CroppedAnimation);
                return o;
            }

            set
            {
                if (value != null)
                {
                    TemplateControl.Object.SetEqual(value);
                    TemplateControl.UpdateAnimation(value.Animation);
                    Tile firstFrame = value.Animation.FirstFrame;
                    TilePickerControl.SetTileIndex(firstFrame.TileIx);
                    ColorPickerControl.SetForeColorIndex(firstFrame.ForeColorIx);
                    ColorPickerControl.SetBackColorIndex(firstFrame.BackColorIx);
                    TemplateControl.Refresh();
                }
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

            set
            {
                TilePickerControl.SetTileIndex(value.TileIx);
                ColorPickerControl.SetForeColorIndex(value.ForeColorIx);
                ColorPickerControl.SetBackColorIndex(value.BackColorIx);
                TilePickerControl.Refresh();
                ColorPickerControl.Refresh();
                TemplateControl.Refresh();
            }
        }

        public MapEditorElements(MainWindow mainWindow)
        {
            MainWindow = mainWindow;

            WorkspacePath = DefaultWorkspacePath;
            if (!Directory.Exists(WorkspacePath))
                Directory.CreateDirectory(WorkspacePath);

            Map = new ObjectMap(DefaultMapWidth, DefaultMapHeight);

            Palette = Map.Palette;
            Tileset = Map.Tileset;

            MapEditorControl = new MapEditorPanel(this);
            TemplateControl = new TemplatePanel(this);
            TilePickerControl = new TilePickerPanel(this);
            ColorPickerControl = new ColorPickerPanel(this);
            MapPropertyGridControl = new MapPropertyGridPanel(this);
            UpdateMapProperties();

            Children.Add(TilePickerControl);
            Children.Add(TemplateControl);
            Children.Add(ColorPickerControl);
            Children.Add(MapPropertyGridControl);
            Children.Add(MapEditorControl);
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

        public void UpdateMapProperties()
        {
            MapPropertyGridControl.UpdateProperties();
        }

        public void ResizeMap(int width, int height)
        {
            if (width != Map.Width || height != Map.Height)
                Map.Resize(width, height);

            MapEditorControl.ResizeMapView(width, height);
            Refresh();
        }

        private GameObject CreateBlankObject()
        {
            return new GameObject(new Tile(0, Palette.Black, Palette.White));
        }
    }
}
