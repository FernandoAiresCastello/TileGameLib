using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TileGameLib.Components;
using TileGameLib.GameElements;
using TileGameLib.Graphics;

namespace TileGameLibCSTest
{
	public partial class MainWindow : Form
	{
		private TiledDisplay Display;

		private MainWindow()
		{
			InitializeComponent();
		}

		public MainWindow(ObjectMap initialMap)
		{
			InitializeComponent();

			Display = new TiledDisplay(PnlMain, 36, 21, 3);
			Size = Display.Size + new Size(16, 39);
			MapRenderer rend = new MapRenderer(initialMap, Display);
		}
	}
}
