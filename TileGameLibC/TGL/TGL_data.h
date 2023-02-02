#pragma once
#include "TGL_global.h"

struct dataset
{
	dataset();

	void set(string prop, string value);
	void set(string prop, int value);
	string get_s(string prop);
	int get_n(string prop);
	bool has(string prop);
	bool has(string prop, string value);
	bool has(string prop, int value);

private:
	friend struct TGL;

	dataset(const dataset&) = delete;
	dataset(dataset&&) = delete;

	CppProperties data;
};
