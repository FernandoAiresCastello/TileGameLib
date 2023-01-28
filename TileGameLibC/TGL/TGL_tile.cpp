#include "TGL_tile.h"

tile::tile()
{
	visible = true;
	ignore_c0 = false;
}
void tile::add(string pixels, rgb c0, rgb c1, rgb c2, rgb c3)
{
	frames.push_back(tile_f(pixels, c0, c1, c2, c3));
}
void tile::tron()
{
	ignore_c0 = true;
}
void tile::troff()
{
	ignore_c0 = false;
}
void tile::show()
{
	visible = true;
}
void tile::hide()
{
	visible = false;
}
