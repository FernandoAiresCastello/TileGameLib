using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.File;
using TileGameLib.GameElements;
using TileGameLib.Graphics;
using TileGameRunner.Windows;

namespace TileGameRunner.Core
{
    public class Environment
    {
        private readonly Variables Variables = new Variables();

        private ProjectArchive ProjectArchive;
        private GameWindow Window;
        private ObjectMap Map;
        private MapRenderer MapRenderer;

        public Environment(ProjectArchive archive)
        {
            SetProjectArchive(archive);
            SetupEnvironmentVariables();
        }

        private void SetupEnvironmentVariables()
        {
            Variables.Set("env.current_map_file", "");
            Variables.Set("env.map_viewport_x", 0);
            Variables.Set("env.map_viewport_y", 0);
            Variables.Set("env.map_viewport_width", Window.Graphics.Cols);
            Variables.Set("env.map_viewport_height", Window.Graphics.Rows);
            Variables.Set("env.map_offset_x", 0);
            Variables.Set("env.map_offset_y", 0);
            Variables.Set("env.text_cursor_x", 0);
            Variables.Set("env.text_cursor_y", 0);
            Variables.Set("env.text_forecolor", Window.Graphics.Palette.Size - 1);
            Variables.Set("env.text_backcolor", 0);
        }

        public void Reset()
        {
            Variables.Clear();
            SetupEnvironmentVariables();
            CloseWindow();
            Map = null;
            MapRenderer = null;
        }

        public void SetVariable(string variable, object value)
        {
            Variables.Set(variable.Substring(1), value);
        }

        public string GetVariable(string variable)
        {
            return Variables.GetStr(variable.Substring(1));
        }

        public void SetProjectArchive(ProjectArchive archive)
        {
            ProjectArchive = archive;
            Variables.Set("env.project_file", ProjectArchive != null ? ProjectArchive.Path : "");
        }

        public bool HasProjectArchive()
        {
            return ProjectArchive != null;
        }

        public void SetProjectArchive(string path)
        {
            SetProjectArchive(new ProjectArchive(path));
        }

        public void CreateWindow(int cols, int rows)
        {
            Window = new GameWindow(cols, rows);
            Window.Show();
        }

        public void CloseWindow()
        {
            if (Window != null)
            {
                if (MapRenderer != null)
                {
                    MapRenderer.Stop();
                    MapRenderer.AutoRefresh = false;
                }

                Window.Close();
                Window = null;
            }
        }

        public bool HasWindow()
        {
            return Window != null;
        }

        public void LoadMapFromProjectArchive(string filename)
        {
            ProjectArchive.LoadMap(ref Map, filename);
            Variables.Set("env.current_map_file", filename);
            UpdateMapRenderer();
        }

        public void LoadMapFromCurrentFolder(string filename)
        {
            MapFile.Load(ref Map, filename);
            Variables.Set("env.current_map_file", filename);
            UpdateMapRenderer();
        }

        private void UpdateMapRenderer()
        {
            if (Window != null)
                MapRenderer = new MapRenderer(Map, Window.Display, GetMapViewport(), GetMapOffset());
        }

        private Rectangle GetMapViewport()
        {
            return new Rectangle(
                Variables.GetInt("env.map_viewport_x"), 
                Variables.GetInt("env.map_viewport_y"),
                Variables.GetInt("env.map_viewport_width"),
                Variables.GetInt("env.map_viewport_height"));
        }

        private Point GetMapOffset()
        {
            return new Point(Variables.GetInt("env.map_offset_x"), Variables.GetInt("env.map_offset_y"));
        }

        public void StartMapRenderer()
        {
            if (MapRenderer != null)
                MapRenderer.AutoRefresh = true;
        }

        public void StopMapRenderer()
        {
            if (MapRenderer != null)
            {
                MapRenderer.AutoRefresh = false;
                Refresh();
            }
        }

        public void Print(string text)
        {
            Point textCursor = GetTextCursor();
            Window.Graphics.PutString(textCursor.X, textCursor.Y, text, GetTextForeColor(), GetTextBackColor());
        }

        private Point GetTextCursor()
        {
            return new Point(Variables.GetInt("env.text_cursor_x"), Variables.GetInt("env.text_cursor_y"));
        }

        private int GetTextForeColor()
        {
            return Variables.GetInt("env.text_forecolor");
        }

        private int GetTextBackColor()
        {
            return Variables.GetInt("env.text_backcolor");
        }

        public void Refresh()
        {
            Window.Graphics.Refresh();
        }
    }
}
