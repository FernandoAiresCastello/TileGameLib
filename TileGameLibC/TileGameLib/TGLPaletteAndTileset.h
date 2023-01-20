/*=============================================================================
	 TGL (TileGameLib)
	 2018-2023 Developed by Fernando Aires Castello
=============================================================================*/
#pragma once
#include <string>
#include "TileGameLib.h"
using namespace std;
using namespace TileGameLib;

struct TGLPalette
{
	void set(int ix, int rgb);
	int get(int ix);
	void setr(int ix, int value);
	void setg(int ix, int value);
	void setb(int ix, int value);
	int getr(int ix);
	int getg(int ix);
	int getb(int ix);
	int len();

private:
	friend struct TGL;
	TPalette* palette = nullptr;

	void init_default();
};

struct TGLTileset
{
	void set(int ix, string pixels);
	string get(int ix);
	int len();

private:
	friend struct TGL;
	TCharset* charset = nullptr;

	void init_default();
};
