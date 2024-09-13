#pragma once
#include <string>
#include "TGL_Globals.h"
#include "TGL_List.h"

namespace TGL
{
	class TGLAPI TGL_String
	{
	public:
		TGL_String();
		TGL_String(const char* str);
		TGL_String(const TGL_String& other);
		TGL_String(const ::std::string& other);
		TGL_String(const char& single_char);
		TGL_String(TGL_String&& other) noexcept;
		TGL_String(int value);
		~TGL_String() = default;

		operator const ::std::string&() const;
		bool operator==(const TGL_String& other) const;
		TGL_String& operator=(const char* other);
		TGL_String& operator=(const TGL_String& other);
		TGL_String& operator=(const ::std::string& other);
		TGL_String& operator=(TGL_String&& other) noexcept;
		char& operator[](size_t index);
		const char& operator[](size_t index) const;
		TGL_String& operator+=(const TGL_String& other);
		TGL_String& operator+=(const int& ch);
		TGL_String operator+(const TGL_String& other) const;

		static TGL_String Fmt(const char* str, ...);
		static TGL_String FromInt(int value);
		static TGL_String FromInt(int value, int digits);
		static TGL_String FromFloat(float value);
		static TGL_String FromBool(bool value);
		static TGL_String ToHex(int value);
		static TGL_String ToHex(int value, int digits);
		static TGL_String ToBinary(int value);
		static TGL_String ToBinary(int value, int digits);
		static TGL_String Join(const TGL_List<TGL_String>& str_list, const TGL_String& separator);
		static TGL_String Repeat(const TGL_String& str, int count);
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
		TGL_String ToUpper() const;
		TGL_String ToLower() const;
		TGL_String Trim() const;
		TGL_String Skip(int count) const;
		TGL_String RemoveFirst(int count = 1) const;
		TGL_String RemoveLast(int count = 1) const;
		TGL_String RemoveFirstAndLast(int count = 1) const;
		TGL_String GetFirst(int count) const;
		TGL_String GetLast(int count) const;
		TGL_List<TGL_String> Split(char delim = ' ') const;
		TGL_List<TGL_String> SplitChunks(int chunk_size) const;
		TGL_String Substr(int first) const;
		TGL_String Substr(int first, int last) const;
		TGL_String Replace(const TGL_String& original, const TGL_String& replacement) const;
		TGL_String Replace(const char& original, const char& replacement) const;
		TGL_String RemoveAll(const TGL_String& chars) const;
		TGL_String Reverse() const;
		bool StartsWith(const TGL_String& prefix) const;
		bool EndsWith(const TGL_String& suffix) const;
		bool StartsAndEndsWith(const TGL_String& prefix, const TGL_String& suffix) const;
		bool StartsAndEndsWith(const TGL_String& same_preffix_and_suffix) const;
		bool Contains(const TGL_String& other) const;
		bool ContainsOnly(const TGL_String& chars) const;
		bool ContainsAny(const TGL_String& chars) const;
		bool In(const TGL_List<TGL_String>& strings) const;
		int IndexOf(const TGL_String& str) const;
		int LastIndexOf(const TGL_String& str) const;
		TGL_List<int> FindAll(const char& ch, size_t offset = 0U);
		int Count(const char& ch);

	private:
		::std::string value;
	};
}

namespace std
{
	template<>
	struct hash<TGL::TGL_String> {
		size_t operator()(const TGL::TGL_String& wrapper) const {
			return hash<::std::string>{}(wrapper.Sstr());
		}
	};
}
