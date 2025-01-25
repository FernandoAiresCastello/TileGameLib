using TileGameLib.Core;
using TileGameLib.Core.TileTypes;
using TileGameLib.ExtensionMethods;

namespace TileGameLib.Controls;

public class ImageEditorDisplay : TileDisplay
{
	public Color CurrentLeftColor = Color.Black;
	public Color CurrentRightColor = Color.White;

	public ImageEditorDisplay(Size bufSize, Size canvasSize, Size cellSize, Color emptyColor, Point viewOffset, int zoomLevel = 1) : 
		base(bufSize, canvasSize, cellSize, emptyColor, viewOffset, zoomLevel)
	{
		CommonInit();
	}

	public ImageEditorDisplay(Size bufSize, Size cellSize, int zoomLevel = 1) :
		base(bufSize, bufSize, cellSize, Color.White, new Point(0, 0), zoomLevel)
	{
		CommonInit();
	}

	private void CommonInit()
	{
		MouseDown += ImageEditorDisplay_MouseDown;
		MouseMove += ImageEditorDisplay_MouseMove;
	}

	private void ImageEditorDisplay_MouseMove(object sender, MouseEventArgs e)
	{
		ImageEditorDisplay_MouseDown(sender, e);
	}

	private void ImageEditorDisplay_MouseDown(object sender, MouseEventArgs e)
	{
		Point cellPos = GetCellPosFromMousePos(e.Location);

		if (e.Button == MouseButtons.Left)
			DrawPixel(CurrentLeftColor, cellPos);
		else if (e.Button == MouseButtons.Right)
			DrawPixel(CurrentRightColor, cellPos);
	}

	public void DrawPixel(Color color, Point cellPos)
	{
		if (!cellPos.IsInside(CellRange))
			return;

		SetTile(new SolidColorTile(color), cellPos);
		Refresh();
	}
}
