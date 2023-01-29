#pragma once
#include "TGL_global.h"

struct dataset
{
	dataset();

	void set(string prop, string value);
	void set(string prop, int value);
	string gets(string prop);
	int getn(string prop);

private:
	friend struct TGL;

	dataset(const dataset&) = delete;
	dataset(dataset&&) = delete;

	CppProperties data;
};
