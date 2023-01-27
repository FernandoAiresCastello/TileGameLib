#pragma once
#include "TGL_global.h"

struct tile_f
{
	string pixels;
	rgb c0, c1, c2, c3;

	tile_f();
	tile_f(string pixels, rgb c0, rgb c1, rgb c2, rgb c3);

	void set(string pixels, rgb c0, rgb c1, rgb c2, rgb c3);
};
