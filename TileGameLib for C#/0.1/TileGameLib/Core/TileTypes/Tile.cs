using TileGameLib.Util;

namespace TileGameLib.Core.TileTypes;

public abstract class Tile
{
	public string Id { get; private set; } = 
		RandomIdentifier.Generate("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 10);

	public Dataset Data { get; set; } = new();
	public bool Visible { get; set; } = true;
	public Point CellPos { get; set; } = new(0, 0);

	public abstract void Draw(TileCanvas canvas, Point canvasPos);

	public override string ToString() => 
		$"Cell: {CellPos}; Visible: {Visible}; Data: {Data.Count} items; ID: {Id}; ";
}
