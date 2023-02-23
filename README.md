# Tile Game Toolkit
This repo is a collection of software libraries and tools for quick and easy development of tile-based, pseudo-8-bit games in C++ or C#.

The goal of this toolkit is to facilitate the development of standalone applications that somewhat resemble the look and feel of *Nintendo GameBoy Color* games, at least graphically, at least on Microsoft Windows.

**Documentation:**

- [TileGameLib (TGL) Documentation Wiki](https://fernandoairescastello.neocities.org/proj/tgl/tgl_index)

**Main project:**

- [TileGameLib (TGL)](https://github.com/FernandoAiresCastello/TileGameToolkit/tree/master/TileGameLibC) is a C++ static library (TGL.lib) built on top of SDL2. TGL currently provides a simplified and integrated API for creating & drawing tiles, text printing, keyboard & mouse input, square-wave sounds, timers, collision detection, filesystem access and other conveniences. This is the "main" project and it's under active development as of 2023.

**Other projects included:**

- [Tile Game Maker](https://github.com/FernandoAiresCastello/TileGameToolkit/tree/master/TileGameLibCS) is a standalone C# desktop application (TileGameMaker.exe) built on top of Windows Forms targeting the .NET Framework. The solution also includes a dynamic library (TileGameLib.dll) that is independent from the TileGameMaker.exe application and can be used in other projects. Mostly useful for drawing and prototyping games, sort of like an IDE. Currently, this project is not being actively developed.

- [TileGameLibJS](https://github.com/FernandoAiresCastello/TileGameToolkit/tree/master/TileGameLibJS) is an ongoing attempt to port TGL.lib to Javascript/HTML/CSS. Currently, this project is not being actively developed.

**Disclaimers:**

- This toolkit is under continuous development, therefore breaking changes in the public APIs may be introduced at any time without prior notice. Use at your own risk.
- Only Microsoft Windows (7 and above) is currently supported. The projects are built using Visual Studio Community 2019. 
- There is no compatibility or interoperability among the C++, C# and JS projects, they are completely independent.
