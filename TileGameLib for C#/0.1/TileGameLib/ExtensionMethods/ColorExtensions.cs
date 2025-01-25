namespace TileGameLib.ExtensionMethods;

public static class ColorExtensions
{
	public static string ToHex(this Color color) =>
		$"{color.R:X2}{color.G:X2}{color.B:X2}";

	public static string ToHexRgbTriplet(this Color color) =>
		$"{color.R:X2},{color.G:X2},{color.B:X2}";

	public static string ToDecimalRgbTriplet(this Color color) =>
		$"{color.R},{color.G},{color.B}";
}
