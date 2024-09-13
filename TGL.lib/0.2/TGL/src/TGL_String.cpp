#include <cstdarg>
#include <algorithm>
#include <sstream>
#include "TGL_String.h"

namespace TGL
{
	constexpr int fmt_buf_maxlen = 1024;

	TGL_String::TGL_String() : value("") {}
	TGL_String::TGL_String(const char* str) : value(str) {}
	TGL_String::TGL_String(const TGL_String& other) : value(other.value) {}
	TGL_String::TGL_String(const std::string& other) : value(other) {}
	TGL_String::TGL_String(const char& single_char) : value(1, single_char) {}
	TGL_String::TGL_String(TGL_String&& other) noexcept : value(std::move(other.value)) {}
	TGL_String::TGL_String(int value) : value(FromInt(value)) {}

	TGL_String::operator const::std::string&() const
	{
		return (const std::string&)value;
	}

	bool TGL_String::operator==(const TGL_String& other) const
	{
		return value == other.value;
	}

	TGL_String& TGL_String::operator=(const char* other)
	{
		value = other;
		return *this;
	}

	TGL_String& TGL_String::operator=(const TGL_String& other)
	{
		if (this != &other)
			value = other.value;

		return *this;
	}

	TGL_String& TGL_String::operator=(const std::string& other)
	{
		value = other;
		return *this;
	}

	TGL_String& TGL_String::operator=(TGL_String&& other) noexcept
	{
		if (this != &other)
			value = std::move(other.value);

		return *this;
	}

	char& TGL_String::operator[](size_t index)
	{
		return value[index];
	}

	const char& TGL_String::operator[](size_t index) const
	{
		return value[index];
	}

	TGL_String& TGL_String::operator+=(const TGL_String& other)
	{
		value += other.value;
		return *this;
	}

	TGL_String& TGL_String::operator+=(const int& ch)
	{
		value.push_back(ch);
		return *this;
	}

	TGL_String TGL_String::operator+(const TGL_String& other) const
	{
		return TGL_String(value + other.value);
	}

	const std::string& TGL_String::Sstr() const
	{
		return value;
	}

	const char* TGL_String::Cstr() const noexcept
	{
		return value.c_str();
	}

	size_t TGL_String::Length() const noexcept
	{
		return value.length();
	}

	bool TGL_String::HasLength(int len) const noexcept
	{
		return value.length() == len;
	}

	bool TGL_String::HasLength(int min, int max) const noexcept
	{
		return value.length() >= min && value.length() <= max;
	}

	int TGL_String::ToInt() const
	{
		TGL_String str = TGL_String(value).Trim();
		if (str.Empty())
			return 0;

		bool negative = str[0] == '-';
		bool positive = str[0] == '+';

		if (negative || positive)
			str = str.Skip(1);

		int int_value = 0;

		try {
			if ((str[0] == '0' && str[1] == 'x') || (str[0] == '&' && toupper(str[1]) == 'H'))
				int_value = std::stoi(str.Skip(2), nullptr, 16);
			else if ((str[0] == '0' && str[1] == 'b') || (str[0] == '&' && toupper(str[1]) == 'B'))
				int_value = std::stoi(str.Skip(2), nullptr, 2);
			else if (isdigit(str[0]))
				int_value = std::stoi(str);
		}
		catch (std::out_of_range) {
			int_value = 0;
		}

		return negative ? -int_value : int_value;
	}

	float TGL_String::ToFloat() const
	{
		float float_value = 0.0f;

		TGL_String str = TGL_String(value).Trim();

		bool sign = str[0] == '-';
		if (sign)
			str = str.Skip(1);

		float_value = (float)std::atof(str.Cstr());

		return sign ? -float_value : float_value;
	}

	void TGL_String::Clear() noexcept
	{
		value.clear();
	}

	bool TGL_String::Empty() const noexcept
	{
		return value.empty();
	}

	bool TGL_String::IsNumber() const noexcept
	{
		std::string text = value;
		if (text.starts_with("-"))
			text = Skip(1);

		std::string::const_iterator it = text.begin();
		while (it != text.end() && std::isdigit(*it)) ++it;
		return !text.empty() && it == text.end();
	}

