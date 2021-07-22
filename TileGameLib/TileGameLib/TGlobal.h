/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once

#ifdef DLLEXPORTS
	#define TILEGAMELIB_API __declspec(dllexport)
#else
	#define TILEGAMELIB_API __declspec(dllimport)
#endif

namespace TileGameLib
{
	typedef unsigned char byte;
	typedef unsigned short ushort;
	typedef unsigned int uint;
	
	typedef int TPaletteIndex;
	typedef int TCharsetIndex;
	typedef int TColorRGB;
}