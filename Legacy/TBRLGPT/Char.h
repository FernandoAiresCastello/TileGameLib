/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include <vector>
#include <string>
#include "Global.h"

namespace TBRLGPT
{
	class TBRLGPT_API Char
	{
	public:
		static const int Width;
		static const int Height;
		static const int Size;

		byte PixelRow0, PixelRow1, PixelRow2, PixelRow3;
		byte PixelRow4, PixelRow5, PixelRow6, PixelRow7;

		Char();
		~Char();

		void Clear();
		void SetEqual(Char& ch);
		std::vector<byte> GetBytes(int index);
		void SetFromBytes(byte row0, byte row1, byte row2, byte row3, byte row4, byte row5, byte row6, byte row7);
		void SetFromBytes(std::vector<byte> bytes);
		void SetFromBinaryString(std::string binary);
		void SetFromBinaryString(char* binary);
		std::string ToBinaryString();
		void ToBinaryString(char* dest);
	};
}
