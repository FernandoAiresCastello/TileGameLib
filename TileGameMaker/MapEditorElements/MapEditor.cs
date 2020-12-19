using System;
using System.Collections.Generic;
using System.Drawing;
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
        public string MapName => MapPropertyGridControl.Properties.Name;
        public GameObject BlankObject => CreateBlankObject();
        public ObjectMap Map { get; private set; }
        public Project Project { get; set; }

        public Palette Palette
        {
            get => Project.Palette;
            set => Project.Palette = value;
        }

        public Tileset Tileset
        {
            get => Project.Tileset;
            set => Project.Tileset = value;
        }

        public StartWindow StartWindow { get; private set; }
        public MainWindow MainWindow { get; private set; }
        public MapEditorPanel MapEditorControl { get; private set; }
        public TilePickerPanel TilePickerControl { get; private set; }
        public ColorPickerPanel ColorPickerControl { get; private set; }
        public MapPropertyGridPanel MapPropertyGridControl { get; private set; }
        public CommandLinePanel CommandLinePanel { get; private set; }
        public ProjectPanel ProjectPanel { get; private set; }
        public GameObjectPanel GameObjectPanel { get; private set; }
        public RecentProjects RecentFiles { get; private set; }

        private GameObject ClipboardObject;
        private readonly List<Control> Children = new List<Control>();

        public MapEditor(StartWindow startWindow, Project project)
        {
            StartWindow = startWindow;
            Project = project;
            Map = Project.Maps[0];

            GameObjectPanel = new GameObjectPanel(this);
            MapEditorControl = new MapEditorPanel(this);
            TilePickerControl = new TilePickerPanel(this, 8);
            ColorPickerControl = new ColorPickerPanel(this);
            CommandLinePanel = new CommandLinePanel(this);
            MapPropertyGridControl = new MapPropertyGridPanel(this);
            ProjectPanel = new ProjectPanel(this);

            UpdateMapProperties();

            Children.Add(TilePickerControl);
            Children.Add(ColorPickerControl);
            Children.Add(MapPropertyGridControl);
            Children.Add(MapEditorControl);
            Children.Add(CommandLinePanel);
            Children.Add(ProjectPanel);
            Children.Add(GameObjectPanel);

            ClipboardObject = CreateBlankObject();

            MainWindow = new MainWindow(this);
        }

        public void SetMap(ObjectMap map)
        {
            Map = map;
            MapEditorControl.SetMap(map);
        }

        public void ClearClipboard()
        {
            ClipboardObject = BlankObject;
        }

        public void SetNewClipboardObject(Tile firstFrame)
        {
            ClipboardObject = new GameObject(firstFrame);
        }

        public void CopyObjectToClipboard(GameObject o)
        {
            ClipboardObject = new GameObject(o);
            UpdatePickerPanelsWithClipboardTile();
        }

        public GameObject GetClipboardObject()
        {
            return new GameObject(ClipboardObject);
        }

        private void UpdatePickerPanelsWithClipboardTile()
        {
            Tile tile = ClipboardObject.Tile;
            TilePickerControl.SetTileIndex(tile.Index);
            ColorPickerControl.SetForeColorIndex(tile.ForeColor);
            ColorPickerControl.SetBackColorIndex(tile.BackColor);
            TilePickerControl.Refresh();
            ColorPickerControl.Refresh();
        }

        public GameObject CopyObjectFromClipboard()
        {
            return new GameObject(ClipboardObject);
        }

        public void SetClipboardTileIndex(int tileIx)
        {
            ClipboardObject.Tile.Index = tileIx;
            ClipboardObject = new GameObject(new Tile(ClipboardObject.Tile));
            GameObjectPanel.UpdateClipboardView();
        }

        public void SetClipboardForeColor(int forecolor)
        {
            ClipboardObject.Tile.ForeColor = forecolor;
            ClipboardObject = new GameObject(new Tile(ClipboardObject.Tile));
            GameObjectPanel.UpdateClipboardView();
        }

        public void SetClipboardBackColor(int backcolor)
        {
            ClipboardObject.Tile.BackColor = backcolor;
            ClipboardObject = new GameObject(new Tile(ClipboardObject.Tile));
            GameObjectPanel.UpdateClipboardView();
        }

        public void Show()
        {
            MainWindow.Show();
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
    }
}
