#pragma once
#include <string>
#include "TGL_Globals.h"
#include "TGL_List.h"

namespace TGL
{
	class TGLAPI String
	{
	public:
		String();
		String(const char* str);
		String(const String& other);
		String(const ::std::string& other);
		String(const char& single_char);
		String(String&& other) noexcept;
		String(int value);
		~String() = default;

		operator const ::std::string&() const;
		bool operator==(const String& other) const;
		String& operator=(const char* other);
		String& operator=(const String& other);
		String& operator=(const ::std::string& other);
		String& operator=(String&& other) noexcept;
		char& operator[](size_t index);
		const char& operator[](size_t index) const;
		String& operator+=(const String& other);
		String& operator+=(const int& ch);
		String operator+(const String& other) const;

		static String Fmt(const char* str, ...);
		static String FromInt(int value);
		static String FromInt(int value, int digits);
		static String FromFloat(float value);
		static String FromBool(bool value);
		static String ToHex(int value);
		static String ToHex(int value, int digits);
		static String ToBinary(int value);
		static String ToBinary(int value, int digits);
		static String Join(const List<String>& str_list, const String& separator);
		static String Repeat(const String& str, int count);
		static char ToUpper(char ch);
		static char ToLower(char ch);

		const ::std::string& Sstr() const;
		const char* Cstr() const noexcept;
		size_t Length() const noexcept;
		bool HasLength(int len) const noexcept;
		bool HasLength(int min, int max) const noexcept;
		int ToInt() const;
		float ToFloat() const;
		void Clear() noexcept;
		bool Empty() const noexcept;
		bool IsNumber() const noexcept;
		String ToUpper() const;
		String ToLower() const;
		String Trim() const;
		String Skip(int count) const;
		String RemoveFirst(int count = 1) const;
		String RemoveLast(int count = 1) const;
		String RemoveFirstAndLast(int count = 1) const;
		String GetFirst(int count) const;
		String GetLast(int count) const;
		List<String> Split(char delim = ' ') const;
		List<String> SplitChunks(int chunk_size) const;
		String Substr(int first) const;
		String Substr(int first, int last) const;
		String Replace(const String& original, const String& replacement) const;
		String Replace(const char& original, const char& replacement) const;
		String RemoveAll(const String& chars) const;
		String Reverse() const;
		bool StartsWith(const String& prefix) const;
		bool EndsWith(const String& suffix) const;
		bool StartsAndEndsWith(const String& prefix, const String& suffix) const;
		bool StartsAndEndsWith(const String& same_preffix_and_suffix) const;
		bool Contains(const String& other) const;
		bool ContainsOnly(const String& chars) const;
		bool ContainsAny(const String& chars) const;
		bool In(const List<String>& strings) const;
		int IndexOf(const String& str) const;
		int LastIndexOf(const String& str) const;
		List<int> FindAll(const char& ch, size_t offset = 0U);
		int Count(const char& ch);

	private:
		::std::string value;
	};
}

namespace std
{
	template<>
	struct hash<TGL::String> {
		size_t operator()(const TGL::String& wrapper) const {
			return hash<::std::string>{}(wrapper.Sstr());
		}
	};
}
