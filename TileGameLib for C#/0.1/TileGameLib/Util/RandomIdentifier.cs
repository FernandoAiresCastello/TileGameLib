using System.Text;

namespace TileGameLib.Util;

public class RandomIdentifier
{
	private static readonly Random Random = new();
	private static readonly string DefaultChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

	public static string Generate(string allowedChars, int length)
	{
		StringBuilder id = new();

		for (int i = 0; i < length; i++)
			id.Append(allowedChars[Random.Next(0, allowedChars.Length)]);

		return id.ToString();
	}

	public static string Generate(int length)
	{
		return Generate(DefaultChars, length);
	}
}
