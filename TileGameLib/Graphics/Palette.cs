using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.Graphics
{
    public class Palette
    {
        public List<int> Colors { get; private set; } = new List<int>();

        public int this[int index]
        {
            get { return Colors[index]; }
            set { Colors[index] = value; }
        }

        public int Size { get { return Colors.Count; } }

        public Palette()
        {
            InitDefault();
        }

        public void Add(uint color)
        {
            Colors.Add((int)color);
        }

        public void Add(int color)
        {
            Colors.Add(color);
        }

        public void Add(Color color)
        {
            Colors.Add(color.ToArgb());
        }

        public void Clear(int count, int color)
        {
            Colors.Clear();
            for (int i = 0; i < count; i++)
                Add(color);
        }

        public void Clear(int count, Color color)
        {
            Clear(count, color.ToArgb());
        }

        public void InitDefault()
        {
            Colors.Clear();

            Add(0xFF000000);
            Add(0xFF000055);
            Add(0xFF0000aa);
            Add(0xFF0000ff);
            Add(0xFF550000);
            Add(0xFF550055);
            Add(0xFF5500aa);
            Add(0xFF5500ff);
            Add(0xFFaa0000);
            Add(0xFFaa0055);
            Add(0xFFaa00aa);
            Add(0xFFaa00ff);
            Add(0xFFff0000);
            Add(0xFFff0055);
            Add(0xFFff00aa);
            Add(0xFFff00ff);
            Add(0xFF005500);
            Add(0xFF005555);
            Add(0xFF0055aa);
            Add(0xFF0055ff);
            Add(0xFF555500);
            Add(0xFF555555);
            Add(0xFF5555aa);
            Add(0xFF5555ff);
            Add(0xFFaa5500);
            Add(0xFFaa5555);
            Add(0xFFaa55aa);
            Add(0xFFaa55ff);
            Add(0xFFff5500);
            Add(0xFFff5555);
            Add(0xFFff55aa);
            Add(0xFFff55ff);
            Add(0xFF00aa00);
            Add(0xFF00aa55);
            Add(0xFF00aaaa);
            Add(0xFF00aaff);
            Add(0xFF55aa00);
            Add(0xFF55aa55);
            Add(0xFF55aaaa);
            Add(0xFF55aaff);
            Add(0xFFaaaa00);
            Add(0xFFaaaa55);
            Add(0xFFaaaaaa);
            Add(0xFFaaaaff);
            Add(0xFFffaa00);
            Add(0xFFffaa55);
            Add(0xFFffaaaa);
            Add(0xFFffaaff);
            Add(0xFF00ff00);
            Add(0xFF00ff55);
            Add(0xFF00ffaa);
            Add(0xFF00ffff);
            Add(0xFF55ff00);
            Add(0xFF55ff55);
            Add(0xFF55ffaa);
            Add(0xFF55ffff);
            Add(0xFFaaff00);
            Add(0xFFaaff55);
            Add(0xFFaaffaa);
            Add(0xFFaaffff);
            Add(0xFFffff00);
            Add(0xFFffff55);
            Add(0xFFffffaa);
            Add(0xFFffffff);
        }
    }
}
