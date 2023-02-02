#pragma once
#include "TGL_global.h"
#include "TGL_tile.h"
#include "TGL_tilemap.h"
#include "TGL_data.h"
#include "TGL_spritelist.h"

struct sprite
{
	sprite();

	void size(int cols, int rows);
	void set_tile(tile* tile_ptr, int col, int row);
	void set_tile(tile* tile_ptr);
	void show();
	void hide();
	bool visible();
	void pos(int x, int y);
	void move(int dx, int dy);
	void set_x(int x);
	void set_y(int y);
	int get_x();
	int get_y();
	void set_data(string key, string value);
	void set_data(string key, int value);
	bool has_data(string key);
	bool has_data(string key, string value);
	bool has_data(string key, int value);
	string get_data_s(string key);
	int get_data_n(string key);
	bool collides(sprite* other);
	vector<sprite*>& get_collisions(spritelist* list);
	void destroy();
	bool destroyed();

private:
	friend class TGL;

	bool is_visible;
	bool is_destroyed;
	tilemap tiles;
	dataset data;
	vector<sprite*> collisions;

	sprite(const sprite&) = delete;
	sprite(sprite&&) = delete;
};
