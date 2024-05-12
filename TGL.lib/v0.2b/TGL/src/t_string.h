#pragma once
#include <string>
#include "t_list.h"

namespace tgl
{
	class t_string
	{
	public:
		t_string();
		t_string(const char* str);
		t_string(const t_string& other);
		t_string(const std::string& other);
		t_string(char single_char);

		operator std::string() const;
		bool operator==(const t_string& other) const;
		t_string& operator=(const char* other);
		t_string& operator=(const t_string& other);
		t_string& operator=(const std::string& other);
		char& operator[](size_t index);
		const char& operator[](size_t index) const;

		static t_string fmt(const char* str, ...);
		static t_string from_int(int value);
		static t_string from_int(int value, int digits);
		static t_string from_float(float value);
		static t_string from_bool(bool value);
		static t_string to_hex(int value);
		static t_string to_hex(int value, int digits);
		static t_string to_binary(int value);
		static t_string to_binary(int value, int digits);
		static t_string join(t_list<t_string>& str_list, t_string separator);
		static t_string repeat(t_string str, int count);
		static char to_upper(char ch);
		static char to_lower(char ch);

		const std::string& s_str() const noexcept;
		const char* c_str() const noexcept;
		size_t length() const noexcept;
		int to_int() const;
		float to_float() const;
		void clear() noexcept;
		bool empty() const noexcept;
		bool is_number() const noexcept;
		t_string to_upper() const;
		t_string to_lower() const;
		t_string trim() const;
		t_string skip(int count) const;
		t_string remove_first(int count = 1) const;
		t_string remove_last(int count = 1) const;
		t_string remove_first_and_last(int count = 1) const;
		t_string get_first(int count) const;
		t_string get_last(int count) const;
		t_list<t_string> split(char delim = ' ') const;
		t_list<t_string> split_chunks(int chunk_size) const;
		t_string substr(int first, int last) const;
		t_string replace(t_string original, t_string replacement) const;
		t_string remove_all(t_string chars) const;
		t_string reverse() const;
		bool starts_with(t_string prefix) const;
		bool ends_with(t_string suffix) const;
		bool starts_and_ends_with(t_string prefix, t_string suffix) const;
		bool starts_and_ends_with(t_string same_preffix_and_suffix) const;
		bool contains(t_string other) const;
		int index_of(t_string str) const;
		int last_index_of(t_string str) const;
		t_list<int> find_all(char ch, size_t offset = 0U);
		int count(char ch);

	private:
		static constexpr int fmt_buf_maxlen = 1024;

		std::string value;
	};
}

namespace std
{
	template<>
	struct hash<tgl::t_string> {
		size_t operator()(const tgl::t_string& wrapper) const {
			return hash<std::string>{}(wrapper.s_str());
		}
	};
}
