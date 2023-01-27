#pragma once
#include "TGL_global.h"
#include "TGL_tile_f.h"

struct tile
{
	static const int width = 8;
	static const int height = 8;
	static const int size = width * height;

	static const char pixel_c0 = '0';
	static const char pixel_c1 = '1';
	static const char pixel_c2 = '2';
	static const char pixel_c3 = '3';

	bool visible = true;

	void add(string pixels, rgb c0, rgb c1, rgb c2, rgb c3);
	void tron();
	void troff();

private:
	friend struct TGL_Old;

	vector<tile_f> frames;
	bool ignore_c0 = false;
};
