/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include <string>
#include "Global.h"

namespace TBRLGPT
{
	class TBRLGPT_API Charset
	{
	public:
		static const int Size;
		static const int PixelCount;

		Charset();
		~Charset();

		byte* Get(int index);
		void Clear();
		void SetChar(int chr, int row1, int row2, int row3, int row4, int row5, int row6, int row7, int row8);
		void CopyChar(int dstix, int srcix);
		void Save(std::string filename);
		void SaveHex(std::string filename);
		void Load(std::string filename);
		void InitDefaultCharset();

	private:
		byte* Pixels;
	};
}
