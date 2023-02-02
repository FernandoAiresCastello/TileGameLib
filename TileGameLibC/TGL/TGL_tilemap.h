#pragma once
#include "TGL_global.h"
#include "TGL_tile.h"

struct tilemap
{
	tilemap();

	void size(int cols, int rows);
	void set(tile* tile, int col, int row);
	tile* get(int col, int row);
	void fill(tile* tile);
	void remove(int col, int row);
	void remove_all();
	void pos(int x, int y);
	void move(int dx, int dy);
	void set_x(int x);
	void set_y(int y);
	int get_x();
	int get_y();
	bool collides(tilemap* other);

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
