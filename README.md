# Tile Game Toolkit
A collection of software libraries and tools for quick and easy development of tile-based, pseudo-8-bit games in C++ or C#.

**Notes:**

1. This toolkit is under continuous development, therefore breaking changes in the public API may be introduced at any time without prior notice. Use at your own risk.
2. There is no dependency or interoperability between the C++ and the C# projects.
3. The public API for TGL (the C++ library) is available via the header TGL.h only. Including any other internal TGL header files in your program is not supported.

**Projects included:**

- [TileGameLibC/TGL](https://github.com/FernandoAiresCastello/TileGameToolkit/tree/master/TileGameLibC) is a C++ static library (.lib). Depends on [SDL2](https://www.libsdl.org/) and [CppUtils](https://github.com/FernandoAiresCastello/CppUtils).

- [TileGameLibCS/TileGameLib](https://github.com/FernandoAiresCastello/TileGameToolkit/tree/master/TileGameLibCS/TileGameLib) is a C# dynamic library (.dll). Depends on Windows Forms.

- [TileGameLibCS/TileGameMaker](https://github.com/FernandoAiresCastello/TileGameToolkit/tree/master/TileGameLibCS/TileGameMaker) is a C# desktop application (.exe). Depends on Windows Forms and TileGameLib.dll

---

*Screenshot of TileGameMaker: (may be outdated)*

![TileGameMaker](https://raw.githubusercontent.com/FernandoAiresCastello/TileGameToolkit/master/Images/TileGameMaker.png)
