using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using TileGameLib.Core;
using TileGameLib.Core.TileTypes;
using Timer = System.Windows.Forms.Timer;

namespace TileGameLib.Controls;

/// <summary>
///		UI control for managing and displaying a <see cref="TileCanvas"/>.
///		Can optionally display a grid, cell selection, and cell text on top of the canvas.
/// </summary>
public class TileDisplay : Control
{
	//================================
	//	Public
	//================================

	public int Cols => Canvas.Cols;
	public int Rows => Canvas.Rows;
	public int LastCol => Canvas.LastCol;
	public int LastRow => Canvas.LastRow;
	public int CellCount => Canvas.CellCount;
	public int CellWidth => Canvas.CellWidth;
	public int CellHeight => Canvas.CellHeight;
	public Rectangle CellRange => Canvas.CellRange;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DockStyle Dock
	{
		get => base.Dock;
		set => throw new InvalidOperationException("TileDisplay cannot be docked.");
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new Color BackColor
	{
		set => Canvas.BackColor = value;
		get => Canvas.BackColor;
	}

	public Point TileBufferViewOffset => new(TileBufferViewOffsetX, TileBufferViewOffsetY);

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool ShowGrid { get; set; } = true;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color GridColor
	{
		get => gridColor;
		set
		{
			gridColor = value;
			CreateGrid();
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int Zoom
	{
		get => zoom;
		set
		{
			if (value < MinZoom) zoom = MinZoom;
			else if (value > MaxZoom) zoom = MaxZoom;
			else zoom = value;

			UpdateSize();
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color SelectionColor { get; set; } = Color.FromArgb(80, Color.Blue);

	//================================
	//	Private
	//================================

	private int zoom = 1;
	private const int MinZoom = 1;
	private const int MaxZoom = 10;

	private Bitmap grid = new(1, 1);
	private Color gridColor = Color.FromArgb(80, 128, 128, 128);
	private int TileBufferViewOffsetX = 0;
	private int TileBufferViewOffsetY = 0;
	private Font TextOverlayFont = new("Consolas", 9);

	private readonly TileCanvas Canvas;
	private readonly TileBuffer Tiles;
	private readonly HashSet<Point> SelectedCells = [];
	private readonly List<Tuple<string, Point>> TextOverlay = [];
	private readonly Timer AutoRefreshTimer = new();

	//================================
	//	Constructor
	//================================

	public TileDisplay(Size tileBufferSize, Size canvasGridSize, Size canvasCellSize, Color canvasColor, Point viewOffset, int zoomLevel)
	{
		ParentChanged += TileDisplay_ParentChanged;

		Margin = new Padding(0);
		Padding = new Padding(0);
		DoubleBuffered = true;
		base.Dock = DockStyle.None;

		Tiles = new TileBuffer(tileBufferSize);
		Canvas = new TileCanvas(canvasGridSize, canvasCellSize, canvasColor);
		TileBufferViewOffsetX = viewOffset.X;
		TileBufferViewOffsetY = viewOffset.Y;
		zoom = zoomLevel;

		UpdateSize();
	}

	//================================
	//	Set / move / delete tiles
	//================================

	public void SetTile(Tile tile) => Tiles.Set(tile, tile.CellPos);
	public void SetTile(Tile tile, int cellIndex) => Tiles.Set(tile, cellIndex);
	public void SetTile(Tile tile, int col, int row) => Tiles.Set(tile, col, row);
	public void SetTile(Tile tile, Point cellPos) => Tiles.Set(tile, cellPos);

	public void MoveTileBy(Tile tile, int dx, int dy) => Tiles.MoveBy(tile, dx, dy);
	public void MoveTileTo(Tile tile, int x, int y) => Tiles.MoveTo(tile, x, y);

	public void DeleteTile(Tile tile) => Tiles.Delete(tile.CellPos);
	public void DeleteTile(int cellIndex) => Tiles.Delete(cellIndex);
	public void DeleteTile(int col, int row) => Tiles.Delete(col, row);
	public void DeleteTile(Point cellPos) => Tiles.Delete(cellPos);

	public void Fill(Func<Tile> tileGenerator)
	{
		for (int row = 0; row < Tiles.Rows; row++)
			for (int col = 0; col < Tiles.Cols; col++)
				SetTile(tileGenerator(), col, row);
	}

	public void Clear()
	{
		for (int row = 0; row < Tiles.Rows; row++)
			for (int col = 0; col < Tiles.Cols; col++)
				DeleteTile(col, row);
	}

	//================================
	//	Get tile at cell position
	//================================

	public Tile GetTile(int cellIndex) => Tiles.At(cellIndex);
	public Tile GetTile(Point cellPos) => Tiles.At(cellPos);
	public Tile GetTile(int col, int row) => Tiles.At(col, row);

	public T GetTile<T>(int cellIndex) where T : Tile => (T)Tiles.At(cellIndex);
	public T GetTile<T>(Point cellPos) where T : Tile => (T)Tiles.At(cellPos);
	public T GetTile<T>(int col, int row) where T : Tile => (T)Tiles.At(col, row);

	//================================
	//	Get cell from mouse position
	//================================

	public Point GetCellPosFromMousePos(Point point)
	{
		return new Point
		{
			X = TileBufferViewOffsetX + (point.X / (Zoom * CellWidth)),
			Y = TileBufferViewOffsetY + (point.Y / (Zoom * CellHeight))
		};
	}

	public int GetCellIndexFromMousePos(Point point)
	{
		Point cellPos = GetCellPosFromMousePos(point);
		return (cellPos.Y * Tiles.Cols) + cellPos.X;
	}

	//================================
	//	Cell selection
	//================================

	public void SelectCell(int x, int y) => SelectCell(new Point(x, y));
	public void SelectCell(Point cellPos) => SelectedCells.Add(cellPos);

	public void SelectAllCells() => SelectCellRegion(0, 0, LastCol, LastRow);
	public void UnselectAllCells() => SelectedCells.Clear();

	public void SelectCellRegion(int x1, int y1, int x2, int y2) => 
		SelectCellRegion(new Point(x1, y1), new Point(x2, y2));

	public void SelectCellRegion(Point topLeftCell, Point bottomRightCell)
	{
		for (int row = topLeftCell.Y; row <= bottomRightCell.Y; row++)
			for (int col = topLeftCell.X; col <= bottomRightCell.X; col++)
				SelectCell(col, row);
	}

	//================================
	//	Text overlay
	//================================

	public void SetTextOverlayFont(Font font) => TextOverlayFont = font;

	public void SetTextOverlay(string text, int x, int y) => 
		TextOverlay.Add(new(text, new Point(x, y)));

	public void SetTextOverlay(string text, Point cellPos) => 
		TextOverlay.Add(new(text, cellPos));

	public string GetTextOverlay(Point cellPos) =>
		TextOverlay.Find(t => t.Item2 == cellPos).Item1;

	public bool HasTextOverlay(Point cellPos)
	{
		var obj = TextOverlay.FindAll(t => t.Item2 == cellPos);

		return obj.Count > 0;
	}

	public void RemoveTextOverlay(Point cellPos) =>
		TextOverlay.RemoveAll(t => t.Item2 == cellPos);

	public void RemoveAllTextOverlay() => TextOverlay.Clear();

	//================================
	//	Viewport
	//================================

	public void ScrollView(int dx, int dy)
	{
		TileBufferViewOffsetX += dx;
		TileBufferViewOffsetY += dy;

		Refresh();
	}

	public void SetView(int x, int y)
	{
		TileBufferViewOffsetX = x;
		TileBufferViewOffsetY = y;

		Refresh();
	}

	//================================
	//	Grid
	//================================

	private void CreateGrid()
	{
		grid = new Bitmap(Width, Height);
		using Graphics g = Graphics.FromImage(grid);
		using Pen gridPen = new(GridColor);

		g.Clear(Color.FromArgb(0));

		int incY = Zoom * CellHeight;
		for (int y = -1; y < Height; y += incY)
			g.DrawLine(gridPen, 0, y, Width, y);
		int incX = Zoom * CellWidth;
		for (int x = -1; x < Width; x += incX)
			g.DrawLine(gridPen, x, 0, x, Height);
	}

	//================================
	//	Control painting
	//================================

	protected override void OnPaint(PaintEventArgs e)
	{
		Canvas.Clear();

		PaintTiles();

		Graphics g = e.Graphics;

		g.InterpolationMode = InterpolationMode.NearestNeighbor;
		g.SmoothingMode = SmoothingMode.None;
		g.PixelOffsetMode = PixelOffsetMode.Half;
		g.CompositingQuality = CompositingQuality.HighSpeed;
		g.CompositingMode = CompositingMode.SourceCopy;

		PaintCanvas(g);

		g.InterpolationMode = InterpolationMode.Default;
		g.SmoothingMode = SmoothingMode.Default;
		g.PixelOffsetMode = PixelOffsetMode.Default;
		g.CompositingQuality = CompositingQuality.Default;
		g.CompositingMode = CompositingMode.SourceOver;

		if (ShowGrid)
			PaintGrid(g);
		if (SelectedCells.Count > 0)
			PaintSelection(g);
		if (TextOverlay.Count > 0)
			PaintCellText(g);
	}

	private void PaintTiles()
	{
		int canvasX = 0;
		int canvasY = 0;

		for (int tileBufRow = TileBufferViewOffsetY; tileBufRow < TileBufferViewOffsetY + Canvas.Rows; tileBufRow++)
		{
			for (int tileBufCol = TileBufferViewOffsetX; tileBufCol < TileBufferViewOffsetX + Canvas.Cols; tileBufCol++)
			{
				Tile tile = GetTile(tileBufCol, tileBufRow);
				if (tile != null && tile.Visible)
					tile.Draw(Canvas, new Point(canvasX, canvasY));

				canvasX++;
			}
			canvasX = 0;
			canvasY++;
		}
	}

	private void PaintCanvas(Graphics g)
	{
		g.DrawImage(Canvas.Buffer.Bitmap, 0, 0, Zoom * Canvas.Width, Zoom * Canvas.Height);
	}

	private void PaintGrid(Graphics g)
	{
		g.DrawImage(grid, 0, 0, ClientRectangle.Width, ClientRectangle.Height);
	}

	private void PaintSelection(Graphics g)
	{
		foreach (Point pos in SelectedCells)
		{
			int x = pos.X * Zoom * CellWidth;
			int y = pos.Y * Zoom * CellHeight;
			int w = Zoom * CellWidth;
			int h = Zoom * CellHeight;
			using Brush brush = new SolidBrush(SelectionColor);
			g.FillRectangle(brush, x, y, w, h);
		}
	}

	private void PaintCellText(Graphics g)
	{
		foreach (var tuple in TextOverlay)
		{
			string text = tuple.Item1;
			Point cellPos = tuple.Item2;

			int x = (cellPos.X - TileBufferViewOffsetX) * Zoom * CellWidth;
			int y = (cellPos.Y - TileBufferViewOffsetY) * Zoom * CellHeight;

			using Brush brush = new SolidBrush(Color.Black);
			g.DrawString(text, TextOverlayFont, brush, x, y);
		}
	}

	//================================
	//	Public utility functions
	//================================

	public void SaveImage(string filename, ImageFormat format) => 
		Canvas.SaveImage(filename, format);

	public void BeginAutoRefresh(int intervalMillis, Action callback)
	{
		AutoRefreshTimer.Interval = intervalMillis;
		AutoRefreshTimer.Tick += (s, e) =>
		{
			callback();
			Refresh();
		};
		AutoRefreshTimer.Start();
	}

	public void StopAutoRefresh()
	{
		AutoRefreshTimer.Stop();
	}

	//================================
	//	Internal utility functions
	//================================

	private void TileDisplay_ParentChanged(object sender, EventArgs e)
	{
		if (Parent == null)
			return;

		var panel = (Panel)Parent;
		if (panel != null)
			panel.AutoScroll = true;
	}

	private void UpdateSize()
	{
		Size = new Size(Zoom * Canvas.Width, Zoom * Canvas.Height);

		CreateGrid();
		Refresh();
	}
}
