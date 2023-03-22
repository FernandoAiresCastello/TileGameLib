using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TileGameLib;
using Random = UnityEngine.Random;

public class TileGameLibTest : MonoBehaviour
{
    private TileDisplay screen;
    private Tileset tileset;
    private Palette palette;

    void Start()
    {
        screen = new TileDisplay(256, 192, 0xffffff);
        screen.ResizeWindow(800, 600);

        tileset = new Tileset();

        tileset.Add("smiley",
            "00111100" +
            "01000010" +
            "10100101" +
            "10000001" +
            "10100101" +
            "10011001" +
            "01000010" +
            "00111100"
        );
        tileset.Add("smiley",
            "00111100" +
            "01000010" +
            "10000001" +
            "10000001" +
            "10000001" +
            "10000001" +
            "01000010" +
            "00111100"
        );

        screen.AddView("top_left", 10, 10, 100, 100, 0x0000ff);
        screen.AddView("btm_right", 80, 80, 240, 170, 0x00ff00);
    }

    void Update()
    {
        Test_02();
    }

    void Test_02()
    {
        TileSeq tile = tileset.Get("smiley");
        screen.ColorBinary(0xffff00, 0xff0000);
        screen.FontColor(0x00ffff, 0xff00ff);

        screen.View("default");
        screen.DrawTiled(tile, 5, 20);
        
        screen.View("top_left");
        screen.DrawTiled(tile, 0, 0);
        screen.DrawTiled(tile, 12, 0);

        screen.View("btm_right");
        screen.DrawTiled(tile, 0, 0);
        screen.PrintTiled("Hello World!", -4, 2);

        screen.Update();

        if (Input.GetKey(KeyCode.RightArrow))
            screen.Scroll("btm_right", 1, 0);
        if (Input.GetKey(KeyCode.LeftArrow))
            screen.Scroll("btm_right", -1, 0);
        if (Input.GetKey(KeyCode.DownArrow))
            screen.Scroll("btm_right", 0, 1);
        if (Input.GetKey(KeyCode.UpArrow))
            screen.Scroll("btm_right", 0, -1);
    }

    void Test_01()
    {
        screen.Clear();

        TileSeq tile = tileset.Get("smiley");

        for (int y = 0; y < screen.Rows; y++)
        {
            for (int x = 0; x < screen.Cols; x++)
            {
                screen.ColorBinary(
                    Random.Range(0x000000, 0x808080),
                    Random.Range(0x909090, 0xffffff));

                screen.DrawTiled(tile, x, y);
            }
        }

        screen.FontColor(palette.Get("red"), palette.Get("yellow"));
        screen.FontTransparent(true);
        screen.PrintFree("~ Hello Free World! ~", 4, 4);
        screen.FontTransparent(false);
        screen.PrintTiled("~ Hello Tiled World! ~", 4, 4);

        screen.Update();
    }
}
