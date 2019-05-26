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

        public void Add(int color)
        {
            Colors.Add(color);
        }

        public void Add(Color color)
        {
            Colors.Add(color.ToArgb());
        }

        public void InitDefault()
        {
            Colors.Clear();

            Add(0x000000);
            Add(0xffffff);
            Add(0xff0000);
            Add(0x00ff00);
            Add(0x0000ff);
            Add(0xffff00);
            Add(0xff00ff);
            Add(0x00ffff);
            Add(0xff8000);
            Add(0x808080);
            Add(0x800000);
            Add(0x008000);
            Add(0x000080);
            Add(0x808000);
            Add(0x800080);
            Add(0x008080);
            Add(0x803000);
            Add(0x303030);
            Add(0xff3080);
            Add(0x3080ff);
            Add(0x40ffa0);
            Add(0xff8080);
            Add(0xffffa0);
            Add(0xb0e0ff);
            Add(0xe0e0e0);
        }
    }
}
