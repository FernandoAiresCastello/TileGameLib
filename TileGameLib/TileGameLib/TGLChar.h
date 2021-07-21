/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once

#include <vector>
#include <string>
#include "TGLGlobal.h"
#include "TGLClass.h"

namespace TileGameLib
{
	class TILEGAMELIB_API TGLChar : TGLClass
	{
	public:
		static const int Width;
		static const int Height;
		static const int Size;

		byte PixelRow0, PixelRow1, PixelRow2, PixelRow3;
		byte PixelRow4, PixelRow5, PixelRow6, PixelRow7;

		TGLChar();
		TGLChar(byte row0, byte row1, byte row2, byte row3, byte row4, byte row5, byte row6, byte row7);
		TGLChar(const TGLChar& other);
		~TGLChar();

		bool Equals(TGLChar& ch);
		void SetEqual(TGLChar& other);
		void Clear();
		std::vector<byte> GetBytes();
		void SetFromBytes(byte row0, byte row1, byte row2, byte row3, byte row4, byte row5, byte row6, byte row7);
		void SetFromBytes(std::vector<byte> bytes);
		void SetFromBinaryString(std::string binary);
		void SetFromBinaryString(char* binary);
		std::string ToBinaryString();
		void ToBinaryString(char* dest);
	};
}
