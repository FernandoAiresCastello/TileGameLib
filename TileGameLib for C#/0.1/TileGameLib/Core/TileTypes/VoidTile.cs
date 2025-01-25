namespace TileGameLib.Core.TileTypes;

public class VoidTile : Tile
{
	public VoidTile() => Visible = false;

	public override void Draw(TileCanvas canvas) {}
}
