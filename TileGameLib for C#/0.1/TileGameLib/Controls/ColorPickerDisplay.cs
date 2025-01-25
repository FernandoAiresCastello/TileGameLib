using TileGameLib.Core;
using TileGameLib.Core.TileTypes;

namespace TileGameLib.Controls;

/// <summary>
///		A panel that displays a grid of colors from a <see cref="ColorPalette"/>.
/// </summary>
/// <param name="bufSize">Size of the tile buffer (number of columns and rows)</param>
/// <param name="canvasSize">Size of the canvas (number of columns and rows)</param>
/// <param name="cellSize">Size of each canvas grid cell (width and height in pixels)</param>
/// <param name="zoomLevel">Magnification factor</param>
/// <param name="emptyColor">Default color for empty cells</param>
/// <param name="viewOffset">Tile buffer offset from which it will be drawn</param>

public class ColorPickerDisplay(
	Size bufSize, Size canvasSize, Size cellSize, Color emptyColor, Point viewOffset, int zoomLevel) :
	TileDisplay(bufSize, canvasSize, cellSize, emptyColor, viewOffset, zoomLevel)
{
	private ColorPalette Colors { get; set; } = new();

	public Color GetColorAtCellIndex(int cellIndex) => GetTile<SolidColorTile>(cellIndex).Color;
	public Color GetColorAtCellPos(Point cellPos) => GetTile<SolidColorTile>(cellPos).Color;
	public Color GetColorAtMousePos(Point mousePos) => GetColorAtCellIndex(GetCellIndexFromMousePos(mousePos));

	public new void Update()
	{
		UpdateTiles();
		Refresh();
	}

	public void SetColors(ColorPalette colors)
	{
		Colors = colors;
		UpdateTiles();
	}

	public void SetColors(List<Color> colors)
	{
		Colors.SetColors(colors);
		UpdateTiles();
	}

	public void SetColors(List<string> hexColors)
	{
		Colors.SetColors(hexColors);
		UpdateTiles();
	}

	public void LoadColors(string path)
	{
		Colors.Load(path);
		UpdateTiles();
	}

	private void UpdateTiles()
	{
		for (int i = 0; i < Colors.Count && i < CellCount; i++)
			SetTile(new SolidColorTile(Colors.Get(i)), i);
	}
}
