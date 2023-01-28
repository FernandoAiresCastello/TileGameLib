#pragma once
#include "TGL_global.h"
#include "TGL_tile_f.h"

struct tile
{
	tile();

	void add(string pixels, rgb c0, rgb c1, rgb c2, rgb c3);
	void tron();
	void troff();
	void show();
	void hide();

private:
	friend struct TGL;
	friend struct tile_f;

	static const int width = 8;
	static const int height = 8;
	static const int size = width * height;

	static const char pixel_c0 = '0';
	static const char pixel_c1 = '1';
	static const char pixel_c2 = '2';
	static const char pixel_c3 = '3';

	tile(const tile&) = delete;
	tile(tile&&) = delete;

	vector<tile_f> frames;
	bool visible;
	bool ignore_c0;
};
