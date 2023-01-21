/*=============================================================================
	 TGL (TileGameLib)
	 2018-2023 Developed by Fernando Aires Castello
=============================================================================*/
#pragma once
#include <string>
#include <map>
#include "TileGameLib.h"
#include "TGLGlobal.h"
using namespace std;
using namespace TileGameLib;

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
