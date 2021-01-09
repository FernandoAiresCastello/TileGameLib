/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#ifdef DLLEXPORTS
	#define TBRLGPT_API __declspec(dllexport)
#else
	#define TBRLGPT_API __declspec(dllimport)
#endif

#ifndef NULL
	#define NULL 0
#endif

namespace TBRLGPT
{
	typedef unsigned char byte;
	typedef unsigned short ushort;
	typedef unsigned int uint;

	static const int TempStrBufferLength = 1000;
}
