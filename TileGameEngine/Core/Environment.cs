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
using TileGameEngine.Windows;
using TileGameEngine.Exceptions;
using System.Windows.Forms;
using TileGameEngine.Util;

namespace TileGameEngine.Core
{
    public partial class Environment
    {
        public Variables Variables { get; private set; } = new Variables();
        public bool ExitIfGameWindowClosed { get; set; } = false;
        public bool HasWindow => Window != null;

        private GameWindow Window;
        private ObjectMap Map;
        private MapRenderer MapRenderer;

        public static readonly string LogFile = Config.ReadString("LogFile");

        public Environment()
        {
            DeleteLogFile();
            SetupEnvironmentVariables();
        }

        private void SetupEnvironmentVariables()
        {
            Variables.Set("env.current_map_file", "");
            Variables.Set("env.map_viewport_x", 0);
            Variables.Set("env.map_viewport_y", 0);
            Variables.Set("env.map_viewport_width", 0);
            Variables.Set("env.map_viewport_height", 0);
            Variables.Set("env.map_offset_x", 0);
            Variables.Set("env.map_offset_y", 0);
            Variables.Set("env.text_cursor_x", 0);
            Variables.Set("env.text_cursor_y", 0);
            Variables.Set("env.text_forecolor", 0);
            Variables.Set("env.text_backcolor", 0);
        }

        public void ExitApplication()
        {
            if (HasWindow)
                CloseWindow();

            Application.Exit();
        }

        public void Reset()
        {
            DeleteLogFile();
            Variables.Clear();
            SetupEnvironmentVariables();

            if (HasWindow)
                CloseWindow();

            Map = null;
            MapRenderer = null;
        }

        public void DeleteLogFile()
        {
            if (File.Exists(LogFile))
                File.Delete(LogFile);
        }

        public void WriteLog(string message)
        {
            using (var stream = File.AppendText(LogFile))
                stream.WriteLine(message);
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

        public void SetVariable(string variable, object value)
        {
            Variables.Set(variable.Substring(1), value);
        }

        public string GetVariable(string variable)
        {
            string name = variable.Substring(1);
            if (!Variables.Contains(name))
                throw new EnvironmentException("Variable not found: " + name);

            return Variables.GetStr(name);
        }

        public void CreateWindow(int cols, int rows)
        {
            AssertWindowIsNotOpen();
            Window = new GameWindow(cols, rows);
            Window.FormClosed += Window_FormClosed;
            Window.Show();
        }

        private void Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ExitIfGameWindowClosed)
                Application.Exit();

            Window = null;
        }

        public void CloseWindow()
        {
            AssertWindowIsOpen();

            if (MapRenderer != null)
            {
                MapRenderer.Stop();
                MapRenderer.AutoRefresh = false;
            }

            Window.Close();
            Window = null;
        }

        public void LoadMapFromCurrentFolder(string filename)
        {
            MapFile.Load(ref Map, filename);
            Variables.Set("env.current_map_file", filename);
            UpdateMapRenderer();
        }

        public void UpdateMapRenderer()
        {
            AssertWindowIsOpen();
            MapRenderer = new MapRenderer(Map, Window.Display, GetMapViewport(), GetMapOffset());
        }

        public void StartMapRenderer()
        {
            AssertWindowIsOpen();
            if (MapRenderer != null)
                MapRenderer.AutoRefresh = true;
        }

        public void StopMapRenderer()
        {
            AssertWindowIsOpen();

            if (MapRenderer != null)
            {
                MapRenderer.AutoRefresh = false;
                RefreshWindow();
            }
        }

        public void Print(string text)
        {
            AssertWindowIsOpen();
            AssertTextColorIsWithinPalette();
            AssertTextCursorIsWithinBounds();

            Point textCursor = GetTextCursor();

            Window.Graphics.PutString(textCursor.X, textCursor.Y, text, GetTextForeColor(), GetTextBackColor());
        }

        public void RefreshWindow()
        {
            AssertWindowIsOpen();
            Window.Refresh();
        }

        public GameObject GetObjectAt(int layer, int x, int y)
        {
            return Map.GetObject(layer, x, y);
        }
    }
}
