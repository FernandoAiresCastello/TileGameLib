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
	void pos(int x, int y);
	void move(int dx, int dy);
	void setx(int x);
	void sety(int y);
	int getx();
	int gety();

private:
	friend struct TGL;

	tilemap(const tilemap&) = delete;
	tilemap(tilemap&&) = delete;

	vector<tile*> tiles;
	int cols;
	int rows;
	int x;
	int y;
};
