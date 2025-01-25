namespace TileGameLib.Core;

/// <summary>
///		Represents an image that can be manipulated pixel by pixel 
///		and also load its pixel data from an image file.
/// </summary>
public class TileImage : PixelBuffer
{
	/// <param name="width">Width of the image, in pixels</param>
	/// <param name="height">Height of the image, in pixels</param>
	/// <param name="color">Default color of the image</param>
	public TileImage(int width, int height, Color color) : base(width, height, color)
	{
	}

	public TileImage(string path)
	{
		Load(path);
	}

	public void Load(string path)
	{
		Bitmap bmp = (Bitmap)Image.FromFile(path);

		FastBitmap = new FastBitmap(bmp.Width, bmp.Height);
		
		for (int y = 0; y < bmp.Height; y++)
			for (int x = 0; x < bmp.Width; x++)
				Bitmap.SetPixel(x, y, bmp.GetPixel(x, y));
	}
}
