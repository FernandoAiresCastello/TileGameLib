using UnityEngine;
using UnityEngine.UI;

public class PixelRenderer : MonoBehaviour
{
    readonly int width = 256;
    readonly int height = 192;

    Texture2D tex;
    Color32[] pixels;
    Canvas canvas;
    RawImage image;

    void Start()
    {
        tex = new Texture2D(width, height, TextureFormat.RGBA32, -1, false);
        tex.filterMode = FilterMode.Point;
        pixels = tex.GetPixels32(0);
        image = GetComponent<RawImage>();
        image.texture = tex;
        image.uvRect = new Rect(0, 0, 1, -1);
        canvas = GetComponent<Canvas>();
        canvas.pixelPerfect = true;
    }

    void Update()
    {
        RenderTestFrame();

        tex.SetPixels32(pixels, 0);
        tex.Apply();
    }

    void RenderTestFrame()
    {
        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                SetPixel(x, y, Random.Range(0x000000, 0xffffff));
            }
        }
    }

    void SetPixel(int x, int y, int rgb)
    {
        byte r = (byte)((rgb & 0xff0000) >> 16);
        byte g = (byte)((rgb & 0x00ff00) >> 8);
        byte b = (byte)((rgb & 0x0000ff));

        pixels[y * tex.width + x] = new Color32(r, g, b, 255);
    }
}
