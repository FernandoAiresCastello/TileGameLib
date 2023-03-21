/*=============================================================================

	 C++ Utils
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#pragma once
#include <string>
#include <vector>
#include "CppGlobal.h"

namespace CppUtils
{
	class String
	{
	public:
		// === Format ===
		static std::string Format(const char* fmt, ...);

		// === Trim ===
		static std::string Trim(std::string text);
		static std::string TrimLeft(std::string text);
		static std::string TrimRight(std::string text);
		
		// === Split ===
		static std::vector<std::string> Split(std::string text, char separator, bool trimTokens);
		static std::vector<std::string> Split(std::string text, std::string separator, bool trimTokens);
		static std::vector<std::string> SplitIntoEqualSizedStrings(std::string text, int sizeOfEachString);
		
		// === String-Number Conversion ===
		static int ToInt(std::string str);
		static int ToInt(char digitAscii);
		static int ToFloat(std::string str);
		
		// === Number-String Conversion ===
		static std::string IntToHex(int x, bool ucase = false);
		static std::string IntToBinary(unsigned int x);
		static std::string IntToBinary(unsigned int x, int digits);
		static std::string ToString(int x);
		
		// === Preffix & Suffix ===
		static bool StartsWith(std::string text, char ch);
		static bool StartsWith(std::string text, std::string prefix);
		static bool StartsWithNumber(std::string text);
		static bool StartsWithLetter(std::string text);
		static bool EndsWith(std::string text, char ch);
		static bool EndsWith(std::string text, std::string suffix);
		static bool StartsAndEndsWith(std::string text, char ch);
		static bool StartsAndEndsWith(std::string text, std::string str);
		static bool IsEnclosedBy(std::string text, char preffix, char suffix);
		static bool IsEnclosedBy(std::string text, std::string preffix, std::string suffix);
		
		// === Remove Parts ===
		static std::string RemoveFirst(std::string text);
		static std::string RemoveLast(std::string text);
		static std::string RemoveFirstAndLast(std::string text);
		static std::string Skip(std::string text, int count);
		static std::string RemoveAll(std::string text, std::string chars);

		// === Substrings ===
		static std::string Substring(std::string text, int begin, int end);
		static std::string Substring(std::string text, int begin);
		static std::string GetFirstChars(std::string text, int count);
		static std::string GetLastChars(std::string text, int count);

		// === Replace ===
		static std::string Replace(std::string text, std::string search, std::string repl);
		
		// === Contains ===
		static bool Contains(std::string text, char character);
		static bool Contains(std::string text, std::string substring);

		// === Search ===
		static size_t IndexOf(std::string text, char character, size_t offset = 0U);
		static size_t LastIndexOf(std::string text, char character, size_t offset = std::string::npos);
		static size_t FindFirst(std::string text, char ch, size_t offset = 0U);
		static size_t FindFirst(std::string text, std::string substring, size_t offset = 0U);
		static size_t FindLast(std::string text, char ch, size_t offset = std::string::npos);
		static size_t FindLast(std::string text, std::string substring, size_t offset = std::string::npos);
		static std::vector<int> FindAll(std::string text, char ch, size_t offset = 0U);
		
		// === Concatenation ===
		static std::string Join(std::vector<std::string> strings, std::string inBetween = "");
		static std::string Repeat(char ch, int times);
		static std::string Repeat(std::string text, int times);

		// === Character Casing ===
		static std::string ToUpper(std::string text);
		static std::string ToLower(std::string text);
		static int ToUpper(int ch);
		static int ToLower(int ch);

		// === Padding ===
		static std::string PadZero(int number, int digits);
		
		// === Classification ===
		static bool IsNumber(std::string text);
		
		// === Transformations ===
		static int ShiftChar(int ch);
	};
}
