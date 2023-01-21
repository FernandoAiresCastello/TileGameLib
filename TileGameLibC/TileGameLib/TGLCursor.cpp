/*=============================================================================
	 TGL (TileGameLib)
	 2018-2023 Developed by Fernando Aires Castello
=============================================================================*/
#include "TGLCursor.h"

void TGLCursor::x(int pos)
{
	px = pos;
}
void TGLCursor::y(int pos)
{
	py = pos;
}
int TGLCursor::get_x()
{
	return px;
}
int TGLCursor::get_y()
{
	return py;
}
void TGLCursor::move(int dist_x, int dist_y)
{
	px += dist_x;
	py += dist_y;
}
