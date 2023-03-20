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
    private Tile tile;

    void Start()
    {
        if (Camera.main == null)
            throw new NullReferenceException("Main camera not found");

        screen = new TileDisplay();
        tileset = new Tileset();

        tile = new Tile(
            "00111100" +
            "01000010" +
            "10100101" +
            "10000001" +
            "10100101" +
            "10011001" +
            "01000010" +
            "00111100"
        );
    }

    void Update()
    {
        screen.Clear();
        //screen.DrawTestFrame();

        screen.ColorBinary(0xff0000, 0xffff00);
        screen.DrawTileFree(tile, 0, 0);
        screen.ColorBinary(0x00ff00, 0x00ffff);
        screen.DrawTileFree(tile, 8, 8);

        screen.Update();
    }
}
