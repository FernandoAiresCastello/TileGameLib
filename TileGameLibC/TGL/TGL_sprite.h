#pragma once
#include "TGL_global.h"
#include "TGL_tile.h"
#include "TGL_tilemap.h"
#include "TGL_data.h"

struct sprite
{
	int x;
	int y;

	sprite();

	void size(int cols, int rows);
	void settile(tile* tile_ptr, int col, int row);
	void single(tile* tile_ptr);
	void show();
	void hide();
	bool visible();
	void pos(int x, int y);
	void setdata(string key, string value);
	void setdata(string key, int value);
	string getdats(string key);
	int getdatn(string key);

private:
	friend class TGL;

	bool is_visible;
	tilemap tiles;
	dataset data;

	sprite(const sprite&) = delete;
	sprite(sprite&&) = delete;
};
