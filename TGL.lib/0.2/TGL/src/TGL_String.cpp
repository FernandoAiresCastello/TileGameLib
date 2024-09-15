#include <cstdarg>
#include <algorithm>
#include <sstream>
#include "TGL_String.h"

namespace TGL
{
	constexpr int fmt_buf_maxlen = 1024;

	String::String() : value("") {}
	String::String(const char* str) : value(str) {}
	String::String(const String& other) : value(other.value) {}
	String::String(const std::string& other) : value(other) {}
	String::String(const char& single_char) : value(1, single_char) {}
	String::String(String&& other) noexcept : value(std::move(other.value)) {}
	String::String(int value) : value(FromInt(value)) {}

	String::operator const::std::string&() const
	{
		return (const std::string&)value;
	}

	bool String::operator==(const String& other) const
	{
		return value == other.value;
	}

	String& String::operator=(const char* other)
	{
		value = other;
		return *this;
	}

	String& String::operator=(const String& other)
	{
		if (this != &other)
			value = other.value;

		return *this;
	}

	String& String::operator=(const std::string& other)
	{
		value = other;
		return *this;
	}

	String& String::operator=(String&& other) noexcept
	{
		if (this != &other)
			value = std::move(other.value);

		return *this;
	}

	char& String::operator[](size_t index)
	{
		return value[index];
	}

	const char& String::operator[](size_t index) const
	{
		return value[index];
	}

	String& String::operator+=(const String& other)
	{
		value += other.value;
		return *this;
	}

	String& String::operator+=(const int& ch)
	{
		value.push_back(ch);
		return *this;
	}

	String String::operator+(const String& other) const
	{
		return String(value + other.value);
	}

	const std::string& String::Sstr() const
	{
		return value;
	}

	const char* String::Cstr() const noexcept
	{
		return value.c_str();
	}

	size_t String::Length() const noexcept
	{
		return value.length();
	}

	bool String::HasLength(int len) const noexcept
	{
		return value.length() == len;
	}

	bool String::HasLength(int min, int max) const noexcept
	{
		return value.length() >= min && value.length() <= max;
	}

