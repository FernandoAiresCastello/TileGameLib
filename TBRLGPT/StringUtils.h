/*=============================================================================

     TBRLGPT
     Tile-Based Retro-Looking Game Project Toolkit

     2018-2020 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include <string>
#include <vector>
#include "Global.h"

namespace TBRLGPT
{
	class TBRLGPT_API String
	{
	public:
		static std::string Trim(std::string text);
		static std::vector<std::string> Split(std::string& text, char separator, bool trimTokens = true);
		static std::string Format(const char* fmt, ...);
		static int ToInt(std::string str);
		static int HexToInt(std::string str);
		static std::string IntToHex(int x, bool ucase = false);
		static unsigned int BinaryToInt(std::string str);
		static std::string IntToBinary(unsigned int x);
		static std::string ToString(int x);
		static bool StartsWith(std::string text, char ch);
		static bool EndsWith(std::string text, char ch);
		static bool StartsWith(std::string text, std::string prefix);
		static bool EndsWith(std::string text, std::string suffix);
		static bool StartsWithNumber(std::string text);
		static bool IsNumber(std::string text);
		static std::string First(std::string text, int count);
		static std::string Last(std::string text, int count);
		static std::string RemoveFirst(std::string text);
		static std::string RemoveLast(std::string text);
		static std::string RemoveFirstAndLast(std::string text);
		static std::string Skip(std::string text, int count);
		static std::string ToUpper(std::string text);
		static std::string ToLower(std::string text);
		static std::string RemoveAll(std::string text, std::string chars);
		static int ShiftChar(int ch);
		static std::string PadZero(int number, int digits);
		static bool Contains(std::string text, char search);
		static bool Contains(std::string text, std::string search);
		static std::string Join(std::vector<std::string> strings, std::string inBetween = "");
		static std::string Repeat(std::string text, int times);
		static int FindFirst(std::string text, char ch);
		static int FindFirst(std::string text, std::string substring);
		static int FindLast(std::string text, char ch);
		static int FindLast(std::string text, std::string substring);
		static std::string Replace(std::string text, std::string search, std::string repl);
	};
}
