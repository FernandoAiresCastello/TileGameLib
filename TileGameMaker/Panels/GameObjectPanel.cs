using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameMaker.MapEditorElements;
using TileGameLib.GameElements;

namespace TileGameMaker.Panels
{
    public partial class GameObjectPanel : UserControl
    {
        public MapEditor MapEditor { get; set; }

        public GameObjectPanel() : this(null)
        {
        }

        public GameObjectPanel(MapEditor editor)
        {
            MapEditor = editor;
            InitializeComponent();
        }

        public void Clear()
        {
            TxtObject.Clear();
        }

        private void Print(string line = null)
        {
            if (line != null)
                TxtObject.AppendText(line + Environment.NewLine);
            else
                TxtObject.AppendText(Environment.NewLine);
        }

        public void Update(PositionedCell pc)
        {
            Clear();
            GameObject o = pc.Cell.Object;
            ObjectPosition pos = pc.Position;

            Print($"[Cell]");
            Print($"    Layer: {pos.Layer}, X: {pos.X}, Y: {pos.Y}");

            if (o != null)
            {
                Print();
                Print($"[Object]");
                Print($"    ID: {o.Id}");
                Print($"    Visible: {o.Visible}");
                Print($"    Frames: {o.Animation.Size}");
                Print($"    Properties: ");

                if (o.Properties.Size > 0)
                {
                    foreach (KeyValuePair<string, string> prop in o.Properties.Entries)
                        Print($"        {prop.Key} = {prop.Value}");
                }
                else
                {
                    Print($"        <empty>");
                }
            }

            GameObject clipboardObject = MapEditor.GetClipboardObject();

            if (clipboardObject != null)
            {
                Print();
                Print($"[ClipboardObject]");
                Print($"    Visible: {clipboardObject.Visible}");
                Print($"    Frames: {clipboardObject.Animation.Size}");
                Print($"    Properties: ");

                if (clipboardObject.Properties.Size > 0)
                {
                    foreach (KeyValuePair<string, string> prop in clipboardObject.Properties.Entries)
                        Print($"        {prop.Key} = {prop.Value}");
                }
                else
                {
                    Print($"        <empty>");
                }
            }

            Update();
        }
    }
}
