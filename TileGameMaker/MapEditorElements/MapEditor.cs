using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.File;
using TileGameLib.GameElements;
using TileGameLib.Graphics;
using TileGameLib.Util;
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
        public MapPropertyGridPanel MapPropertyGridControl { get; private set; }
        public CommandLinePanel CommandLinePanel { get; private set; }

        public UserSettings Settings { get; private set; }

        public int DefaultMapWidth { get; private set; } = Config.ReadInt("DefaultMapWidth");
        public int DefaultMapHeight { get; private set; } = Config.ReadInt("DefaultMapHeight");

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
            ApplyUserSettings();

            Map = new ObjectMap(DefaultMapWidth, DefaultMapHeight);

            if (Palette == null)
                Palette = Map.Palette;
            else
                Map.Palette = Palette;

            if (Tileset == null)
                Tileset = Map.Tileset;
            else
                Map.Tileset = Tileset;

            MapEditorControl = new MapEditorPanel(this);
            TemplateControl = new TemplatePanel(this);
            TilePickerControl = new TilePickerPanel(this, 8);
            ColorPickerControl = new ColorPickerPanel(this);
            CommandLinePanel = new CommandLinePanel(this);
            MapPropertyGridControl = new MapPropertyGridPanel(this);
            UpdateMapProperties();

            Children.Add(TilePickerControl);
            Children.Add(TemplateControl);
            Children.Add(ColorPickerControl);
            Children.Add(MapPropertyGridControl);
            Children.Add(MapEditorControl);
            Children.Add(CommandLinePanel);
        }

        private void ApplyUserSettings()
        {
            if (Settings == null)
                Settings = new UserSettings();

            if (Settings.Has("TilesetFile"))
            {
                string tilesetFile = Settings.Get("TilesetFile");

                try
                {
                    Tileset = TilesetFile.LoadFromRawBytes(tilesetFile);
                }
                catch
                {
                    Alert.Error("Tileset file not found: " + tilesetFile);
                }
            }

            if (Settings.Has("PaletteFile"))
            {
                string paletteFile = Settings.Get("PaletteFile");

                try
                {
                    Palette = PaletteFile.LoadFromRawBytes(paletteFile);
                }
                catch
                {
                    Alert.Error("Palette file not found: " + paletteFile);
                }
            }

            if (Settings.Has("DefaultMapWidth"))
                DefaultMapWidth = Settings.GetInteger("DefaultMapWidth");
            if (Settings.Has("DefaultMapHeight"))
                DefaultMapHeight = Settings.GetInteger("DefaultMapHeight");
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

        public void ShowCommandLine(bool show)
        {
            MainWindow.ShowCommandLine(show);
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
            TilePickerControl.SetTileIndex(tile.Index);
            ColorPickerControl.SetForeColorIndex(tile.ForeColor);
            ColorPickerControl.SetBackColorIndex(tile.BackColor);
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
            TilePickerControl.SetTileIndex(firstFrame.Index);
            ColorPickerControl.SetForeColorIndex(firstFrame.ForeColor);
            ColorPickerControl.SetBackColorIndex(firstFrame.BackColor);
            TemplateControl.Refresh();
        }
    }
}
