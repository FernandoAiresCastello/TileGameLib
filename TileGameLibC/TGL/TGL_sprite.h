#pragma once
#include "TGL_global.h"
#include "TGL_tile.h"
#include "TGL_tilemap.h"
#include "TGL_data.h"

struct sprite
{
	sprite();

	void size(int cols, int rows);
	void settile(tile* tile_ptr, int col, int row);
	void settile(tile* tile_ptr);
	void show();
	void hide();
	bool visible();
	void pos(int x, int y);
	void move(int dx, int dy);
	void setx(int x);
	void sety(int y);
	int getx();
	int gety();
	void setdata(string key, string value);
	void setdata(string key, int value);
	void setdata(string key, bool value);
	bool hasdata(string key);
	bool hasdata(string key, string value);
	bool hasdata(string key, int value);
	bool hasdata(string key, bool value);
	string getdats(string key);
	int getdatn(string key);
	bool collides(sprite& other);

private:
	friend class TGL;

	bool is_visible;
	tilemap tiles;
	dataset data;

	sprite(const sprite&) = delete;
	sprite(sprite&&) = delete;
};
