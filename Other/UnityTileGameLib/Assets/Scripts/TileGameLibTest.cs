using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TileGameLib;
using Random = UnityEngine.Random;

public class TileGameLibTest : MonoBehaviour
{
    private TileDisplay screen;
    private Tileset tileset;

    void Start()
    {
        screen = new TileDisplay(256, 192);
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
    }

    void Update()
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
        
        screen.FontColor(0xff0000, 0xffff00);
        screen.FontTransparent(true);
        screen.PrintFree("~ Hello Free World! ~", 4, 4);
        screen.FontTransparent(false);
        screen.PrintTiled("~ Hello Tiled World! ~", 4, 4);

        screen.Update();
    }
}
