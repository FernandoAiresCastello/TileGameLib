using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TileGameLib : MonoBehaviour
{
    private Screen screen;

    void Start()
    {
        if (Camera.main == null)
            throw new NullReferenceException("Main camera not found");

        screen = new Screen(0xffffff);
    }

    void Update()
    {
        screen.Clear();
        screen.DrawTestFrame();
        screen.Update();
    }
}
