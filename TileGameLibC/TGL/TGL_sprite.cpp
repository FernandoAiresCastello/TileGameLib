#include "TGL_sprite.h"

sprite::sprite()
{
	is_visible = true;
	is_destroyed = false;
}
void sprite::size(int cols, int rows)
{
	tiles.size(cols, rows);
}
void sprite::set_tile(tile* tile_ptr, int col, int row)
{
	tiles.set(tile_ptr, col, row);
}
void sprite::set_tile(tile* tile_ptr)
{
	size(1, 1);
	set_tile(tile_ptr, 0, 0);
}
void sprite::show()
{
	is_visible = true;
}
void sprite::hide()
{
	is_visible = false;
}
bool sprite::visible()
{
	return is_visible;
}
void sprite::pos(int x, int y)
{
	tiles.pos(x, y);
}
void sprite::move(int dx, int dy)
{
	tiles.move(dx, dy);
}
void sprite::set_x(int x)
{
	tiles.set_x(x);
}
void sprite::set_y(int y)
{
	tiles.set_y(y);
}
int sprite::get_x()
{
	return tiles.get_x();
}
int sprite::get_y()
{
	return tiles.get_y();
}
void sprite::set_data(string key, string value)
{
	data.set(key, value);
}
void sprite::set_data(string key, int value)
{
	data.set(key, value);
}
bool sprite::has_data(string key)
{
	return data.has(key);
}
bool sprite::has_data(string key, string value)
{
	return data.has(key, value);
}
bool sprite::has_data(string key, int value)
{
	return data.has(key, value);
}
string sprite::get_data_s(string key)
{
	return data.get_s(key);
}
int sprite::get_data_n(string key)
{
	return data.get_n(key);
}
bool sprite::collides(sprite* other)
{
	return tiles.collides(&other->tiles);
}
vector<sprite*>& sprite::get_collisions(spritelist* list)
{
	collisions.clear();

	for (auto* sprite : list->sprites) {
		if (!sprite->is_destroyed && this->collides(sprite)) {
			collisions.push_back(sprite);
		}
	}
	return collisions;
}
void sprite::destroy()
{
	is_destroyed = true;
	is_visible = false;
}
bool sprite::destroyed()
{
	return is_destroyed;
}
