﻿namespace TileGameLib.Core.TileTypes;

public class SolidColorTile(Color color) : Tile
{
	public Color Color { get; set; } = color;

	public override void Draw(TileCanvas canvas, Point canvasPos)
	{
		canvas.DrawColor(Color, canvasPos);
	}
}
