using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TileGameLib.File;

namespace TileGameLibCSTest
{
	public class Game
	{
		private Project Proj;
		private MainWindow Window;

		public Game()
		{
			Proj = new Project();
			Proj.Load("TileGameLibTest.tgpro");
			Window = new MainWindow(Proj.Maps[0]);
		}

		public void Run()
		{
			Application.Run(Window);
		}
	}
}
