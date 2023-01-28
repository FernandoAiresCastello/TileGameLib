#pragma once
#include "TGL_global.h"
#include "TGL_tile.h"

struct tilemap
{
	tilemap();

	void size(int cols, int rows);
	void set(tile* tile_ptr, int col, int row);
	tile* get(int col, int row);
	void fill(tile* tile_ptr);
	void del(int col, int row);
	void clear();
	void show();
	void hide();

private:
	friend struct TGL;

	tilemap(const tilemap&) = delete;
	tilemap(tilemap&&) = delete;

	bool visible;
	vector<tile*> tiles;
	int cols;
	int rows;
	int tile_count;
};
