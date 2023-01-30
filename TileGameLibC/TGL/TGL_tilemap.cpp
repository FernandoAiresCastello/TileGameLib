#include "TGL_tilemap.h"

tilemap::tilemap()
{
	cols = 0;
	rows = 0;
	x = 0;
	y = 0;
}
void tilemap::size(int cols, int rows)
{
	if (cols > 0 && rows > 0) {
		this->cols = cols;
		this->rows = rows;

		tiles.clear();
		for (int i = 0; i < cols * rows; i++) {
			tiles.push_back(nullptr);
		}
	}
}
void tilemap::set(tile* tile_ptr, int col, int row)
{
	if (col >= 0 && row >= 0 && col < cols && row < rows) {
		tiles[row * cols + col] = tile_ptr;
	}
}
tile* tilemap::get(int col, int row)
{
	if (col >= 0 && row >= 0 && col < cols && row < rows) {
		return tiles[row * cols + col];
	}
	return nullptr;
}
void tilemap::fill(tile* tile_ptr)
{
	for (int row = 0; row < rows; row++) {
		for (int col = 0; col < cols; col++) {
			set(tile_ptr, col, row);
		}
	}
}
void tilemap::del(int col, int row)
{
	if (col >= 0 && row >= 0 && col < cols && row < rows) {
		tiles[row * cols + col] = nullptr;
	}
}
void tilemap::clear()
{
	for (int row = 0; row < rows; row++) {
		for (int col = 0; col < cols; col++) {
			del(col, row);
		}
	}
}
void tilemap::pos(int x, int y)
{
	setx(x);
	sety(y);
}
void tilemap::move(int dx, int dy)
{
	setx(x + dx);
	sety(y + dy);
}
void tilemap::setx(int x)
{
	this->x = x;
}
void tilemap::sety(int y)
{
	this->y = y;
}
int tilemap::getx()
{
	return x;
}
int tilemap::gety()
{
	return y;
}
