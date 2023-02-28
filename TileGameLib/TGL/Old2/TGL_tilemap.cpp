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
void tilemap::set(tile* tile, int col, int row)
{
	if (col >= 0 && row >= 0 && col < cols && row < rows) {
		tiles[row * cols + col] = tile;
	}
}
tile* tilemap::get(int col, int row)
{
	if (col >= 0 && row >= 0 && col < cols && row < rows) {
		return tiles[row * cols + col];
	}
	return nullptr;
}
void tilemap::fill(tile* tile)
{
	for (int row = 0; row < rows; row++) {
		for (int col = 0; col < cols; col++) {
			set(tile, col, row);
		}
	}
}
void tilemap::remove(int col, int row)
{
	if (col >= 0 && row >= 0 && col < cols && row < rows) {
		tiles[row * cols + col] = nullptr;
	}
}
void tilemap::remove_all()
{
	for (int row = 0; row < rows; row++) {
		for (int col = 0; col < cols; col++) {
			remove(col, row);
		}
	}
}
void tilemap::pos(int x, int y)
{
	set_x(x);
	set_y(y);
}
void tilemap::move(int dx, int dy)
{
	set_x(x + dx);
	set_y(y + dy);
}
void tilemap::set_x(int x)
{
	this->x = x;
}
void tilemap::set_y(int y)
{
	this->y = y;
}
int tilemap::get_x()
{
	return x;
}
int tilemap::get_y()
{
	return y;
}
bool tilemap::collides(tilemap* other)
{
	return
		this->x > other->x - tile::width &&
		this->y > other->y - tile::height &&
		this->x < other->x + (other->cols * tile::width) &&
		this->y < other->y + (other->rows * tile::height);
}
