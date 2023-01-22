/*=============================================================================
	 TGL (TileGameLib)
	 2018-2023 Developed by Fernando Aires Castello
=============================================================================*/
#pragma once
#include "TGLGlobal.h"
#include "TGLPalette.h"
#include "TGLTileset.h"

struct TGLTile
{
	void set(tileid ch, colorid fg, colorid bg);
	void add(tileid ch, colorid fg, colorid bg);
	void prop(string prop, string value);
	void prop(string prop, int value);
	string prop_s(string prop);
	int prop_n(string prop);
	void store(presetid id);
	void load(presetid id);

private:
	friend struct TGL;
	TTileSeq cur_tile;
	TGLTileset* tileset = nullptr;
	TGLPalette* palette = nullptr;
	map<presetid, TTileSeq> presets;
};
