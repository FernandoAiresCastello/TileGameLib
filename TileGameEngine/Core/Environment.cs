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
            Variables.Set("env.map.file", "");
            Variables.Set("env.map.view.x", 0);
            Variables.Set("env.map.view.y", 0);
            Variables.Set("env.map.view.width", 0);
            Variables.Set("env.map.view.height", 0);
            Variables.Set("env.map.offset.x", 0);
            Variables.Set("env.map.offset.y", 0);
            Variables.Set("env.window.backcolor", 0);
            Variables.Set("env.text.cursor.x", 0);
            Variables.Set("env.text.cursor.y", 0);
            Variables.Set("env.text.forecolor", 0);
            Variables.Set("env.text.backcolor", 0);
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
            return new Point(Variables.GetInt("env.text.cursor.x"), Variables.GetInt("env.text.cursor.y"));
        }

        private int GetTextForeColor()
        {
            return Variables.GetInt("env.text.forecolor");
        }

        private int GetTextBackColor()
        {
            return Variables.GetInt("env.text.backcolor");
        }

        private int GetWindowBackColor()
        {
            return Variables.GetInt("env.window.backcolor");
        }

        private Rectangle GetMapViewport()
        {
            return new Rectangle(
                Variables.GetInt("env.map.view.x"),
                Variables.GetInt("env.map.view.y"),
                Variables.GetInt("env.map.view.width"),
                Variables.GetInt("env.map.view.height"));
        }

        private Point GetMapOffset()
        {
            return new Point(Variables.GetInt("env.map.offset.x"), Variables.GetInt("env.map.offset.y"));
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
            Variables.Set("env.map.file", filename);
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

        public void ClearWindow()
        {
            AssertWindowIsOpen();
            Window.Graphics.Clear(GetWindowBackColor());
        }

        public void ClearMapViewport()
        {
            AssertWindowIsOpen();
            Rectangle view = GetMapViewport();
            Window.Graphics.ClearRect(GetWindowBackColor(), view.X, view.Y, view.Width, view.Height);
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

        public void SetMapBackColor(int color)
        {
            Map.BackColor = color;
        }

        public void SetWindowPalette(int index, int rgb)
        {
            Window.Graphics.Palette.Set(index, rgb);
        }

        public void SetWindowTileset(int index, byte[] pattern)
        {
            Window.Graphics.Tileset.Set(index,
                pattern[0], pattern[1], pattern[2], pattern[3],
                pattern[4], pattern[5], pattern[6], pattern[7]);
        }

        public void SetMapPalette(int index, int rgb)
        {
            Map.Palette.Set(index, rgb);
        }

        public void SetMapTileset(int index, byte[] pattern)
        {
            Map.Tileset.Set(index,
                pattern[0], pattern[1], pattern[2], pattern[3],
                pattern[4], pattern[5], pattern[6], pattern[7]);
        }

        public void SetMapName(string name)
        {
            Map.Name = name;
        }

        public string GetMapName()
        {
            return Map.Name;
        }

        public bool IsKeyPressed(string keyname)
        {
            return Window.IsKeyPressed(keyname);
        }
    }
}
