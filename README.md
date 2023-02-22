# Tile Game Toolkit
This repo is a collection of software libraries and tools for quick and easy development of tile-based, pseudo-8-bit games in C++ or C#.

**Main project:**

- [TileGameLib (TGL)](https://github.com/FernandoAiresCastello/TileGameToolkit/tree/master/TileGameLibC) is a C++ static library (TGL.lib) built on top of SDL2. This is the "main" project and it's under active development.

**Other projects included:**

- [Tile Game Maker](https://github.com/FernandoAiresCastello/TileGameToolkit/tree/master/TileGameLibCS) is a standalone C# desktop application (TileGameMaker.exe) built on top of Windows Forms targeting the .NET Framework. The solution also includes a dynamic library (TileGameLib.dll) that is independent from the TileGameMaker.exe application and can be used in other projects. Mostly useful for drawing and prototyping games, sort of like an IDE. Currently, this project is not being actively developed.

- [TileGameLibJS](https://github.com/FernandoAiresCastello/TileGameToolkit/tree/master/TileGameLibJS) is an ongoing attempt to port TGL.lib to Javascript/HTML/CSS. Currently, this project is not being actively developed.

**Disclaimers:**

- This toolkit is under continuous development, therefore breaking changes in the public APIs may be introduced at any time without prior notice. Use at your own risk.
- Only Microsoft Windows (7 and above) is currently supported. The projects are built using Visual Studio Community 2019. 
- There is no compatibility or interoperability among the C++, C# and JS projects, they are completely independent.
