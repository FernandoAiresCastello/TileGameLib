#pragma once
#include "t_dict.h"
#include "t_string.h"

namespace tgl
{
	class t_data
	{
	public:
		t_data();
		t_data(const t_data& other);

		bool operator==(const t_data& other) const;
		t_data& operator=(const t_data& other);

		bool is_empty() const;
		bool is_not_empty() const;
		void clear();
		void set(t_string key, t_string value);
		void set(t_string key, int value);
		t_string get(t_string key);
		int get_int(t_string key);
		bool has(t_string key);
		bool has(t_string key, t_string value);
		bool has(t_string key, int value);
		t_dict<t_string, t_string> get_all();

	private:
		t_dict<t_string, t_string> entries;
	};
}
