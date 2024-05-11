#pragma once
#include "common.h"

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
	void set(std::string key, std::string value);
	void set(std::string key, int value);
	std::string get(std::string key);
	int get_int(std::string key);
	bool has(std::string key);
	bool has(std::string key, std::string value);
	bool has(std::string key, int value);
	std::unordered_map<std::string, std::string> get_all();

private:
	std::unordered_map<std::string, std::string> entries;
};
