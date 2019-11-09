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

namespace TileGameMaker.MapEditorElements
{
    public class MapEditor
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
            get => GetSelectedObject();
            set => SetSelectedObject(value);
        }

        public Tile SelectedTile
        {
            get => GetSelectedTile();
            set => SetSelectedTile(value);
        }

        public MapEditor(MainWindow mainWindow)
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

        private Tile GetSelectedTile()
        {
            return new Tile(
                TilePickerControl.GetTileIndex(),
                ColorPickerControl.GetForeColorIndex(),
                ColorPickerControl.GetBackColorIndex());
        }

        private void SetSelectedTile(Tile tile)
        {
            TilePickerControl.SetTileIndex(tile.TileIx);
            ColorPickerControl.SetForeColorIndex(tile.ForeColorIx);
            ColorPickerControl.SetBackColorIndex(tile.BackColorIx);
            TilePickerControl.Refresh();
            ColorPickerControl.Refresh();
            TemplateControl.Refresh();
        }

        private GameObject GetSelectedObject()
        {
            GameObject o = new GameObject();
            o.Tag = TemplateControl.Object.Tag;
            o.Visible = TemplateControl.Object.Visible;
            o.Properties.SetEqual(TemplateControl.Properties);
            o.Animation.SetEqual(TemplateControl.CroppedAnimation);
            return o;
        }

        private void SetSelectedObject(GameObject o)
        {
            if (o == null)
                return;

            TemplateControl.Object.SetEqual(o);
            TemplateControl.UpdateAnimation(o.Animation);
            Tile firstFrame = o.Animation.FirstFrame;
            TilePickerControl.SetTileIndex(firstFrame.TileIx);
            ColorPickerControl.SetForeColorIndex(firstFrame.ForeColorIx);
            ColorPickerControl.SetBackColorIndex(firstFrame.BackColorIx);
            TemplateControl.Refresh();
        }
    }
}
