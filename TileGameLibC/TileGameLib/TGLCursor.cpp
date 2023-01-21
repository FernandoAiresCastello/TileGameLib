#include "TGLCursor.h"

void TGLCursor::x(int pos)
{
	px = pos;
}
void TGLCursor::y(int pos)
{
	py = pos;
}
void TGLCursor::move(int dist_x, int dist_y)
{
	px += dist_x;
	py += dist_y;
}
