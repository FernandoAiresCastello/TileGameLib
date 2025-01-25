using TileGameLib.Core.TileTypes;

namespace TileGameLib.Core;

/// <summary>
///		A container for tile objects.
/// </summary>
public class TileBuffer
{
	public int Cols { get; private set; }
	public int Rows { get; private set; }
	public int LastCol { get; private set; }
	public int LastRow { get; private set; }
	public int CellCount { get; private set; }

	public Tile[,] Tiles { get; private set; }

	/// <summary>
	///		Constructs a new TileBuffer
	/// </summary>
	/// <param name="size">Number of tile columns and rows</param>
	public TileBuffer(Size size) => SetSize(size.Width, size.Height);

	/// <summary>
	///		Constructs a new TileBuffer
	/// </summary>
	/// <param name="cols">Number of tile columns</param>
	/// <param name="rows">Number of tile rows</param>
	public TileBuffer(int cols, int rows) => SetSize(cols, rows);

	private void SetSize(int cols, int rows)
	{
		Cols = cols;
		Rows = rows;
		LastCol = cols - 1;
		LastRow = rows - 1;
		CellCount = cols * rows;

		Tiles = new Tile[Cols, Rows];

		for (int row = 0; row < rows; row++)
			for (int col = 0; col < cols; col++)
				Tiles[col, row] = new VoidTile();
	}

	//===============
	//	Set
	//===============

	public void Set(Tile tile, Point cellPos) => Set(tile, cellPos.X, cellPos.Y);
	
	public void Set(Tile tile, int cellIndex)
	{
		int col = cellIndex % Cols;
		int row = cellIndex / Cols;

		Set(tile, col, row);
	}

	public void Set(Tile tile, int col, int row)
	{
		tile.CellPos = new(col, row);

		if (col >= 0 && row >= 0 && col < Cols && row < Rows)
			Tiles[col, row] = tile;
	}

	//===============
	//	Move
	//===============

	public void MoveBy(Tile tile, int dx, int dy)
	{
		Point originalPos = tile.CellPos;

		tile.CellPos = new(originalPos.X + dx, originalPos.Y + dy);

		Set(tile, tile.CellPos);
		Delete(originalPos);
	}

	public void MoveTo(Tile tile, int x, int y)
	{
		Point originalPos = tile.CellPos;

		tile.CellPos = new(x, y);

		Set(tile, tile.CellPos);
		Delete(originalPos);
	}

	//===============
	//	Delete
	//===============

	public void Delete(Point cellPos) => Delete(cellPos.X, cellPos.Y);

	public void Delete(int col, int row)
	{
		if (col >= 0 && row >= 0 && col < Cols && row < Rows)
			Tiles[col, row] = new VoidTile();
	}

	public void Delete(int cellIndex)
	{
		int col = cellIndex % Cols;
		int row = cellIndex / Cols;

		Delete(col, row);
	}

	//===============
	//	Get
	//===============

	public Tile At(Point cellPos) => At(cellPos.X, cellPos.Y);

	public Tile At(int col, int row)
	{
		if (col >= 0 && row >= 0 && col < Cols && row < Rows)
			return Tiles[col, row];

		return null;
	}

	public Tile At(int cellIndex)
	{
		int col = cellIndex % Cols;
		int row = cellIndex / Cols;

		return At(col, row);
	}
}
