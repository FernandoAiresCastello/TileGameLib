namespace TileGameLib.Core.TileTypes;

public class ImageTile : Tile
{
	public TileImage Image { get; set; }

	public ImageTile() {}
	public ImageTile(TileImage image) => Image = image;
	public ImageTile(string imageFilePath) => Image = new TileImage(imageFilePath);

	public override void Draw(TileCanvas canvas, Point canvasPos)
	{
		canvas.DrawTile(Image, canvasPos);
	}
}
