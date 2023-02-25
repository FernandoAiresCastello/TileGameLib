# THINGS TO DO

The items in this list are not in any particular order.

**GRAPHICS:**

- Improve rendering performance
- Implement stable frame rate
- Implement loading and converting tiles and tilesets from external file to the TGL internal format

**SOUND:**

- Implement loading and playback of audio from external files
- Improve square-wave sound synthesis
- Change sound synthesis to be able to generate the same kinds of sounds 
that the GameBoy Color is capable of

**INPUT:**

- Implement gamepad/controller input handling

**DATA:**

- Implement datafiles, probably using ZIP methods, to allow grouping all game 
data files into a single file for release. An example of this is what the 
Allegro library does: [https://liballeg.org/stabledocs/en/datafile.html](https://liballeg.org/stabledocs/en/datafile.html)

**PROJECT STRUCTURE:**

- Replace all absolute paths with macros. For example the SDL2 path should not point to the specific directory in my computer as it currently does
- Remove from build all experimental and old unused internal APIs to prevent bloating of the final product

**COMPATIBILITY:**

- Attempt to make the library cross-platform, most importantly by removing the Windows API dependency, so that in the future it can be built on Linux and MacOS.
