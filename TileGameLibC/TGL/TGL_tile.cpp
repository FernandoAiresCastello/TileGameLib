#include "TGL_tile.h"

tile::tile()
{
	is_visible = true;
	ignore_c0 = false;
}
void tile::add(string pixels, rgb c0)
{
	add(pixels, c0, default_color, default_color, default_color);
}
void tile::add(string pixels, rgb c0, rgb c1)
{
	add(pixels, c0, c1, default_color, default_color);
}
void tile::add(string pixels, rgb c0, rgb c1, rgb c2)
{
	add(pixels, c0, c1, c2, default_color);
}
void tile::add(string pixels, rgb c0, rgb c1, rgb c2, rgb c3)
{
	frames.push_back(tile_f(pixels, c0, c1, c2, c3));
}
tile_f& tile::get(int frame_index)
{
	return frames[frame_index];
}
void tile::sprite()
{
	ignore_c0 = true;
}
void tile::show()
{
	is_visible = true;
}
void tile::hide()
{
	is_visible = false;
}
bool tile::visible()
{
	return is_visible;
}
