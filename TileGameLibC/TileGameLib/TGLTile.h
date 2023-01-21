/*=============================================================================
	 TGL (TileGameLib)
	 2018-2023 Developed by Fernando Aires Castello
=============================================================================*/
#pragma once
#include <string>
#include "TileGameLib.h"
#include "TGLGlobal.h"
#include "TGLPaletteAndTileset.h"
using namespace std;
using namespace TileGameLib;

struct TGLTile
{
	void newf(tileid ch, colorid fg, colorid bg);
	void addf(tileid ch, colorid fg, colorid bg);
	void prop(string prop, string value);
	string prop_s(string prop);
	int prop_n(string prop);

private:
	friend struct TGL;
	TTileSeq cur_tile;
	TGLTileset* tileset = nullptr;
	TGLPalette* palette = nullptr;
};
