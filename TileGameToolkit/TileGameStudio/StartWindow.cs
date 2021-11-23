using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Components;
using TileGameLib.Graphics;

namespace TileGameStudio
{
    public partial class StartWindow : Form
    {
        private MCTiledDisplay Display;

        public StartWindow()
        {
            InitializeComponent();

            Display = new MCTiledDisplay(MainPanel, 32, 24, 3);
            Display.BorderStyle = BorderStyle.Fixed3D;
            Display.ShowGrid = false;
            Display.Graphics.BackColor = 3;

            MCTile tile = new MCTile();
            tile.SetPattern
            (
                " 2, 2, 2, 2, 2, 2, 2, 2," +
                " 2, 1, 1, 1, 1, 1, 1, 2," +
                " 2, 1,-1,-1,-1,-1, 1, 2," +
                " 2, 1,-1,-1,-1,-1, 1, 2," +
                " 2, 1,-1,-1,-1,-1, 1, 2," +
                " 2, 1,-1,-1,-1,-1, 1, 2," +
                " 2, 1, 1, 1, 1, 1, 1, 2," +
                " 2, 2, 2, 2, 2, 2, 2, 2,"
            );

            Display.Graphics.Tileset.Add(tile);

            Display.Graphics.PutTile(0, 0, 1);
            Display.Graphics.PutTile(1, 1, 1);
            Display.Graphics.PutTile(1, 0, 1);

            Display.Graphics.Refresh();
        }
    }
}
