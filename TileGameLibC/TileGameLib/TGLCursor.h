/*=============================================================================
	 TGL (TileGameLib)
	 2018-2023 Developed by Fernando Aires Castello
=============================================================================*/
#pragma once
#include "TGLGlobal.h"

struct TGLCursor
{
	void x(int pos);
	void y(int pos);
	int get_x();
	int get_y();
	void move(int dist_x, int dist_y);

private:
	friend struct TGL;

	int px;
	int py;
};
