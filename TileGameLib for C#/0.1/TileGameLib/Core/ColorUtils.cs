namespace TileGameLib.Core;

public static class ColorUtils
{
	public static Color? FromHex(string hexColor)
	{
		try
		{
			string hex = hexColor;

			if (hex.StartsWith('#'))
				hex = hex[1..];
			else if (hex.StartsWith("0x"))
				hex = hex[2..];

			return ColorTranslator.FromHtml("#" + hex);
		}
		catch
		{
			return null;
		}
	}
}
