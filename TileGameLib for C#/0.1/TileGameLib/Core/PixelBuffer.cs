using System.Drawing.Imaging;

namespace TileGameLib.Core;

/// <summary>
///		An off-screen graphical object that stores a bitmap, and can be used to set or get individual pixels.
/// </summary>
public class PixelBuffer
{
	public Bitmap Bitmap => FastBitmap.Bitmap;
	public int PixelCount => FastBitmap.Pixels.Length;
	public int Width => FastBitmap.Width;
	public int Height => FastBitmap.Height;

	protected FastBitmap FastBitmap;

	public PixelBuffer() {}
	public PixelBuffer(int width, int height, Color color)
	{
		FastBitmap = new FastBitmap(width, height);
		Clear(color);
	}

	public void SaveImage(string file, ImageFormat format) => 
		Bitmap.Save(file, format);

	public void Clear(Color color)
	{
		for (int i = 0; i < PixelCount; i++)
			FastBitmap.Pixels[i] = color.ToArgb();
	}

	public void SetPixel(int x, int y, Color color)
	{
		if (x < 0 || y < 0 || x >= Width || y >= Height)
			return;

		FastBitmap.Pixels[y * Width + x] = color.ToArgb();
	}

	public Color GetPixel(int x, int y)
	{
		if (x < 0 || y < 0 || x >= Width || y >= Height)
			throw new Exception($"Pixel index out of bounds. X: {x}; Y: {y}; PixelCount: {PixelCount}");

		return Color.FromArgb(FastBitmap.Pixels[y * Width + x]);
	}
}
