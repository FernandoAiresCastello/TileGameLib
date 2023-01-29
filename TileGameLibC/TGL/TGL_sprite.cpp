#include "TGL_sprite.h"

sprite::sprite()
{
	x = 0;
	y = 0;
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
void sprite::single(tile* tile_ptr)
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
	this->x = x;
	this->y = y;
}
void sprite::setdata(string key, string value)
{
	data.set(key, value);
}
void sprite::setdata(string key, int value)
{
	data.set(key, value);
}
string sprite::getdats(string key)
{
	return data.gets(key);
}
int sprite::getdatn(string key)
{
	return data.getn(key);
}
