/*=============================================================================
	 TGL (TileGameLib)
	 2018-2023 Developed by Fernando Aires Castello
=============================================================================*/
#pragma once
#include "TGLGlobal.h"

struct TGLTileset
{
	void add(tileid id, string pixels);
	string get_pixels(tileid id);

private:
	friend struct TGL;
	friend struct TGLTile;

	TCharset* charset = nullptr;
	map<string, int> tileids;

	void init_default();
	int get_index(tileid id);
};
