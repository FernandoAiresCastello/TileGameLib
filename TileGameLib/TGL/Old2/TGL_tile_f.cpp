#include "TGL_tile_f.h"
#include "TGL_tile.h"

tile_f::tile_f()
{
	set(String::Repeat(tile::pixel_c0, tile::size), 
		tile::default_color, tile::default_color, tile::default_color, tile::default_color);
}
tile_f::tile_f(string pixels, rgb c0, rgb c1, rgb c2, rgb c3)
{
	set(pixels, c0, c1, c2, c3);
}
void tile_f::set(string pixels, rgb c0, rgb c1, rgb c2, rgb c3)
{
	this->pixels = pixels;
	this->c0 = c0;
	this->c1 = c1;
	this->c2 = c2;
	this->c3 = c3;
}
