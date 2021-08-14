/*=============================================================================

	 TileGameLib
	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/
#include <cstdarg>
#include <sstream>
#include <algorithm>
#include <string>
#include <cctype>
#include <bitset>
#include "TString.h"
#include "TUtil.h"

namespace TileGameLib
{
	std::string TString::Trim(std::string text)
	{
		text.erase(0, text.find_first_not_of(" \t"));
		text.erase(text.find_last_not_of(" \t") + 1);
		return text;
	}

	std::vector<std::string> TString::Split(std::string& text, char separator, bool trimTokens)
	{
		std::vector<std::string> tokens;
		std::string token;
		std::istringstream tokenStream(text);

		while (std::getline(tokenStream, token, separator))
			tokens.push_back(trimTokens ? Trim(token) : token);

		return tokens;
	}

	std::vector<std::string> TString::SplitIntoEqualSizedStrings(std::string& text, int sizeOfEachString)
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

	std::string TString::Format(const char* fmt, ...)
	{
		char str[1000] = { 0 };
		va_list arg;
		va_start(arg, fmt);
		vsprintf(str, fmt, arg);
		va_end(arg);

		return str;
	}

	int TString::ToInt(std::string str)
	{
		if (str[0] == '0' && str[1] == 'x') {
			int value = 0;
			sscanf(str.c_str(), "%x", &value);
			return value;
		}
		else if (str[0] == '0' && str[1] == 'b') {
			return BinaryToInt(str);
		}

		return atoi(str.c_str());
	}

	int TString::HexToInt(std::string str)
	{
		if (str[0] == '0' && str[1] == 'x') {
			return ToInt(str);
		}
		return ToInt("0x" + str);
	}

	std::string TString::IntToHex(int x, bool ucase)
	{
		return ucase ? Format("%X", x) : Format("%x", x);
	}

	unsigned int TString::BinaryToInt(std::string str)
	{
		if (str[0] == '0' && str[1] == 'b') {
			str = TString::Skip(str, 2);
		}
		return std::stoi(str, nullptr, 2);
	}

	std::string TString::IntToBinary(unsigned int x)
	{
		std::string value = "";
		while (x != 0) { value = (x % 2 == 0 ? "0" : "1") + value; x /= 2; }
		return value;
	}

	std::string TString::IntToBinary(unsigned int x, int digits)
	{
		const std::string binary = IntToBinary(x);
		std::string padding = "";

		for (int i = 0; i < digits - binary.length(); i++)
			padding += '0';
		
		return padding + binary;
	}

	std::string TString::ToString(int x)
	{
		return Format("%i", x);
	}

	bool TString::StartsWith(std::string text, char ch)
	{
		return !text.empty() && text[0] == ch;
	}

	bool TString::EndsWith(std::string text, char ch)
	{
		return !text.empty() && text[text.size() - 1] == ch;
	}

	bool TString::StartsWith(std::string text, std::string prefix)
	{
		std::transform(text.begin(), text.end(), text.begin(), ::tolower);
		std::transform(prefix.begin(), prefix.end(), prefix.begin(), ::tolower);
		return text.find(prefix) == 0;
	}

	bool TString::EndsWith(std::string text, std::string suffix)
	{
		auto it = suffix.begin();
		return text.size() >= suffix.size() && std::all_of(
			std::next(text.begin(), text.size() - suffix.size()), text.end(), 
			[&it](const char & c) { return ::tolower(c) == ::tolower(*(it++)); });
	}

	bool TString::StartsAndEndsWith(std::string text, char ch)
	{
		return StartsWith(text, ch) && EndsWith(text, ch);
	}

	bool TString::StartsAndEndsWith(std::string text, std::string str)
	{
		return StartsWith(text, str) && EndsWith(text, str);
	}

	bool TString::StartsWithNumber(std::string text)
	{
		return !text.empty() && isdigit(text[0]);
	}

	bool TString::IsNumber(std::string text)
	{
		if (StartsWith(text, "-"))
			text = TString::Skip(text, 1);

		std::string::const_iterator it = text.begin();
		while (it != text.end() && std::isdigit(*it)) ++it;
		return !text.empty() && it == text.end();
	}

	std::string TString::First(std::string text, int count)
	{
		return text.substr(0, count);
	}

	std::string TString::Last(std::string text, int count)
	{
		if (text.size() < (unsigned)count)
			return text;

		return text.substr(text.size() - count, count);
	}

	std::string TString::RemoveFirst(std::string text)
	{
		if (text.size() > 0)
			return text.substr(1, text.size());

		return "";
	}

	std::string TString::RemoveLast(std::string text)
	{
		if (text.size() > 0)
			return text.substr(0, text.size() - 1);
		
		return "";
	}

	std::string TString::RemoveFirstAndLast(std::string text)
	{
		text = RemoveFirst(text);
		text = RemoveLast(text);
		return text;
	}

	std::string TString::Skip(std::string text, int count)
	{
		return text.substr(count);
	}

	std::string TString::ToUpper(std::string text)
	{
		for (unsigned i = 0; i < text.size(); i++)
			text[i] = toupper(text[i]);

		return text;
	}

	std::string TString::ToLower(std::string text)
	{
		for (unsigned i = 0; i < text.size(); i++)
			text[i] = tolower(text[i]);

		return text;
	}

	std::string TString::RemoveAll(std::string text, std::string chars)
	{
		for (unsigned int i = 0; i < chars.length(); i++) {
			text.erase(remove(text.begin(), text.end(), chars[i]), text.end());
		}
		return text;
	}

	int TString::ShiftChar(int ch)
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

	std::string TString::PadZero(int number, int digits)
	{
		std::string fmt = "%0";
		fmt += TString::ToString(digits);
		fmt += "i";

		return TString::Format(fmt.c_str(), number);
	}

	bool TString::Contains(std::string text, char search)
	{
		return text.find(search) != std::string::npos;
	}

	bool TString::Contains(std::string text, std::string search)
	{
		return text.find(search) != std::string::npos;
	}

	std::string TString::Join(std::vector<std::string> strings, std::string inBetween)
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

	std::string TString::Repeat(std::string text, int times)
	{
		std::string str = "";
		for (int i = 0; i < times; i++) {
			str += text;
		}
		return str;
	}

	int TString::FindFirst(std::string text, char ch)
	{
		int index = text.find_first_of(ch);
		return index != std::string::npos ? index : -1;
	}

	int TString::FindFirst(std::string text, std::string substring)
	{
		int index = text.find_first_of(substring);
		return index != std::string::npos ? index : -1;
	}

	int TString::FindLast(std::string text, char ch)
	{
		int index = text.find_last_of(ch);
		return index != std::string::npos ? index : -1;
	}

	int TString::FindLast(std::string text, std::string substring)
	{
		int index = text.find_last_of(substring);
		return index != std::string::npos ? index : -1;
	}

	std::string TString::Replace(std::string text, std::string search, std::string repl)
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