	TGL_String TGL_String::ToUpper() const
	{
		std::string result = value;

		for (unsigned i = 0; i < result.size(); i++)
			result[i] = toupper(result[i]);

		return result;
	}

	TGL_String TGL_String::ToLower() const
	{
		std::string result = value;

		for (unsigned i = 0; i < result.size(); i++)
			result[i] = tolower(result[i]);

		return result;
	}

	TGL_String TGL_String::Trim() const
	{
		size_t first = value.find_first_not_of(" \t\n\r");
		if (first == std::string::npos)
			return "";

		size_t last = value.find_last_not_of(" \t\n\r");
		return value.substr(first, last - first + 1);
	}

	TGL_String TGL_String::Skip(int count) const
	{
		return RemoveFirst(count);
	}

	TGL_String TGL_String::RemoveFirst(int count) const
	{
		if (count > value.length())
			return "";

		return value.substr(count);
	}

	TGL_String TGL_String::RemoveLast(int count) const
	{
		if (count > value.length())
			return "";

		return value.substr(0, value.length() - count);
	}

	TGL_String TGL_String::RemoveFirstAndLast(int count) const
	{
		return RemoveFirst(count).RemoveLast(count);
	}

	TGL_String TGL_String::GetFirst(int count) const
	{
		return value.substr(0, count);
	}

	TGL_String TGL_String::GetLast(int count) const
	{
		if (value.size() < (unsigned)count)
			return value;

		return value.substr(value.size() - count, count);
	}

	TGL_List<TGL_String> TGL_String::Split(char delim) const
	{
		TGL_List<TGL_String> elems;
		std::string item;
		std::stringstream ss(value);

		while (std::getline(ss, item, delim)) {
			TGL_String trimmed_item(item);
			if (!trimmed_item.Empty())
				elems.push_back(trimmed_item.Trim());
		}

		return elems;
	}

	TGL_List<TGL_String> TGL_String::SplitChunks(int chunk_size) const
	{
		TGL_List<TGL_String> tokens;
		std::string token = "";

		for (int i = 0; i < value.length(); i++) {
			token += value[i];
			if (token.length() == chunk_size) {
				tokens.push_back(token);
				token = "";
			}
		}

		if (!token.empty())
			tokens.push_back(token);

		return tokens;
	}

	TGL_String TGL_String::Substr(int first) const
	{
		return value.substr(first);
	}

	TGL_String TGL_String::Substr(int first, int last) const
	{
		last++;

		if (first < 0)
			first = 0;
		if (last > value.length() || last < first)
			return "";

		return value.substr(first, last - first);
	}

	TGL_String TGL_String::Replace(const TGL_String& original, const TGL_String& replacement) const
	{
		if (original.Empty())
			return "";

		std::string replaced = value;
		size_t startPos = 0;

		while ((startPos = replaced.find(original, startPos)) != std::string::npos) {
			replaced.replace(startPos, original.Length(), replacement);
			startPos += replacement.Length();
		}

		return replaced;
	}

	TGL_String TGL_String::Replace(const char& original, const char& replacement) const
	{
		TGL_String replaced;

		for (auto& current : value) {
			if (current == original)
				replaced += replacement;
			else
				replaced += current;
		}

		return replaced;
	}

	TGL_String TGL_String::RemoveAll(const TGL_String& chars) const
	{
		std::string result = value;

		for (unsigned int i = 0; i < chars.Length(); i++)
			result.erase(remove(result.begin(), result.end(), chars[i]), result.end());

		return result;
	}

	TGL_String TGL_String::Reverse() const
	{
		std::string reversed = value;
		std::reverse(reversed.begin(), reversed.end());
		return reversed;
	}

	bool TGL_String::StartsWith(const TGL_String& prefix) const
	{
		return value.starts_with(prefix.Sstr());
	}

	bool TGL_String::EndsWith(const TGL_String& suffix) const
	{
		return value.ends_with(suffix.Sstr());
	}

