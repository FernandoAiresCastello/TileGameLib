/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include <string>
#include <vector>
#include "Global.h"
#include "Char.h"

namespace TBRLGPT
{
	class TBRLGPT_API Charset
	{
	public:
		Charset();
		~Charset();

		Char& Get(int index);
		std::vector<byte> GetBytes(int index);
		int GetSize();
		void Clear();
		void Clear(int size);
		void AddEmptyChar();
		void AddEmptyChars(int count);
		void Set(int chr, int row1, int row2, int row3, int row4, int row5, int row6, int row7, int row8);
		void Set(int chr, std::string row1, std::string row2, std::string row3, std::string row4, std::string row5, std::string row6, std::string row7, std::string row8);
		void Set(int ix, Char& ch);
		void CopyChar(int dstix, int srcix);
		void InitDefaultCharset();

	private:
		std::vector<Char> Chars;
	};
}