	int String::ToInt() const
	{
		String str = String(value).Trim();
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

	float String::ToFloat() const
	{
		float float_value = 0.0f;

		String str = String(value).Trim();

		bool sign = str[0] == '-';
		if (sign)
			str = str.Skip(1);

		float_value = (float)std::atof(str.Cstr());

		return sign ? -float_value : float_value;
	}

	void String::Clear() noexcept
	{
		value.clear();
	}

	bool String::Empty() const noexcept
	{
		return value.empty();
	}

	bool String::IsNumber() const noexcept
	{
		std::string text = value;
		if (text.starts_with("-"))
			text = Skip(1);

		std::string::const_iterator it = text.begin();
		while (it != text.end() && std::isdigit(*it)) ++it;
		return !text.empty() && it == text.end();
	}

	String String::ToUpper() const
	{
		std::string result = value;

		for (unsigned i = 0; i < result.size(); i++)
			result[i] = toupper(result[i]);

		return result;
	}

	String String::ToLower() const
	{
		std::string result = value;

		for (unsigned i = 0; i < result.size(); i++)
			result[i] = tolower(result[i]);

		return result;
	}

	String String::Trim() const
	{
		size_t first = value.find_first_not_of(" \t\n\r");
		if (first == std::string::npos)
			return "";

		size_t last = value.find_last_not_of(" \t\n\r");
		return value.substr(first, last - first + 1);
	}

	String String::Skip(int count) const
	{
		return RemoveFirst(count);
	}

	String String::RemoveFirst(int count) const
	{
		if (count > value.length())
			return "";

		return value.substr(count);
	}

	String String::RemoveLast(int count) const
	{
		if (count > value.length())
			return "";

		return value.substr(0, value.length() - count);
	}

	String String::RemoveFirstAndLast(int count) const
	{
		return RemoveFirst(count).RemoveLast(count);
	}

	String String::GetFirst(int count) const
	{
		return value.substr(0, count);
	}

	String String::GetLast(int count) const
	{
		if (value.size() < (unsigned)count)
			return value;

		return value.substr(value.size() - count, count);
	}

	List<String> String::Split(char delim) const
	{
		List<String> elems;
		std::string item;
		std::stringstream ss(value);

		while (std::getline(ss, item, delim)) {
			String trimmed_item(item);
			if (!trimmed_item.Empty())
				elems.push_back(trimmed_item.Trim());
		}

		return elems;
	}

	List<String> String::SplitChunks(int chunk_size) const
	{
		List<String> tokens;
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

	String String::Substr(int first) const
	{
		return value.substr(first);
	}

	String String::Substr(int first, int last) const
	{
		last++;

		if (first < 0)
			first = 0;
		if (last > value.length() || last < first)
			return "";

		return value.substr(first, last - first);
	}

	String String::Truncate(int max_length) const
	{
		if (value.length() > max_length)
			return value.substr(0, max_length);
		
		return value;
	}

	String String::Replace(const String& original, const String& replacement) const
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

	String String::Replace(const char& original, const char& replacement) const
	{
		String replaced;

		for (auto& current : value) {
			if (current == original)
				replaced += replacement;
			else
				replaced += current;
		}

		return replaced;
	}

	String String::RemoveAll(const String& chars) const
	{
		std::string result = value;

		for (unsigned int i = 0; i < chars.Length(); i++)
			result.erase(remove(result.begin(), result.end(), chars[i]), result.end());

		return result;
	}

	String String::Reverse() const
	{
		std::string reversed = value;
		std::reverse(reversed.begin(), reversed.end());
		return reversed;
	}

	bool String::StartsWith(const String& prefix) const
	{
		return value.starts_with(prefix.Sstr());
	}

	bool String::EndsWith(const String& suffix) const
	{
		return value.ends_with(suffix.Sstr());
	}

	bool String::StartsAndEndsWith(const String& prefix, const String& suffix) const
	{
		return StartsWith(prefix) && EndsWith(suffix);
	}

	bool String::StartsAndEndsWith(const String& same_preffix_and_suffix) const
	{
		return StartsWith(same_preffix_and_suffix) && EndsWith(same_preffix_and_suffix);
	}

	bool String::Contains(const String& other) const
	{
		return value.find(other) != std::string::npos;
	}

	bool String::ContainsOnly(const String& chars) const
	{
		return std::all_of(value.begin(), value.end(), [&chars](char c) {
			return chars.Sstr().find(c) != std::string::npos;
		});
	}

	bool String::ContainsAny(const String& chars) const
	{
		return value.find_first_of(chars.Sstr()) != std::string::npos;
	}

	bool String::In(const List<String>& strings) const
	{
		return std::find(strings.begin(), strings.end(), value) != strings.end();
	}

	int String::IndexOf(const String& str) const
	{
		return (int)value.find(str);
	}

	int String::LastIndexOf(const String& str) const
	{
		return (int)value.find_last_not_of(str);
	}

	List<int> String::FindAll(const char& ch, size_t offset)
	{
		List<int> indexes;

		for (size_t i = offset; i < value.length(); i++) {
			if (value[i] == ch) {
				indexes.push_back((int)i);
			}
		}

		return indexes;
	}

	int String::Count(const char& ch)
	{
		return (int)FindAll(ch).size();
	}

	String String::Fmt(const char* str, ...)
	{
		char output[fmt_buf_maxlen] = { 0 };

		va_list arg;
		va_start(arg, str);
		vsprintf_s(output, str, arg);
		va_end(arg);

		return output;
	}

	String String::FromInt(int value)
	{
		return std::to_string(value);
	}

	String String::FromInt(int value, int digits)
	{
		const std::string result = FromInt(value);
		std::string padding = "";

		for (int i = 0; i < digits - result.length(); i++)
			padding += '0';

		return padding + result;
	}

	String String::FromFloat(float value)
	{
		return std::to_string(value);
	}

	String String::FromBool(bool value)
	{
		return value ? "true" : "false";
	}

	String String::ToHex(int value)
	{
		return Fmt("%x", value);
	}

	String String::ToHex(int value, int digits)
	{
		const std::string hex = ToHex(value);
		std::string padding = "";

		for (int i = 0; i < digits - hex.length(); i++)
			padding += '0';

		return padding + hex;
	}

	String String::ToBinary(int value)
	{
		std::string str = "";

		while (value != 0) {
			str = (value % 2 == 0 ? "0" : "1") + str;
			value /= 2;
		}

		return str;
	}

	String String::ToBinary(int value, int digits)
	{
		const std::string binary = ToBinary(value);
		std::string padding = "";

		for (int i = 0; i < digits - binary.length(); i++)
			padding += '0';

		return padding + binary;
	}

	String String::Join(const List<String>& str_list, const String& separator)
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

	String String::Repeat(const String& str, int count)
	{
		std::string result = "";
		for (int i = 0; i < count; i++)
			result += str;

		return result;
	}

	char String::ToUpper(char ch)
	{
		return toupper(ch);
	}

	char String::ToLower(char ch)
	{
		return tolower(ch);
	}
}