	bool TGL_String::StartsAndEndsWith(const TGL_String& prefix, const TGL_String& suffix) const
	{
		return StartsWith(prefix) && EndsWith(suffix);
	}

	bool TGL_String::StartsAndEndsWith(const TGL_String& same_preffix_and_suffix) const
	{
		return StartsWith(same_preffix_and_suffix) && EndsWith(same_preffix_and_suffix);
	}

	bool TGL_String::Contains(const TGL_String& other) const
	{
		return value.find(other) != std::string::npos;
	}

	bool TGL_String::ContainsOnly(const TGL_String& chars) const
	{
		return std::all_of(value.begin(), value.end(), [&chars](char c) {
			return chars.Sstr().find(c) != std::string::npos;
		});
	}

	bool TGL_String::ContainsAny(const TGL_String& chars) const
	{
		return value.find_first_of(chars.Sstr()) != std::string::npos;
	}

	bool TGL_String::In(const TGL_List<TGL_String>& strings) const
	{
		return std::find(strings.begin(), strings.end(), value) != strings.end();
	}

	int TGL_String::IndexOf(const TGL_String& str) const
	{
		return (int)value.find(str);
	}

	int TGL_String::LastIndexOf(const TGL_String& str) const
	{
		return (int)value.find_last_not_of(str);
	}

	TGL_List<int> TGL_String::FindAll(const char& ch, size_t offset)
	{
		TGL_List<int> indexes;

		for (size_t i = offset; i < value.length(); i++) {
			if (value[i] == ch) {
				indexes.push_back((int)i);
			}
		}

		return indexes;
	}

	int TGL_String::Count(const char& ch)
	{
		return (int)FindAll(ch).size();
	}

	TGL_String TGL_String::Fmt(const char* str, ...)
	{
		char output[fmt_buf_maxlen] = { 0 };

		va_list arg;
		va_start(arg, str);
		vsprintf_s(output, str, arg);
		va_end(arg);

		return output;
	}

	TGL_String TGL_String::FromInt(int value)
	{
		return std::to_string(value);
	}

	TGL_String TGL_String::FromInt(int value, int digits)
	{
		const std::string result = FromInt(value);
		std::string padding = "";

		for (int i = 0; i < digits - result.length(); i++)
			padding += '0';

		return padding + result;
	}

	TGL_String TGL_String::FromFloat(float value)
	{
		return std::to_string(value);
	}

	TGL_String TGL_String::FromBool(bool value)
	{
		return value ? "true" : "false";
	}

	TGL_String TGL_String::ToHex(int value)
	{
		return Fmt("%x", value);
	}

	TGL_String TGL_String::ToHex(int value, int digits)
	{
		const std::string hex = ToHex(value);
		std::string padding = "";

		for (int i = 0; i < digits - hex.length(); i++)
			padding += '0';

		return padding + hex;
	}

	TGL_String TGL_String::ToBinary(int value)
	{
		std::string str = "";

		while (value != 0) {
			str = (value % 2 == 0 ? "0" : "1") + str;
			value /= 2;
		}

		return str;
	}

	TGL_String TGL_String::ToBinary(int value, int digits)
	{
		const std::string binary = ToBinary(value);
		std::string padding = "";

		for (int i = 0; i < digits - binary.length(); i++)
			padding += '0';

		return padding + binary;
	}

	TGL_String TGL_String::Join(const TGL_List<TGL_String>& str_list, const TGL_String& separator)
	{
		std::string str = "";

		for (int i = 0; i < str_list.size(); i++) {
			if (!separator.Empty()) {
				str += str_list[i];
				if (i < str_list.size() - 1) {
					str += separator;
				}
			}
			else {
				str += str_list[i];
			}
		}

		return str;
	}

	TGL_String TGL_String::Repeat(const TGL_String& str, int count)
	{
		std::string result = "";
		for (int i = 0; i < count; i++)
			result += str;

		return result;
	}

	char TGL_String::ToUpper(char ch)
	{
		return toupper(ch);
	}

	char TGL_String::ToLower(char ch)
	{
		return tolower(ch);
	}
}
