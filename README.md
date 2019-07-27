# Tile Game Maker
#### Library and tools for tile-based game creation

The goal of this project is to make it easier to develop pseudo-8-bit tile-based games. It was heavily inspired by two classic game engines: [ZZT](https://museumofzzt.com/) and [MegaZeux](https://vault.digitalmzx.net/index.php), as well as early 8-bit computer systems such as the [ZX Spectrum](https://en.wikipedia.org/wiki/ZX_Spectrum), [MSX](https://en.wikipedia.org/wiki/MSX) and [Atari 800](https://en.wikipedia.org/wiki/Atari_8-bit_family). A more recent game engine called [Bitsy](https://ledoux.itch.io/bitsy) is also a source of inspiration.

This repository contains a Visual Studio solution comprised of three C# projects targeting the .NET Framework 4.6.1 and above:

- **TileGameLib** (TGL for short) is a library project that generates a .NET DLL file, which can be used in other projects. It contains several classes designed to aid in the programming of pseudo-8-bit tile-based games.

- **TileGameMaker** is a Windows desktop application project built using TileGameLib that generates a .NET executable file. It contains several tools mainly focused on graphics editing and map design. It does not implement any game logic, but it will provide a simple scripting language for its programming.

- **TileGameRunner** is another Windows desktop application which contains the implementation of an engine that can run game projects created with the TileGameMaker tool.

This project is a spiritual successor of [TBRLGPT](https://github.com/FernandoAiresCastello/TBRLGPT).
