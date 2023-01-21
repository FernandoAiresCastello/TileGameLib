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
	void move(int dist_x, int dist_y);

private:
	friend struct TGL;

	int layer;
	int px;
	int py;
};
