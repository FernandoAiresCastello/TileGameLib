#pragma once
#include "TGLGlobal.h"

struct tile_f
{
	string pixels;
	rgb c0, c1, c2, c3;

	tile_f();
	tile_f(string pixels, rgb c0, rgb c1, rgb c2, rgb c3);

	void set(string pixels, rgb c0, rgb c1, rgb c2, rgb c3);
};

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
