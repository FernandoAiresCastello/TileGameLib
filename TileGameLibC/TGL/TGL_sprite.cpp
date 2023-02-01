#include "TGL_sprite.h"

sprite::sprite()
{
	is_visible = true;
}
void sprite::size(int cols, int rows)
{
	tiles.size(cols, rows);
}
void sprite::settile(tile* tile_ptr, int col, int row)
{
	tiles.set(tile_ptr, col, row);
}
void sprite::settile(tile* tile_ptr)
{
	size(1, 1);
	settile(tile_ptr, 0, 0);
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
void sprite::setx(int x)
{
	tiles.setx(x);
}
void sprite::sety(int y)
{
	tiles.sety(y);
}
int sprite::getx()
{
	return tiles.getx();
}
int sprite::gety()
{
	return tiles.gety();
}
void sprite::setdata(string key, string value)
{
	data.set(key, value);
}
void sprite::setdata(string key, int value)
{
	data.set(key, value);
}
void sprite::setdata(string key, bool value)
{
	data.set(key, value ? 0 : 1);
}
bool sprite::hasdata(string key)
{
	return data.has(key);
}
bool sprite::hasdata(string key, string value)
{
	return data.has(key, value);
}
bool sprite::hasdata(string key, int value)
{
	return data.has(key, value);
}
bool sprite::hasdata(string key, bool value)
{
	return data.has(key, value ? 1 : 0);
}
string sprite::getdats(string key)
{
	return data.gets(key);
}
int sprite::getdatn(string key)
{
	return data.getn(key);
}
bool sprite::collides(sprite& other)
{
	return tiles.collides(other.tiles);
}
