![TileGameLib Logo](https://github.com/FernandoAiresCastello/TileGameToolkit/blob/master/Images/github-banner-1.png?raw=true)

# TileGameLib
TileGameLib is a toolkit for quick and easy development of tile-based, pseudo-8-bit games, in C/C++ or C# (Unity)

This repository was created in 2019. The goal of this toolkit is to facilitate the development of games that somewhat resemble the look and feel of *GameBoy Color* games and other 8-bit tile-based computer systems, providing a simplified and minimalistic API, while requiring few dependencies on external libraries.

Currently, the main project in the toolkit is **TGL.lib**, a C/C++ static library built on top of SDL2. This repository also includes a few other "side projects" located in the "Other" subdirectory, which may or may not be under active development (check below for status).

I (Fernando) am currently the sole developer for this toolkit. Please check out the documentation wiki and the TODO list to see where help is needed and let me know if you can contribute somehow! Questions, suggestions and bug reports are also welcome in the official TileGameLib subreddit. Thanks for stopping by! ❤

**Downloads:**

- [TGL.lib - Latest build](https://github.com/FernandoAiresCastello/TileGameLib/tree/master/Releases/TGL)
- [TGLDemo.exe - Latest demo build](https://github.com/FernandoAiresCastello/TileGameLib/tree/master/TGLDemo/Builds)

**Documentation:**

- [TGL.lib - Public API Header File (TGL.h)](https://github.com/FernandoAiresCastello/TileGameToolkit/blob/master/TGL/TGL/TGL.h)
- [TGL.lib - Documentation Wiki](https://fernandoairescastello.neocities.org/proj/tgl/tgl_index)
- [Help Needed - TO-DO List](https://github.com/FernandoAiresCastello/TileGameLib/blob/master/TODO.md)

**Subreddit:**

- [https://www.reddit.com/r/TileGameLib](https://www.reddit.com/r/TileGameLib)

**Main project:**

- [TGL.lib](https://github.com/FernandoAiresCastello/TileGameToolkit/tree/master/TGL) is a C/C++ static library built on top of [SDL2](https://www.libsdl.org/). Under active development as of 2023.

**Side projects:**

The following projects are also part of the TileGameLib toolkit, but are otherwise completely independent of the main project. These side projects are all located under the [Other](https://github.com/FernandoAiresCastello/TileGameLib/tree/master/Other) subdirectory:

- [Unity TileGameLib](https://github.com/FernandoAiresCastello/TileGameLib/tree/master/Other/UnityTileGameLib) contains a collection of C# scripts for use in the [Unity](https://unity.com/) game engine. Under active development as of 2023

- [TGL TilePaint](https://github.com/FernandoAiresCastello/TileGameLib/tree/master/Other/TGLTilePaint) is a standalone C# desktop app for drawing 8x8 or 16x16 tiles in the TGL format.

- [TileGameLibJS](https://github.com/FernandoAiresCastello/TileGameToolkit/tree/master/Other/TileGameLibJS) was an early attempt to create a web-based version of TGL.lib using Typescript and HTML/CSS. Currently, this project is not being actively developed.

- [TileGameLibCS](https://github.com/FernandoAiresCastello/TileGameLib/tree/master/Other/TileGameLibCS) is a standalone C# desktop application (TileGameMaker.exe) built on top of Windows Forms targeting the .NET Framework. The solution also includes a dynamic library (TileGameLib.dll) that is independent from the TileGameMaker.exe application and can be used in other projects. Mostly useful for drawing and prototyping games, sort of like an IDE. Currently, this project is not being actively developed, as it will most likely be replaced by the Unity version in the future.

**Disclaimers:**

- This toolkit is under continuous development, therefore breaking changes in the public APIs may be introduced at any time without prior notice. Use at your own risk.
- Only Microsoft Windows (7 and above) is currently supported. Most projects are built using Visual Studio Community 2019. 
- There is no direct compatibility or interoperability among the projects, each project in this toolkit is completely independent.
