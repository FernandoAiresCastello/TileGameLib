#include "TGLView.h"

view::view(int x1, int y1, int x2, int y2, rgb back_color)
{
	set(x1, y1, x2, y2, back_color);
}
void view::set(int x1, int y1, int x2, int y2, rgb back_color)
{
	this->x1 = x1;
	this->y1 = y1;
	this->x2 = x2;
	this->y2 = y2;
	this->back_color = back_color;
}
void view::set_null()
{
	set(0, 0, 0, 0, back_color);
}
bool view::is_null()
{
	return x1 == 0 && y1 == 0 && x2 == 0 && y2 == 0;
}
