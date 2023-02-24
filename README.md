![TileGameLib Logo](https://github.com/FernandoAiresCastello/TileGameToolkit/blob/master/Images/github-banner-1.png?raw=true)

# TileGameLib (TGL)
This repo is a collection of software libraries and tools for quick and easy development of tile-based, pseudo-8-bit games in C++ or C#.

The goal of this toolkit is to facilitate the development of standalone game applications (.exe) that somewhat resemble the look and feel of *Nintendo GameBoy Color* games, providing a simple API and require minimal dependencies on external libraries.

**Docs:**

- [TileGameLib (TGL) Documentation Wiki](https://fernandoairescastello.neocities.org/proj/tgl/tgl_index)

**Main project:**

- [TileGameLib (TGL)](https://github.com/FernandoAiresCastello/TileGameToolkit/tree/master/TileGameLibC) is a C++ static library (TGL.lib) built on top of SDL2. TGL currently provides a simplified and integrated API for creating & drawing tiles, windowing, text printing, keyboard & mouse input, sound, timers, simple collision detection, filesystem access and other conveniences. This is the "main" project and it's under active development as of 2023.

**Other projects included:**

- [Tile Game Maker](https://github.com/FernandoAiresCastello/TileGameToolkit/tree/master/TileGameLibCS) is a standalone C# desktop application (TileGameMaker.exe) built on top of Windows Forms targeting the .NET Framework. The solution also includes a dynamic library (TileGameLib.dll) that is independent from the TileGameMaker.exe application and can be used in other projects. Mostly useful for drawing and prototyping games, sort of like an IDE. Currently, this project is not being actively developed.

- [TileGameLibJS (TGL.js)](https://github.com/FernandoAiresCastello/TileGameToolkit/tree/master/TileGameLibJS) was an early attempt to create a web-based version of TGL.lib using Typescript and HTML/CSS. Currently, this project is not being actively developed.

**Disclaimers:**

- This toolkit is under continuous development, therefore breaking changes in the public APIs may be introduced at any time without prior notice. Use at your own risk.
- Only Microsoft Windows (7 and above) is currently supported. The projects are built using Visual Studio Community 2019. 
- There is no compatibility or interoperability among the C++, C# and JS projects, they are completely independent.
