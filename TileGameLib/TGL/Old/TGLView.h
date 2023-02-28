#pragma once
#include "TGLGlobal.h"

struct view {
	int x1 = 0;
	int y1 = 0;
	int x2 = 0;
	int y2 = 0;
	rgb back_color = 0x000000;

	view(int x1, int y1, int x2, int y2, rgb back_color);

	void set(int x1, int y1, int x2, int y2, rgb back_color);
	void set_null();
	bool is_null();
};
