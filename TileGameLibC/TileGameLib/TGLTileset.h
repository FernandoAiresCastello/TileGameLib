/*=============================================================================
	 TGL (TileGameLib)
	 2018-2023 Developed by Fernando Aires Castello
=============================================================================*/
#pragma once
#include "TGLGlobal.h"

struct TGLTileset
{
	void add(tileid id, string pixels);
	void add(tileid id, byte row0, byte row1, byte row2, byte row3, byte row4, byte row5, byte row6, byte row7);
	string get_pixels(tileid id);

private:
	friend struct TGL;
	friend struct TGLTile;
	friend struct TGLSprite;

	TCharset* charset = nullptr;
	map<string, int> tileids;

	void init_default();
	int get_index(tileid id);
};
