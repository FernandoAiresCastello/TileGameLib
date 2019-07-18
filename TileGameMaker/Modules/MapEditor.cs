﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.GameElements;
using TileGameLib.File;
using TileGameLib.Graphics;
using TileGameLib.Components;
using TileGameMaker.Panels;
using TileGameMaker.Util;

namespace TileGameMaker.Modules
{
    public class MapEditor
    {
        public string ProjectPath => WorkspacePath + "/" + ProjectFile;

        public ObjectMap Map { get; private set; }
        public ObjectMap Clipboard { get; private set; }
        public Palette Palette { get; private set; }
        public Tileset Tileset { get; private set; }
        public GameObject NullGameObject { get; private set; }

        public MapEditorPanel MapEditorControl { get; private set; }
        public TilePickerPanel TilePickerControl { get; private set; }
        public ColorPickerPanel ColorPickerControl { get; private set; }
        public TemplatePanel TemplateControl { get; private set; }
        public MapPropertyPanel MapPropertyControl { get; private set; }

        private static readonly string DefaultProjectFile = Config.ReadString("DefaultProjectFile");
        private static readonly string DefaultWorkspacePath = Config.ReadString("DefaultWorkspacePath");
        private static readonly int DefaultMapWidth = Config.ReadInt("DefaultMapWidth");
        private static readonly int DefaultMapHeight = Config.ReadInt("DefaultMapHeight");

        private string ProjectFile { get; set; }
        private string WorkspacePath { get; set; }

        private readonly List<Control> Children = new List<Control>();

        public GameObject SelectedObject
        {
            get
            {
                GameObject o = new GameObject();
                o.Script = TemplateControl.Object.Script;
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

        public MapEditor(Form parent)
        {
            WorkspacePath = DefaultWorkspacePath;
            ProjectFile = DefaultProjectFile;

            Map = new ObjectMap(DefaultMapWidth, DefaultMapHeight);
            Clipboard = null;
            Palette = Map.Palette;
            Tileset = Map.Tileset;

            NullGameObject = new GameObject(new Tile(
                Config.ReadInt("DefaultTileIndex"),
                Config.ReadInt("DefaultTileForeColor"),
                Config.ReadInt("DefaultTileBackColor")));

            Map.Fill(NullGameObject);

            MapEditorControl = new MapEditorPanel(this);
            TemplateControl = new TemplatePanel(this);
            TilePickerControl = new TilePickerPanel(this);
            ColorPickerControl = new ColorPickerPanel(this);
            MapPropertyControl = new MapPropertyPanel(this);
            UpdateMapProperties();

            Children.Add(TilePickerControl);
            Children.Add(TemplateControl);
            Children.Add(ColorPickerControl);
            Children.Add(MapPropertyControl);
            Children.Add(MapEditorControl);

            Archive.CreateIfNotExists(ProjectPath);
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

        public void ResizeMap(int width, int height)
        {
            if (width != Map.Width || height != Map.Height)
                Map.Resize(width, height);

            MapEditorControl.ResizeMapView(width, height);
            Refresh();
        }

        public void CreateNewProject(string filename)
        {
            string fileExtension = Config.ReadString("ProjectFileExt");
            if (!filename.EndsWith(fileExtension))
                filename += "." + fileExtension;

            Archive.CreateIfNotExists(WorkspacePath + "\\" + filename);

            ProjectFile = filename;
        }
    }
}
