![TileGameLib Logo](https://github.com/FernandoAiresCastello/TileGameToolkit/blob/master/Images/github-banner-1.png?raw=true)

# TileGameLib (TGL)
TileGameLib (TGL) is a C/C++ static library for quick and easy development of tile-based, pseudo-8-bit games that have a strong Nintendo GameBoy Color aesthetic. This repository also includes some other tools for C# .NET which are independent from the TGL library itself. This project was started in 2019.

The goal of this toolkit is to facilitate the development of standalone game applications (.exe) that somewhat resemble the look and feel of *Nintendo GameBoy Color* games and other 8-bit tile-based computer systems, providing a simplified and minimalistic API, while requiring few dependencies on external libraries.

I (Fernando) am currently the sole developer in this project. Please check out the documentation wiki and the TODO list (links below) to see where help is currently needed and let me know if you can contribute to the library somehow! Also, all questions, suggestions and bug reports are welcome. Thanks for stopping by! ❤️

**Download:**

- [Click here to find the latest TileGameLib (TGL) build files](https://github.com/FernandoAiresCastello/TileGameLib/tree/master/Releases/TGL)

**Contact:**

- If you'd like to join the project or if you have any questions or suggestions, please create a post in the official TGL subreddit here: [https://www.reddit.com/r/TileGameLib](https://www.reddit.com/r/TileGameLib)

**Docs:**

- [TileGameLib (TGL) - Documentation Wiki](https://fernandoairescastello.neocities.org/proj/tgl/tgl_index)
- [TileGameLib (TGL) - Public API Header File (TGL.h)](https://github.com/FernandoAiresCastello/TileGameToolkit/blob/master/TileGameLibC/TGL/TGL.h)
- [Help Needed - TODO List](https://github.com/FernandoAiresCastello/TileGameLib/blob/master/TODO.md)

**Main project:**

- [TileGameLib (TGL)](https://github.com/FernandoAiresCastello/TileGameToolkit/tree/master/TileGameLibC) is a C++ static library. This is the "main" project and it's under active development as of 2023.

**Other projects included:**

- [Tile Game Maker](https://github.com/FernandoAiresCastello/TileGameToolkit/tree/master/TileGameLibCS) is a standalone C# desktop application (TileGameMaker.exe) built on top of Windows Forms targeting the .NET Framework. The solution also includes a dynamic library (TileGameLib.dll) that is independent from the TileGameMaker.exe application and can be used in other projects. Mostly useful for drawing and prototyping games, sort of like an IDE. Currently, this project is not being actively developed.

- [TileGameLibJS (TGL.js)](https://github.com/FernandoAiresCastello/TileGameToolkit/tree/master/TileGameLibJS) was an early attempt to create a web-based version of TGL.lib using Typescript and HTML/CSS. Currently, this project is not being actively developed.

**Disclaimers:**

- This toolkit is under continuous development, therefore breaking changes in the public APIs may be introduced at any time without prior notice. Use at your own risk.
- Only Microsoft Windows (7 and above) is currently supported. The projects are built using Visual Studio Community 2019. 
- There is no compatibility or interoperability among the C++, C# and JS projects, they are completely independent.
