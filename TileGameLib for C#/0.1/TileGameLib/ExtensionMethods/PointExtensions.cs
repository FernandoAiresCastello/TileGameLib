namespace TileGameLib.ExtensionMethods;

public static class PointExtensions
{
	public static bool IsInside(this Point point, Rectangle rect) =>
		point.IsInside(rect.Left, rect.Top, rect.Right, rect.Bottom);

	public static bool IsOutside(this Point point, Rectangle rect) =>
		!IsInside(point, rect);

	public static bool IsInside(this Point point, int x, int y, int width, int height) =>
		point.X >= x && point.Y >= y && point.X < width && point.Y < height;

	public static bool IsOutside(this Point point, int x, int y, int width, int height) =>
		!IsInside(point, x, y, width, height);
}
