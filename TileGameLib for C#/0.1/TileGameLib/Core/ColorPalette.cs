using TileGameLib.ExtensionMethods;

namespace TileGameLib.Core;

public class ColorPalette
{
	public List<Color> Colors { get; private set; } = [];

	public ColorPalette() {}
	public ColorPalette(Color color, int count) => Add(color, count);
	public ColorPalette(string colorString, int count) => Add(colorString, count);

	public int Count => Colors.Count;
	
	public void RemoveAll() => Colors.Clear();
	
	public void Reset(Color color, int count)
	{
		Colors.Clear();
		Add(color, count);
	}

	public void Add(Color color) => Colors.Add(color);
	public void Add(string colorString)
	{
		colorString = colorString.Trim();

		try
		{
			if (colorString.Contains(','))
			{
				string[] rgbTriplet = colorString.Split(',');
				if (rgbTriplet.Length != 3)
					throw new ArgumentException(
						$"Exactly three values were expected, but {rgbTriplet.Length} values were provided: " + colorString);

				int r = Math.Clamp(int.Parse(rgbTriplet[0].Trim()), 0, 255);
				int g = Math.Clamp(int.Parse(rgbTriplet[1].Trim()), 0, 255);
				int b = Math.Clamp(int.Parse(rgbTriplet[2].Trim()), 0, 255);

				Add(Color.FromArgb(255, r, g, b));
				return;
			}

			string hex = colorString;
			if (hex.StartsWith('#'))
				hex = hex[1..];
			else if (hex.StartsWith("0x"))
				hex = hex[2..];

			Add(ColorTranslator.FromHtml("#" + hex));
		}
		catch (FormatException ex)
		{
			throw new ArgumentException("Could not parse the value as a hexadecimal number: " + ex.Message);
		}
		catch (Exception ex)
		{
			throw new ArgumentException($"Could not add value as a color: " + ex.Message);
		}
	}

	public void Add(Color color, int count)
	{
		for (int i = 0; i < count; i++)
			Add(color);
	}

	public void Add(string colorString, int count)
	{
		for (int i = 0; i < count; i++)
			Add(colorString);
	}

	public void Set(int index, Color color) => Colors[index] = color;
	public void Set(int index, string hexColor)
	{
		Set(index, ColorUtils.FromHex(hexColor).Value);
	}

	public void SetColors(List<Color> colors) => Colors = colors;
	public void SetColors(List<string> hexColors)
	{
		foreach (string hexColor in hexColors)
			Add(hexColor);
	}

	public Color Get(int index)
	{
		return Colors[index];
	}

	public string GetHex(int index) => Get(index).ToHex();

	public void Load(string path)
	{
		RemoveAll();

		foreach (string line in File.ReadAllLines(path))
		{
			if (!string.IsNullOrWhiteSpace(line))
				Add(line);
		}
	}

	public void Load(string path, int fixedSize, Color blankColor)
	{
		Load(path);

		if (Colors.Count < fixedSize)
		{
			int count = fixedSize - Colors.Count;
			Add(blankColor, count);
		}
	}

	public void Save(string path)
	{
		List<string> lines = [];

		foreach (Color color in Colors)
			lines.Add(color.ToHex());

		File.WriteAllLines(path, lines);
	}
}
