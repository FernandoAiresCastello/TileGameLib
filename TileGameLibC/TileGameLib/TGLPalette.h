/*=============================================================================
	 TGL (TileGameLib)
	 2018-2023 Developed by Fernando Aires Castello
=============================================================================*/
#pragma once
#include "TGLGlobal.h"

struct TGLPalette
{
	void add(colorid id, int rgb);
	int get_rgb(colorid id);

private:
	friend struct TGL;
	friend struct TGLTile;

	TPalette* palette = nullptr;
	map<string, int> colorids;

	void init_default();
	int get_index(colorid id);
};
