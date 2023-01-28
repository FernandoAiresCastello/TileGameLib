#include "TGL_tilemap.h"

tilemap::tilemap()
{
	visible = true;
	cols = 0;
	rows = 0;
	tile_count = 0;
}
void tilemap::size(int cols, int rows)
{
	if (cols > 0 && rows > 0) {
		this->cols = cols;
		this->rows = rows;
		this->tile_count = cols * rows;

		tiles.clear();
		for (int i = 0; i < tile_count; i++) {
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
void tilemap::show()
{
	visible = true;
}
void tilemap::hide()
{
	visible = false;
}
