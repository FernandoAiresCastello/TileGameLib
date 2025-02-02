using System.Drawing.Imaging;
using TileGameLib.Controls;

namespace TileGameLib.Core;

/// <summary>
///		Represents an off-screen graphical object where tile-based images can be drawn on a grid.
///		To actually show this object on screen, a <see cref="TileDisplay"/> control is required.
/// </summary>
public class TileCanvas(Size gridSize, Size cellSize, Color backColor)
{
	public readonly int Cols = gridSize.Width;
	public readonly int Rows = gridSize.Height;
	public readonly int LastCol = gridSize.Width - 1;
	public readonly int LastRow = gridSize.Height - 1;
	public readonly int CellCount = gridSize.Width * gridSize.Height;
	public readonly int CellWidth = cellSize.Width;
	public readonly int CellHeight = cellSize.Height;
	public readonly Rectangle CellRange = new(0, 0, gridSize.Width, gridSize.Height);

	public PixelBuffer Buffer { get; private set; } = 
		new PixelBuffer(gridSize.Width * cellSize.Width, gridSize.Height * cellSize.Height, backColor);

	public int Width => Buffer.Width;
	public int Height => Buffer.Height;

	public Color BackColor = backColor;

	public void Clear()
	{
		Buffer.Clear(BackColor);
	}

	public void DrawColor(Color color, Point cellPos) => 
		DrawTile(new(CellWidth, CellHeight, color), cellPos.X, cellPos.Y);

	public void DrawColor(Color color, int col, int row) => 
		DrawTile(new(CellWidth, CellHeight, color), col, row);

	public void DrawColor(Color color, int cellIndex) => 
		DrawTile(new(CellWidth, CellHeight, color), cellIndex);

	public void DrawTile(TileImage tile, Point cellPos) =>
		DrawTile(tile, cellPos.X, cellPos.Y);

	public void DrawTile(TileImage tile, int col, int row) => 
		DrawFreeTile(tile, col * CellWidth, row * CellHeight);

	public void DrawTile(TileImage tile, int cellIndex)
	{
		int col = cellIndex % Cols;
		int row = cellIndex / Cols;

		DrawFreeTile(tile, col * CellWidth, row * CellHeight);
	}

	public void DrawFreeTile(TileImage tile, int x, int y)
	{
		int initialX = x;
		int initialY = y;
		int bufX = initialX;
		int bufY = initialY;

		for (int imageY = 0; imageY < tile.Height && imageY < CellHeight; imageY++)
		{
			for (int imageX = 0; imageX < tile.Width && imageY < CellWidth; imageX++)
			{
				Buffer.SetPixel(bufX, bufY, tile.GetPixel(imageX, imageY));
				bufX++;
			}
			bufY++;
			bufX = initialX;
		}
	}

	public void SaveImage(string filename, ImageFormat format) => 
		Buffer.SaveImage(filename, format);
}
