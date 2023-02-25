/*=============================================================================

	 C++ Utils
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#include <cstdarg>
#include <sstream>
#include <algorithm>
#include <functional> 
#include <locale>
#include <string>
#include <cctype>
#include <bitset>
#include "CppString.h"

namespace CppUtils
{
	std::string String::Trim(std::string text)
	{
		return TrimLeft(TrimRight(text));
	}

	std::string String::TrimLeft(std::string text)
	{
		text.erase(text.begin(), std::find_if(text.begin(), text.end(),
			std::not1(std::ptr_fun<int, int>(std::isspace))));
		return text;
	}

	std::string String::TrimRight(std::string text)
	{
		text.erase(std::find_if(text.rbegin(), text.rend(),
			std::not1(std::ptr_fun<int, int>(std::isspace))).base(), text.end());
		return text;
	}

	std::vector<std::string> String::Split(std::string text, char separator, bool trimTokens)
	{
		std::stringstream ss(text);
		std::string item;
		std::vector<std::string> elems;

		while (std::getline(ss, item, separator))
			elems.push_back(trimTokens ? Trim(item) : item);

		return elems;
	}

	std::vector<std::string> String::Split(std::string text, std::string separator, bool trimTokens)
	{
		size_t pos = 0;
		std::string item;
		std::vector<std::string> elems;
		bool finished = false;

		while (!finished) {
			pos = text.find(separator);
			item = text.substr(0, pos);
			elems.push_back(trimTokens ? Trim(item) : item);

			if (pos == std::string::npos)
				finished = true;
			else
				text.erase(0, pos + separator.length());
		}

		return elems;
	}

	std::vector<std::string> String::SplitIntoEqualSizedStrings(std::string text, int sizeOfEachString)
	{
		std::vector<std::string> tokens;
		std::string token = "";
		
		for (int i = 0; i < text.length(); i++) {
			token += text[i];
			if (token.length() == sizeOfEachString) {
				tokens.push_back(token);
				token = "";
			}
		}

		return tokens;
	}

	std::string String::Format(const char* fmt, ...)
	{
		char str[1000] = { 0 };
		va_list arg;
		va_start(arg, fmt);
		vsprintf(str, fmt, arg);
		va_end(arg);

		return str;
	}

	int String::ToInt(std::string str)
	{
		int value = 0;

		bool sign = str[0] == '-';
		if (sign)
			str = String::Skip(str, 1);

		if (str[0] == '0' && str[1] == 'x')
			sscanf(str.c_str(), "%x", &value);
		else if (str[0] == '0' && str[1] == 'b')
			value = stoi(String::Skip(str, 2), nullptr, 2);
		else
			value = atoi(str.c_str());

		return sign ? -value : value;
	}

	int String::ToInt(char digitAscii)
	{
		return digitAscii - '0';
	}

	int String::ToFloat(std::string str)
	{
		int value = 0;

		bool sign = str[0] == '-';
		if (sign)
			str = String::Skip(str, 1);

		value = atof(str.c_str());

		return sign ? -value : value;
	}

	std::string String::IntToHex(int x, bool ucase)
	{
		return ucase ? Format("%X", x) : Format("%x", x);
	}

	std::string String::IntToBinary(unsigned int x)
	{
		std::string value = "";
		while (x != 0) { value = (x % 2 == 0 ? "0" : "1") + value; x /= 2; }
		return value;
	}

	std::string String::IntToBinary(unsigned int x, int digits)
	{
		const std::string binary = IntToBinary(x);
		std::string padding = "";

		for (int i = 0; i < digits - binary.length(); i++)
			padding += '0';
		
		return padding + binary;
	}

	std::string String::ToString(int x)
	{
		return Format("%i", x);
	}

	bool String::StartsWith(std::string text, char ch)
	{
		return !text.empty() && text[0] == ch;
	}

	bool String::EndsWith(std::string text, char ch)
	{
		return !text.empty() && text[text.size() - 1] == ch;
	}

	bool String::StartsWith(std::string text, std::string prefix)
	{
		std::transform(text.begin(), text.end(), text.begin(), ::tolower);
		std::transform(prefix.begin(), prefix.end(), prefix.begin(), ::tolower);
		return text.find(prefix) == 0;
	}

	bool String::EndsWith(std::string text, std::string suffix)
	{
		auto it = suffix.begin();
		return text.size() >= suffix.size() && std::all_of(
			std::next(text.begin(), text.size() - suffix.size()), text.end(), 
			[&it](const char & c) { return ::tolower(c) == ::tolower(*(it++)); });
	}

	bool String::StartsAndEndsWith(std::string text, char ch)
	{
		return StartsWith(text, ch) && EndsWith(text, ch);
	}

	bool String::StartsAndEndsWith(std::string text, std::string str)
	{
		return StartsWith(text, str) && EndsWith(text, str);
	}

	bool String::IsEnclosedBy(std::string text, char preffix, char suffix)
	{
		return StartsWith(text, preffix) && EndsWith(text, suffix);
	}

	bool String::IsEnclosedBy(std::string text, std::string preffix, std::string suffix)
	{
		return StartsWith(text, preffix) && EndsWith(text, suffix);
	}

	bool String::StartsWithNumber(std::string text)
	{
		return !text.empty() && isdigit(text[0]);
	}

	bool String::StartsWithLetter(std::string text)
	{
		return !text.empty() && isalpha(text[0]);
	}

	bool String::IsNumber(std::string text)
	{
		if (StartsWith(text, "-"))
			text = String::Skip(text, 1);

		std::string::const_iterator it = text.begin();
		while (it != text.end() && std::isdigit(*it)) ++it;
		return !text.empty() && it == text.end();
	}

	std::string String::Substring(std::string text, int begin, int end)
	{
		if (begin < 0)
			begin = 0;
		if (begin >= text.length() || end < begin)
			return "";

		return text.substr(begin, end - begin);
	}

	std::string String::Substring(std::string text, int begin)
	{
		if (begin < 0)
			begin = 0;
		if (begin >= text.length())
			return "";

		return text.substr(begin);
	}

	std::string String::GetFirstChars(std::string text, int count)
	{
		return text.substr(0, count);
	}

	std::string String::GetLastChars(std::string text, int count)
	{
		if (text.size() < (unsigned)count)
			return text;

		return text.substr(text.size() - count, count);
	}

	std::string String::RemoveFirst(std::string text)
	{
		if (text.size() > 0)
			return text.substr(1, text.size());

		return "";
	}

	std::string String::RemoveLast(std::string text)
	{
		if (text.size() > 0)
			return text.substr(0, text.size() - 1);
		
		return "";
	}

	std::string String::RemoveFirstAndLast(std::string text)
	{
		text = RemoveFirst(text);
		text = RemoveLast(text);
		return text;
	}

	std::string String::Skip(std::string text, int count)
	{
		return text.substr(count);
	}

	std::string String::ToUpper(std::string text)
	{
		for (unsigned i = 0; i < text.size(); i++)
			text[i] = toupper(text[i]);

		return text;
	}

	std::string String::ToLower(std::string text)
	{
		for (unsigned i = 0; i < text.size(); i++)
			text[i] = tolower(text[i]);

		return text;
	}

	int String::ToUpper(int ch)
	{
		return toupper(ch);
	}

	int String::ToLower(int ch)
	{
		return tolower(ch);
	}

	std::string String::RemoveAll(std::string text, std::string chars)
	{
		for (unsigned int i = 0; i < chars.length(); i++) {
			text.erase(remove(text.begin(), text.end(), chars[i]), text.end());
		}
		return text;
	}

	int String::ShiftChar(int ch)
	{
		switch (ch) {
			case '1': return '!';
			case '2': return '@';
			case '3': return '#';
			case '4': return '$';
			case '5': return '%';
			case '6': return '^';
			case '7': return '&';
			case '8': return '*';
			case '9': return '(';
			case '0': return ')';
			case '-': return '_';
			case '=': return '+';
			case '\'': return '"';
			case '[': return '{';
			case ']': return '}';
			case '~': return '^';
			case '\\': return '|';
			case ',': return '<';
			case '.': return '>';
			case ';': return ':';
			case '/': return '?';
		}
		return ch;
	}

	std::string String::PadZero(int number, int digits)
	{
		std::string fmt = "%0";
		fmt += String::ToString(digits);
		fmt += "i";

		return String::Format(fmt.c_str(), number);
	}

	bool String::Contains(std::string text, char character)
	{
		std::string substring = std::string(1, character);
		size_t pos = text.find(substring);
		return pos != std::string::npos;
	}

	bool String::Contains(std::string text, std::string substring)
	{
		size_t pos = text.find(substring);
		return pos != std::string::npos;
	}

	size_t String::IndexOf(std::string text, char character, size_t offset)
	{
		return text.find(character, offset);
	}

	size_t String::LastIndexOf(std::string text, char character, size_t offset)
	{
		return text.find_last_of(character, offset);
	}

	std::string String::Join(std::vector<std::string> strings, std::string inBetween)
	{
		std::string str = "";
		for (int i = 0; i < strings.size(); i++) {
			if (!inBetween.empty()) {
				str += strings[i] + inBetween;
			}
			else {
				str += strings[i];
			}
		}
		return str;
	}

	std::string String::Repeat(char ch, int times)
	{
		std::string str = "";
		for (int i = 0; i < times; i++) {
			str.push_back(ch);
		}
		return str;
	}

	std::string String::Repeat(std::string text, int times)
	{
		std::string str = "";
		for (int i = 0; i < times; i++) {
			str += text;
		}
		return str;
	}

	size_t String::FindFirst(std::string text, char ch, size_t offset)
	{
		return text.find_first_of(ch, offset);
	}

	size_t String::FindFirst(std::string text, std::string substring, size_t offset)
	{
		return text.find_first_of(substring, offset);
	}

	size_t String::FindLast(std::string text, char ch, size_t offset)
	{
		return text.find_last_of(ch);
	}

	size_t String::FindLast(std::string text, std::string substring, size_t offset)
	{
		return text.find_last_of(substring, offset);
	}

	std::vector<int> String::FindAll(std::string text, char ch, size_t offset)
	{
		std::vector<int> indexes;

		for (int i = offset; i < text.length(); i++) {
			if (text[i] == ch) {
				indexes.push_back(i);
			}
		}

		return indexes;
	}

	std::string String::Replace(std::string text, std::string search, std::string repl)
	{
		std::string replaced = std::string(text);
		if (search.empty())
			return "";
		size_t startPos = 0;
		while ((startPos = replaced.find(search, startPos)) != std::string::npos) {
			replaced.replace(startPos, search.length(), repl);
			startPos += repl.length();
		}
		return replaced;
	}
}
