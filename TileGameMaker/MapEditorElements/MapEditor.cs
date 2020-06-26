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
        public string WorkspacePath { get; set; }
        public string MapFile { get; set; }
        public string MapName => MapPropertyGridControl.Properties.Name;
        public GameObject BlankObject => CreateBlankObject();
        public ObjectMap Map { get; private set; }
        public Palette Palette { get; private set; }
        public Tileset Tileset { get; private set; }
        public MainWindow MainWindow { get; private set; }
        public MapEditorPanel MapEditorControl { get; private set; }
        public TilePickerPanel TilePickerControl { get; private set; }
        public ColorPickerPanel ColorPickerControl { get; private set; }
        public MapPropertyGridPanel MapPropertyGridControl { get; private set; }
        public CommandLinePanel CommandLinePanel { get; private set; }
        public WorkspacePanel WorkspacePanel { get; private set; }
        public GameObjectPanel GameObjectPanel { get; private set; }
        public UserSettings Settings { get; private set; }
        public RecentFiles RecentFiles { get; private set; }
        public int DefaultMapWidth { get; private set; } = Config.ReadInt("DefaultMapWidth");
        public int DefaultMapHeight { get; private set; } = Config.ReadInt("DefaultMapHeight");
        private GameObject ClipboardObject;
        private readonly List<Control> Children = new List<Control>();

        public MapEditor(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
            MainWindow.FormClosed += MainWindow_FormClosed;

            ApplyUserSettings();
            RecentFiles = new RecentFiles();

            Map = new ObjectMap(DefaultMapWidth, DefaultMapHeight);

            if (Palette == null)
                Palette = Map.Palette;
            else
                Map.Palette = Palette;

            if (Tileset == null)
                Tileset = Map.Tileset;
            else
                Map.Tileset = Tileset;

            GameObjectPanel = new GameObjectPanel(this);
            MapEditorControl = new MapEditorPanel(this);
            TilePickerControl = new TilePickerPanel(this, 8);
            ColorPickerControl = new ColorPickerPanel(this);
            CommandLinePanel = new CommandLinePanel(this);
            MapPropertyGridControl = new MapPropertyGridPanel(this);
            WorkspacePanel = new WorkspacePanel(this);

            UpdateMapProperties();
            WorkspacePanel.UpdateWorkspace();

            Children.Add(TilePickerControl);
            Children.Add(ColorPickerControl);
            Children.Add(MapPropertyGridControl);
            Children.Add(MapEditorControl);
            Children.Add(CommandLinePanel);
            Children.Add(WorkspacePanel);
            Children.Add(GameObjectPanel);

            ClipboardObject = CreateBlankObject();
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveUserSettings();
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
        }

        public void SetClipboardForeColor(int forecolor)
        {
            ClipboardObject.Tile.ForeColor = forecolor;
            ClipboardObject = new GameObject(new Tile(ClipboardObject.Tile));
        }

        public void SetClipboardBackColor(int backcolor)
        {
            ClipboardObject.Tile.BackColor = backcolor;
            ClipboardObject = new GameObject(new Tile(ClipboardObject.Tile));
        }

        private void SaveUserSettings()
        {
            Settings.Set("Workspace", WorkspacePath);
            RecentFiles.Save();
            Settings.Save();
        }

        private void ApplyUserSettings()
        {
            if (Settings == null)
                Settings = new UserSettings();

            if (Settings.Has("Workspace"))
            {
                string workspace = Settings.Get("Workspace");
                if (!string.IsNullOrWhiteSpace(workspace))
                    WorkspacePath = workspace;
            }

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
    }
}
