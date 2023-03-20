using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Screen
{
    private GameObject gameObject;
    private PixelBuffer buf;
    private RawImage img;
    private Rgb backColor;

    public Screen(Rgb backColor)
    {
        gameObject = new GameObject("Screen");

        this.backColor = backColor;
        img = gameObject.AddComponent<RawImage>();
        buf = new PixelBuffer(img, 256, 192);

        Canvas canvas = gameObject.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.pixelPerfect = true;
    }

    public void Update()
    {
        buf.Update();
    }

    public void Clear()
    {
        buf.Clear(backColor);
    }

    public void DrawTestFrame()
    {
        for (int y = 0; y < buf.Height; y++)
        {
            for (int x = 0; x < buf.Width; x++)
            {
                buf.SetPixel(x, y, Random.Range(0x000000, 0xffffff));
            }
        }
    }
}
